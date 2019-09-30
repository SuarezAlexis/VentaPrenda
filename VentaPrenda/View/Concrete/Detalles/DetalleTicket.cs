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
using System.Drawing.Printing;

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetalleTicket : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private TicketConfigDto _dto;

        public override object Dto
        {
            get
            {
                _dto.PrinterName = printerNameComboBox.SelectedItem != null? (String)printerNameComboBox.SelectedItem : null;
                _dto.PrinterName = String.IsNullOrEmpty(_dto.PrinterName) ? null : _dto.PrinterName;
                _dto.Encabezado = encabezadoTextBox.Text;
                _dto.Pie = pieTextBox.Text;
                return _dto;
            }
            set
            {
                if (value != null && (value is TicketConfigDto))
                    _dto = (TicketConfigDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleTicket porque no es del tipo correcto.");
            }
        }


        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleTicket()
        {
            InitializeComponent();
            _dto = new TicketConfigDto();
            printerNameComboBox.Items.Add("");
            foreach (string p in PrinterSettings.InstalledPrinters)
            { printerNameComboBox.Items.Add(p); }
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public override void Clear()
        {
            printerNameComboBox.SelectedItem = null;
            encabezadoTextBox.Text = "";
            pieTextBox.Text = "";
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(TicketConfigDto))
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
                TicketConfigDto t = (TicketConfigDto)model;
                Visible = false;
                printerNameComboBox.SelectedItem = t.PrinterName;
                encabezadoTextBox.Text = t.Encabezado;
                pieTextBox.Text = t.Pie;
                Visible = true;
            }
        }
    }
}