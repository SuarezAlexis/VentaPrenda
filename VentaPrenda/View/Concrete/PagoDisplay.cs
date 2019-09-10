using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DTO;

namespace VentaPrenda.View.Concrete
{
    public partial class PagoDisplay : UserControl
    {
        private bool _readOnly;
        public PagoDto Dto;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                editButton.Enabled = !value;
                deleteButton.Enabled = !value;
            }
        }

        public event EventHandler Edit;
        public event EventHandler Delete;
        public PagoDisplay()
        { InitializeComponent(); }

        public PagoDisplay(PagoDto p) : this()
        { Update(p); }

        internal void Update(PagoDto dto)
        {
            Dto = dto;
            fechaLabel.Text = dto.Fecha.ToShortDateString() + " " + dto.Fecha.ToShortTimeString();
            metodoLabel.Text = dto.Metodo.ToString();
            montoLabel.Text = "$ " + string.Format("{0:0.00}", dto.Monto);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        { Delete?.Invoke(this, EventArgs.Empty); }

        private void EditButton_Click(object sender, EventArgs e)
        { Edit?.Invoke(this,EventArgs.Empty); }
    }
}
