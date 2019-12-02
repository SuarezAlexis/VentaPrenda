using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VentaPrenda.Controller;
using VentaPrenda.DTO;
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
        private ColoresGUIDto _colores = new ColoresGUIDto();
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
                //listGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                listGridView.DataSource = _dataSource;
                //listGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                listGridView.ClearSelection();
                if (Controller.Funcion == Funcion.NOTA)
                    UpdateListColors();
            }
        }

        private void UpdateListColors()
        {
            foreach (DataGridViewRow row in listGridView.Rows)
            {
                switch (Enum.Parse(typeof(Estatus), row.Cells["Estatus"].Value.ToString()))
                {
                    case Estatus.Cancelado:
                        row.DefaultCellStyle.BackColor = _colores.Cancelado;
                        break;
                    case Estatus.Pendiente:
                        row.DefaultCellStyle.BackColor = _colores.Pendiente;
                        break;
                    case Estatus.Terminado:
                        row.DefaultCellStyle.BackColor = _colores.Terminado;
                        break;
                    case Estatus.Entregado:
                        row.DefaultCellStyle.BackColor = _colores.Entregado;
                        break;
                    case Estatus.Caducado:
                        row.DefaultCellStyle.BackColor = _colores.Caducado;
                        break;
                }
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public MainView()
        { InitializeComponent(); }

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
            Detalle = NewDetalle(errorProvider);
            if (Detalle != null) { Detalle.Colores = _colores; }
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
                    PerfilesButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.USUARIOS:
                    UsuariosButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.COLORES:
                    ColoresButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.PRENDAS:
                    PrendasButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.TIPOS_PRENDA:
                    TiposButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.SERVICIOS:
                    ServiciosButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.DESCUENTOS:
                    DescuentosButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.NOTA:
                    SetFiltroVisible(true);
                    NotasButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.CLIENTES:
                    ClientesButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.BALANCE:
                    SetFiltroVisible(true);
                    BalanceButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.REPORTES:
                    ReportesButton.BackColor = _colores.FondoBotonActivo;
                    listGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    listGridView.MultiSelect = true;
                    SetSelectButtonsEnabled(false);
                    break;
                case Funcion.HISTORIAL:
                    SetFiltroVisible(true);
                    HistorialButton.BackColor = _colores.FondoBotonActivo;
                    SetSelectButtonsEnabled(false);
                    break;
                case Funcion.TICKET:
                    TicketButton.BackColor = _colores.FondoBotonActivo;
                    break;
                case Funcion.DATABASE:
                    BaseDeDatosButton.BackColor = _colores.FondoBotonActivo;
                    SetSelectButtonsEnabled(false);
                    break;
                case Funcion.PERSONALIZAR:
                    PersonalizarButton.BackColor = _colores.FondoBotonActivo;
                    break;
            }
        }

        public void SetProfile(Permisos p)
        {
            NotasButton.Visible = p.Notas || p.GenerarNota || p.EliminarNota || p.EditarNota;
            ClientesButton.Visible = p.Clientes || p.AdmonClientes;
            UsuariosButton.Visible = p.Usuarios || p.AdmonUsuarios;
            PerfilesButton.Visible = p.Perfiles || p.AdmonPerfiles;
            BaseDeDatosButton.Visible = p.Database;
            ReportesButton.Visible = p.Reportes;
            BalanceButton.Visible = p.Balance || p.AdmonMovimientos || p.GeneraMovimientos;
            HistorialButton.Visible = p.Historial;
            DescuentosButton.Visible = p.Descuentos;
            ColoresButton.Visible = p.Catalogos;
            PrendasButton.Visible = p.Catalogos;
            TiposButton.Visible = p.Catalogos;
            ServiciosButton.Visible = p.Catalogos;
            TicketButton.Visible = p.Ticket;
            PersonalizarButton.Visible = true;
        }

        public void SetColors(ColoresGUIDto colores)
        {
            _colores = colores;

            BackColor = _colores.FondoVentana;
            listGridView.BackgroundColor = _colores.FondoLista;
            ClearFunctionButtons();
            if(Controller.Funcion == Funcion.PERSONALIZAR)
            { PersonalizarButton.BackColor = _colores.FondoBotonActivo; }
            RegresarButton.BackColor = _colores.FondoBoton;
            NuevoButton.BackColor = _colores.FondoBoton;
            EditarButton.BackColor = _colores.FondoBoton;
            GuardarButton.BackColor = _colores.FondoBoton;
            EliminarButton.BackColor = _colores.FondoBoton;
            LimpiarButton.BackColor = _colores.FondoBoton;
            filtrarButton.BackColor = _colores.FondoBoton;

            statusStrip.BackColor = _colores.FondoVentana;

            RegresarButton.FlatAppearance.MouseDownBackColor = _colores.FondoBotonActivo;
            NuevoButton.FlatAppearance.MouseDownBackColor = _colores.FondoBotonActivo;
            EditarButton.FlatAppearance.MouseDownBackColor = _colores.FondoBotonActivo;
            GuardarButton.FlatAppearance.MouseDownBackColor = _colores.FondoBotonActivo;
            EliminarButton.FlatAppearance.MouseDownBackColor = _colores.FondoBotonActivo;
            LimpiarButton.FlatAppearance.MouseDownBackColor = _colores.FondoBotonActivo;
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
            _dto = null;
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
            switch (Controller.Funcion)
            {
                case Funcion.NOTA:
                    EliminarButton.Enabled = e && Controller.Usuario.Permisos.EliminarNota;
                    EditarButton.Enabled = e && Controller.Usuario.Permisos.EditarNota;
                    NuevoButton.Enabled = e && Controller.Usuario.Permisos.GenerarNota;
                    break;
                case Funcion.BALANCE:
                    EliminarButton.Enabled = e && Controller.Usuario.Permisos.AdmonMovimientos;
                    EditarButton.Enabled = e && Controller.Usuario.Permisos.AdmonMovimientos;
                    NuevoButton.Enabled = e && Controller.Usuario.Permisos.GeneraMovimientos;
                    break;
                case Funcion.PERFILES:
                    EliminarButton.Enabled = e && Controller.Usuario.Permisos.AdmonPerfiles;
                    EditarButton.Enabled = e && Controller.Usuario.Permisos.AdmonPerfiles;
                    NuevoButton.Enabled = e && Controller.Usuario.Permisos.AdmonPerfiles;
                    break;
                case Funcion.USUARIOS:
                    EliminarButton.Enabled = e && Controller.Usuario.Permisos.AdmonUsuarios;
                    EditarButton.Enabled = e && Controller.Usuario.Permisos.AdmonUsuarios;
                    NuevoButton.Enabled = e && Controller.Usuario.Permisos.AdmonUsuarios;
                    break;
                case Funcion.CLIENTES:
                    EliminarButton.Enabled = e && Controller.Usuario.Permisos.AdmonClientes;
                    EditarButton.Enabled = e && Controller.Usuario.Permisos.AdmonClientes;
                    NuevoButton.Enabled = e && Controller.Usuario.Permisos.AdmonClientes;
                    break;
                case Funcion.COLORES:
                case Funcion.PRENDAS:
                case Funcion.SERVICIOS:
                case Funcion.TIPOS_PRENDA:
                    EliminarButton.Enabled = e && Controller.Usuario.Permisos.AdmonCatalogos;
                    EditarButton.Enabled = e && Controller.Usuario.Permisos.AdmonCatalogos;
                    NuevoButton.Enabled = e && Controller.Usuario.Permisos.AdmonCatalogos;
                    break;
                default:
                    EliminarButton.Enabled = e;
                    EditarButton.Enabled = e;
                    NuevoButton.Enabled = e;
                    break;

            }
        }

        private void SetSelectButtonsEnabled(bool e)
        {
            switch(Controller.Funcion)
            {
                case Funcion.NOTA:
                    GuardarButton.Enabled = e && Controller.Usuario.Permisos.GenerarNota;
                    break;
                case Funcion.BALANCE:
                    GuardarButton.Enabled = e && Controller.Usuario.Permisos.GeneraMovimientos;
                    break;
                case Funcion.CLIENTES:
                    GuardarButton.Enabled = e && Controller.Usuario.Permisos.AdmonClientes;
                    break;
                case Funcion.PERFILES:
                    GuardarButton.Enabled = e && Controller.Usuario.Permisos.AdmonPerfiles;
                    break;
                case Funcion.USUARIOS:
                    GuardarButton.Enabled = e && Controller.Usuario.Permisos.AdmonUsuarios;
                    break;
                case Funcion.COLORES:
                case Funcion.PRENDAS:
                case Funcion.SERVICIOS:
                case Funcion.TIPOS_PRENDA:
                    GuardarButton.Enabled = e && Controller.Usuario.Permisos.AdmonCatalogos;
                    break;
                default:
                    GuardarButton.Enabled = e;
                    LimpiarButton.Enabled = e;
                    break;
            }
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
            NotasButton.BackColor = _colores.FondoBoton;
            ClientesButton.BackColor = _colores.FondoBoton;
            BalanceButton.BackColor = _colores.FondoBoton;
            ReportesButton.BackColor = _colores.FondoBoton;
            HistorialButton.BackColor = _colores.FondoBoton;
            ColoresButton.BackColor = _colores.FondoBoton;
            PrendasButton.BackColor = _colores.FondoBoton;
            TiposButton.BackColor = _colores.FondoBoton;
            ServiciosButton.BackColor = _colores.FondoBoton;
            DescuentosButton.BackColor = _colores.FondoBoton;
            UsuariosButton.BackColor = _colores.FondoBoton;
            PerfilesButton.BackColor = _colores.FondoBoton;
            TicketButton.BackColor = _colores.FondoBoton;
            BaseDeDatosButton.BackColor = _colores.FondoBoton;
            PersonalizarButton.BackColor = _colores.FondoBoton;
        }

        private DetalleModelo NewDetalle(ErrorProvider e)
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
                    return new DetalleNota(errorProvider, Controller.Usuario    );
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
                case Funcion.DATABASE:
                    return new DetalleBaseDeDatos();
                case Funcion.PERSONALIZAR:
                    return new DetallePersonalizar();
            }
            return null;
        }

        private void Filtrar()
        {
            if(_dataSource != null)
            {
                DataTable filteredDataSource = new DataTable();
                foreach (DataColumn dc in _dataSource.Columns)
                { filteredDataSource.Columns.Add(dc.ColumnName); }

                string cellName = Controller.Funcion == Funcion.NOTA ? "Recibido" : "Fecha";
                bool show = true;

                for (int i = 0; i < _dataSource.Rows.Count; i++)
                {
                    if (cellName != null && filtrarButton.BackColor == _colores.FondoBotonActivo)
                    {
                        DateTime fecha = (DateTime)_dataSource.Rows[i][cellName];
                        show = fecha >= desdeDateTimePicker.Value && fecha <= hastaDateTimePicker.Value;
                    }
                    else { show = true; }
                    if (show && !String.IsNullOrEmpty(busquedaTextBox.Text))
                    {
                        foreach (object cell in _dataSource.Rows[i].ItemArray)
                        {
                            if (cell.ToString().ToLower().Contains(busquedaTextBox.Text.ToLower()))
                            { show = true; break; }
                            else
                            { show = false; }
                        }
                    }
                    if (show) { filteredDataSource.Rows.Add(_dataSource.Rows[i].ItemArray); }
                }
                listGridView.DataSource = filteredDataSource;
            }
        }

        /******************** MÉTODOS: EventHandlers *******************/
        private void PerfilesButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Perfiles(); Cursor = Cursors.Default; Cursor = Cursors.Default; }

        private void UsuariosButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Usuarios(); Cursor = Cursors.Default; }

        public void ColoresButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Colores(); Cursor = Cursors.Default; }

        public void PrendasButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Prendas(); Cursor = Cursors.Default; }

        public void TiposButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.TiposPrenda(); Cursor = Cursors.Default; } 

        public void ServiciosButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Servicios(); Cursor = Cursors.Default; }

        public void DescuentosButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Descuentos(); Cursor = Cursors.Default; }

        private void TicketButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Ticket(); Cursor = Cursors.Default; }

        public void NotasButton_Click(object sender, EventArgs e)
        { 
            Cursor = Cursors.WaitCursor; 
            Controller.Notas();
            Cursor = Cursors.Default; 
        }

        public void ClientesButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Clientes(); Cursor = Cursors.Default; }

        public void BalanceButton_Click(object sender, EventArgs e)
        { 
            Cursor = Cursors.WaitCursor; 
            Controller.Balance(); 
            Cursor = Cursors.Default; 
        }

        public void ReportesButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Reportes(); Cursor = Cursors.Default; }

        public void HistorialButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Historial(); Cursor = Cursors.Default; }

        private void BaseDeDatosButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.BaseDeDatos(); Cursor = Cursors.Default; }

        private void PersonalizarButton_Click(object sender, EventArgs e)
        { Cursor = Cursors.WaitCursor; Controller.Personalizar(); Cursor = Cursors.Default; }

        private void ListGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (listGridView.SelectedRows.Count > 0)
            {
                Controller.FillDetalle(Convert.ToInt64(listGridView.SelectedRows[0].Cells[0].Value));
                objetoLabel.Text = Detalle.Dto.ToString();
                switch (Controller.Funcion)
                {
                    case Funcion.HISTORIAL:
                        SetEditButtonsEnabled(false);
                        break;
                    case Funcion.NOTA:
                        break;
                    case Funcion.BALANCE:
                        break;
                }
            }
            Cursor = Cursors.Default;
        }

        private void ListGridView_Sorted(object sender, EventArgs e)
        {
            if (Controller.Funcion == Funcion.NOTA)
            { UpdateListColors(); }
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
            Detalle = NewDetalle(errorProvider);
            Detalle.Colores = _colores;
            Controller.Nuevo();
            Detalle.Focus();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if(Detalle.ValidateChildren())
            {
                if (Controller.Funcion == Funcion.NOTA && ((NotaDto)Detalle.Dto).Prendas.Count == 0)
                {
                    MessageBox.Show("Es necesario agregar al menos una prenda.",
                        "No se agregaron prendas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    if(Controller.Guardar(Detalle.Dto))
                    {
                        infoLabel.Text = "Se guardó correctamente: " + Dto.ToString();
                        if (Controller.Funcion == Funcion.TICKET || Controller.Funcion == Funcion.PERSONALIZAR)
                        { SetEditButtonsEnabled(false); SetSelectButtonsEnabled(true); }
                        else
                        { NuevoButton.Focus(); }
                    }
                    Cursor = Cursors.Default;
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (MessageBox.Show("Se eliminará " + Detalle.Dto.ToString() + "\n¿Estas seguro?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dtoString = Dto.ToString();
                Controller.Eliminar(Detalle.Dto);
                Type DtoType = Detalle.Dto.GetType();
                bool eliminado = true;
                foreach(DataRow dr in DataSource.Rows)
                {
                    eliminado = !Convert.ToInt64(dr["ID"]).Equals(Convert.ToInt64(DtoType.GetProperty("ID").GetValue(Detalle.Dto)));
                    if (!eliminado) break;
                }
                if (!eliminado 
                    && ( 
                    (DtoType.GetProperties().Where(p => "Habilitado".Equals(p.Name)).Count() > 0 && !(bool)DtoType.GetProperty("Habilitado").GetValue(Detalle.Dto)) 
                    ||
                    (DtoType.GetProperties().Where(p => "Bloqueado".Equals(p.Name)).Count() > 0 && (bool)DtoType.GetProperty("Bloqueado").GetValue(Detalle.Dto))
                    ))
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
            Cursor = Cursors.Default;
        }

        private void BusquedaTextBox_TextChanged(object sender, EventArgs e)
        { Filtrar(); }

        private void DesdeDateTimePicker_ValueChanged(object sender, EventArgs e)
        { Filtrar(); }

        private void HastaDateTimePicker_ValueChanged(object sender, EventArgs e)
        { Filtrar(); }

        private void FiltrarButton_Click(object sender, EventArgs e)
        {
            filtrarButton.BackColor = filtrarButton.BackColor == _colores.FondoBotonActivo? _colores.FondoBoton : _colores.FondoBotonActivo;
            Filtrar();
        }
    }
}
