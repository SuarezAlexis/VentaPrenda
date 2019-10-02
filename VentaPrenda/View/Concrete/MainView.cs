using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VentaPrenda.Controller;
using VentaPrenda.Model;
using VentaPrenda.View.Abstract;
using VentaPrenda.View.Concrete.Detalles;

namespace VentaPrenda.View.Concrete
{
    public partial class MainView : Form, IMainView
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private readonly System.Drawing.Color ClearColor = SystemColors.ControlLight;
        private readonly System.Drawing.Color ActiveColor = SystemColors.ControlDark;
        private readonly int DataRowHeight = 22;
        public MainController Controller { get; set; }

        private object _dto;
        private DetalleModelo _detalle;
        private DataTable _dataSource;
        public object Dto
        {
            get { return _dto; }
            set
            {
                _dto = value;
                if (value != null)
                    Detalle.Fill(Dto);                    
            }
        }
        private DetalleModelo Detalle {
            get { return _detalle; }
            set
            { //Quita el objeto que anteriormente ocupaba el espacio y lo llena con el nuevo.
                detalleBox.Controls.Clear();
                _detalle = value;
                if(value != null)
                {
                    detalleBox.Controls.Add(value);
                    Detalle.Dock = DockStyle.Fill;
                }
            }
        }
        public DataTable DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                listGridView.DataSource = _dataSource;
                listGridView.ClearSelection();
                if (Controller.Funcion == Funcion.NOTA)
                {
                    foreach (DataGridViewRow row in listGridView.Rows)
                    {
                        switch(Enum.Parse(typeof(Estatus), row.Cells["Estatus"].Value.ToString()))
                        {
                            case Estatus.Cancelado:
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                                break;
                            case Estatus.Pendiente:
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                                break;
                            case Estatus.Terminado:
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                                break;
                            case Estatus.Entregado:
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew;
                                break;
                            case Estatus.Caducado:
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Thistle;
                                break;
                        }
                    }
                        
                }
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public MainView()
        {
            InitializeComponent();
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        /************************ MÉTODOS: Públicos ************************/
        public void ShowDashboard()
        {
            fechaLabel.Text = DateTime.Now.ToShortDateString();
            usuarioLabel.Text = Controller.Usuario.Username;
            modoLabel.Text = "";
            infoLabel.Text = "";
            objetoLabel.Text = "";
            UpdateModo();
            Application.Run(this);
        }

        public void UpdateModo()
        {
            switch (Controller.Modo)
            {
                case Modo.NINGUNO:
                    ModoNinguno();
                    break;
                case Modo.SELECCION:
                    ModoSeleccion();
                    break;
                case Modo.SOLO_LECTURA:
                    ModoSoloLectura();
                    break;
                case Modo.EDICION:
                    ModoEdicion();
                    break;
            }
        }

        public void UpdateFuncion()
        {
            ClearFunctionButtons();
            Detalle = newDetalle(errorProvider);
            listGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listGridView.MultiSelect = false;
            SetFiltroVisible(false);
            switch (Controller.Funcion)
            {
                case Funcion.NINGUNA:
                    SetEditButtonsEnabled(false);
                    SetSelectButtonsEnabled(false);
                    RegresarButton.Enabled = false;
                    infoLabel.Text = "Selecciona una función del menú.";
                    break;
                case Funcion.PERFILES:
                    PerfilesButton.BackColor = ActiveColor;
                    break;
                case Funcion.USUARIOS:
                    UsuariosButton.BackColor = ActiveColor;
                    break;
                case Funcion.COLORES:
                    ColoresButton.BackColor = ActiveColor;
                    break;
                case Funcion.PRENDAS:
                    PrendasButton.BackColor = ActiveColor;
                    break;
                case Funcion.TIPOS_PRENDA:
                    TiposButton.BackColor = ActiveColor;
                    break;
                case Funcion.SERVICIOS:
                    ServiciosButton.BackColor = ActiveColor;
                    break;
                case Funcion.DESCUENTOS:
                    DescuentosButton.BackColor = ActiveColor;
                    break;
                case Funcion.NOTA:
                    SetFiltroVisible(true);
                    NotasButton.BackColor = ActiveColor;
                    break;
                case Funcion.CLIENTES:
                    ClientesButton.BackColor = ActiveColor;
                    break;
                case Funcion.BALANCE:
                    SetFiltroVisible(true);
                    BalanceButton.BackColor = ActiveColor;
                    break;
                case Funcion.REPORTES:
                    ReportesButton.BackColor = ActiveColor;
                    listGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    listGridView.MultiSelect = true;
                    SetSelectButtonsEnabled(false);
                    break;
                case Funcion.HISTORIAL:
                    SetFiltroVisible(true);
                    HistorialButton.BackColor = ActiveColor;
                    SetSelectButtonsEnabled(false);
                    break;
                case Funcion.TICKET:
                    TicketButton.BackColor = ActiveColor;
                    break;
            }
        }

        public void SetProfile(Permisos p)
        {
            NotasButton.Visible = p.Notas || p.GenerarNota || p.EliminarNota || p.EditarNota;
            ClientesButton.Visible = p.Clientes || p.AdmonClientes;
            UsuariosButton.Visible = p.Usuarios || p.AdmonUsuarios;
            PerfilesButton.Visible = p.Perfiles || p.AdmonPerfiles;
            ReportesButton.Visible = p.Reportes;
            BalanceButton.Visible = p.Balance || p.AdmonMovimientos || p.GeneraMovimientos;
            HistorialButton.Visible = p.Historial;
            DescuentosButton.Visible = p.Descuentos;
            ColoresButton.Visible = p.Catalogos;
            PrendasButton.Visible = p.Catalogos;
            TiposButton.Visible = p.Catalogos;
            ServiciosButton.Visible = p.Catalogos;
        }

        public void DuplicateKeyAlert(string duplicateKey)
        {
            MessageBox.Show(
                "Ya existe un registro con el identificador " + duplicateKey + ".\nNo fue posible guardar los datos.",
                "Identificador duplicado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        /************************ MÉTODOS: Privados ************************/
        private void ModoNinguno()
        {
            detalleBox.Controls.Clear();
            SetEditButtonsEnabled(false);
            SetSelectButtonsEnabled(false);
            RegresarButton.Enabled = false;
            ClearFunctionButtons();
            modoLabel.Text = "";
            objetoLabel.Text = "";
            infoLabel.Text = "";
        }

        private void ModoSeleccion()
        {
            SetEditButtonsEnabled(false);
            SetSelectButtonsEnabled(true);
            RegresarButton.Enabled = true;
            modoLabel.Text = "SELECCIÓN";
            objetoLabel.Text = "";
            infoLabel.Text = "Haz doble clic sobre un registro para ver sus detalles.";
        }

        private void ModoSoloLectura()
        {
            SetEditButtonsEnabled(true);
            SetSelectButtonsEnabled(false);
            Detalle.ReadOnly = true;
            modoLabel.Text = "SÓLO LECTURA";
            infoLabel.Text = "";
        }

        private void ModoEdicion()
        {
            SetEditButtonsEnabled(false);
            SetSelectButtonsEnabled(true);
            modoLabel.Text = "EDICIÓN";
            objetoLabel.Text = Detalle.Dto.ToString();
            infoLabel.Text = "No se han guardado los cambios";
            Detalle.ReadOnly = false;
        }

        private void SetEditButtonsEnabled(bool e)
        {
            EliminarButton.Enabled = e;
            EditarButton.Enabled = e;
            NuevoButton.Enabled = e;
        }

        private void SetSelectButtonsEnabled(bool e)
        {
            GuardarButton.Enabled = e;
            LimpiarButton.Enabled = e;
        }

        private void SetFiltroVisible(bool v)
        {
            desdeLabel.Visible = v;
            hastaLabel.Visible = v;
            desdeDateTimePicker.Visible = v;
            hastaDateTimePicker.Visible = v;
            filtrarButton.Visible = v;
            desdeDateTimePicker.Value = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            hastaDateTimePicker.Value = DateTime.Today.AddSeconds(86399);
        }

        private void ClearFunctionButtons()
        {
            NotasButton.BackColor = ClearColor;
            ClientesButton.BackColor = ClearColor;
            BalanceButton.BackColor = ClearColor;
            ReportesButton.BackColor = ClearColor;
            HistorialButton.BackColor = ClearColor;
            ColoresButton.BackColor = ClearColor;
            PrendasButton.BackColor = ClearColor;
            TiposButton.BackColor = ClearColor;
            ServiciosButton.BackColor = ClearColor;
            DescuentosButton.BackColor = ClearColor;
            UsuariosButton.BackColor = ClearColor;
            PerfilesButton.BackColor = ClearColor;
            TicketButton.BackColor = ClearColor;
        }

        private DetalleModelo newDetalle(ErrorProvider e)
        {
            switch (Controller.Funcion)
            {
                case Funcion.PERFILES:
                    return new DetallePerfil(errorProvider);
                case Funcion.USUARIOS:
                    return new DetalleUsuario(errorProvider);
                case Funcion.COLORES:
                case Funcion.PRENDAS:
                case Funcion.TIPOS_PRENDA:
                    return new DetalleCatalogo(errorProvider);
                case Funcion.SERVICIOS:
                    return new DetalleServicio(errorProvider);
                case Funcion.DESCUENTOS:
                    return new DetalleDescuento(errorProvider);
                case Funcion.NOTA:
                    return new DetalleNota(errorProvider);
                case Funcion.CLIENTES:
                    return new DetalleCliente(errorProvider);
                case Funcion.BALANCE:
                    return new DetalleMovimiento(errorProvider);
                case Funcion.REPORTES:
                    return new DetalleReporte(errorProvider);
                case Funcion.TICKET:
                    return new DetalleTicket();
                case Funcion.HISTORIAL:
                    return new DetalleHistorial();
            }
            return null;
        }

        private void Filtrar()
        {
            string cellName = Controller.Funcion == Funcion.NOTA ? "Recibido" : "Fecha";
            bool show = true;
            foreach (DataGridViewRow row in listGridView.Rows)
            {
                if (cellName != null && filtrarButton.BackColor == ActiveColor)
                {
                    DateTime fecha = (DateTime)row.Cells[cellName].Value;
                    show = fecha >= desdeDateTimePicker.Value && fecha <= hastaDateTimePicker.Value;
                }
                else { show = true; }
                if (show && !String.IsNullOrEmpty(busquedaTextBox.Text))
                {
                    foreach (DataGridViewTextBoxCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().ToLower().Contains(busquedaTextBox.Text.ToLower()))
                        { show = true; break; }
                        else
                        { show = false; }
                    }
                }
                listGridView.Rows[row.Index].Height = show ? DataRowHeight : 0;
            }
        }

        /******************** MÉTODOS: EventHandlers *******************/
        private void PerfilesButton_Click(object sender, EventArgs e)
        { Controller.Perfiles(); }

        private void UsuariosButton_Click(object sender, EventArgs e)
        { Controller.Usuarios(); }

        public void ColoresButton_Click(object sender, EventArgs e)
        { Controller.Colores(); }

        public void PrendasButton_Click(object sender, EventArgs e)
        { Controller.Prendas(); }

        public void TiposButton_Click(object sender, EventArgs e)
        { Controller.TiposPrenda(); } 

        public void ServiciosButton_Click(object sender, EventArgs e)
        { Controller.Servicios(); }

        public void DescuentosButton_Click(object sender, EventArgs e)
        { Controller.Descuentos(); }

        private void TicketButton_Click(object sender, EventArgs e)
        { Controller.Ticket(); }

        public void NotasButton_Click(object sender, EventArgs e)
        { Controller.Notas(); }

        public void ClientesButton_Click(object sender, EventArgs e)
        { Controller.Clientes(); }

        public void BalanceButton_Click(object sender, EventArgs e)
        { Controller.Balance(); }

        public void ReportesButton_Click(object sender, EventArgs e)
        { Controller.Reportes(); }

        public void HistorialButton_Click(object sender, EventArgs e)
        { Controller.Historial(); }

        private void ListGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(listGridView.SelectedRows.Count > 0)
            {
                Controller.FillDetalle(Convert.ToInt64(listGridView.SelectedRows[0].Cells[0].Value));
                objetoLabel.Text = Detalle.Dto.ToString();
                if (Controller.Funcion == Funcion.HISTORIAL)
                    SetEditButtonsEnabled(false);
            }
        }

        /******************** MÉTODOS: EventHandlers *******************/
        private void RegresarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Controller.Regresar();
        }

