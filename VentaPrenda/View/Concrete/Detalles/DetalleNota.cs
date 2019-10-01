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
                clienteComboBox.Enabled = !value;
                foreach(PrendaItemDisplay p in resumenFlowLayoutPanel.Controls)
                { p.ReadOnly = value; }
                agregarPrendaButton.Enabled = !value;
                descuentoComboBox.Enabled = !value;
                foreach(PagoDisplay p in pagosFlowLayoutPanel.Controls)
                { p.ReadOnly = value; }
                agregarPagoButton.Enabled = !value;
                entregadoDateTimePicker.Enabled = !value;
                estatusComboBox.Enabled = !value && !string.IsNullOrEmpty(idDataLabel.Text);
                observacionesTextBox.ReadOnly = value;
                imprimirButton.Enabled = value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = string.IsNullOrEmpty(idDataLabel.Text) ? -1 : Convert.ToInt64(idDataLabel.Text);
                _dto.Cliente = clienteComboBox.SelectedItem != null ? (ClienteDto)clienteComboBox.SelectedItem : new ClienteDto { Nombre = clienteComboBox.Text };
                _dto.Descuento = new DescuentoDto().Equals(descuentoComboBox.SelectedItem)? null : (DescuentoDto)descuentoComboBox.SelectedItem;
                _dto.Recibido = string.IsNullOrEmpty(idDataLabel.Text) ? DateTime.Now : Convert.ToDateTime(recibidoDataLabel.Text);
                _dto.Entregado = entregadoDateTimePicker.Value;
                _dto.Estatus = (Estatus)estatusComboBox.SelectedItem;
                _dto.Observaciones = observacionesTextBox.Text.Replace("\n"," ");
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
            Visible = false;
            InitializeComponent();
            entregadoDateTimePicker.MinDate = DateTime.Now;
            _dto = new NotaDto();
            foreach (ClienteDto c in NotaDto.Clientes)
            { clienteComboBox.Items.Add(c); }
            descuentoComboBox.Items.Add(new DescuentoDto());
            foreach(DescuentoDto d in NotaDto.Descuentos)
            { descuentoComboBox.Items.Add(d); }
            recibidoDataLabel.Text = DateTime.Now.ToShortDateString();
            foreach(Estatus s in Enum.GetValues(typeof(Estatus)))
            { estatusComboBox.Items.Add(s); }
            estatusComboBox.SelectedIndex = 1;
            Visible = true;
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
            _dto.ID = -1;
            idDataLabel.Text = "";
            clienteComboBox.SelectedIndex = -1;
            clienteDataLabel.Text = "";
            _dto.Prendas.Clear();
            resumenFlowLayoutPanel.Controls.Clear();
            detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(resumenLayoutPanel)].Height = 110;
            descuentoComboBox.SelectedIndex = -1;
            _dto.Pagos.Clear();
            pagosFlowLayoutPanel.Controls.Clear();
            detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(pagosLayoutPanel)].Height = 130;
            entregadoDateTimePicker.Value = DateTime.Now;
            estatusComboBox.SelectedIndex = 0;
            observacionesTextBox.Text = "";
            ActualizarTotalLabel();
            ActualizarDescuentoLabels();
            ActualizarPagosLabels();
            imprimirButton.Enabled = false;
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
                Visible = false;
                idDataLabel.Text = n.ID > 0 ? n.ID.ToString() : "";
                clienteComboBox.SelectedItem = n.Cliente;
                clienteStatsDisplay.Fill(n.Cliente.Estadisticas);
                resumenFlowLayoutPanel.Controls.Clear();
                detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(resumenLayoutPanel)].Height = 110;
                foreach (PrendaItemDto p in n.Prendas)
                { AgregarPrenda(p); }
                descuentoComboBox.SelectedItem = n.Descuento;
                pagosFlowLayoutPanel.Controls.Clear();
                detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(pagosLayoutPanel)].Height = 130;
                foreach (PagoDto p in n.Pagos)
                { AgregarPago(p); }
                ActualizarTotalLabel();
                ActualizarDescuentoLabels();
                ActualizarPagosLabels();
                recibidoDataLabel.Text = n.Recibido.ToShortDateString() + " " + n.Recibido.ToShortTimeString();
                entregadoDateTimePicker.MinDate = DateTimePicker.MinimumDateTime;
                entregadoDateTimePicker.Value = n.Entregado;
                estatusComboBox.SelectedItem = n.Estatus;
                observacionesTextBox.Text = n.Observaciones;
                imprimirButton.Enabled = !String.IsNullOrEmpty(idDataLabel.Text);
                Visible = true;
            }
        }

        /**************************** Métodos: Auxiliares ****************************/
        private void ActualizarTotalLabel()
        {
            decimal total = 0;
            int servicios = 0;
            int prendas = 0;
            foreach(PrendaItemDisplay p in resumenFlowLayoutPanel.Controls)
            {
                prendas += p.Dto.Cantidad;
                servicios += p.Servicios;
                total += p.Total;
            }
            totalDataLabel.Text = "$ " + string.Format("{0:0.00}", total);
            prendasDataLabel.Text = prendas.ToString();
            serviciosDataLabel.Text = servicios.ToString();
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

        private int Descuentos(DescuentoDto d)
        {
            int i = 0;
            foreach(PrendaItemDto p in _dto.Prendas)
            {
                foreach(ServicioItemDto s in p.Servicios)
                { if (d.Equals(s.Descuento)) { i++; } }
            }
            return i;
        }

        private void AgregarPrenda(PrendaItemDto prenda)
        {
            PrendaItemDisplay nuevaPrenda = new PrendaItemDisplay(prenda);
            nuevaPrenda.Width = resumenFlowLayoutPanel.Width - 25;
            nuevaPrenda.Edit += Prenda_Edit;
            nuevaPrenda.Delete += Prenda_Delete;
            resumenFlowLayoutPanel.Controls.Add(nuevaPrenda);
            detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(resumenLayoutPanel)].Height += nuevaPrenda.Height + 5;
        }

        private void AgregarPago(PagoDto pago)
        {
            PagoDisplay pagoDisplay = new PagoDisplay(pago);
            pagoDisplay.Width = pagosFlowLayoutPanel.Width - 25;
            pagoDisplay.Edit += Pago_Edit;
            pagoDisplay.Delete += Pago_Delete;
            pagosFlowLayoutPanel.Controls.Add(pagoDisplay);
            detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(pagosLayoutPanel)].Height += pagoDisplay.Height + 5;
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
                        if(clienteComboBox.Text.Length <= 0)
                        {
                            MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                            descuentoComboBox.SelectedIndex = -1;
                            return 0;
                        }
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
                        if (clienteComboBox.Text.Length <= 0)
                        {
                            MessageBox.Show("Selecciona un cliente para poder validar el descuento.",
                            "Selecciona un cliente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                            descuentoComboBox.SelectedIndex = -1;
                            return 0;
                        }
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


        /************************ Métodos: EventListenners **************************/
        private void DetalleNota_Resize(object sender, EventArgs e)
        {
            foreach (Control c in resumenFlowLayoutPanel.Controls)
            { c.Width = resumenFlowLayoutPanel.Width - 25; }
            foreach (Control c in pagosFlowLayoutPanel.Controls)
            { c.Width = pagosFlowLayoutPanel.Width - 25; }
        }

        private void ClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clienteComboBox.SelectedItem != null)
            {
                ClienteDto c = (ClienteDto)clienteComboBox.SelectedItem;
                clienteDataLabel.Text = c.Nombre + "\n" + c.Telefono + "\n"
                    + c.Domicilio + " " + c.Colonia + (String.IsNullOrEmpty(c.CP) ? "" : (" C.P. " + c.CP));
                clienteStatsDisplay.Fill(((IMainView)ParentForm).Controller.ClienteStats(c).Estadisticas);
            }
            else
            {
                clienteDataLabel.Text = "";
                clienteStatsDisplay.Clear();
            }

        }
        private void ClienteComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl((Control)sender, true, true, true, true);
        }
        private void ClienteComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clienteComboBox.SelectedItem == null)
            {
                foreach (ClienteDto c in clienteComboBox.Items)
                {
                    string search = clienteComboBox.Text.Replace(" ", "");
                    if (!string.IsNullOrEmpty(search)
                        && (c.Nombre.ToLower().IndexOf(search.ToLower()) >= 0
                            || c.Telefono.IndexOf(search) >= 0)
                        )
                    {
                        clienteComboBox.SelectedItem = c;
                        e.Cancel = false;
                        ClienteComboBox_Validated(sender, EventArgs.Empty);
                        break;
                    }
                }
                if (clienteComboBox.SelectedItem == null)
                {
                    /*
                    e.Cancel = true;
                    clienteComboBox.BackColor = System.Drawing.Color.Pink;
                    _errorProvider.SetError(clienteComboBox, "No fue posible encontrar un cliente que coincida con el criterio de búsqueda. Para continuar selecciona un cliente válido o crea uno nuevo en el apartado de clientes.");
                    */
                    clienteDataLabel.Text = "";
                    clienteStatsDisplay.Clear();
                }
            }
            else
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
            nuevoPrendaItem.Owner = ParentForm;
            nuevoPrendaItem.MontoRequested += NuevoPrendaItem_MontoRequested;
            nuevoPrendaItem.ServiciosRequested += NuevoPrendaItem_ServiciosRequested;
            if (nuevoPrendaItem.ShowDialog() == DialogResult.OK)
            {
                PrendaItemDto prendaDto = nuevoPrendaItem.Dto;
                prendaDto.Nota = _dto;
                _dto.Prendas.Add(prendaDto);
                AgregarPrenda(prendaDto);
                ActualizarTotalLabel();
                ActualizarDescuentoLabels();
                ActualizarPagosLabels();
            }
        }
        private void Prenda_Edit(object sender, EventArgs e)
        {
            PrendaItemDisplay display = (PrendaItemDisplay)sender;
            PrendaItemDto prenda = display.Dto;
            NuevoPrendaItem nuevoPrendaItem = new NuevoPrendaItem(prenda);
            nuevoPrendaItem.Owner = ParentForm;
            nuevoPrendaItem.MontoRequested += NuevoPrendaItem_MontoRequested;
            nuevoPrendaItem.ServiciosRequested += NuevoPrendaItem_ServiciosRequested;
            if (nuevoPrendaItem.ShowDialog() == DialogResult.OK)
            {
                _dto.Prendas.Remove(prenda);
                prenda = nuevoPrendaItem.Dto;
                _dto.Prendas.Add(prenda);
                detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(resumenLayoutPanel)].Height -= display.Height;
                display.Update(prenda);
                detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(resumenLayoutPanel)].Height += display.Height;
            }
            ActualizarTotalLabel();
            ActualizarDescuentoLabels();
            ActualizarPagosLabels();
        }
        private void Prenda_Delete(object sender, EventArgs e)
        {
            PrendaItemDisplay display = (PrendaItemDisplay)sender;
            _dto.Prendas.Remove(display.Dto);
            detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(resumenLayoutPanel)].Height -= display.Height + 5;
            resumenFlowLayoutPanel.Controls.Remove(display);
            ActualizarTotalLabel();
            ActualizarDescuentoLabels();
            ActualizarPagosLabels();
        }

        private void AgregarPagoButton_Click(object sender, EventArgs e)
        {
            NuevoPago nuevoPago = new NuevoPago(new PagoDto(_dto));
            if (nuevoPago.ShowDialog() == DialogResult.OK)
            {
                PagoDto pagoDto = nuevoPago.Dto;
                pagoDto.Nota = _dto;
                _dto.Pagos.Add(pagoDto);
                AgregarPago(pagoDto);
                ActualizarPagosLabels();
            }
        }
        private void Pago_Edit(object sender, EventArgs e)
        {
            PagoDisplay display = (PagoDisplay)sender;
            PagoDto pago = display.Dto;
            NuevoPago nuevoPago = new NuevoPago(pago);
            if (nuevoPago.ShowDialog() == DialogResult.OK)
            {
                _dto.Pagos.Remove(pago);
                pago = nuevoPago.Dto;
                _dto.Pagos.Add(pago);
                display.Update(pago);
            }
            ActualizarPagosLabels();
        }
        private void Pago_Delete(object sender, EventArgs e)
        {
            PagoDisplay display = (PagoDisplay)sender;
            _dto.Pagos.Remove(display.Dto);
            detalleNotaLayoutPanel.RowStyles[detalleNotaLayoutPanel.GetRow(pagosLayoutPanel)].Height -= display.Height + 5;
            pagosFlowLayoutPanel.Controls.Remove(display);
            ActualizarPagosLabels();
        }

        private void DescuentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( descuentoComboBox.SelectedItem != null && ((DescuentoDto)descuentoComboBox.SelectedItem).ID >= 0)
            {
                ActualizarDescuentoLabels();
                ActualizarPagosLabels();
            }
        }

        private void NuevoPrendaItem_ServiciosRequested(object sender, DescuentoEventArgs e)
        {
            e.ServiciosNota = Servicios;
            e.DescuentosNota = Descuentos(e.DescuentoDto);
            e.ClienteID = clienteComboBox.SelectedItem != null ? ((ClienteDto)clienteComboBox.SelectedItem).ID : clienteComboBox.Text.Length > 0? -1 : -2;
        }

        private void NuevoPrendaItem_MontoRequested(object sender, DescuentoEventArgs e)
        {
            e.MontoNota = Total;
            e.DescuentosNota = Descuentos(e.DescuentoDto);
            e.ClienteID = clienteComboBox.SelectedItem != null ? ((ClienteDto)clienteComboBox.SelectedItem).ID : clienteComboBox.Text.Length > 0? -1 : -2;
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            IMainView mainView = (IMainView)ParentForm;
            try { mainView.Controller.ImprimirNota((NotaDto)Dto); }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar imprimir:\n\n" + ex.Message + "\n\nError: " + ex.GetType(),
                            "Error de impresión",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            
        }
    }
}
