﻿using System;
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
    public partial class DetalleMovimiento : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        private bool _readOnly;
        private MovimientoDto _dto;
        private ErrorProvider _errorProvider;

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                conceptoTextBox.ReadOnly = value;
                importeNumUpDown.ReadOnly = value;
                descripcionTextBox.ReadOnly = value;
                deducibleCheckBox.Enabled = !value;
                numFacturaTextBox.ReadOnly = value;
                rfcTextBox.ReadOnly = value;
                fechaFacturaDateTimePicker.Enabled = !value;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0 ? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Concepto = conceptoTextBox.Text;
                _dto.Importe = importeNumUpDown.Value;
                _dto.Descripcion = descripcionTextBox.Text;
                _dto.Fecha = fechaDateTimePicker.Value;
                if(deducibleCheckBox.Checked)
                {
                    _dto.NumFactura = numFacturaTextBox.Text;
                    _dto.RFC = rfcTextBox.Text;
                    _dto.FechaFactura = fechaFacturaDateTimePicker.Value;
                }
                else
                {
                    _dto.NumFactura = String.Empty;
                    _dto.RFC = string.Empty;
                }
                return _dto;
            }
            set
            {
                if (value != null && (value is MovimientoDto))
                    _dto = (MovimientoDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetalleMovimiento porque no es del tipo correcto.");
            }
        }

        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetalleMovimiento()
        {
            InitializeComponent();
            _dto = new MovimientoDto();
        }

        public DetalleMovimiento(ErrorProvider e) : this()
        {
            _errorProvider = e;
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public override void Clear()
        {
            idDataLabel.Text = "";
            conceptoTextBox.Text = "";
            importeNumUpDown.Value = 0;
            descripcionTextBox.Text = "";
            fechaDateTimePicker.Value = DateTime.Now;
            fechaFacturaDateTimePicker.Value = DateTime.Now;
        }

        public override void Fill(object model)
        {
            Dto = model;
            if (model == null || model.GetType() != typeof(MovimientoDto))
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
                MovimientoDto m = (MovimientoDto)model;
                Visible = false;
                idDataLabel.Text = m.ID > 0 ? m.ID.ToString() : "";
                conceptoTextBox.Text = m.Concepto;
                importeNumUpDown.Value = m.Importe;
                descripcionTextBox.Text = m.Descripcion;
                fechaDateTimePicker.Value = m.Fecha;
                if (deducibleCheckBox.Checked = m.Deducible)
                {
                    numFacturaTextBox.Text = m.NumFactura;
                    rfcTextBox.Text = m.RFC;
                    fechaFacturaDateTimePicker.Value = m.FechaFactura == new DateTime()? DateTimePicker.MinimumDateTime : m.FechaFactura;
                }
                Visible = true;
            }
        }

        /************************ EventListenners **************************/
        private void conceptoTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        { ValidatingTextBox(conceptoTextBox, 32, e, _errorProvider); }
        private void conceptoTextBox_Validated(object sender, EventArgs e)
        { ValidatedTextBox(conceptoTextBox); }

        private void IngresoRadioButton_Click(object sender, EventArgs e)
        {
            gastoRadioButton.Checked = false;
            importeNumUpDown.Value = Math.Abs(importeNumUpDown.Value);
        }

        private void GastoRadioButton_Click(object sender, EventArgs e)
        {
            ingresoRadioButton.Checked = false;
            importeNumUpDown.Value = -Math.Abs(importeNumUpDown.Value);
        }

        private void ImporteNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(ingresoRadioButton.Checked)
            { importeNumUpDown.Value = Math.Abs(importeNumUpDown.Value); }
            if (gastoRadioButton.Checked)
            { importeNumUpDown.Value = -Math.Abs(importeNumUpDown.Value); }
        }

        private void DeducibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            numFacturaLayoutPanel.Visible = deducibleCheckBox.Checked;
            rfcLayoutPanel.Visible = deducibleCheckBox.Checked;
            fechaFacturaLayoutPanel.Visible = deducibleCheckBox.Checked;
        }
    }
}
