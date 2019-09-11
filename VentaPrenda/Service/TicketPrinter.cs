using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.Service
{
    public class TicketPrinter
    {
        public static Font Font = new Font(FontFamily.GenericMonospace.Name, 6);
        public static Font BoldFont = new Font(FontFamily.GenericMonospace.Name, 6, FontStyle.Bold);
        public static Brush Brush = Brushes.Black;
        public static float LineSpacing = 1.25f;
        public static Margins Margins = new Margins(15, 15, 15, 15);
        static private NotaDto Nota;
        
        public static void PrintTicket(NotaDto nota)
        {
            Nota = nota;
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Roll Paper 80mm x 297mm", 333, 1236);
            pd.DefaultPageSettings.Margins = Margins;
            pd.PrintPage += pd_PrintPage;
            pd.Print();
        }

        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            float lineHeight = LineSpacing * Font.GetHeight(ev.Graphics);
            float yPos = topMargin;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;


            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            ev.Graphics.DrawString("__________________________________________________________", Font,Brush,leftMargin,yPos,format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Nota: " + Nota.ID, Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Cliente: " + Nota.Cliente.Nombre, Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight / 2;
            ev.Graphics.DrawString("__________________________________________________________", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Cant. Item                             $/Unit  Desc. Subt.", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;

            decimal total = 0;
            decimal descuentos = 0;
            foreach(PrendaItemDto p in Nota.Prendas)
            {
                ev.Graphics.DrawString(p.Cantidad.ToString().PadLeft(3).PadRight(4) + p.Prenda.Nombre.ToUpper() + " " + p.Color.Nombre.ToUpper() + " " + (p.TipoPrenda != null? p.TipoPrenda.Nombre.ToUpper() : ""), BoldFont, Brush, leftMargin, yPos, format);
                yPos += lineHeight;
                foreach(ServicioItemDto s in p.Servicios)
                {
                    total += p.Cantidad * s.Monto;
                    descuentos += s.Monto / s.Cantidad - s.Servicio.Costo;
                    ev.Graphics.DrawString(s.Cantidad.ToString().PadLeft(3).PadRight(4) 
                        + s.Servicio.Nombre.Substring(0,Math.Min(s.Servicio.Nombre.Length,32)).PadRight(33) 
                        + String.Format("{0:0.00}", s.Servicio.Costo).PadLeft(7) 
                        + String.Format("{0:0.00}", s.Monto / s.Cantidad - s.Servicio.Costo).PadLeft(7) 
                        + String.Format("{0:0.00}", s.Monto / s.Cantidad).PadLeft(7), 
                        Font, Brush, leftMargin, yPos, format);
                    yPos += lineHeight;
                }
            }
            ev.Graphics.DrawString("__________________________________________________________", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Subtotal".PadRight(48) + "$ " + string.Format("{0:0.00}",total).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            descuentos = Nota.Descuento != null ? total / Nota.Descuento.Porcentaje : 0M;
            ev.Graphics.DrawString("Descuento adicional".PadRight(48) + "$ " + string.Format("{0:0.00}", descuentos).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight / 2;
            ev.Graphics.DrawString("__________________________________________________________", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            total = total - descuentos;
            ev.Graphics.DrawString("Total a pagar".PadRight(48) + "$ " + string.Format("{0:0.00}", total).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            decimal aCuenta = Nota.Pagos.Sum((p) => p.Monto);
            ev.Graphics.DrawString("A cuenta".PadRight(48) + "$ " + string.Format("{0:0.00}", aCuenta).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Por pagar".PadRight(48) + "$ " + string.Format("{0:0.00}", total - aCuenta).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += 2 * lineHeight;
            ev.Graphics.DrawString("Entrega: " + Nota.Entregado.ToLongDateString(), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Lo atendió: ", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("__________________________________________________________", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;

            //ev.Graphics.DrawLine(SystemPens.ControlDark, ev.MarginBounds.X + ev.MarginBounds.Width, topMargin, ev.MarginBounds.X + ev.MarginBounds.Width, ev.MarginBounds.Height);
            ev.Graphics.DrawLine(SystemPens.ControlDark, ev.PageBounds.Width, topMargin, ev.PageBounds.Width, ev.MarginBounds.Height);
        }
    }
}
