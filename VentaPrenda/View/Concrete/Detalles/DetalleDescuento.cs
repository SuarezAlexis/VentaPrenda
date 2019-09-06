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
    enum ConsumoMinimo
    {
        Servicios,
        MXN
    }

    enum Descuento
    {
        Servicios,
        Porcentaje
    }
    public partial class DetalleDescuento : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private DescuentoDto _dto;
        private ErrorProvider _errorProvider;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                nombreTextBox.ReadOnly = value;
                inicioVigenciaDateTimePicker.Enabled = !value;
                finVigenciaDateTimePicker.Enabled = !value;
                consMinNumUpDown.ReadOnly = value;
                consMinDomainUpDown.ReadOnly = value;
                vigenciaRadioButton.Enabled = !value;
                soloNotaRadioButton.Enabled = !value;
                descuentoNumUpDown.ReadOnly = value;
                descuentoDomainUpDown.ReadOnly = value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0 ? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Nombre = nombreTextBox.Text;
                _dto.VigenciaInicio = inicioVigenciaDateTimePicker.Value;
                _dto.VigenciaFin = finVigenciaDateTimePicker.Value;
                if(consMinDomainUpDown.Text.Equals("Servicios"))
                {
                    _dto.CantMinima = consMinNumUpDown.Value;
                    _dto.MontoMinimo = -1;
                } else
                {
                    _dto.MontoMinimo = consMinNumUpDown.Value;
                    _dto.CantMinima = -1;
                }
                _dto.SoloNota = soloNotaRadioButton.Checked;
                if(descuentoDomainUpDown.Text.Equals("% de nota"))
                {
                    _dto.Porcentaje = descuentoNumUpDown.Value;
                    _dto.Unidades = -1;
                } else
                {
                    _dto.Unidades = descuentoNumUpDown.Value;
                    _dto.Porcentaje = -1;
                }
                return _dto;
            }
            set
            {
                if (value != null && (value is DescuentoDto))
                    _dto = (DescuentoDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleDescuento porque no es del tipo correcto.");
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleDescuento()
        {
            InitializeComponent();
            _dto = new DescuentoDto();
        }

        public DetalleDescuento(ErrorProvider e) : this()
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
            inicioVigenciaDateTimePicker.Value = DateTime.Now;
            finVigenciaDateTimePicker.Value = DateTime.Now;
            consMinNumUpDown.Value = 0;
            consMinDomainUpDown.ResetText();
            soloNotaRadioButton.Checked = false;
            vigenciaRadioButton.Checked = true;
            descuentoNumUpDown.Value = 0;
            descuentoNumUpDown.ResetText();
            
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(DescuentoDto))
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
                DescuentoDto d = (DescuentoDto)model;
                idDataLabel.Text = d.ID > 0 ? d.ID.ToString() : "";
                nombreTextBox.Text = d.Nombre;
                inicioVigenciaDateTimePicker.Value = d.VigenciaInicio;
                finVigenciaDateTimePicker.Value = d.VigenciaFin;
                if(d.MontoMinimo < 0)
                {
                    consMinDomainUpDown.Text = "Servicios";
                    //ConsMinDomainUpDown_SelectedItemChanged(null, null);
                    consMinNumUpDown.Value = d.CantMinima;
                } else
                {
                    consMinDomainUpDown.Text = "MXN";
                    //ConsMinDomainUpDown_SelectedItemChanged(null, null);
                    consMinNumUpDown.Value = d.MontoMinimo;
                }
                vigenciaRadioButton.Checked = !d.SoloNota;
                soloNotaRadioButton.Checked = d.SoloNota;
                if(d.Porcentaje < 0)
                {
                    descuentoDomainUpDown.Text = "Servicios";
                    //DescuentoDomainUpDown_SelectedItemChanged(null, null);
                    descuentoNumUpDown.Value = d.Unidades;
                } else
                {
                    descuentoDomainUpDown.Text = "% de nota";
                    //DescuentoDomainUpDown_SelectedItemChanged(null, null);
                    descuentoNumUpDown.Value = d.Porcentaje;
                }
            }
        }

        /************************ EventListenners **************************/
        private void conceptoTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(nombreTextBox, 32, e, _errorProvider); }
        private void conceptoTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(nombreTextBox); }

        private void ConsMinDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            switch(consMinDomainUpDown.Text)
            {
                case "Servicios":
                    consMinNumUpDown.Maximum = 99;
                    consMinNumUpDown.DecimalPlaces = 0;
                    break;
                case "MXN":
                    consMinNumUpDown.Maximum = 999999.99M;
                    consMinNumUpDown.DecimalPlaces = 2;
                    break;
            }
        }

        private void DescuentoDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (descuentoDomainUpDown.Text)
            {
                case "Servicios":
                    descuentoNumUpDown.Maximum = 99.99M;
                    descuentoNumUpDown.DecimalPlaces = 2;
                    descuentoNumUpDown.Increment = 0.5M;
                    break;
                case "% de nota":
                    descuentoNumUpDown.Maximum = 100;
                    descuentoNumUpDown.DecimalPlaces = 0;
                    descuentoNumUpDown.Increment = 1;
                    break;
            }
        }

        private void InicioVigenciaDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if(inicioVigenciaDateTimePicker.Value > finVigenciaDateTimePicker.Value)
            {
                e.Cancel = true;
                inicioVigenciaDateTimePicker.BackColor = System.Drawing.Color.Pink;
                _errorProvider.SetError(inicioVigenciaDateTimePicker,"El inicio de la vigencia debe ser anterior al fin de la vigencia.");
            } else
            {
                e.Cancel = false;
                _errorProvider.SetError(inicioVigenciaDateTimePicker, "");
            }
        }

        private void InicioVigenciaDateTimePicker_Validated(object sender, EventArgs e)
        { inicioVigenciaDateTimePicker.BackColor = SystemColors.Window; }

        private void FinVigenciaDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (finVigenciaDateTimePicker.Value < finVigenciaDateTimePicker.Value)
            {
                e.Cancel = true;
                finVigenciaDateTimePicker.BackColor = System.Drawing.Color.Pink;
                _errorProvider.SetError(finVigenciaDateTimePicker, "El fin de la vigencia debe ser posterior al inicio de la vigencia.");
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(finVigenciaDateTimePicker, "");
            }
        }

        private void FinVigenciaDateTimePicker_Validated(object sender, EventArgs e)
        { finVigenciaDateTimePicker.BackColor = SystemColors.Window; }

        private void VigenciaRadioButton_Click(object sender, EventArgs e)
        {
            vigenciaRadioButton.Checked = !vigenciaRadioButton.Checked;
            soloNotaRadioButton.Checked = !soloNotaRadioButton.Checked;
        }

        private void SoloNotaRadioButton_Click(object sender, EventArgs e)
        {
            vigenciaRadioButton.Checked = !vigenciaRadioButton.Checked;
            soloNotaRadioButton.Checked = !soloNotaRadioButton.Checked;
        }
    }
}
