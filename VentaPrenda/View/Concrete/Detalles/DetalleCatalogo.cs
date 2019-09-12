using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.View.Abstract;
using VentaPrenda.DTO;

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetalleCatalogo : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private CatalogoDto _dto;
        private ErrorProvider _errorProvider;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                nombreTextBox.ReadOnly = value;
                habilitadoCheckBox.Enabled = !value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0 ? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Nombre = nombreTextBox.Text;
                _dto.Habilitado = habilitadoCheckBox.Checked;
                return _dto;
            }
            set
            {
                if (value != null && (value is CatalogoDto))
                    _dto = (CatalogoDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleCatalogo porque no es del tipo correcto.");
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleCatalogo()
        {
            InitializeComponent();
            _dto = new CatalogoDto();
        }

        public DetalleCatalogo(ErrorProvider e) : this()
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
            habilitadoCheckBox.Checked = false;
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(CatalogoDto))
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
                CatalogoDto c = (CatalogoDto)model;
                Visible = false;
                idDataLabel.Text = c.ID > 0 ? c.ID.ToString() : "";
                nombreTextBox.Text = c.Nombre;
                habilitadoCheckBox.Checked = c.Habilitado;
                Visible = true;
            }
        }

        /************************ EventListenners **************************/
        private void nombreTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(nombreTextBox, 32, e, _errorProvider); }
        private void nombreTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(nombreTextBox); }
    }
}
