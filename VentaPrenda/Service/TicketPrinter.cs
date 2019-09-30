using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
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
        public static Margins Margins = new Margins(15, 15, 15, 15);
        public static TicketConfigDto Config;
        static private NotaDto Nota;
        static private Usuario Usuario;
        
        public static void PrintTicket(NotaDto nota, Usuario usuario)
        {
            Nota = nota;
            Usuario = usuario;
            Config = DaoManager.TicketConfigDao.GetConfig();
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Roll Paper 80mm x 297mm", 333, 1236);
            pd.DefaultPageSettings.Margins = Margins;
            if( ! String.IsNullOrEmpty(Config.PrinterName))
            { pd.PrinterSettings.PrinterName = Config.PrinterName; }
            pd.PrintPage += pd_PrintPage;
            pd.Print();
        }

        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float rightMargin = ev.MarginBounds.Right;
            float topMargin = ev.MarginBounds.Top;
            float center = ev.PageBounds.Width / 2;
            float lineHeight = LineSpacing * Font.GetHeight(ev.Graphics);
            float yPos = topMargin;
            StringFormat format = new StringFormat();

            /*****************************************************************
             * Logo
             ****************************************************************/
            if (Config.Logo != null)
            {
                ev.Graphics.DrawImage(Config.Logo, center - Config.Logo.Width / 2, yPos);
                yPos += Config.Logo.Height + (float)1.5 * lineHeight;
            }

            /*****************************************************************
             * Encabezado
             ****************************************************************/
            format.Alignment = StringAlignment.Center;
            ev.Graphics.DrawString(Config.Encabezado, Font, Brush, center, yPos, format);
            yPos += lineHeight * Config.Encabezado.Split(new char[] { '\n' }).Length;

            /*****************************************************************
             * Datos
             ****************************************************************/
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            ev.Graphics.DrawLine(Pen, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight / 2;
            ev.Graphics.DrawString("Nota: " + Nota.ID, Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Cliente: " + Nota.Cliente.Nombre, Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawLine(Pen, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight;
            ev.Graphics.DrawString("Cant. Item".PadRight(39) + "$/Unit  Desc. Subt.", Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;

            /*****************************************************************
             * Listado
             ****************************************************************/
            decimal total = 0;
            decimal descuentos = 0;
            foreach (PrendaItemDto p in Nota.Prendas)
            {
                ev.Graphics.DrawString(p.Cantidad.ToString().PadLeft(3).PadRight(4) + p.Prenda.Nombre.ToUpper() + " " + p.Color.Nombre.ToUpper() + " " + (p.TipoPrenda != null ? p.TipoPrenda.Nombre.ToUpper() : ""), BoldFont, Brush, leftMargin, yPos, format);
                yPos += lineHeight;
                foreach (ServicioItemDto s in p.Servicios)
                {
                    total += p.Cantidad * s.Monto;
                    descuentos += s.Monto / s.Cantidad - s.Servicio.Costo;
                    ev.Graphics.DrawString(s.Cantidad.ToString().PadLeft(3).PadRight(4)
                        + s.Servicio.Nombre.Substring(0, Math.Min(s.Servicio.Nombre.Length, 32)).PadRight(33)
                        + String.Format("{0:0.00}", s.Servicio.Costo).PadLeft(7)
                        + String.Format("{0:0.00}", s.Monto / s.Cantidad - s.Servicio.Costo).PadLeft(7)
                        + String.Format("{0:0.00}", s.Monto / s.Cantidad).PadLeft(7),
                        Font, Brush, leftMargin, yPos, format);
                    yPos += lineHeight;
                }
            }
            /*****************************************************************
             * Cuenta
             ****************************************************************/
            ev.Graphics.DrawLine(Pen, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight / 2;
            ev.Graphics.DrawString("Subtotal".PadRight(48) + "$ " + string.Format("{0:0.00}", total).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            descuentos = Nota.Descuento != null ? total / Nota.Descuento.Porcentaje : 0M;
            ev.Graphics.DrawString("Descuento adicional".PadRight(48) + "$ " + string.Format("{0:0.00}", descuentos).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;

            ev.Graphics.DrawLine(Pen, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight / 2;
            total = total - descuentos;
            ev.Graphics.DrawString("Total a pagar".PadRight(48) + "$ " + string.Format("{0:0.00}", total).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            decimal aCuenta = Nota.Pagos.Sum((p) => p.Monto);
            ev.Graphics.DrawString("A cuenta".PadRight(48) + "$ " + string.Format("{0:0.00}", aCuenta).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Por pagar".PadRight(48) + "$ " + string.Format("{0:0.00}", total - aCuenta).PadLeft(8), Font, Brush, leftMargin, yPos, format);
            yPos += 2 * lineHeight;
            ev.Graphics.DrawString("Entrega: " + Nota.Entregado.ToLongDateString().PadLeft(49), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            ev.Graphics.DrawString("Lo atendió: " + Usuario.Nombre.PadLeft(46), Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;

            string obs = Nota.Observaciones;
            ev.Graphics.DrawString("Observaciones: "
                + (String.IsNullOrEmpty(obs) ? "Ninguna" : obs.Substring(0, Math.Min(43, obs.Length))),
                Font, Brush, leftMargin, yPos, format);
            yPos += lineHeight;
            obs = obs.Length > 43 ? obs.Substring(43).TrimStart(new char[] { ' ' }) : String.Empty;
            while (obs.Length > 0)
            {
                ev.Graphics.DrawString(obs.Substring(0, Math.Min(58, obs.Length)), Font, Brush, leftMargin, yPos, format);
                yPos += lineHeight;
                obs = obs.Length > 58 ? obs.Substring(58).TrimStart(new char[] { ' ' }) : String.Empty;
            }
            ev.Graphics.DrawLine(Pen, leftMargin, yPos, rightMargin, yPos);
            yPos += lineHeight;

            /*****************************************************************
             * Pie
             ****************************************************************/
            format.Alignment = StringAlignment.Center;
            ev.Graphics.DrawString(Config.Pie, Font, Brush, center, yPos, format);

            //ev.Graphics.DrawLine(SystemPens.ControlDark, ev.MarginBounds.X + ev.MarginBounds.Width, topMargin, ev.MarginBounds.X + ev.MarginBounds.Width, ev.MarginBounds.Height);
            ev.Graphics.DrawLine(Pen, ev.PageBounds.Width, topMargin, ev.PageBounds.Width, ev.MarginBounds.Height);
        }
    }
}
