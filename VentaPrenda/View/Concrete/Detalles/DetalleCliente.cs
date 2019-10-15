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

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetalleCliente : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private ClienteDto _dto;
        private ErrorProvider _errorProvider;
        private ColoresGUIDto _colores;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                nombreTextBox.ReadOnly = value;
                domicilioTextBox.ReadOnly = value;
                coloniaTextBox.ReadOnly = value;
                cpTextBox.ReadOnly = value;
                telefonoTextBox.ReadOnly = value;
                emailTextBox.ReadOnly = value;
                habilitadoCheckBox.Enabled = !value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0 ? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Nombre = nombreTextBox.Text;
                _dto.Domicilio = domicilioTextBox.Text;
                _dto.Colonia = coloniaTextBox.Text;
                _dto.CP = cpTextBox.Text;
                _dto.Telefono = telefonoTextBox.Text;
                _dto.Email = emailTextBox.Text;
                _dto.Habilitado = habilitadoCheckBox.Checked;
                return _dto;
            }
            set
            {
                if (value != null && (value is ClienteDto))
                    _dto = (ClienteDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleCliente porque no es del tipo correcto.");
            }
        }

        public override ColoresGUIDto Colores
        {
            get { return _colores; }
            set { _colores = value; }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleCliente()
        {
            InitializeComponent();
            _dto = new ClienteDto();
        }

        public DetalleCliente(ErrorProvider e) : this()
        {
            _errorProvider = e;
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public override void Clear()
        {
            idDataLabel.Text = "";
            nombreTextBox.Text = "";
            domicilioTextBox.Text = "";
            coloniaTextBox.Text = "";
            cpTextBox.Text = "";
            telefonoTextBox.Text = "";
            emailTextBox.Text = "";
            habilitadoCheckBox.Checked = true;
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(ClienteDto))
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
                ClienteDto c = (ClienteDto)model;
                Visible = false;
                idDataLabel.Text = c.ID > 0 ? c.ID.ToString() : "";
                nombreTextBox.Text = c.Nombre;
                domicilioTextBox.Text = c.Domicilio;
                coloniaTextBox.Text = c.Colonia;
                cpTextBox.Text = c.CP;
                telefonoTextBox.Text = c.Telefono;
                emailTextBox.Text = c.Email;
                habilitadoCheckBox.Checked = c.Habilitado;
                clienteStatsDisplay.Fill(c.Estadisticas);
                Visible = true;
            }
        }

        /************************ EventListenners **************************/
        private void nombreTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(nombreTextBox, 128, e, _errorProvider); }
        private void nombreTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(nombreTextBox); }
    }
}
