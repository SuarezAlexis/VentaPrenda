using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.View.Abstract;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetalleNota : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private NotaDto _dto;
        private ErrorProvider _errorProvider;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
            }
        }

        public override object Dto
        {
            get
            {
                return _dto;
            }
            set
            {
                if (value != null && (value is NotaDto))
                    _dto = (NotaDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleNota porque no es del tipo correcto.");
            }
        }

        public int Servicios
        {
            get
            {
                int servicios = 0;
                foreach (PrendaItemDisplay p in resumenFlowLayoutPanel.Controls)
                { servicios += p.Servicios; }
                return servicios;
            }
        }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (PrendaItemDisplay p in resumenFlowLayoutPanel.Controls)
                { total += p.Total; }
                return total;
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleNota()
        {
            InitializeComponent();
            _dto = new NotaDto();
            foreach (ClienteDto c in NotaDto.Clientes)
            { clienteComboBox.Items.Add(c); }
            foreach(DescuentoDto d in NotaDto.Descuentos)
            { descuentoComboBox.Items.Add(d); }
            recibidoDataLabel.Text = DateTime.Now.ToShortDateString();
            foreach(Estatus s in Enum.GetValues(typeof(Estatus)))
            {
                estatusListBox.Items.Add(s);
            }
        }

        public DetalleNota(ErrorProvider e) : this()
        {
            _errorProvider = e;
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public override void Clear()
        {
            
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(NotaDto))
            {
                //Registrar el Log
                MessageBox.Show(
                    "No fue posible obtener el registro solicitado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                NotaDto n = (NotaDto)model;
                idDataLabel.Text = n.ID > 0 ? n.ID.ToString() : "";
            }
        }

        private void ClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteDto c = (ClienteDto)clienteComboBox.SelectedItem;
            clienteDataLabel.Text = c.Nombre + "\n" + c.Telefono + "\n"
                + c.Domicilio + " " + c.Colonia + (String.IsNullOrEmpty(c.CP) ? "" : (" C.P. " + c.CP));
        }

        /************************ EventListenners **************************/
        private void ClienteComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(clienteComboBox.SelectedItem == null)
            {
                foreach (ClienteDto c in clienteComboBox.Items)
                {
                    clienteComboBox.Text = clienteComboBox.Text.Replace(" ", "");
                    if ( !string.IsNullOrEmpty(clienteComboBox.Text) 
                        && (c.Nombre.ToLower().IndexOf(clienteComboBox.Text.ToLower()) >= 0 
                            || c.Telefono.IndexOf(clienteComboBox.Text) >= 0)
                        )
                    {
                        clienteComboBox.SelectedItem = c;
                        e.Cancel = false;
                        ClienteComboBox_Validated(sender, EventArgs.Empty);
                        break;
                    }
                }
                if(clienteComboBox.SelectedItem == null)
                {
                    e.Cancel = true;
                    clienteComboBox.BackColor = System.Drawing.Color.Pink;
                    _errorProvider.SetError(clienteComboBox,"No fue posible encontrar un cliente que coincida con el criterio de búsqueda. Para continuar selecciona un cliente válido o crea uno nuevo en el apartado de clientes.");
                    clienteDataLabel.Text = "";
                }
            } else
            {
                e.Cancel = false;
                ClienteComboBox_Validated(sender, EventArgs.Empty);
            }
        }

        private void ClienteComboBox_Validated(object sender, EventArgs e)
        {
            clienteComboBox.BackColor = SystemColors.Window;
            _errorProvider.SetError(clienteComboBox, "");
        }

        private void AgregarPrendaButton_Click(object sender, EventArgs e)
        {
            NuevoPrendaItem nuevoPrendaItem = new NuevoPrendaItem();
            nuevoPrendaItem.Owner = this.ParentForm;
            nuevoPrendaItem.MontoRequested += NuevoPrendaItem_MontoRequested;
            nuevoPrendaItem.ServiciosRequested += NuevoPrendaItem_ServiciosRequested;
            if(nuevoPrendaItem.ShowDialog() == DialogResult.OK)
            {
                PrendaItemDto prendaDto = nuevoPrendaItem.Prenda;
                _dto.Prendas.Add(prendaDto);
                PrendaItemDisplay nuevaPrenda = new PrendaItemDisplay(prendaDto);
                nuevaPrenda.Width = resumenFlowLayoutPanel.Width - 25;
                nuevaPrenda.Edit += Prenda_Edit;
                nuevaPrenda.Delete += Prenda_Delete;
                resumenFlowLayoutPanel.Controls.Add(nuevaPrenda);                
                ActualizarTotalLabel();
                ActualizarDescuentoLabels();
                ActualizarPagosLabels();
            }
        }

        private void NuevoPrendaItem_ServiciosRequested(object sender, EventArgs e)
        {
            ((NuevoPrendaItem)sender).ServiciosNota = Servicios;
            ((NuevoPrendaItem)sender).ClienteID = clienteComboBox.SelectedItem != null? ((ClienteDto)clienteComboBox.SelectedItem).ID : -1;
        }

        private void NuevoPrendaItem_MontoRequested(object sender, EventArgs e)
        {
            ((NuevoPrendaItem)sender).MontoNota = Total;
            ((NuevoPrendaItem)sender).ClienteID = clienteComboBox.SelectedItem != null ? ((ClienteDto)clienteComboBox.SelectedItem).ID : -1;
        }

        private void AgregarPagoButton_Click(object sender, EventArgs e)
        {
            NuevoPago nuevoPago = new NuevoPago(new PagoDto(_dto));
            if (nuevoPago.ShowDialog() == DialogResult.OK)
            {
                PagoDto pagoDto = nuevoPago.Dto;
                _dto.Pagos.Add(pagoDto);
                PagoDisplay pagoDisplay = new PagoDisplay(pagoDto);
                pagoDisplay.Width = pagosFlowLayoutPanel.Width - 25;
                pagoDisplay.Edit += Pago_Edit;
                pagoDisplay.Delete += Pago_Delete;
                pagosFlowLayoutPanel.Controls.Add(pagoDisplay);
                ActualizarPagosLabels();
            }
        }

        private void ActualizarTotalLabel()
        {
            decimal total = 0;
            foreach(PrendaItemDisplay p in resumenFlowLayoutPanel.Controls)
            {
                total += p.Total;
            }
            totalDataLabel.Text = "$ " + string.Format("{0:0.00}", total);
        }

        private void ActualizarDescuentoLabels()
        {
            decimal monto = 0;
            if (descuentoComboBox.SelectedItem != null)
                monto = CalcularMontoDescuento();
            decimal totalNota = Convert.ToDecimal(totalDataLabel.Text.Substring(2));
            montoDescuentoDataLabel.Text = "$ " + string.Format("{0:0.00}", monto);
            totalDescuentoDataLabel.Text = "$ " + string.Format("{0:0.00}", totalNota - monto);
        }

        private void ActualizarPagosLabels()
        {
            Decimal totalPagado = 0;
            foreach(PagoDisplay p in pagosFlowLayoutPanel.Controls)
            {
                totalPagado += p.Dto.Monto;
            }
            totalPagadoDataLabel.Text = "$ " + string.Format("{0:0.00}",totalPagado);
            restanteDataLabel.Text = "$ " + string.Format("{0:0.00}", Convert.ToDecimal(totalDescuentoDataLabel.Text.Substring(2)) - totalPagado);
        }

        private decimal CalcularMontoDescuento()
        {
            decimal montoDescuento = 0;
            decimal totalNota = Convert.ToDecimal(totalDescuentoDataLabel.Text.Substring(2));
            DescuentoDto d = (DescuentoDto)descuentoComboBox.SelectedItem;
            if (d.CantMinima > 0)
            {
                int servicios = 0;
                if (!d.SoloNota)
                {
                    if (clienteComboBox.SelectedItem != null)
                    {
                        IMainView mainView = (IMainView)ParentForm;
                        servicios += mainView.Controller.ServiciosAcumulados(((ClienteDto)clienteComboBox.SelectedItem).ID, d.VigenciaInicio);
                    }
                    else
                    {
                        MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        descuentoComboBox.SelectedIndex = -1;
                        return 0;
                    }
                }
                servicios += Servicios;
                if (servicios >= d.CantMinima)
                { montoDescuento = d.Porcentaje * Total * 0.01M; }
                else
                {
                    MessageBox.Show("No es posible aplicar el descuento.\nSe requiere un consumo mínimo de " + d.CantMinima + " servicios y sólo se encontraron " + servicios + ".",
                            "Servicios insuficientes",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    descuentoComboBox.SelectedIndex = -1;
                }
            }
            else
            {
                decimal monto = 0;

                if (!d.SoloNota)
                {
                    if (clienteComboBox.SelectedItem != null)
                    {
                        IMainView mainView = (IMainView)ParentForm;
                        monto += mainView.Controller.MontoAcumulado(((ClienteDto)clienteComboBox.SelectedItem).ID, d.VigenciaInicio);
                    }
                    else
                    {
                        MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        descuentoComboBox.SelectedIndex = -1;
                        return 0;
                    }
                }
                monto += Total;
                if (monto >= d.MontoMinimo)
                { montoDescuento = d.Porcentaje * Total * 0.01M; }
                else
                {
                    MessageBox.Show("No es posible aplicar el descuento.\nSe requiere un consumo mínimo de $ " + d.MontoMinimo + " y sólo se encontraron pagos por $ " + monto + ".",
                            "Monto insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    descuentoComboBox.SelectedIndex = -1;
                }

            }
            return montoDescuento;
        }

        private void Prenda_Edit(object sender, EventArgs e)
        {
            PrendaItemDisplay display = (PrendaItemDisplay)sender;
            PrendaItemDto prenda = display.Dto;
            NuevoPrendaItem nuevoPrendaItem = new NuevoPrendaItem(prenda);
            if(nuevoPrendaItem.ShowDialog() == DialogResult.OK)
            {
                _dto.Prendas.Remove(prenda);
                prenda = nuevoPrendaItem.Prenda;
                _dto.Prendas.Add(prenda);
                display.Update(prenda);
            }
            ActualizarTotalLabel();
            ActualizarDescuentoLabels();
            ActualizarPagosLabels();
        }

        private void Prenda_Delete(object sender, EventArgs e)
        {
            PrendaItemDisplay p = (PrendaItemDisplay)sender;
            _dto.Prendas.Remove(p.Dto);
            resumenFlowLayoutPanel.Controls.Remove(p);
            ActualizarTotalLabel();
            ActualizarDescuentoLabels();
            ActualizarPagosLabels();
        }

        private void Pago_Delete(object sender, EventArgs e)
        {
            PagoDisplay p = (PagoDisplay)sender;
            _dto.Pagos.Remove(p.Dto);
            pagosFlowLayoutPanel.Controls.Remove(p);
            ActualizarPagosLabels();
        }


        private void Pago_Edit(object sender, EventArgs e)
        {
            PagoDisplay display = (PagoDisplay)sender;
            PagoDto pago = display.Dto;
            NuevoPago nuevoPago = new NuevoPago(pago);
            if(nuevoPago.ShowDialog() == DialogResult.OK)
            {
                _dto.Pagos.Remove(pago);
                pago = nuevoPago.Dto;
                _dto.Pagos.Add(pago);
                display.Update(pago);
            }
            ActualizarPagosLabels();
        }

        private void ResumenFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach(Control c in resumenFlowLayoutPanel.Controls)
            {
                c.Width = resumenFlowLayoutPanel.Width - 25;
            }
        }

        private void ClienteComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                this.SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DescuentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDescuentoLabels();
            ActualizarPagosLabels();
        }
    }
}
