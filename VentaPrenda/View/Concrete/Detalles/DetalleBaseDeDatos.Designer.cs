namespace VentaPrenda.View.Concrete.Detalles
{
    partial class DetalleBaseDeDatos
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
            this.detalleBaseDeDatosLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.respaldosLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.respaldosLabel = new System.Windows.Forms.Label();
            this.archivosListBox = new System.Windows.Forms.ListBox();
            this.restaurarButton = new System.Windows.Forms.Button();
            this.archivosButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.desdeArchivoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.desdeArchivoLabel = new System.Windows.Forms.Label();
            this.seleccionarButton = new System.Windows.Forms.Button();
            this.respaldarLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.respaldarLabel = new System.Windows.Forms.Label();
            this.iniciarRespaldoButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.detalleBaseDeDatosLayoutPanel.SuspendLayout();
            this.respaldosLayoutPanel.SuspendLayout();
            this.desdeArchivoLayoutPanel.SuspendLayout();
            this.respaldarLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // detalleBaseDeDatosLayoutPanel
            // 
            this.detalleBaseDeDatosLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.detalleBaseDeDatosLayoutPanel.ColumnCount = 1;
            this.detalleBaseDeDatosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleBaseDeDatosLayoutPanel.Controls.Add(this.respaldosLayoutPanel, 0, 1);
            this.detalleBaseDeDatosLayoutPanel.Controls.Add(this.desdeArchivoLayoutPanel, 0, 2);
            this.detalleBaseDeDatosLayoutPanel.Controls.Add(this.respaldarLayoutPanel, 0, 0);
            this.detalleBaseDeDatosLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalleBaseDeDatosLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.detalleBaseDeDatosLayoutPanel.Name = "detalleBaseDeDatosLayoutPanel";
            this.detalleBaseDeDatosLayoutPanel.RowCount = 4;
            this.detalleBaseDeDatosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.detalleBaseDeDatosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.detalleBaseDeDatosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.detalleBaseDeDatosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleBaseDeDatosLayoutPanel.Size = new System.Drawing.Size(574, 500);
            this.detalleBaseDeDatosLayoutPanel.TabIndex = 0;
            // 
            // respaldosLayoutPanel
            // 
            this.respaldosLayoutPanel.ColumnCount = 3;
            this.respaldosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.respaldosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.respaldosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.respaldosLayoutPanel.Controls.Add(this.respaldosLabel, 0, 0);
            this.respaldosLayoutPanel.Controls.Add(this.archivosListBox, 1, 0);
            this.respaldosLayoutPanel.Controls.Add(this.restaurarButton, 2, 0);
            this.respaldosLayoutPanel.Controls.Add(this.archivosButton, 2, 2);
            this.respaldosLayoutPanel.Controls.Add(this.eliminarButton, 2, 1);
            this.respaldosLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.respaldosLayoutPanel.Location = new System.Drawing.Point(5, 67);
            this.respaldosLayoutPanel.Name = "respaldosLayoutPanel";
            this.respaldosLayoutPanel.RowCount = 3;
            this.respaldosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.respaldosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.respaldosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.respaldosLayoutPanel.Size = new System.Drawing.Size(564, 234);
            this.respaldosLayoutPanel.TabIndex = 0;
            // 
            // respaldosLabel
            // 
            this.respaldosLabel.AutoSize = true;
            this.respaldosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.respaldosLabel.Location = new System.Drawing.Point(3, 0);
            this.respaldosLabel.Name = "respaldosLabel";
            this.respaldosLabel.Size = new System.Drawing.Size(144, 60);
            this.respaldosLabel.TabIndex = 0;
            this.respaldosLabel.Text = "Archivos disponibles";
            this.respaldosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // archivosListBox
            // 
            this.archivosListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.archivosListBox.FormattingEnabled = true;
            this.archivosListBox.Location = new System.Drawing.Point(153, 3);
            this.archivosListBox.Name = "archivosListBox";
            this.respaldosLayoutPanel.SetRowSpan(this.archivosListBox, 3);
            this.archivosListBox.Size = new System.Drawing.Size(200, 228);
            this.archivosListBox.TabIndex = 1;
            this.archivosListBox.SelectedIndexChanged += new System.EventHandler(this.ArchivosListBox_SelectedIndexChanged);
            // 
            // restaurarButton
            // 
            this.restaurarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.restaurarButton.Enabled = false;
            this.restaurarButton.Location = new System.Drawing.Point(360, 8);
            this.restaurarButton.Name = "restaurarButton";
            this.restaurarButton.Size = new System.Drawing.Size(201, 43);
            this.restaurarButton.TabIndex = 2;
            this.restaurarButton.Text = "Iniciar restauración";
            this.restaurarButton.UseVisualStyleBackColor = true;
            this.restaurarButton.Click += new System.EventHandler(this.RestaurarButton_Click);
            // 
            // archivosButton
            // 
            this.archivosButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.archivosButton.Location = new System.Drawing.Point(360, 208);
            this.archivosButton.Name = "archivosButton";
            this.archivosButton.Size = new System.Drawing.Size(201, 23);
            this.archivosButton.TabIndex = 3;
            this.archivosButton.Text = "Abrir ubicación de archivos";
            this.archivosButton.UseVisualStyleBackColor = true;
            this.archivosButton.Click += new System.EventHandler(this.ArchivosButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.eliminarButton.Enabled = false;
            this.eliminarButton.Location = new System.Drawing.Point(360, 68);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(201, 43);
            this.eliminarButton.TabIndex = 4;
            this.eliminarButton.Text = "Eliminar archivo";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // desdeArchivoLayoutPanel
            // 
            this.desdeArchivoLayoutPanel.ColumnCount = 2;
            this.desdeArchivoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.desdeArchivoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.desdeArchivoLayoutPanel.Controls.Add(this.desdeArchivoLabel, 0, 0);
            this.desdeArchivoLayoutPanel.Controls.Add(this.seleccionarButton, 1, 0);
            this.desdeArchivoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desdeArchivoLayoutPanel.Location = new System.Drawing.Point(5, 309);
            this.desdeArchivoLayoutPanel.Name = "desdeArchivoLayoutPanel";
            this.desdeArchivoLayoutPanel.RowCount = 1;
            this.desdeArchivoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.desdeArchivoLayoutPanel.Size = new System.Drawing.Size(564, 34);
            this.desdeArchivoLayoutPanel.TabIndex = 1;
            // 
            // desdeArchivoLabel
            // 
            this.desdeArchivoLabel.AutoSize = true;
            this.desdeArchivoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desdeArchivoLabel.Location = new System.Drawing.Point(3, 0);
            this.desdeArchivoLabel.Name = "desdeArchivoLabel";
            this.desdeArchivoLabel.Size = new System.Drawing.Size(144, 34);
            this.desdeArchivoLabel.TabIndex = 0;
            this.desdeArchivoLabel.Text = "Cargar archivo";
            this.desdeArchivoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seleccionarButton
            // 
            this.seleccionarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.seleccionarButton.Location = new System.Drawing.Point(153, 5);
            this.seleccionarButton.Name = "seleccionarButton";
            this.seleccionarButton.Size = new System.Drawing.Size(200, 23);
            this.seleccionarButton.TabIndex = 1;
            this.seleccionarButton.Text = "Seleccionar archivo";
            this.seleccionarButton.UseVisualStyleBackColor = true;
            this.seleccionarButton.Click += new System.EventHandler(this.SeleccionarButton_Click);
            // 
            // respaldarLayoutPanel
            // 
            this.respaldarLayoutPanel.ColumnCount = 2;
            this.respaldarLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.respaldarLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.respaldarLayoutPanel.Controls.Add(this.respaldarLabel, 0, 0);
            this.respaldarLayoutPanel.Controls.Add(this.iniciarRespaldoButton, 1, 0);
            this.respaldarLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.respaldarLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.respaldarLayoutPanel.Name = "respaldarLayoutPanel";
            this.respaldarLayoutPanel.RowCount = 1;
            this.respaldarLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.respaldarLayoutPanel.Size = new System.Drawing.Size(564, 54);
            this.respaldarLayoutPanel.TabIndex = 2;
            // 
            // respaldarLabel
            // 
            this.respaldarLabel.AutoSize = true;
            this.respaldarLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.respaldarLabel.Location = new System.Drawing.Point(3, 0);
            this.respaldarLabel.Name = "respaldarLabel";
            this.respaldarLabel.Size = new System.Drawing.Size(144, 54);
            this.respaldarLabel.TabIndex = 0;
            this.respaldarLabel.Text = "Generar respaldo";
            this.respaldarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iniciarRespaldoButton
            // 
            this.iniciarRespaldoButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iniciarRespaldoButton.Location = new System.Drawing.Point(153, 5);
            this.iniciarRespaldoButton.Name = "iniciarRespaldoButton";
            this.iniciarRespaldoButton.Size = new System.Drawing.Size(200, 43);
            this.iniciarRespaldoButton.TabIndex = 1;
            this.iniciarRespaldoButton.Text = "Iniciar respaldo";
            this.iniciarRespaldoButton.UseVisualStyleBackColor = true;
            this.iniciarRespaldoButton.Click += new System.EventHandler(this.IniciarRespaldoButton_Click);
            // 
            // DetalleBaseDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detalleBaseDeDatosLayoutPanel);
            this.Name = "DetalleBaseDeDatos";
            this.Size = new System.Drawing.Size(574, 500);
            this.detalleBaseDeDatosLayoutPanel.ResumeLayout(false);
            this.respaldosLayoutPanel.ResumeLayout(false);
            this.respaldosLayoutPanel.PerformLayout();
            this.desdeArchivoLayoutPanel.ResumeLayout(false);
            this.desdeArchivoLayoutPanel.PerformLayout();
            this.respaldarLayoutPanel.ResumeLayout(false);
            this.respaldarLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel detalleBaseDeDatosLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel respaldosLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel desdeArchivoLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel respaldarLayoutPanel;
        private System.Windows.Forms.Label respaldarLabel;
        private System.Windows.Forms.Label respaldosLabel;
        private System.Windows.Forms.ListBox archivosListBox;
        private System.Windows.Forms.Button iniciarRespaldoButton;
        private System.Windows.Forms.Button restaurarButton;
        private System.Windows.Forms.Label desdeArchivoLabel;
        private System.Windows.Forms.Button archivosButton;
        private System.Windows.Forms.Button seleccionarButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
