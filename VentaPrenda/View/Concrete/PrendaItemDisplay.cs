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
    public partial class PrendaItemDisplay : UserControl
    {
        private bool _readOnly = false;
        public decimal Total;
        public int Servicios;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public PrendaItemDto Dto;
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

        public PrendaItemDisplay()
        { InitializeComponent(); }
        
        public PrendaItemDisplay(PrendaItemDto Dto) : this()
        { Update(Dto); }

        public void Update(PrendaItemDto Dto)
        {
            this.Dto = Dto;
            decimal prendaUnitario = 0;
            decimal prendaDescuento = 0;
            Servicios = 0;
            prendaLabel.Text = Dto.Cantidad + " " + Dto.Prenda + " " + Dto.Color + " " + Dto.TipoPrenda;
            serviciosLabel.Text = "";
            servicioUnitarioLabel.Text = "";
            servicioDescuentoLabel.Text = "";
            servicioSubtotalLabel.Text = "";
            servicioTotalLabel.Text = "";
            Height = 40;
            foreach (ServicioItemDto s in Dto.Servicios)
            {
                decimal subtotal = s.Monto / s.Cantidad;
                decimal descuento = subtotal - s.Servicio.Costo;
                serviciosLabel.Text += s.Cantidad + " " + s.Servicio + "\n";
                servicioUnitarioLabel.Text += string.Format("{0:0.00}", s.Servicio.Costo) + "\n";
                servicioDescuentoLabel.Text += string.Format("{0:0.00}", descuento) + "\n";
                servicioSubtotalLabel.Text += string.Format("{0:0.00}", subtotal) + "\n";
                servicioTotalLabel.Text += string.Format("{0:0.00}", s.Monto) + "\n";
                prendaUnitario += s.Servicio.Costo*s.Cantidad;
                prendaDescuento += descuento * s.Cantidad;
                Servicios += s.Cantidad;
                Height += serviciosLabel.Font.Height;
            }
            decimal prendaSubtotal = prendaUnitario + prendaDescuento;
            prendaUnitarioLabel.Text = string.Format("{0:0.00}", prendaUnitario);
            prendaDescuentoLabel.Text = string.Format("{0:0.00}", prendaDescuento);
            prendaSubtotalLabel.Text = string.Format("{0:0.00}", prendaSubtotal);
            prendaTotalLabel.Text = string.Format("{0:0.00}", Total = prendaSubtotal * Dto.Cantidad);
            Servicios *= Dto.Cantidad;
        }

        public void OnDelete()
        { Delete?.Invoke(this,EventArgs.Empty); }

        public void OnEdit()
        { Edit?.Invoke(this, EventArgs.Empty); }

        private void EditButton_Click(object sender, EventArgs e)
        { OnEdit(); }

        private void DeleteButton_Click(object sender, EventArgs e)
        { OnDelete(); }
    }
}
