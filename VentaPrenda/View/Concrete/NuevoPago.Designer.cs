namespace VentaPrenda.View.Concrete
{
    partial class NuevoPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoPago));
            this.nuevoPagoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.idNotaLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.idLabel = new System.Windows.Forms.Label();
            this.idDataLabel = new System.Windows.Forms.Label();
            this.notaLabel = new System.Windows.Forms.Label();
            this.notaDataLabel = new System.Windows.Forms.Label();
            this.fechaLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fechaLabel = new System.Windows.Forms.Label();
            this.fechaDataLabel = new System.Windows.Forms.Label();
            this.metodoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.metodoLabel = new System.Windows.Forms.Label();
            this.metodoDomUpDown = new System.Windows.Forms.DomainUpDown();
            this.montoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.montoLabel = new System.Windows.Forms.Label();
            this.montoNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.nuevoPagoLayoutPanel.SuspendLayout();
            this.idNotaLayoutPanel.SuspendLayout();
            this.fechaLayoutPanel.SuspendLayout();
            this.metodoLayoutPanel.SuspendLayout();
            this.montoLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.montoNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nuevoPagoLayoutPanel
            // 
            this.nuevoPagoLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.nuevoPagoLayoutPanel.ColumnCount = 1;
            this.nuevoPagoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nuevoPagoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nuevoPagoLayoutPanel.Controls.Add(this.idNotaLayoutPanel, 0, 0);
            this.nuevoPagoLayoutPanel.Controls.Add(this.fechaLayoutPanel, 0, 1);
            this.nuevoPagoLayoutPanel.Controls.Add(this.metodoLayoutPanel, 0, 2);
            this.nuevoPagoLayoutPanel.Controls.Add(this.montoLayoutPanel, 0, 3);
            this.nuevoPagoLayoutPanel.Controls.Add(this.aceptarButton, 0, 4);
            this.nuevoPagoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuevoPagoLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.nuevoPagoLayoutPanel.Name = "nuevoPagoLayoutPanel";
            this.nuevoPagoLayoutPanel.RowCount = 5;
            this.nuevoPagoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.nuevoPagoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.nuevoPagoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.nuevoPagoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.nuevoPagoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.nuevoPagoLayoutPanel.Size = new System.Drawing.Size(327, 211);
            this.nuevoPagoLayoutPanel.TabIndex = 0;
            // 
            // idNotaLayoutPanel
            // 
            this.idNotaLayoutPanel.ColumnCount = 4;
            this.idNotaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.idNotaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.idNotaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.idNotaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.idNotaLayoutPanel.Controls.Add(this.idLabel, 0, 0);
            this.idNotaLayoutPanel.Controls.Add(this.idDataLabel, 1, 0);
            this.idNotaLayoutPanel.Controls.Add(this.notaLabel, 2, 0);
            this.idNotaLayoutPanel.Controls.Add(this.notaDataLabel, 3, 0);
            this.idNotaLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idNotaLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.idNotaLayoutPanel.Name = "idNotaLayoutPanel";
            this.idNotaLayoutPanel.RowCount = 1;
            this.idNotaLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.idNotaLayoutPanel.Size = new System.Drawing.Size(317, 34);
            this.idNotaLayoutPanel.TabIndex = 0;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idLabel.Location = new System.Drawing.Point(3, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(82, 34);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idDataLabel
            // 
            this.idDataLabel.AutoSize = true;
            this.idDataLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idDataLabel.Location = new System.Drawing.Point(91, 0);
            this.idDataLabel.Name = "idDataLabel";
            this.idDataLabel.Size = new System.Drawing.Size(64, 34);
            this.idDataLabel.TabIndex = 1;
            this.idDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notaLabel
            // 
            this.notaLabel.AutoSize = true;
            this.notaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notaLabel.Location = new System.Drawing.Point(161, 0);
            this.notaLabel.Name = "notaLabel";
            this.notaLabel.Size = new System.Drawing.Size(82, 34);
            this.notaLabel.TabIndex = 2;
            this.notaLabel.Text = "Nota";
            this.notaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notaDataLabel
            // 
            this.notaDataLabel.AutoSize = true;
            this.notaDataLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notaDataLabel.Location = new System.Drawing.Point(249, 0);
            this.notaDataLabel.Name = "notaDataLabel";
            this.notaDataLabel.Size = new System.Drawing.Size(65, 34);
            this.notaDataLabel.TabIndex = 3;
            this.notaDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaLayoutPanel
            // 
            this.fechaLayoutPanel.ColumnCount = 2;
            this.fechaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.fechaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fechaLayoutPanel.Controls.Add(this.fechaLabel, 0, 0);
            this.fechaLayoutPanel.Controls.Add(this.fechaDataLabel, 1, 0);
            this.fechaLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fechaLayoutPanel.Location = new System.Drawing.Point(5, 47);
            this.fechaLayoutPanel.Name = "fechaLayoutPanel";
            this.fechaLayoutPanel.RowCount = 1;
            this.fechaLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fechaLayoutPanel.Size = new System.Drawing.Size(317, 34);
            this.fechaLayoutPanel.TabIndex = 1;
            // 
            // fechaLabel
            // 
            this.fechaLabel.AutoSize = true;
            this.fechaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fechaLabel.Location = new System.Drawing.Point(3, 0);
            this.fechaLabel.Name = "fechaLabel";
            this.fechaLabel.Size = new System.Drawing.Size(103, 34);
            this.fechaLabel.TabIndex = 0;
            this.fechaLabel.Text = "Fecha";
            this.fechaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fechaDataLabel
            // 
            this.fechaDataLabel.AutoSize = true;
            this.fechaDataLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fechaDataLabel.Location = new System.Drawing.Point(112, 0);
            this.fechaDataLabel.Name = "fechaDataLabel";
            this.fechaDataLabel.Size = new System.Drawing.Size(202, 34);
            this.fechaDataLabel.TabIndex = 1;
            this.fechaDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metodoLayoutPanel
            // 
            this.metodoLayoutPanel.ColumnCount = 2;
            this.metodoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.metodoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.metodoLayoutPanel.Controls.Add(this.metodoLabel, 0, 0);
            this.metodoLayoutPanel.Controls.Add(this.metodoDomUpDown, 1, 0);
            this.metodoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metodoLayoutPanel.Location = new System.Drawing.Point(5, 89);
            this.metodoLayoutPanel.Name = "metodoLayoutPanel";
            this.metodoLayoutPanel.RowCount = 1;
            this.metodoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.metodoLayoutPanel.Size = new System.Drawing.Size(317, 34);
            this.metodoLayoutPanel.TabIndex = 2;
            // 
            // metodoLabel
            // 
            this.metodoLabel.AutoSize = true;
            this.metodoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metodoLabel.Location = new System.Drawing.Point(3, 0);
            this.metodoLabel.Name = "metodoLabel";
            this.metodoLabel.Size = new System.Drawing.Size(103, 34);
            this.metodoLabel.TabIndex = 0;
            this.metodoLabel.Text = "Método de pago";
            this.metodoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metodoDomUpDown
            // 
            this.metodoDomUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metodoDomUpDown.Location = new System.Drawing.Point(112, 7);
            this.metodoDomUpDown.Name = "metodoDomUpDown";
            this.metodoDomUpDown.Size = new System.Drawing.Size(100, 20);
            this.metodoDomUpDown.TabIndex = 1;
            this.metodoDomUpDown.Text = "domainUpDown1";
            // 
            // montoLayoutPanel
            // 
            this.montoLayoutPanel.ColumnCount = 2;
            this.montoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.montoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.montoLayoutPanel.Controls.Add(this.montoLabel, 0, 0);
            this.montoLayoutPanel.Controls.Add(this.montoNumUpDown, 1, 0);
            this.montoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.montoLayoutPanel.Location = new System.Drawing.Point(5, 131);
            this.montoLayoutPanel.Name = "montoLayoutPanel";
            this.montoLayoutPanel.RowCount = 1;
            this.montoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.montoLayoutPanel.Size = new System.Drawing.Size(317, 34);
            this.montoLayoutPanel.TabIndex = 3;
            // 
            // montoLabel
            // 
            this.montoLabel.AutoSize = true;
            this.montoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.montoLabel.Location = new System.Drawing.Point(3, 0);
            this.montoLabel.Name = "montoLabel";
            this.montoLabel.Size = new System.Drawing.Size(103, 34);
            this.montoLabel.TabIndex = 0;
            this.montoLabel.Text = "Monto";
            this.montoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // montoNumUpDown
            // 
            this.montoNumUpDown.DecimalPlaces = 2;
            this.montoNumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.montoNumUpDown.Location = new System.Drawing.Point(112, 3);
            this.montoNumUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.montoNumUpDown.Name = "montoNumUpDown";
            this.montoNumUpDown.Size = new System.Drawing.Size(100, 20);
            this.montoNumUpDown.TabIndex = 1;
            this.montoNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // aceptarButton
            // 
            this.aceptarButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aceptarButton.Location = new System.Drawing.Point(126, 178);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 4;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // NuevoPago
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 211);
            this.Controls.Add(this.nuevoPagoLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NuevoPago";
            this.nuevoPagoLayoutPanel.ResumeLayout(false);
            this.idNotaLayoutPanel.ResumeLayout(false);
            this.idNotaLayoutPanel.PerformLayout();
            this.fechaLayoutPanel.ResumeLayout(false);
            this.fechaLayoutPanel.PerformLayout();
            this.metodoLayoutPanel.ResumeLayout(false);
            this.metodoLayoutPanel.PerformLayout();
            this.montoLayoutPanel.ResumeLayout(false);
            this.montoLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.montoNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel nuevoPagoLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel idNotaLayoutPanel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label idDataLabel;
        private System.Windows.Forms.Label notaLabel;
        private System.Windows.Forms.Label notaDataLabel;
        private System.Windows.Forms.TableLayoutPanel fechaLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel metodoLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel montoLayoutPanel;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Label fechaLabel;
        private System.Windows.Forms.Label fechaDataLabel;
        private System.Windows.Forms.Label metodoLabel;
        private System.Windows.Forms.DomainUpDown metodoDomUpDown;
        private System.Windows.Forms.Label montoLabel;
        private System.Windows.Forms.NumericUpDown montoNumUpDown;
    }
}