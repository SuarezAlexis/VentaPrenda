namespace VentaPrenda.View.Concrete.Detalles
{
    partial class DetalleReporte
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.detalleReporteLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.obtenerReporteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tipoReporteLabel = new System.Windows.Forms.Label();
            this.tipoReporteComboBox = new System.Windows.Forms.ComboBox();
            this.ingresosLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.desdeLabel = new System.Windows.Forms.Label();
            this.desdePicker = new System.Windows.Forms.DateTimePicker();
            this.hastaLabel = new System.Windows.Forms.Label();
            this.hastaPicker = new System.Windows.Forms.DateTimePicker();
            this.intervaloCheckBox = new System.Windows.Forms.CheckBox();
            this.detalleReporteLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ingresosLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // detalleReporteLayoutPanel
            // 
            this.detalleReporteLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.detalleReporteLayoutPanel.ColumnCount = 1;
            this.detalleReporteLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleReporteLayoutPanel.Controls.Add(this.obtenerReporteButton, 0, 2);
            this.detalleReporteLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.detalleReporteLayoutPanel.Controls.Add(this.ingresosLayoutPanel, 0, 1);
            this.detalleReporteLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalleReporteLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.detalleReporteLayoutPanel.Name = "detalleReporteLayoutPanel";
            this.detalleReporteLayoutPanel.RowCount = 5;
            this.detalleReporteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.detalleReporteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.detalleReporteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.detalleReporteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.detalleReporteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleReporteLayoutPanel.Size = new System.Drawing.Size(500, 500);
            this.detalleReporteLayoutPanel.TabIndex = 0;
            // 
            // obtenerReporteButton
            // 
            this.obtenerReporteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.obtenerReporteButton.Location = new System.Drawing.Point(175, 135);
            this.obtenerReporteButton.Name = "obtenerReporteButton";
            this.obtenerReporteButton.Size = new System.Drawing.Size(150, 34);
            this.obtenerReporteButton.TabIndex = 0;
            this.obtenerReporteButton.Text = "Obtener reporte";
            this.obtenerReporteButton.UseVisualStyleBackColor = true;
            this.obtenerReporteButton.Click += new System.EventHandler(this.ObtenerReporteButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tipoReporteLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tipoReporteComboBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 34);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tipoReporteLabel
            // 
            this.tipoReporteLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tipoReporteLabel.AutoSize = true;
            this.tipoReporteLabel.Location = new System.Drawing.Point(27, 10);
            this.tipoReporteLabel.Name = "tipoReporteLabel";
            this.tipoReporteLabel.Size = new System.Drawing.Size(79, 13);
            this.tipoReporteLabel.TabIndex = 0;
            this.tipoReporteLabel.Text = "Tipo de reporte";
            // 
            // tipoReporteComboBox
            // 
            this.tipoReporteComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tipoReporteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoReporteComboBox.FormattingEnabled = true;
            this.tipoReporteComboBox.Location = new System.Drawing.Point(112, 6);
            this.tipoReporteComboBox.Name = "tipoReporteComboBox";
            this.tipoReporteComboBox.Size = new System.Drawing.Size(200, 21);
            this.tipoReporteComboBox.TabIndex = 1;
            this.tipoReporteComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoReporteComboBox_SelectedIndexChanged);
            this.tipoReporteComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TipoReporteComboBox_Validating);
            this.tipoReporteComboBox.Validated += new System.EventHandler(this.TipoReporteComboBox_Validated);
            // 
            // ingresosLayoutPanel
            // 
            this.ingresosLayoutPanel.ColumnCount = 3;
            this.ingresosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.ingresosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.ingresosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ingresosLayoutPanel.Controls.Add(this.desdeLabel, 0, 0);
            this.ingresosLayoutPanel.Controls.Add(this.desdePicker, 1, 0);
            this.ingresosLayoutPanel.Controls.Add(this.hastaLabel, 0, 1);
            this.ingresosLayoutPanel.Controls.Add(this.hastaPicker, 1, 1);
            this.ingresosLayoutPanel.Controls.Add(this.intervaloCheckBox, 2, 0);
            this.ingresosLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingresosLayoutPanel.Location = new System.Drawing.Point(5, 47);
            this.ingresosLayoutPanel.Name = "ingresosLayoutPanel";
            this.ingresosLayoutPanel.RowCount = 2;
            this.ingresosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ingresosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ingresosLayoutPanel.Size = new System.Drawing.Size(490, 80);
            this.ingresosLayoutPanel.TabIndex = 1;
            // 
            // desdeLabel
            // 
            this.desdeLabel.AutoSize = true;
            this.desdeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desdeLabel.Location = new System.Drawing.Point(3, 0);
            this.desdeLabel.Name = "desdeLabel";
            this.desdeLabel.Size = new System.Drawing.Size(103, 40);
            this.desdeLabel.TabIndex = 1;
            this.desdeLabel.Text = "Desde";
            this.desdeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // desdePicker
            // 
            this.desdePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.desdePicker.CustomFormat = "dddd dd/MM/yyyy";
            this.desdePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdePicker.Location = new System.Drawing.Point(112, 10);
            this.desdePicker.Name = "desdePicker";
            this.desdePicker.Size = new System.Drawing.Size(200, 20);
            this.desdePicker.TabIndex = 2;
            this.desdePicker.ValueChanged += new System.EventHandler(this.DesdePicker_ValueChanged);
            // 
            // hastaLabel
            // 
            this.hastaLabel.AutoSize = true;
            this.hastaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hastaLabel.Location = new System.Drawing.Point(3, 40);
            this.hastaLabel.Name = "hastaLabel";
            this.hastaLabel.Size = new System.Drawing.Size(103, 40);
            this.hastaLabel.TabIndex = 3;
            this.hastaLabel.Text = "Hasta";
            this.hastaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hastaPicker
            // 
            this.hastaPicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hastaPicker.CustomFormat = "dddd dd/MM/yyyy";
            this.hastaPicker.Enabled = false;
            this.hastaPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastaPicker.Location = new System.Drawing.Point(112, 50);
            this.hastaPicker.Name = "hastaPicker";
            this.hastaPicker.Size = new System.Drawing.Size(200, 20);
            this.hastaPicker.TabIndex = 4;
            // 
            // intervaloCheckBox
            // 
            this.intervaloCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.intervaloCheckBox.AutoSize = true;
            this.intervaloCheckBox.Location = new System.Drawing.Point(371, 11);
            this.intervaloCheckBox.Name = "intervaloCheckBox";
            this.intervaloCheckBox.Size = new System.Drawing.Size(67, 17);
            this.intervaloCheckBox.TabIndex = 5;
            this.intervaloCheckBox.Text = "Intervalo";
            this.intervaloCheckBox.UseVisualStyleBackColor = true;
            this.intervaloCheckBox.CheckedChanged += new System.EventHandler(this.IntervaloCheckBox_CheckedChanged);
            // 
            // DetalleReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.detalleReporteLayoutPanel);
            this.Name = "DetalleReporte";
            this.Size = new System.Drawing.Size(500, 500);
            this.detalleReporteLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ingresosLayoutPanel.ResumeLayout(false);
            this.ingresosLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel detalleReporteLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel ingresosLayoutPanel;
        private System.Windows.Forms.Button obtenerReporteButton;
        private System.Windows.Forms.Label desdeLabel;
        private System.Windows.Forms.DateTimePicker desdePicker;
        private System.Windows.Forms.Label hastaLabel;
        private System.Windows.Forms.DateTimePicker hastaPicker;
        private System.Windows.Forms.CheckBox intervaloCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tipoReporteLabel;
        private System.Windows.Forms.ComboBox tipoReporteComboBox;
    }
}
