using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using VentaPrenda.DAO;
using VentaPrenda.DTO;
using VentaPrenda.Model;

namespace VentaPrenda.Service
{
    public class TicketPrinter
    {

        public static Font Font = new Font(FontFamily.GenericMonospace.Name, 6);
        public static Font BoldFont = new Font(FontFamily.GenericMonospace.Name, 6, FontStyle.Bold);
        public static Brush Brush = Brushes.Black;
        public static Pen Pen = SystemPens.WindowText;
        public static float LineSpacing = 1.25f;
        public static Margins Margins = new Margins(1, 1, 1, 1);
        public static StringFormat Format = new StringFormat();
        public static readonly int PAGE_WIDTH = 400;
        public static readonly int AVAILABLE_WIDTH = 400;

        public static TicketConfigDto Config;
        private static PrintDocument PrintDocument = new PrintDocument();

        private static NotaDto Nota;
        private static Usuario Usuario;
        
        public static void PrintTicket(NotaDto nota, Usuario usuario)
        {
            Nota = nota;
            Usuario = usuario;
            Config = DaoManager.TicketConfigDao.GetConfig();

            PrintDocument.DefaultPageSettings.PaperSize = new PaperSize("Roll Paper 80mm x 297mm", PAGE_WIDTH, 1236);
            PrintDocument.DefaultPageSettings.Margins = Margins;
            if( ! String.IsNullOrEmpty(Config.PrinterName))
            { PrintDocument.PrinterSettings.PrinterName = Config.PrinterName; }
            PrintDocument.PrintPage += pd_PrintPage;
            PrintDocument.Print();
        }

        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float rightMargin = ev.MarginBounds.Right;
            float topMargin = ev.MarginBounds.Top;
            float center = ev.PageBounds.Width / 2; 
            float lineHeight = LineSpacing * Font.GetHeight(ev.Graphics);
            float yPos = topMargin;
            StringBuilder sb = new StringBuilder();

            /*****************************************************************
             * Logo
             ****************************************************************/
            if (Config.Logo != null)
            {
                ev.Graphics.DrawImage(Config.Logo, new RectangleF(
                    new PointF(center - Config.Logo.Width/2, yPos), 
                    new SizeF(Config.Logo.Width,Config.Logo.Height)
                    ));
                yPos += Config.Logo.Height + (float)0.5 * lineHeight;
            }

            /*****************************************************************
             * Encabezado
             ****************************************************************/
            
            yPos += DrawString(Config.Encabezado, yPos, StringAlignment.Center, ev);
            
            /*****************************************************************
             * Datos
             ****************************************************************/

            ev.Graphics.DrawLine(Pen, new PointF(leftMargin, yPos), new PointF(rightMargin, yPos));
            yPos += lineHeight / 2;

            yPos += DrawString(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), yPos, StringAlignment.Center, ev);
            yPos += DrawString("Nota: " + Nota.ID, yPos, StringAlignment.Near, ev);
            yPos += DrawString("Cliente: " + Nota.Cliente.Nombre, yPos, StringAlignment.Near, ev);

            ev.Graphics.DrawLine(Pen, new PointF(leftMargin, yPos), new PointF(rightMargin, yPos));
            yPos += lineHeight;

            yPos += DrawString("Cant. Item".PadRight(20) + " $Unit   +/-   Subt.", yPos, StringAlignment.Near, ev);

            /*****************************************************************
             * Listado
             ****************************************************************/
            decimal total = 0;
            decimal descuentos = 0;
            foreach (PrendaItemDto p in Nota.Prendas)
            {
                yPos += DrawString(p.Cantidad.ToString().PadLeft(2) + " " + p.Prenda.Nombre.ToUpper() + " " + p.Color.Nombre.ToUpper() + " " + (p.TipoPrenda != null ? p.TipoPrenda.Nombre.ToUpper() : ""), 
                    yPos, StringAlignment.Near, ev);
                foreach (ServicioItemDto s in p.Servicios)
                {
                    total += p.Cantidad * s.Monto;
                    descuentos += s.Monto / s.Cantidad - s.Servicio.Costo;
                    yPos += DrawString(s.Cantidad.ToString().PadLeft(2) + " "
                        + s.Servicio.Nombre.Substring(0, Math.Min(s.Servicio.Nombre.Length, 15)).PadRight(16)
                        + String.Format("{0:0.00}", s.Servicio.Costo).PadLeft(7)
                        + String.Format("{0:0.00}", s.Monto / s.Cantidad - s.Servicio.Costo).PadLeft(7)
                        + String.Format("{0:0.00}", s.Monto / s.Cantidad).PadLeft(7),
                        yPos, StringAlignment.Near, ev);
                }
            }
            /*****************************************************************
             * Cuenta
             ****************************************************************/
            ev.Graphics.DrawLine(Pen, new PointF(leftMargin, yPos), new PointF(rightMargin, yPos));
            yPos += lineHeight / 2;
            
