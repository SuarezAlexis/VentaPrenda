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
        private PrendaItemDto _dto;

        public event EventHandler ServiciosRequested;
        public event EventHandler MontoRequested;
        public int ServiciosNota;
        public decimal MontoNota;
        public int ClienteID;
        public PrendaItemDto Prenda
        {
            get
            {
                PrendaItemDto p = new PrendaItemDto();
                p.ID = String.IsNullOrEmpty(idDataLabel.Text) ? -1L : Convert.ToInt64(idDataLabel.Text);
                p.Nota = _dto.Nota;
                p.Prenda = (CatalogoDto)prendasComboBox.SelectedItem;
                p.TipoPrenda = (CatalogoDto)tiposPrendaComboBox.SelectedItem;
                p.Color = (CatalogoDto)coloresComboBox.SelectedItem;
                p.Cantidad = Convert.ToInt32(cantNumUpDown.Value);
                p.Servicios = new List<ServicioItemDto>();
                foreach(ServicioUserControl s in serviciosFlowLayoutPanel.Controls)
                {
                    if(s.Servicios > 0)
                        p.Servicios.Add(s.Dto);
                }
                return p;
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


        public NuevoPrendaItem()
        {
            InitializeComponent();
            AgregarServicio();
            foreach(CatalogoDto p in PrendaItemDto.Prendas)
            { prendasComboBox.Items.Add(p); }
            foreach (CatalogoDto t in PrendaItemDto.Tipos)
            { tiposPrendaComboBox.Items.Add(t); }
            tiposPrendaComboBox.SelectedText = "N/A";
            foreach (CatalogoDto c in PrendaItemDto.Colores)
            { coloresComboBox.Items.Add(c); }
            Prenda = new PrendaItemDto();

        }

        public NuevoPrendaItem(PrendaItemDto Prenda) : this()
        {
            serviciosFlowLayoutPanel.Controls.Clear();
            this.Prenda = Prenda;
        }

        private void AgregarServicio()
        {
            ServicioUserControl servicio = new ServicioUserControl();
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

            if (d.CantMinima > 0)
            {
                int servicios = 0;
                ServiciosRequested?.Invoke(this, EventArgs.Empty);
                servicios = ServiciosNota;
                if (!d.SoloNota)
                {
                    if(ClienteID >= 0)
                        servicios += mainView.Controller.ServiciosAcumulados(ClienteID, d.VigenciaInicio);
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
                { servicios += s.Servicios * (int)cantNumUpDown.Value; }
                if (servicios >= d.CantMinima)
                    AplicarDescuento(d, (ServicioUserControl)sender);
                else
                {
                    ((ServicioUserControl)sender).DescuentoInvalido = true;
                    MessageBox.Show("No es posible aplicar el descuento.\nSe requiere un consumo mínimo de " + d.CantMinima + " servicios y sólo se encontraron " + servicios + ".",
                            "Servicios insuficientes",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
            if (d.MontoMinimo > 0)
            {
                decimal monto = 0;
                if (!d.SoloNota)
                {
                    if (ClienteID >= 0)
                        monto += mainView.Controller.MontoAcumulado(ClienteID, d.VigenciaInicio);
                    else
                    {
                        MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        ((ServicioUserControl)sender).DescuentoInvalido = true;
                    }
                }
                MontoRequested?.Invoke(this,EventArgs.Empty);
                monto = MontoNota;
                foreach (ServicioUserControl s in serviciosFlowLayoutPanel.Controls)
                { monto += s.Monto; }
                if (monto >= d.MontoMinimo)
                    AplicarDescuento(d, (ServicioUserControl)sender);
                else
                {
                    ((ServicioUserControl)sender).DescuentoInvalido = true;
                    MessageBox.Show("No es posible aplicar el descuento.\nSe requiere un consumo mínimo de $ " + d.MontoMinimo + " y sólo se encontraron pagos por $ " + monto + ".",
                            "Monto insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
        }

        private void AplicarDescuento(DescuentoDto d, ServicioUserControl s)
        {
            throw new NotImplementedException();
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
}
