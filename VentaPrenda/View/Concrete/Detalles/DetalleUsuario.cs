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
    public partial class DetalleUsuario : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private UsuarioDto _dto;
        private ErrorProvider _errorProvider;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                usernameTextBox.ReadOnly = value;
                nombreTextBox.ReadOnly = value;
                passwordTextBox.ReadOnly = value;
                confirmaTextBox.ReadOnly = value;
                bloqueadoCheckBox.Enabled = !value;
                perfilesListBox.Enabled = !value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0 ? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Nombre = nombreTextBox.Text;
                _dto.Username = usernameTextBox.Text;
                _dto.Contraseña = passwordTextBox.Text;
                _dto.Confirmacion = confirmaTextBox.Text;
                _dto.Bloqueado = bloqueadoCheckBox.Checked;
                _dto.Perfiles.Clear();
                for(int i = 0; i < perfilesListBox.Items.Count; i++)
                {
                    _dto.Perfiles.Add((PerfilDto)perfilesListBox.Items[i],
                        perfilesListBox.GetItemChecked(i));
                }
                return _dto;
            }
            set
            {
                if (value != null && value.GetType() == typeof(UsuarioDto))
                    _dto = (UsuarioDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleUsuario porque no es del tipo correcto.");
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleUsuario()
        {
            InitializeComponent();
        }

        public DetalleUsuario(ErrorProvider e) : this()
        {
            _errorProvider = e;
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public override void Clear()
        {
            idDataLabel.Text = "";
            usernameTextBox.Text = "";
            nombreTextBox.Text = "";
            passwordTextBox.Text = "";
            confirmaTextBox.Text = "";
            bloqueadoCheckBox.Checked = false;
            intentosDataLabel.Text = "";
            ultimoDataLabel.Text = "";
            for(int i = 0; i < perfilesListBox.Items.Count; i++)
            { perfilesListBox.SetItemChecked(i, false); }
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(UsuarioDto))
            {
                //Registrar el Log
                MessageBox.Show(
                    "No fue posible obtener el registro solicitado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } else
            {
                UsuarioDto u = (UsuarioDto)model;
                idDataLabel.Text = u.ID > 0? u.ID.ToString() : "";
                usernameTextBox.Text = u.Username;
                nombreTextBox.Text = u.Nombre;
                bloqueadoCheckBox.Checked = u.Bloqueado;
                intentosDataLabel.Text = u.IntentosFallidos.ToString();
                ultimoDataLabel.Text = u.UltimoIngreso == new DateTime()? "" : u.UltimoIngreso.ToShortDateString() + " " + u.UltimoIngreso.ToShortTimeString();
                perfilesListBox.Items.Clear();
                int i = 0;
                foreach (KeyValuePair<PerfilDto,Boolean> kvp in u.Perfiles)
                {
                    perfilesListBox.Items.Add(kvp.Key);
                    perfilesListBox.SetItemChecked(i++,kvp.Value);
                }
            }
        }

        /************************ EventListenners **************************/
        private void nombreTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(nombreTextBox, 128, e); }
        private void nombreTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(nombreTextBox); }

        private void usernameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(usernameTextBox, 32, e); }
        private void usernameTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(usernameTextBox); }

        private void passwordTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(idDataLabel.Text))
                ValidatingTextBox(passwordTextBox, 64, e);
            else
                e.Cancel = false;
        }
        private void passwordTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(passwordTextBox); }

        private void confirmaTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!passwordTextBox.Text.Equals(confirmaTextBox.Text))
            {
                e.Cancel = true;
                confirmaTextBox.Select(0, confirmaTextBox.Text.Length);
                passwordTextBox.BackColor = System.Drawing.Color.Pink;
                confirmaTextBox.BackColor = System.Drawing.Color.Pink;
                _errorProvider.SetError(confirmaTextBox, "La contraseña y su confirmación no coinciden");
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(confirmaTextBox, "");
            }
        }
        private void confirmaTextBox_Validated(object sender, EventArgs e)
        {
            ValidatedTextBox(confirmaTextBox);
            ValidatedTextBox(passwordTextBox);
        }


        private void ValidatingTextBox(TextBox textBox, int maxLength, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox.Text.Length > maxLength || textBox.Text.Length == 0)
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                textBox.BackColor = System.Drawing.Color.Pink;
                _errorProvider.SetError(textBox, "Campo obligatorio. Debe contener menos de " + maxLength + " caracteres.");
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(textBox, "");
            }
        }

        private void ValidatedTextBox(TextBox textBox)
        {
            textBox.BackColor = SystemColors.Window;
        }

    }
}
