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
    public partial class DetalleReporte : DetalleModelo
    {
        private ReporteDto _dto;
        private ErrorProvider _errorProvider;
        public override object Dto
        {
            get
            {
                _dto.Desde = desdePicker.Value;
                _dto.Hasta = hastaPicker.Value;
                _dto.Tipo = (TipoReporte)tipoReporteComboBox.SelectedItem;
                return _dto;
            }
            set
            {
                _dto = (ReporteDto)value;
            }
        }

        public DetalleReporte()
        {
            InitializeComponent();
            _dto = new ReporteDto();
            desdePicker.MaxDate = DateTime.Today;
            desdePicker.Value = DateTime.Today;
            hastaPicker.MaxDate = DateTime.Today;
            hastaPicker.Value = DateTime.Today;
            foreach(TipoReporte tr in Enum.GetValues(typeof(TipoReporte)) )
            { tipoReporteComboBox.Items.Add(tr); }
        }

        public DetalleReporte(ErrorProvider e) : this()
        { _errorProvider = e; }


        private void ObtenerReporteButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            { ((IMainView)ParentForm).Controller.Reporte((ReporteDto)Dto); }
        }

        private void IntervaloCheckBox_CheckedChanged(object sender, EventArgs e)
        { hastaPicker.Enabled = intervaloCheckBox.Checked; }

        private void DesdePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!intervaloCheckBox.Checked)
                hastaPicker.Value = desdePicker.Value;
        }

        private void TipoReporteComboBox_Validating(object sender, CancelEventArgs e)
        {
            if(tipoReporteComboBox.SelectedItem == null)
            {
                e.Cancel = true;
                _errorProvider.SetError(tipoReporteComboBox,"Por favor selecciona un tipo de reporte.");
                tipoReporteComboBox.BackColor = Color.Pink;
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(tipoReporteComboBox,"");
                tipoReporteComboBox.BackColor = SystemColors.Window;
            }
        }

        private void TipoReporteComboBox_Validated(object sender, EventArgs e)
        {
            _errorProvider.SetError(tipoReporteComboBox, "");
            tipoReporteComboBox.BackColor = SystemColors.Window;
        }

        private void TipoReporteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoReporteComboBox_Validating(sender, new CancelEventArgs());
        }
    }
}
