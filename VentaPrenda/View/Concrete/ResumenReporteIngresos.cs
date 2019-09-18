using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaPrenda.View.Concrete
{
    public partial class ResumenReporteIngresos : UserControl
    {
        public string Notas
        {
            get { return notasDataLabel.Text; }
            set { notasDataLabel.Text = value; }
        }
        public string Prendas
        {
            get { return prendasDataLabel.Text; }
            set { prendasDataLabel.Text = value; }
        }

        public string Servicios
        {
            get { return serviciosDataLabel.Text; }
            set { serviciosDataLabel.Text = value; }
        }

        public string Monto
        {
            get { return montoDataLabel.Text; }
            set { montoDataLabel.Text = value; }
        }

        public string Descuento
        {
            get { return descuentoDataLabel.Text; }
            set { descuentoDataLabel.Text = value; }
        }

        public string VentaNeta
        {
            get { return ventaNetaDataLabel.Text; }
            set { ventaNetaDataLabel.Text = value; }
        }

        public string Efectivo
        {
            get { return efectivoDataLabel.Text; }
            set { efectivoDataLabel.Text = value; }
        }

        public string Tarjeta
        {
            get { return tarjetaDataLabel.Text; }
            set { tarjetaDataLabel.Text = value; }
        }

        public string TotalIngresos
        {
            get { return totalIngresosDataLabel.Text; }
            set { totalIngresosDataLabel.Text = value; }
        }

        public string PorCobrar
        {
            get { return porCobrarDataLabel.Text; }
            set { porCobrarDataLabel.Text = value; }
        }

        public ResumenReporteIngresos()
        {
            Visible = false;
            InitializeComponent();
            Visible = true;
        }
    }
}
