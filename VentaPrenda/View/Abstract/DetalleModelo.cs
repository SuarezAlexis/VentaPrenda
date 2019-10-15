using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DTO;

namespace VentaPrenda.View.Abstract
{
    public class DetalleModelo : UserControl
    {
        public virtual bool ReadOnly { get; set; }
        public virtual object Dto { get; set; }
        public virtual ColoresGUIDto Colores { get; set; }
        public virtual void Clear() { }
        public virtual void Fill(Object model) { }
        protected static void ValidatingTextBox(TextBox textBox, int maxLength, System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider)
        {
            if (textBox.Text.Length > maxLength || textBox.Text.Length == 0)
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                textBox.BackColor = Color.Pink;
                errorProvider.SetError(textBox, "Campo obligatorio. Debe contener menos de " + maxLength + " caracteres.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, "");
            }
        }

        protected void ValidatedTextBox(TextBox textBox)
        { textBox.BackColor = SystemColors.Window; }
    }
}
