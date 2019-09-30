namespace VentaPrenda.View.Concrete.Detalles
{
    partial class DetalleTicket
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
            this.ticketLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.printerNameLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.printerNameLabel = new System.Windows.Forms.Label();
            this.printerNameComboBox = new System.Windows.Forms.ComboBox();
            this.encabezadoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.encabezadoLabel = new System.Windows.Forms.Label();
            this.encabezadoTextBox = new System.Windows.Forms.TextBox();
            this.pieLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pieLabel = new System.Windows.Forms.Label();
            this.pieTextBox = new System.Windows.Forms.TextBox();
            this.logoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.logoButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.quitarLogoButton = new System.Windows.Forms.Button();
            this.anchoLabel = new System.Windows.Forms.Label();
            this.anchoNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ticketLayoutPanel.SuspendLayout();
            this.printerNameLayoutPanel.SuspendLayout();
            this.encabezadoLayoutPanel.SuspendLayout();
            this.pieLayoutPanel.SuspendLayout();
            this.logoLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchoNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketLayoutPanel
            // 
            this.ticketLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.ticketLayoutPanel.ColumnCount = 1;
            this.ticketLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ticketLayoutPanel.Controls.Add(this.printerNameLayoutPanel, 0, 0);
            this.ticketLayoutPanel.Controls.Add(this.encabezadoLayoutPanel, 0, 1);
            this.ticketLayoutPanel.Controls.Add(this.pieLayoutPanel, 0, 2);
            this.ticketLayoutPanel.Controls.Add(this.logoLayoutPanel, 0, 3);
            this.ticketLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ticketLayoutPanel.Name = "ticketLayoutPanel";
            this.ticketLayoutPanel.RowCount = 4;
            this.ticketLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ticketLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.ticketLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.ticketLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ticketLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ticketLayoutPanel.Size = new System.Drawing.Size(500, 500);
            this.ticketLayoutPanel.TabIndex = 0;
            // 
            // printerNameLayoutPanel
            // 
            this.printerNameLayoutPanel.ColumnCount = 2;
            this.printerNameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.printerNameLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printerNameLayoutPanel.Controls.Add(this.printerNameLabel, 0, 0);
            this.printerNameLayoutPanel.Controls.Add(this.printerNameComboBox, 1, 0);
            this.printerNameLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printerNameLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.printerNameLayoutPanel.Name = "printerNameLayoutPanel";
            this.printerNameLayoutPanel.RowCount = 1;
            this.printerNameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printerNameLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.printerNameLayoutPanel.Size = new System.Drawing.Size(490, 34);
            this.printerNameLayoutPanel.TabIndex = 0;
            // 
            // printerNameLabel
            // 
            this.printerNameLabel.AutoSize = true;
            this.printerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printerNameLabel.Location = new System.Drawing.Point(3, 0);
            this.printerNameLabel.Name = "printerNameLabel";
            this.printerNameLabel.Size = new System.Drawing.Size(103, 34);
            this.printerNameLabel.TabIndex = 0;
            this.printerNameLabel.Text = "Impresora";
            this.printerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // printerNameComboBox
            // 
            this.printerNameComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.printerNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printerNameComboBox.FormattingEnabled = true;
            this.printerNameComboBox.Location = new System.Drawing.Point(112, 6);
            this.printerNameComboBox.Name = "printerNameComboBox";
            this.printerNameComboBox.Size = new System.Drawing.Size(200, 21);
            this.printerNameComboBox.TabIndex = 1;
            // 
            // encabezadoLayoutPanel
            // 
            this.encabezadoLayoutPanel.ColumnCount = 2;
            this.encabezadoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.encabezadoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.encabezadoLayoutPanel.Controls.Add(this.encabezadoLabel, 0, 0);
            this.encabezadoLayoutPanel.Controls.Add(this.encabezadoTextBox, 1, 0);
            this.encabezadoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encabezadoLayoutPanel.Location = new System.Drawing.Point(5, 47);
            this.encabezadoLayoutPanel.Name = "encabezadoLayoutPanel";
            this.encabezadoLayoutPanel.RowCount = 1;
            this.encabezadoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.encabezadoLayoutPanel.Size = new System.Drawing.Size(490, 68);
            this.encabezadoLayoutPanel.TabIndex = 1;
            // 
            // encabezadoLabel
            // 
            this.encabezadoLabel.AutoSize = true;
            this.encabezadoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encabezadoLabel.Location = new System.Drawing.Point(3, 0);
            this.encabezadoLabel.Name = "encabezadoLabel";
            this.encabezadoLabel.Size = new System.Drawing.Size(103, 68);
            this.encabezadoLabel.TabIndex = 0;
            this.encabezadoLabel.Text = "Encabezado";
            this.encabezadoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // encabezadoTextBox
            // 
            this.encabezadoTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.encabezadoTextBox.Location = new System.Drawing.Point(112, 4);
            this.encabezadoTextBox.MaxLength = 1024;
            this.encabezadoTextBox.Multiline = true;
            this.encabezadoTextBox.Name = "encabezadoTextBox";
            this.encabezadoTextBox.Size = new System.Drawing.Size(200, 60);
            this.encabezadoTextBox.TabIndex = 1;
            // 
            // pieLayoutPanel
            // 
            this.pieLayoutPanel.ColumnCount = 2;
            this.pieLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.pieLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pieLayoutPanel.Controls.Add(this.pieLabel, 0, 0);
            this.pieLayoutPanel.Controls.Add(this.pieTextBox, 1, 0);
            this.pieLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieLayoutPanel.Location = new System.Drawing.Point(5, 123);
            this.pieLayoutPanel.Name = "pieLayoutPanel";
            this.pieLayoutPanel.RowCount = 1;
            this.pieLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pieLayoutPanel.Size = new System.Drawing.Size(490, 68);
            this.pieLayoutPanel.TabIndex = 2;
            // 
            // pieLabel
            // 
            this.pieLabel.AutoSize = true;
            this.pieLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieLabel.Location = new System.Drawing.Point(3, 0);
            this.pieLabel.Name = "pieLabel";
            this.pieLabel.Size = new System.Drawing.Size(103, 68);
            this.pieLabel.TabIndex = 0;
            this.pieLabel.Text = "Pie";
            this.pieLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pieTextBox
            // 
            this.pieTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pieTextBox.Location = new System.Drawing.Point(112, 4);
            this.pieTextBox.Multiline = true;
            this.pieTextBox.Name = "pieTextBox";
            this.pieTextBox.Size = new System.Drawing.Size(200, 60);
            this.pieTextBox.TabIndex = 1;
            // 
            // logoLayoutPanel
            // 
            this.logoLayoutPanel.ColumnCount = 5;
            this.logoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.logoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.logoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.logoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.logoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.logoLayoutPanel.Controls.Add(this.logoLabel, 0, 0);
            this.logoLayoutPanel.Controls.Add(this.logoButton, 1, 0);
            this.logoLayoutPanel.Controls.Add(this.logoPictureBox, 1, 1);
            this.logoLayoutPanel.Controls.Add(this.quitarLogoButton, 2, 0);
            this.logoLayoutPanel.Controls.Add(this.anchoLabel, 3, 0);
            this.logoLayoutPanel.Controls.Add(this.anchoNumUpDown, 4, 0);
            this.logoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoLayoutPanel.Location = new System.Drawing.Point(5, 199);
            this.logoLayoutPanel.Name = "logoLayoutPanel";
            this.logoLayoutPanel.RowCount = 2;
            this.logoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.logoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logoLayoutPanel.Size = new System.Drawing.Size(490, 296);
            this.logoLayoutPanel.TabIndex = 3;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoLabel.Location = new System.Drawing.Point(3, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(103, 40);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "Logo";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logoButton
            // 
            this.logoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.logoButton.Location = new System.Drawing.Point(112, 8);
            this.logoButton.Name = "logoButton";
            this.logoButton.Size = new System.Drawing.Size(105, 23);
            this.logoButton.TabIndex = 1;
            this.logoButton.Text = "Seleccionar archivo";
            this.logoButton.UseVisualStyleBackColor = true;
            this.logoButton.Click += new System.EventHandler(this.LogoButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.logoLayoutPanel.SetColumnSpan(this.logoPictureBox, 4);
            this.logoPictureBox.Location = new System.Drawing.Point(112, 43);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(200, 250);
            this.logoPictureBox.TabIndex = 4;
            this.logoPictureBox.TabStop = false;
            // 
            // quitarLogoButton
            // 
            this.quitarLogoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.quitarLogoButton.Location = new System.Drawing.Point(223, 8);
            this.quitarLogoButton.Name = "quitarLogoButton";
            this.quitarLogoButton.Size = new System.Drawing.Size(105, 23);
            this.quitarLogoButton.TabIndex = 5;
            this.quitarLogoButton.Text = "Quitar logo";
            this.quitarLogoButton.UseVisualStyleBackColor = true;
            this.quitarLogoButton.Click += new System.EventHandler(this.QuitarLogoButton_Click);
            // 
            // anchoLabel
            // 
            this.anchoLabel.AutoSize = true;
            this.anchoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anchoLabel.Location = new System.Drawing.Point(334, 0);
            this.anchoLabel.Name = "anchoLabel";
            this.anchoLabel.Size = new System.Drawing.Size(68, 40);
            this.anchoLabel.TabIndex = 6;
            this.anchoLabel.Text = "Tamaño";
            this.anchoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // anchoNumUpDown
            // 
            this.anchoNumUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.anchoNumUpDown.Location = new System.Drawing.Point(408, 10);
            this.anchoNumUpDown.Maximum = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.anchoNumUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.anchoNumUpDown.Name = "anchoNumUpDown";
            this.anchoNumUpDown.Size = new System.Drawing.Size(60, 20);
            this.anchoNumUpDown.TabIndex = 7;
            this.anchoNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.anchoNumUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.anchoNumUpDown.ValueChanged += new System.EventHandler(this.AnchoNumUpDown_ValueChanged);
            // 
            // DetalleTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ticketLayoutPanel);
            this.Name = "DetalleTicket";
            this.Size = new System.Drawing.Size(500, 500);
            this.ticketLayoutPanel.ResumeLayout(false);
            this.printerNameLayoutPanel.ResumeLayout(false);
            this.printerNameLayoutPanel.PerformLayout();
            this.encabezadoLayoutPanel.ResumeLayout(false);
            this.encabezadoLayoutPanel.PerformLayout();
            this.pieLayoutPanel.ResumeLayout(false);
            this.pieLayoutPanel.PerformLayout();
            this.logoLayoutPanel.ResumeLayout(false);
            this.logoLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchoNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ticketLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel printerNameLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel encabezadoLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel pieLayoutPanel;
        private System.Windows.Forms.Label printerNameLabel;
        private System.Windows.Forms.Label encabezadoLabel;
        private System.Windows.Forms.Label pieLabel;
        private System.Windows.Forms.ComboBox printerNameComboBox;
        private System.Windows.Forms.TextBox encabezadoTextBox;
        private System.Windows.Forms.TextBox pieTextBox;
        private System.Windows.Forms.TableLayoutPanel logoLayoutPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Button logoButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button quitarLogoButton;
        private System.Windows.Forms.Label anchoLabel;
        private System.Windows.Forms.NumericUpDown anchoNumUpDown;
    }
}
