using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.View.Concrete
{
    public partial class NuevoPago : Form
    {
        private PagoDto _dto;
        private ColoresGUIDto _colores;
        public PagoDto Dto
        {
            get
            {
                _dto.ID = string.IsNullOrEmpty(idDataLabel.Text) ? -1 : Convert.ToInt32(idDataLabel.Text);
                _dto.Nota = _dto.Nota;
                _dto.Fecha = string.IsNullOrEmpty(fechaDataLabel.Text)? DateTime.Now : Convert.ToDateTime(fechaDataLabel.Text);
                _dto.Metodo = (MetodoPago)metodoDomUpDown.SelectedItem;
                _dto.Monto = montoNumUpDown.Value;
                return _dto;
            }
            set
            {
                _dto = value;
                idDataLabel.Text = value.ID < 0? "" : value.ID.ToString();
                notaDataLabel.Text = value.Nota != null && value.Nota.ID >= 0? value.Nota.ID.ToString() : "";
                fechaDataLabel.Text = value.Fecha.ToShortDateString() + " " + value.Fecha.ToShortTimeString();
                metodoDomUpDown.SelectedItem = value.Metodo;
                montoNumUpDown.Value = value.Monto;
            }
        }

        public ColoresGUIDto Colores
        {
            get { return _colores; }
            set
            {
                _colores = value;
                aceptarButton.BackColor = _colores.FondoBoton;
                BackColor = _colores.FondoVentana;
            }
        }

        public NuevoPago()
        {
            InitializeComponent();
            foreach(MetodoPago m in Enum.GetValues(typeof(MetodoPago)))
            { metodoDomUpDown.Items.Add(m); }
            Dto = new PagoDto();
        }

        public NuevoPago(PagoDto pago) : this()
        { Dto = pago;  }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
