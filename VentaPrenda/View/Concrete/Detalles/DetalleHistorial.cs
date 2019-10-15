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
    public partial class DetalleHistorial : DetalleModelo
    {
        private ColoresGUIDto _colores;
        private HistorialDto _dto;

        public override object Dto
        {
            get { return _dto; }
            set
            {
                if (value != null && (value is HistorialDto))
                    _dto = (HistorialDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleHistorial porque no es del tipo correcto.");
            }
        }

        public override ColoresGUIDto Colores
        {
            get { return _colores; }
            set { _colores = value; }
        }

        public DetalleHistorial()
        {
            InitializeComponent();
            _dto = new HistorialDto();
        }

        public override void Fill(object model)
        {
            if (model == null || model.GetType() != typeof(HistorialDto))
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
                Dto = model;
                HistorialDto h = (HistorialDto)model;
                Visible = false;
                idDataLabel.Text = h.ID.ToString();
                usuarioDataLabel.Text = h.Usuario.Username + " - " + h.Usuario.Nombre;
                conceptoDataLabel.Text = h.Concepto;
                fechaDataLabel.Text = h.Fecha.ToString("dddd dd/MM/yyyy hh:mm tt");
                FillDataGridView();
                Visible = true;
            }
        }

        public void FillDataGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Entidad");
            dt.Columns.Add("Clave");
            dt.Columns.Add("Valor");
            foreach(DatoHistorialDto d in _dto.Cambios)
            { dt.Rows.Add(new object[] { d.ID, d.Tabla, d.Columna, d.Valor }); }
            dataGridView.DataSource = dt;
        }
    }
}
