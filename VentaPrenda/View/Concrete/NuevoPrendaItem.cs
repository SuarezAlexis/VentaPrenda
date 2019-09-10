using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DTO;
using VentaPrenda.View.Abstract;

namespace VentaPrenda.View.Concrete
{
    public partial class NuevoPrendaItem : Form
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private PrendaItemDto _dto;

        public event DescuentoEventHandler ServiciosRequested;
        public event DescuentoEventHandler MontoRequested;

        public PrendaItemDto Dto
        {
            get
            {
                _dto.ID = String.IsNullOrEmpty(idDataLabel.Text) ? -1L : Convert.ToInt64(idDataLabel.Text);
                _dto.Nota = _dto.Nota;
                _dto.Prenda = (CatalogoDto)prendasComboBox.SelectedItem;
                _dto.TipoPrenda = (CatalogoDto)tiposPrendaComboBox.SelectedItem;
                _dto.Color = (CatalogoDto)coloresComboBox.SelectedItem;
                _dto.Cantidad = Convert.ToInt32(cantNumUpDown.Value);
                _dto.Servicios = new List<ServicioItemDto>();
                foreach(ServicioUserControl s in serviciosFlowLayoutPanel.Controls)
                {
                    if(s.Servicios > 0)
                        _dto.Servicios.Add(s.Dto);
                }
                return _dto;
            }
            set
            {
                _dto = value;
                idDataLabel.Text = value.ID < 0 ? "" : value.ID.ToString();
                notaDataLabel.Text = _dto.Nota == null || _dto.Nota.ID < 0 ? "" : _dto.Nota.ID.ToString();
                prendasComboBox.SelectedItem = value.Prenda;
                tiposPrendaComboBox.SelectedItem = value.TipoPrenda;
                coloresComboBox.SelectedItem = value.Color;
                cantNumUpDown.Value = value.Cantidad;
                foreach(ServicioItemDto s in value.Servicios)
                {
                    ServicioUserControl servicio = new ServicioUserControl(s);
                    servicio.Width = serviciosFlowLayoutPanel.Width - 30;
                    servicio.DeleteClicked += Servicio_DeleteClicked;
                    servicio.DataChanged += Servicio_DataChanged;
                    servicio.DescuentoRequested += Servicio_DescuentoRequested;
                    serviciosFlowLayoutPanel.Controls.Add(servicio);
                }
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public NuevoPrendaItem()
        {
            InitializeComponent();
            Dto = new PrendaItemDto();
            AgregarServicio();
            foreach(CatalogoDto p in PrendaItemDto.Prendas)
            { prendasComboBox.Items.Add(p); }
            foreach (CatalogoDto t in PrendaItemDto.Tipos)
            { tiposPrendaComboBox.Items.Add(t); }
            tiposPrendaComboBox.SelectedText = "N/A";
            foreach (CatalogoDto c in PrendaItemDto.Colores)
            { coloresComboBox.Items.Add(c); }
        }

        public NuevoPrendaItem(PrendaItemDto Prenda) : this()
        {
            serviciosFlowLayoutPanel.Controls.Clear();
            Dto = Prenda;
            UpdateLabels();
            EnableAceptarButton();
            agregarServicioButton.Enabled = true;
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        /************************ MÉTODOS: Privados ************************/
        private void AgregarServicio()
        {
            ServicioUserControl servicio = new ServicioUserControl(_dto);
            servicio.Width = serviciosFlowLayoutPanel.Width - 30;
            servicio.DeleteClicked += Servicio_DeleteClicked;
            servicio.DataChanged += Servicio_DataChanged;
            servicio.DescuentoRequested += Servicio_DescuentoRequested;
            serviciosFlowLayoutPanel.Controls.Add(servicio);
        }

        private void EnableAceptarButton()
        {
            if (prendasComboBox.SelectedItem != null 
                && coloresComboBox.SelectedItem != null 
                && Convert.ToInt32(totalServiciosDataLabel.Text) > 0)
                aceptarButton.Enabled = true;
            else
                aceptarButton.Enabled = false;
        }

        private void UpdateLabels()
        {
            decimal total = 0;
            int servicios = 0;
            agregarServicioButton.Enabled = true;
            foreach (ServicioUserControl s in serviciosFlowLayoutPanel.Controls)
            {
                if (s.Servicios > 0)
                {
                    servicios += s.Servicios;
                    total += s.Monto;
                }
                else
                { agregarServicioButton.Enabled = false; }
            }
            totalDataLabel.Text = "$ " + string.Format("{0:0.00}", cantNumUpDown.Value * total);
            totalServiciosDataLabel.Text = servicios.ToString();
            EnableAceptarButton();
        }
        
        /********************* MÉTODOS: EventHandlers **********************/
        private void Servicio_DeleteClicked(object sender, EventArgs e)
        {
            serviciosFlowLayoutPanel.Controls.Remove((ServicioUserControl)sender);
            UpdateLabels();
        }

        private void Servicio_DataChanged(object sender, EventArgs e)
        { UpdateLabels(); }

        private void Servicio_DescuentoRequested(object sender, EventArgs e)
        {
            IMainView mainView = (IMainView)Owner;
            DescuentoDto d = ((ServicioUserControl)sender).Descuento;
            DescuentoEventArgs eventArgs = new DescuentoEventArgs(d);
            int aplicados = 0;

            if (d.CantMinima > 0)
            {
                int servicios = 0;
                ServiciosRequested?.Invoke(this, eventArgs);
                servicios = eventArgs.ServiciosNota;
                aplicados = eventArgs.DescuentosNota;
                if (!d.SoloNota)
                {
                    if(eventArgs.ClienteID >= 0)
                        servicios += mainView.Controller.ServiciosAcumulados(eventArgs.ClienteID, d.VigenciaInicio);
                    else
                    {
                        MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        ((ServicioUserControl)sender).DescuentoInvalido = true;
                        return;
                    }
                }
                foreach (ServicioUserControl s in serviciosFlowLayoutPanel.Controls)
                {
                    servicios += s.Servicios * (int)cantNumUpDown.Value;
                    aplicados += d.Equals(s.Descuento) ? 1 : 0;
                }

                int comprometidos = aplicados * (int)d.CantMinima;
                if (servicios >= comprometidos)
                {
                    ((ServicioUserControl)sender).AplicarDescuento();
                    ((ServicioUserControl)sender).DescuentoInvalido = false;
                }    
                else
                {
                    comprometidos = --aplicados * (int)d.CantMinima;
                    ((ServicioUserControl)sender).DescuentoInvalido = true;
                    MessageBox.Show("No es posible aplicar el descuento.\nSe requiere un consumo mínimo de " + d.CantMinima + " servicios y sólo se encontraron " + (servicios - comprometidos) + ".",
                            "Servicios insuficientes",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
            if (d.MontoMinimo > 0)
            {
                decimal monto = 0;
                MontoRequested?.Invoke(this, eventArgs);
                monto = eventArgs.MontoNota;
                aplicados = eventArgs.DescuentosNota;
                if (!d.SoloNota)
                {
                    if (eventArgs.ClienteID >= 0)
                        monto += mainView.Controller.MontoAcumulado(eventArgs.ClienteID, d.VigenciaInicio);
                    else
                    {
                        MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        ((ServicioUserControl)sender).DescuentoInvalido = true;
                    }
                }
                foreach (ServicioUserControl s in serviciosFlowLayoutPanel.Controls)
                {
                    monto += s.Monto;
                    aplicados += s.Descuento.Equals(d) ? 1 : 0;
                }

                decimal comprometidos = aplicados * d.MontoMinimo;
                if (monto >= comprometidos)
                {
                    ((ServicioUserControl)sender).AplicarDescuento();
                    ((ServicioUserControl)sender).DescuentoInvalido = false;
                }
                else
                {
                    comprometidos = --aplicados * d.MontoMinimo;
                    ((ServicioUserControl)sender).DescuentoInvalido = true;
                    MessageBox.Show("No es posible aplicar el descuento.\nSe requiere un consumo mínimo de $ " + d.MontoMinimo + " y sólo se encontraron pagos por $ " + (monto - comprometidos) + ".",
                            "Monto insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
        }

        private void ServiciosFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach(Control c in serviciosFlowLayoutPanel.Controls)
            { c.Width = serviciosFlowLayoutPanel.Width - 30; }
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.OK; }

        private void PrendasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { EnableAceptarButton(); }

        private void ColoresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { EnableAceptarButton();  }

        private void AgregarServicioButton_Click(object sender, EventArgs e)
        { AgregarServicio(); }

        private void ServiciosFlowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        { agregarServicioButton.Enabled = false; }

        private void ServiciosFlowLayoutPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            if(serviciosFlowLayoutPanel.Controls.Count < 1)
            { agregarServicioButton.Enabled = true; }
            EnableAceptarButton();
        }

        private void CantNumUpDown_ValueChanged(object sender, EventArgs e)
        { UpdateLabels(); }
    }

    public class DescuentoEventArgs : EventArgs
    {
        public int ServiciosNota;
        public decimal MontoNota;
        public DescuentoDto DescuentoDto;
        public int DescuentosNota;
        public int ClienteID;

        public DescuentoEventArgs() { }
        public DescuentoEventArgs(DescuentoDto Descuento)
        { DescuentoDto = Descuento; }
    }

    public delegate void DescuentoEventHandler(object sender, DescuentoEventArgs e);
}
