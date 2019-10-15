using System.Drawing;

namespace VentaPrenda.DTO
{
    public class ColoresGUIDto
    {
        public Color FondoVentana { get; set; }
        public Color FondoBoton { get; set; }
        public Color FondoBotonActivo { get; set; }
        public Color FondoLista { get; set; }
        public Color Cancelado { get; set; }
        public Color Pendiente { get; set; }
        public Color Terminado { get; set; }
        public Color Entregado { get; set; }
        public Color Caducado { get; set; }

        public ColoresGUIDto()
        {
            FondoVentana = SystemColors.Control;
            FondoBoton = SystemColors.ControlLight;
            FondoBotonActivo = SystemColors.ControlDark;
            FondoLista = SystemColors.AppWorkspace;
            Cancelado = Color.Pink;
            Pendiente = Color.LightYellow;
            Terminado = Color.LightCyan;
            Entregado = Color.Honeydew;
            Caducado = Color.Thistle;
        }
    }
}
