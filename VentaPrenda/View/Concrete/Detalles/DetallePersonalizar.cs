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
        public override void Fill(object model)
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
            fondoVentanaButton.BackColor = _dto.FondoVentana;
            fondoBotonButton.BackColor = _dto.FondoBoton;
            fondoBotonActivoButton.BackColor = _dto.FondoBotonActivo;
            canceladoButton.BackColor = _dto.Cancelado;
            pendienteButton.BackColor = _dto.Pendiente;
            entregadoButton.BackColor = _dto.Entregado;
            terminadoButton.BackColor = _dto.Terminado;
            caducadoButton.BackColor = _dto.Caducado;
            fondoListaButton.BackColor = _dto.FondoLista;
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
            ActualizarColores();
        }

        private void CanceladoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Cancelado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Cancelado= colorDialog.Color; }
            ActualizarColores();
        }

        private void PedienteButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Pendiente;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Pendiente = colorDialog.Color; }
            ActualizarColores();
        }

        private void TerminadoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Terminado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Terminado = colorDialog.Color; }
            ActualizarColores();
        }

        private void EntregadoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Entregado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Entregado = colorDialog.Color; }
            ActualizarColores();
        }

        private void CaducadoButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = _dto.Caducado;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            { _dto.Caducado = colorDialog.Color; }
            ActualizarColores();
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
            ActualizarColores();
        }
    }
}