        private void EditarButton_Click(object sender, EventArgs e)
        { Controller.Editar(); }

        private void LimpiarButton_Click(object sender, EventArgs e)
        { Detalle.Clear(); }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Detalle = newDetalle(errorProvider);
            Controller.Nuevo();
            Detalle.Focus();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Detalle.ValidateChildren() && Controller.Guardar(Detalle.Dto))
            {
                infoLabel.Text = "Se guardó correctamente: " + Dto.ToString();
                if (Controller.Funcion == Funcion.TICKET)
                { SetEditButtonsEnabled(false); SetSelectButtonsEnabled(true); }
                else
                { NuevoButton.Focus(); }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Se eliminará " + Detalle.Dto.ToString() + "\n¿Estas seguro?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dtoString = Dto.ToString();
                Controller.Eliminar(Detalle.Dto);
                Type DetalleType = Detalle.Dto.GetType();
                bool eliminado = true;
                foreach(DataRow dr in DataSource.Rows)
                {
                    eliminado = !Convert.ToInt64(dr["ID"]).Equals(Convert.ToInt64(DetalleType.GetProperty("ID").GetValue(Detalle.Dto)));
                    if (!eliminado) break;
                }
                if (DetalleType.GetProperties().Where(p => "Habilitado".Equals(p.Name)).Count() > 0
                    && !(bool)DetalleType.GetProperty("Habilitado").GetValue(Detalle.Dto) 
                    && !eliminado)
                {
                    MessageBox.Show("No fue posible eliminar: '" + dtoString 
                        + "' debido a que está asociado a otros registros.\nSe inhabilitó.",
                        "Se inhabilitó correctamente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    infoLabel.Text = "Se inhabilitó correctamente: " + dtoString;
                }
                else
                { infoLabel.Text = "Se eliminó correctamente: " + dtoString;  }
                Detalle.Clear();
                Detalle.ReadOnly = false;
            }
        }

        private void BusquedaTextBox_TextChanged(object sender, EventArgs e)
        { Filtrar(); }

        private void DesdeDateTimePicker_ValueChanged(object sender, EventArgs e)
        { Filtrar(); }

        private void HastaDateTimePicker_ValueChanged(object sender, EventArgs e)
        { Filtrar(); }

        private void FiltrarButton_Click(object sender, EventArgs e)
        {
            filtrarButton.BackColor = filtrarButton.BackColor == ActiveColor? ClearColor : ActiveColor;
            Filtrar();
        }

    }
}
