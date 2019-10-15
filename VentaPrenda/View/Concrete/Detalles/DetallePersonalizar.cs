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

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetallePersonalizar : DetalleModelo
    {
        private ColoresGUIDto _dto;
        private IMainView _mainView;
        public override object Dto
        {
            get { return _dto; }
            set
            {
                if (value != null && (value is ColoresGUIDto))
                    _dto = (ColoresGUIDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetallePersonalizar porque no es del tipo correcto.");
            }
        }

        public override ColoresGUIDto Colores
        {
            get { return _dto; }
            set
            {
                _dto = value;
                ActualizarColores();
            }
        }

        public DetallePersonalizar()
        {
            InitializeComponent();
            _dto = new ColoresGUIDto();
        }

        public override void Clear()
        {
            Dto = new ColoresGUIDto();
            ActualizarColores();
            _mainView.SetColors(_dto);
        }
        public void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(ColoresGUIDto))
            {
                //Registrar el Log
                MessageBox.Show(
                    "No fue posible obtener el registro solicitado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ActualizarColores()
        {
            fondoVentanaButton.BackColor = _dto.FondoBoton;
            fondoBotonButton.BackColor = _dto.FondoBoton;
            fondoBotonActivoButton.BackColor = _dto.FondoBoton;
            fondoListaButton.BackColor = _dto.FondoBoton;
            canceladoButton.BackColor = _dto.FondoBoton;
            pendienteButton.BackColor = _dto.FondoBoton;
            terminadoButton.BackColor = _dto.FondoBoton;
            entregadoButton.BackColor = _dto.FondoBoton;
            caducadoButton.BackColor = _dto.FondoBoton;
        }

        private void FondoVentanaButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.FondoVentana;
            DialogResult result = colorDialog.ShowDialog();
            if(result == DialogResult.OK)
            { _dto.FondoVentana = colorDialog.Color; }
            _mainView.SetColors(_dto);
        }

        private void FondoBotonButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.FondoBoton;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.FondoBoton = colorDialog.Color; }
            _mainView.SetColors(_dto);
            ActualizarColores();
        }

        private void FondoBotonActivoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.FondoBotonActivo;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.FondoBotonActivo = colorDialog.Color; }
            _mainView.SetColors(_dto);
        }

        private void CanceladoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Cancelado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Cancelado= colorDialog.Color; }
        }

        private void PedienteButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Pendiente;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Pendiente = colorDialog.Color; }
        }

        private void TerminadoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Terminado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Terminado = colorDialog.Color; }
        }

        private void EntregadoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Entregado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Entregado = colorDialog.Color; }
        }

        private void CaducadoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Caducado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Caducado = colorDialog.Color; }
        }

        private void DetallePersonalizar_ParentChanged(object sender, EventArgs e)
        {
            if(Parent != null)
                _mainView = (IMainView)Parent.Parent.Parent.Parent.Parent;
        }

        private void FondoListaButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.FondoLista;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.FondoLista = colorDialog.Color; }
            _mainView.SetColors(_dto);
        }
    }
}