            yPos += DrawString("Subtotal".PadRight(31) + "$" + string.Format("{0:0.00}", total).PadLeft(8), 
                yPos, StringAlignment.Near, ev);
            descuentos = Nota.Descuento != null ? total / Nota.Descuento.Porcentaje : 0M;
            yPos += DrawString("Descuento adicional".PadRight(31) + "$" + string.Format("{0:0.00}", descuentos).PadLeft(8), 
                yPos, StringAlignment.Near, ev);

            ev.Graphics.DrawLine(Pen, new PointF(leftMargin, yPos), new PointF(rightMargin, yPos));
            yPos += lineHeight / 2;

            total = total - descuentos;
            yPos += DrawString("Total a pagar".PadRight(31) + "$" + string.Format("{0:0.00}", total).PadLeft(8), 
                yPos, StringAlignment.Near, ev);

            decimal aCuenta = Nota.Pagos.Sum((p) => p.Monto);
            yPos += DrawString("A cuenta".PadRight(31) + "$" + string.Format("{0:0.00}", aCuenta).PadLeft(8), 
                yPos, StringAlignment.Near, ev);
            yPos += DrawString("Por pagar".PadRight(31) + "$" + string.Format("{0:0.00}", total - aCuenta).PadLeft(8) + "\n", 
                yPos, StringAlignment.Near, ev);
            yPos += DrawString("Entrega: " + Nota.Entregado.ToLongDateString().PadLeft(31), 
                yPos, StringAlignment.Near, ev);
            yPos += DrawString("Lo atendio: " + Usuario.Nombre.PadLeft(28), 
                yPos, StringAlignment.Near, ev);

            yPos += DrawString("Observaciones: "
                + (String.IsNullOrEmpty(Nota.Observaciones) ? "Ninguna" : Nota.Observaciones),
                yPos, StringAlignment.Near, ev);

            ev.Graphics.DrawLine(Pen, new PointF(leftMargin, yPos), new PointF(rightMargin, yPos));
            yPos += lineHeight;

            /*****************************************************************
             * Pie
             ****************************************************************/

            yPos += DrawString(Config.Pie, yPos, StringAlignment.Center, ev);
            
            /*****************************************************************
             * Ajustar tamaño de página
             * **************************************************************/
            PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom Roll Paper 80mm", PAGE_WIDTH, (int)(yPos + topMargin)/2);
            PrintDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom Roll Paper 80mm", PAGE_WIDTH, (int)(yPos + topMargin)/2);

            //ev.Graphics.DrawLine(Pen, ev.PageBounds.Width, topMargin, ev.PageBounds.Width, (int)(yPos + topMargin));
        }

        private static float DrawString(string str, float yPos, StringAlignment align, PrintPageEventArgs ev)
        {
            Format.Alignment = StringAlignment.Near;
            float dy = 0;
            foreach (string line in str.Split(new char[] { '\n' }))
            {
                string remaining = line;
                do
                {
                    int charsInLine = String.IsNullOrWhiteSpace(remaining) ? 0 : Math.Min(remaining[Math.Min(40, remaining.Length - 1)] == '\r' ? 41 : 40, remaining.Length);
                    string s = remaining.Substring(0, charsInLine);
                    if (align == StringAlignment.Center)
                    {
                        s = s.PadLeft((int)(20 + s.Length / 2));
                    }
                    s += "\n\n";
                    SizeF stringSize = ev.Graphics.MeasureString(s, Font, new SizeF(AVAILABLE_WIDTH, 0), Format);
                    RectangleF rectf = new RectangleF(new PointF(0, yPos + dy), new SizeF(AVAILABLE_WIDTH, stringSize.Height));
                    ev.Graphics.DrawString(s, Font, Brush, rectf, Format);
                    dy += stringSize.Height;
                    remaining = remaining.Length > charsInLine? 
                        remaining.Substring(charsInLine).TrimStart(new char[] { ' ' }) 
                        : String.Empty;
                } while (remaining.Length > 0);
                
            }
            return dy;
        }
    }
}
