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
    public partial class EstadisticasClienteDisplay : UserControl
    {
        private EstadisticasCliente _e;
        public EstadisticasClienteDisplay()
        {
            InitializeComponent();
        }

        public EstadisticasClienteDisplay(EstadisticasCliente e) : this()
        {
            Fill(e);
        }

        public void Clear()
        {
            Fill(new EstadisticasCliente());
        }

        public void Fill(EstadisticasCliente e)
        {
            _e = e;
            totalNotasDataLabel.Text = _e.NotasTotal.ToString();
            totalPrendasDataLabel.Text = _e.PrendasTotal.ToString();
            totalServiciosDataLabel.Text = _e.ServiciosTotal.ToString();
            totalMontoDataLabel.Text = "$ " + string.Format("{0:0.00}", _e.MontoTotal);
            ultimasNotasDataLabel.Text = _e.NotasPeriodo.ToString();
            ultimasPrendasDataLabel.Text = _e.PrendasPeriodo.ToString();
            ultimosServiciosDataLabel.Text = _e.ServiciosPeriodo.ToString();
            ultimoMontoDataLabel.Text = "$ " + string.Format("{0:0.00}", _e.MontoPeriodo);
        }
    }
}
