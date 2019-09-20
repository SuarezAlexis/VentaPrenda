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
    public partial class DetalleServicio : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private ServicioDto _dto;
        private ErrorProvider _errorProvider;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                nombreTextBox.ReadOnly = value;
                descripcionTextBox.ReadOnly = value;
                costoNumUpDown.ReadOnly = value;
                habilitadoCheckBox.Enabled = !value;
                prendasCheckedListBox.Enabled = !value;
                seleccionarTodoButton.Enabled = !value;
                limpiarSeleccionButton.Enabled = !value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0 ? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Nombre = nombreTextBox.Text;
                _dto.Costo = costoNumUpDown.Value;
                _dto.Descripcion = descripcionTextBox.Text;
                _dto.Habilitado = habilitadoCheckBox.Checked;
                _dto.Prendas.Clear();
                foreach(CatalogoDto p in prendasCheckedListBox.CheckedItems)
                { _dto.Prendas.Add(p); }
                return _dto;
            }
            set
            {
                if (value != null && (value is ServicioDto))
                    _dto = (ServicioDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleServicio porque no es del tipo correcto.");
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleServicio()
        {
            InitializeComponent();
            _dto = new ServicioDto();
            foreach(CatalogoDto p in PrendaItemDto.Prendas)
            { prendasCheckedListBox.Items.Add(p); }
        }

        public DetalleServicio(ErrorProvider e) : this()
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
            descripcionTextBox.Text = "";
            costoNumUpDown.Value = 0;
            habilitadoCheckBox.Checked = true;
            SeleccionarTodasLasPrendas(false);
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(ServicioDto))
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
                ServicioDto s = (ServicioDto)model;
                Visible = false;
                idDataLabel.Text = s.ID > 0 ? s.ID.ToString() : "";
                nombreTextBox.Text = s.Nombre;
                costoNumUpDown.Value = s.Costo;
                descripcionTextBox.Text = s.Descripcion;
                habilitadoCheckBox.Checked = s.Habilitado;
                for(int i = 0; i < prendasCheckedListBox.Items.Count; i++)
                { prendasCheckedListBox.SetItemChecked(i, s.Prendas.Contains(prendasCheckedListBox.Items[i])); }
                Visible = true;
            }
        }

        private void SeleccionarTodasLasPrendas(bool s)
        {
            for (int i = 0; i < prendasCheckedListBox.Items.Count; i++)
            { prendasCheckedListBox.SetItemChecked(i, s); }
        }

        /************************ EventListenners **************************/
        private void nombreTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(nombreTextBox, 64, e, _errorProvider); }
        private void nombreTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(nombreTextBox); }

        private void SeleccionarTodoButton_Click(object sender, EventArgs e)
        { SeleccionarTodasLasPrendas(true); }

        private void LimpiarSeleccionButton_Click(object sender, EventArgs e)
        { SeleccionarTodasLasPrendas(false); }
    }
}
