﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using VentaPrenda.View.Abstract;
using VentaPrenda.DTO;

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetalleReporte : DetalleModelo
    {
        private ColoresGUIDto _colores;
        private ReporteDto _dto;
        private ErrorProvider _errorProvider;
        private Control resumen;
        public override object Dto
        {
            get
            {
                _dto.Desde = desdePicker.Value;
                _dto.Hasta = hastaPicker.Value;
                _dto.Tipo = (TipoReporte)tipoReporteComboBox.SelectedItem;
                return _dto;
            }
            set
            {
                _dto = (ReporteDto)value;
            }
        }

        public override ColoresGUIDto Colores
        {
            get { return _colores; }
            set
            {
                _colores = value;
                obtenerReporteButton.BackColor = _colores.FondoBoton;
            }
        }

        public DetalleReporte()
        {
            Visible = false;
            InitializeComponent();
            _dto = new ReporteDto();
            desdePicker.MaxDate = DateTime.Today;
            desdePicker.Value = DateTime.Today;
            hastaPicker.MaxDate = DateTime.Today;
            hastaPicker.Value = DateTime.Today;
            foreach(TipoReporte tr in Enum.GetValues(typeof(TipoReporte)) )
            { tipoReporteComboBox.Items.Add(tr); }
            Visible = true;
        }

        public DetalleReporte(ErrorProvider e) : this()
        { _errorProvider = e; }

        private void FillIngresosResumen(DataRowCollection rows)
        {
            int notas = 0, prendas = 0, servicios = 0;
            decimal monto = 0,
                desc = 0,
                ventaNeta = 0,
                efectivo = 0,
                tarjeta = 0,
                totalIngresos = 0,
                porCobrar = 0;
            foreach (DataRow row in rows)
            {
                notas++;
                prendas += Convert.ToInt32(row["Prendas"]);
                servicios += Convert.ToInt32(row["Servicios"]);
                monto += Convert.ToDecimal(row["Monto"]);
                desc += Convert.ToDecimal(row["Descuento"]);
                ventaNeta += Convert.ToDecimal(row["Total a pagar"]);
                efectivo += Convert.ToDecimal(row["Efectivo"]);
                tarjeta += Convert.ToDecimal(row["Tarjeta"]);
                totalIngresos += Convert.ToDecimal(row["Total ingresos"]);
                porCobrar += Convert.ToDecimal(row["Por cobrar"]);
            }
            ResumenReporteIngresos r = new ResumenReporteIngresos();
            r.Notas = notas.ToString();
            r.Prendas = prendas.ToString();
            r.Servicios = servicios.ToString();
            r.Monto = "$ " + String.Format("{0:0.00}",monto);
            r.Descuento = "$ " + String.Format("{0:0.00}", desc);
            r.VentaNeta = "$ " + String.Format("{0:0.00}", ventaNeta);
            r.Efectivo = "$ " + String.Format("{0:0.00}", efectivo);
            r.Tarjeta = "$ " + String.Format("{0:0.00}", tarjeta);
            r.TotalIngresos = "$ " + String.Format("{0:0.00}", totalIngresos);
            r.PorCobrar = "$ " + String.Format("{0:0.00}", porCobrar);
            resumen = r;
            detalleReporteLayoutPanel.Controls.Add(resumen);
            resumen.Dock = DockStyle.Fill;
        }

        private void FillProduccionResumen(DataRowCollection rows)
        {
            DataGridView dgv = new DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.ShowEditingIcon = false;
            dgv.BackgroundColor = Colores.FondoLista;
            dgv.ReadOnly = true;
            dgv.Dock = DockStyle.Fill;
            dgv.Columns.Add("Usuario", "Usuario");
            dgv.Columns.Add("Servicios", "Servicios");
            dgv.Columns.Add("Monto", "Monto");

            Dictionary<string, Object[]> renglones = new Dictionary<string, Object[]>();
            foreach (DataRow row in rows)
            {
                if (!renglones.ContainsKey(row["Elaboró"].ToString()))
                {
                    renglones.Add(
                        row["Elaboró"].ToString(),
                        new Object[] {
                            Convert.ToInt32(row["Cantidad"]),
                            Convert.ToDecimal(row["Precio"])
                        }); ;
                } else
                {
                    renglones[row["Elaboró"].ToString()][0] = (int)renglones[row["Elaboró"].ToString()][0] + Convert.ToInt32(row["Cantidad"]);
                    renglones[row["Elaboró"].ToString()][1] = (decimal)renglones[row["Elaboró"].ToString()][1] + Convert.ToDecimal(row["Precio"]);
                }
            }
            foreach (KeyValuePair<string, Object[]> kvp in renglones) 
            {
                dgv.Rows.Add(new Object[] 
                { 
                    String.IsNullOrEmpty(kvp.Key)? "Sin asignar": kvp.Key, 
                    kvp.Value[0], 
                    kvp.Value[1] 
                });
            }
            resumen = dgv;
            detalleReporteLayoutPanel.Controls.Add(resumen);
        }

        private void ObtenerReporteButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Cursor = Cursors.WaitCursor;
                if (resumen != null) detalleReporteLayoutPanel.Controls.Remove(resumen);
                IMainView mainView = (IMainView)ParentForm;
                mainView.Controller.Reporte((ReporteDto)Dto);
                switch(((ReporteDto)Dto).Tipo)
                {
                    case TipoReporte.Clientes:
                        break;
                    case TipoReporte.Ingresos:
                        FillIngresosResumen(mainView.DataSource.Rows);
                        break;
                    case TipoReporte.Produccion:
                        mainView.DataSource.Columns.Remove("#");
                        FillProduccionResumen(mainView.DataSource.Rows);
                        break;
                }
                Cursor = Cursors.Default;
            }
        }

        private void IntervaloCheckBox_CheckedChanged(object sender, EventArgs e)
        { hastaPicker.Enabled = intervaloCheckBox.Checked; }

        private void DesdePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!intervaloCheckBox.Checked)
                hastaPicker.Value = desdePicker.Value;
        }

        private void TipoReporteComboBox_Validating(object sender, CancelEventArgs e)
        {
            if(tipoReporteComboBox.SelectedItem == null)
            {
                e.Cancel = true;
                _errorProvider.SetError(tipoReporteComboBox,"Por favor selecciona un tipo de reporte.");
                tipoReporteComboBox.BackColor = Color.Pink;
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(tipoReporteComboBox,"");
                tipoReporteComboBox.BackColor = SystemColors.Window;
            }
        }

        private void TipoReporteComboBox_Validated(object sender, EventArgs e)
        {
            _errorProvider.SetError(tipoReporteComboBox, "");
            tipoReporteComboBox.BackColor = SystemColors.Window;
        }

        private void TipoReporteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoReporteComboBox_Validating(sender, new CancelEventArgs());
        }
    }
}
