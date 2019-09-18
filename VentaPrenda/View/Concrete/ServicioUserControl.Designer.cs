namespace VentaPrenda.View.Concrete
{
    partial class ServicioUserControl
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
            this.servicioLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cantNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.servicioComboBox = new System.Windows.Forms.ComboBox();
            this.descuentoComboBox = new System.Windows.Forms.ComboBox();
            this.subtotalLabel = new System.Windows.Forms.Label();
            this.encargadoComboBox = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.montoNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.costoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.porcentajeRadioButton = new System.Windows.Forms.RadioButton();
            this.monedaRadioButton = new System.Windows.Forms.RadioButton();
            this.montoLabel = new System.Windows.Forms.Label();
            this.servicioLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.montoNumUpDown)).BeginInit();
            this.costoLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // servicioLayoutPanel
            // 
            this.servicioLayoutPanel.ColumnCount = 9;
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.servicioLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.servicioLayoutPanel.Controls.Add(this.cantNumUpDown, 0, 0);
            this.servicioLayoutPanel.Controls.Add(this.servicioComboBox, 1, 0);
            this.servicioLayoutPanel.Controls.Add(this.descuentoComboBox, 2, 0);
            this.servicioLayoutPanel.Controls.Add(this.subtotalLabel, 3, 0);
            this.servicioLayoutPanel.Controls.Add(this.encargadoComboBox, 7, 0);
            this.servicioLayoutPanel.Controls.Add(this.editButton, 8, 0);
            this.servicioLayoutPanel.Controls.Add(this.montoNumUpDown, 4, 0);
            this.servicioLayoutPanel.Controls.Add(this.costoLayoutPanel, 5, 0);
            this.servicioLayoutPanel.Controls.Add(this.montoLabel, 6, 0);
            this.servicioLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicioLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.servicioLayoutPanel.Name = "servicioLayoutPanel";
            this.servicioLayoutPanel.RowCount = 1;
            this.servicioLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.servicioLayoutPanel.Size = new System.Drawing.Size(700, 55);
            this.servicioLayoutPanel.TabIndex = 0;
            // 
            // cantNumUpDown
            // 
            this.cantNumUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cantNumUpDown.Location = new System.Drawing.Point(3, 17);
            this.cantNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantNumUpDown.Name = "cantNumUpDown";
            this.cantNumUpDown.Size = new System.Drawing.Size(34, 20);
            this.cantNumUpDown.TabIndex = 1;
            this.cantNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cantNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantNumUpDown.ValueChanged += new System.EventHandler(this.CantNumUpDown_ValueChanged);
            // 
            // servicioComboBox
            // 
            this.servicioComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.servicioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servicioComboBox.DropDownWidth = 200;
            this.servicioComboBox.FormattingEnabled = true;
            this.servicioComboBox.Location = new System.Drawing.Point(43, 17);
            this.servicioComboBox.Name = "servicioComboBox";
            this.servicioComboBox.Size = new System.Drawing.Size(131, 21);
            this.servicioComboBox.TabIndex = 2;
            this.servicioComboBox.SelectedIndexChanged += new System.EventHandler(this.ServicioComboBox_SelectedIndexChanged);
            // 
            // descuentoComboBox
            // 
            this.descuentoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.descuentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.descuentoComboBox.DropDownWidth = 200;
            this.descuentoComboBox.FormattingEnabled = true;
            this.descuentoComboBox.Location = new System.Drawing.Point(180, 17);
            this.descuentoComboBox.Name = "descuentoComboBox";
            this.descuentoComboBox.Size = new System.Drawing.Size(131, 21);
            this.descuentoComboBox.TabIndex = 3;
            this.descuentoComboBox.SelectedIndexChanged += new System.EventHandler(this.DescuentoComboBox_SelectedIndexChanged);
            this.descuentoComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.DescuentoComboBox_Validating);
            // 
            // subtotalLabel
            // 
            this.subtotalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtotalLabel.AutoSize = true;
            this.subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalLabel.Location = new System.Drawing.Point(335, 21);
            this.subtotalLabel.Name = "subtotalLabel";
            this.subtotalLabel.Size = new System.Drawing.Size(37, 13);
            this.subtotalLabel.TabIndex = 4;
            this.subtotalLabel.Text = "$ 0.00";
            // 
            // encargadoComboBox
            // 
            this.encargadoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.encargadoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encargadoComboBox.Enabled = false;
            this.encargadoComboBox.FormattingEnabled = true;
            this.encargadoComboBox.Location = new System.Drawing.Point(597, 17);
            this.encargadoComboBox.Name = "encargadoComboBox";
            this.encargadoComboBox.Size = new System.Drawing.Size(64, 21);
            this.encargadoComboBox.TabIndex = 7;
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(670, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(24, 23);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "X";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // montoNumUpDown
            // 
            this.montoNumUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.montoNumUpDown.DecimalPlaces = 2;
            this.montoNumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.montoNumUpDown.Location = new System.Drawing.Point(404, 17);
            this.montoNumUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.montoNumUpDown.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147352576});
            this.montoNumUpDown.Name = "montoNumUpDown";
            this.montoNumUpDown.Size = new System.Drawing.Size(60, 20);
            this.montoNumUpDown.TabIndex = 5;
            this.montoNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.montoNumUpDown.ThousandsSeparator = true;
            this.montoNumUpDown.ValueChanged += new System.EventHandler(this.MontoNumUpDown_ValueChanged);
            // 
            // costoLayoutPanel
            // 
            this.costoLayoutPanel.ColumnCount = 1;
            this.costoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.costoLayoutPanel.Controls.Add(this.porcentajeRadioButton, 0, 0);
            this.costoLayoutPanel.Controls.Add(this.monedaRadioButton, 0, 1);
            this.costoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.costoLayoutPanel.Location = new System.Drawing.Point(477, 3);
            this.costoLayoutPanel.Name = "costoLayoutPanel";
            this.costoLayoutPanel.RowCount = 2;
            this.costoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.costoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.costoLayoutPanel.Size = new System.Drawing.Size(34, 49);
            this.costoLayoutPanel.TabIndex = 6;
            // 
            // porcentajeRadioButton
            // 
            this.porcentajeRadioButton.AutoSize = true;
            this.porcentajeRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porcentajeRadioButton.Location = new System.Drawing.Point(3, 3);
            this.porcentajeRadioButton.Name = "porcentajeRadioButton";
            this.porcentajeRadioButton.Size = new System.Drawing.Size(28, 18);
            this.porcentajeRadioButton.TabIndex = 0;
            this.porcentajeRadioButton.Text = "%";
            this.porcentajeRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.porcentajeRadioButton.UseVisualStyleBackColor = true;
            this.porcentajeRadioButton.Click += new System.EventHandler(this.PorcentajeRadioButton_Click);
            // 
            // monedaRadioButton
            // 
            this.monedaRadioButton.AutoSize = true;
            this.monedaRadioButton.Checked = true;
            this.monedaRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monedaRadioButton.Location = new System.Drawing.Point(3, 27);
            this.monedaRadioButton.Name = "monedaRadioButton";
            this.monedaRadioButton.Size = new System.Drawing.Size(28, 19);
            this.monedaRadioButton.TabIndex = 1;
            this.monedaRadioButton.TabStop = true;
            this.monedaRadioButton.Text = "$";
            this.monedaRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.monedaRadioButton.UseVisualStyleBackColor = true;
            this.monedaRadioButton.Click += new System.EventHandler(this.MonedaRadioButton_Click);
            // 
            // montoLabel
            // 
            this.montoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.montoLabel.AutoSize = true;
            this.montoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoLabel.Location = new System.Drawing.Point(532, 21);
            this.montoLabel.Name = "montoLabel";
            this.montoLabel.Size = new System.Drawing.Size(43, 13);
            this.montoLabel.TabIndex = 8;
            this.montoLabel.Text = "$ 0.00";
            this.montoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServicioUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.servicioLayoutPanel);
            this.Name = "ServicioUserControl";
            this.Size = new System.Drawing.Size(700, 55);
            this.servicioLayoutPanel.ResumeLayout(false);
            this.servicioLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.montoNumUpDown)).EndInit();
            this.costoLayoutPanel.ResumeLayout(false);
            this.costoLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel servicioLayoutPanel;
        private System.Windows.Forms.NumericUpDown cantNumUpDown;
        private System.Windows.Forms.ComboBox servicioComboBox;
        private System.Windows.Forms.ComboBox descuentoComboBox;
        private System.Windows.Forms.Label subtotalLabel;
        private System.Windows.Forms.NumericUpDown montoNumUpDown;
        private System.Windows.Forms.TableLayoutPanel costoLayoutPanel;
        private System.Windows.Forms.RadioButton porcentajeRadioButton;
        private System.Windows.Forms.RadioButton monedaRadioButton;
        private System.Windows.Forms.ComboBox encargadoComboBox;
        private System.Windows.Forms.Label montoLabel;
        private System.Windows.Forms.Button editButton;
    }
}
