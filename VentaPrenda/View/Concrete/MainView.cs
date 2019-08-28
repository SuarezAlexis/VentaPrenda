using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly Color ClearColor = SystemColors.ControlLight;
        private readonly Color ActiveColor = SystemColors.ControlDark;
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
                    NotasButton.BackColor = ActiveColor;
                    break;
                case Funcion.CLIENTES:
                    ClientesButton.BackColor = ActiveColor;
                    break;
                case Funcion.BALANCE:
                    BalanceButton.BackColor = ActiveColor;
                    break;
                case Funcion.REPORTES:
                    ReportesButton.BackColor = ActiveColor;
                    break;
                case Funcion.HISTORIAL:
                    HistorialButton.BackColor = ActiveColor;
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

                    break;
                case Funcion.NOTA:

                    break;
                case Funcion.CLIENTES:
                    return new DetalleCliente(errorProvider);
                case Funcion.BALANCE:
                    return new DetalleMovimiento(errorProvider);
                case Funcion.REPORTES:

                    break;
                case Funcion.HISTORIAL:

                    break;
            }
            return null;
        }

        /******************** MÉTODOS: EventHandlers *******************/
        private void PerfilesButton_Click(object sender, EventArgs e)
        {
            Controller.Perfiles();
        }

        private void UsuariosButton_Click(object sender, EventArgs e)
        {
            Controller.Usuarios();
        }

        public void ColoresButton_Click(object sender, EventArgs e)
        {
            Controller.Colores();
        }

        public void PrendasButton_Click(object sender, EventArgs e)
        {
            Controller.Prendas();
        }

        public void TiposButton_Click(object sender, EventArgs e)
        {
            Controller.TiposPrenda();
        }

        public void ServiciosButton_Click(object sender, EventArgs e)
        {
            Controller.Servicios();
        }

        public void DescuentosButton_Click(object sender, EventArgs e)
        {
            Controller.Descuentos();
        }

        public void NotasButton_Click(object sender, EventArgs e)
        {
            Controller.Notas();
        }

        public void ClientesButton_Click(object sender, EventArgs e)
        {
            Controller.Clientes();
        }

        public void BalanceButton_Click(object sender, EventArgs e)
        {
            Controller.Balance();
        }

        public void ReportesButton_Click(object sender, EventArgs e)
        {
            Controller.Reportes();
        }

        public void HistorialButton_Click(object sender, EventArgs e)
        {
            Controller.Historial();
        }

        private void ListGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Controller.FillDetalle(Convert.ToInt64(listGridView.SelectedRows[0].Cells[0].Value));
            objetoLabel.Text = Detalle.Dto.ToString();
        }

        /******************** MÉTODOS: EventHandlers *******************/
        private void RegresarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Controller.Regresar();
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            Controller.Editar();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Detalle.Clear();
        }

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
                NuevoButton.Focus();
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Se eliminará " + Detalle.Dto.ToString() + "\n¿Estas seguro?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dtoString = Dto.ToString();
                Controller.Eliminar(Detalle.Dto);
                Detalle.Clear();
                Detalle.ReadOnly = false;
                infoLabel.Text = "Se eliminó correctamente: " + dtoString;
            }
        }

        
    }
}
