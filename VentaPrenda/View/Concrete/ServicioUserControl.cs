using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DTO;

namespace VentaPrenda.View.Concrete
{
    public partial class ServicioUserControl : UserControl
    {
        private ServicioItemDto _dto;
        public decimal Monto;
        public DescuentoDto Descuento
        {
            get { return (DescuentoDto)descuentoComboBox.SelectedItem; }
        }
        public bool DescuentoInvalido
        {
            get { return descuentoComboBox.SelectedItem == null; }
            set { descuentoComboBox.SelectedIndex = value? -1 : descuentoComboBox.SelectedIndex; }
        }

        public event EventHandler DeleteClicked;
        public event EventHandler DataChanged;
        public event EventHandler DescuentoRequested;

        public int Servicios { get { return servicioComboBox.SelectedItem != null? Convert.ToInt32(cantNumUpDown.Value) : 0; } }

        public ServicioItemDto Dto
        {
            get
            {
                _dto.Cantidad = Convert.ToInt32(cantNumUpDown.Value);
                _dto.Descuento = (DescuentoDto)descuentoComboBox.SelectedItem;
                _dto.Encargado = (UsuarioDto)encargadoComboBox.SelectedItem;
                _dto.ID = _dto != null && _dto.ID >= 0 ? _dto.ID : -1;
                _dto.Monto = Monto;
                _dto.Servicio = (ServicioDto)servicioComboBox.SelectedItem;
                return _dto;
            }
            set
            {
                _dto = value;
                cantNumUpDown.Value = value.Cantidad;
                descuentoComboBox.SelectedItem = value.Descuento;
                encargadoComboBox.SelectedItem = value.Encargado;
                servicioComboBox.SelectedItem = value.Servicio;
                subtotalLabel.Text = "$ " + string.Format("{0:0.00}", value.Monto);
                montoNumUpDown.Value = value.Monto/value.Cantidad - value.Servicio.Costo;
            }
        }

        public ServicioUserControl()
        {
            InitializeComponent();
            _dto = new ServicioItemDto();
            foreach(ServicioDto s in ServicioItemDto.Servicios)
            { servicioComboBox.Items.Add(s); }
            foreach(DescuentoDto d in ServicioItemDto.Descuentos)
            { descuentoComboBox.Items.Add(d); }
            foreach(UsuarioDto u in ServicioItemDto.Usuarios)
            { encargadoComboBox.Items.Add(u); }
        }

        public ServicioUserControl(PrendaItemDto Prenda) : this()
        { _dto.PrendaItem = Prenda; }

        public ServicioUserControl(ServicioItemDto Servicio) : this(Servicio.PrendaItem)
        { Dto = Servicio; }

        public void OnEditClicked()
        { DeleteClicked?.Invoke(this, EventArgs.Empty); }

        public void OnDataChanged()
        { DataChanged?.Invoke(this,EventArgs.Empty); }

        private void ActualizarSubtotal()
        {
            if(servicioComboBox.SelectedItem != null)
            {
                editButton.Enabled = true;
                Monto = ((ServicioDto)servicioComboBox.SelectedItem).Costo;
                if (porcentajeRadioButton.Checked)
                    Monto += Monto * montoNumUpDown.Value / 100;
                if (monedaRadioButton.Checked)
                    Monto += montoNumUpDown.Value;
                subtotalLabel.Text = "$ " + string.Format("{0:0.00}", Monto);
                montoLabel.Text = "$ " + string.Format("{0:0.00}", Monto *= cantNumUpDown.Value);
                OnDataChanged();
            }
        }

        public void AplicarDescuento()
        {
            DescuentoDto d = (DescuentoDto)descuentoComboBox.SelectedItem;
            PorcentajeRadioButton_Click(this, EventArgs.Empty);
            montoNumUpDown.Value = cantNumUpDown.Value > d.Unidades ? -100 * d.Unidades / cantNumUpDown.Value : -100;
            ActualizarSubtotal();
        }

        private void ServicioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { ActualizarSubtotal(); }

        private void MonedaRadioButton_Click(object sender, EventArgs e)
        {
            porcentajeRadioButton.Checked = false;
            monedaRadioButton.Checked = true;
            montoNumUpDown.DecimalPlaces = 2;
            montoNumUpDown.ThousandsSeparator = true;
            montoNumUpDown.Maximum = 999999.99M;
            montoNumUpDown.Minimum = -999999.99M;
            montoNumUpDown.Increment = 0.1M;
            montoNumUpDown.Value = Convert.ToDecimal(subtotalLabel.Text.Substring(2)) - ((ServicioDto)servicioComboBox.SelectedItem).Costo;
        }

        private void PorcentajeRadioButton_Click(object sender, EventArgs e)
        {
            porcentajeRadioButton.Checked = true;
            monedaRadioButton.Checked = false;
            montoNumUpDown.DecimalPlaces = 0;
            montoNumUpDown.ThousandsSeparator = false;
            montoNumUpDown.Maximum = 1000;
            montoNumUpDown.Minimum = -1000;
            montoNumUpDown.Increment = 1;
            montoNumUpDown.Value = 100*montoNumUpDown.Value / ((ServicioDto)servicioComboBox.SelectedItem).Costo;
        }

        private void MontoNumUpDown_ValueChanged(object sender, EventArgs e)
        { ActualizarSubtotal(); }

        private void CantNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            DescuentoComboBox_Validating(sender, new CancelEventArgs());
            ActualizarSubtotal();
        }

        private void EditButton_Click(object sender, EventArgs e)
        { OnEditClicked(); }

        private void DescuentoComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (descuentoComboBox.SelectedItem != null)
            {
                DescuentoRequested?.Invoke(this, EventArgs.Empty);
                if (DescuentoInvalido)
                { e.Cancel = true; }
                else
                { e.Cancel = false; }
            }
            else
                e.Cancel = false;
        }

        private void DescuentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { DescuentoComboBox_Validating(sender, new CancelEventArgs()); }
    }
}
