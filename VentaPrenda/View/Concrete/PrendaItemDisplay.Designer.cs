namespace VentaPrenda.View.Concrete
{
    partial class PrendaItemDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrendaItemDisplay));
            this.prendaItemLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.prendaLabel = new System.Windows.Forms.Label();
            this.prendaUnitarioLabel = new System.Windows.Forms.Label();
            this.serviciosLabel = new System.Windows.Forms.Label();
            this.servicioUnitarioLabel = new System.Windows.Forms.Label();
            this.prendaTotalLabel = new System.Windows.Forms.Label();
            this.prendaDescuentoLabel = new System.Windows.Forms.Label();
            this.prendaSubtotalLabel = new System.Windows.Forms.Label();
            this.servicioDescuentoLabel = new System.Windows.Forms.Label();
            this.servicioSubtotalLabel = new System.Windows.Forms.Label();
            this.servicioTotalLabel = new System.Windows.Forms.Label();
            this.prendaItemLayoutPanel.SuspendLayout();
            this.editButtonsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // prendaItemLayoutPanel
            // 
            this.prendaItemLayoutPanel.ColumnCount = 7;
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.prendaItemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.prendaItemLayoutPanel.Controls.Add(this.editButtonsLayoutPanel, 0, 0);
            this.prendaItemLayoutPanel.Controls.Add(this.prendaLabel, 1, 0);
            this.prendaItemLayoutPanel.Controls.Add(this.prendaUnitarioLabel, 3, 0);
            this.prendaItemLayoutPanel.Controls.Add(this.serviciosLabel, 2, 1);
            this.prendaItemLayoutPanel.Controls.Add(this.servicioUnitarioLabel, 3, 1);
            this.prendaItemLayoutPanel.Controls.Add(this.prendaTotalLabel, 6, 0);
            this.prendaItemLayoutPanel.Controls.Add(this.prendaDescuentoLabel, 4, 0);
            this.prendaItemLayoutPanel.Controls.Add(this.prendaSubtotalLabel, 5, 0);
            this.prendaItemLayoutPanel.Controls.Add(this.servicioDescuentoLabel, 4, 1);
            this.prendaItemLayoutPanel.Controls.Add(this.servicioSubtotalLabel, 5, 1);
            this.prendaItemLayoutPanel.Controls.Add(this.servicioTotalLabel, 6, 1);
            this.prendaItemLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prendaItemLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.prendaItemLayoutPanel.Name = "prendaItemLayoutPanel";
            this.prendaItemLayoutPanel.RowCount = 2;
            this.prendaItemLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.prendaItemLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.prendaItemLayoutPanel.Size = new System.Drawing.Size(500, 40);
            this.prendaItemLayoutPanel.TabIndex = 0;
            // 
            // editButtonsLayoutPanel
            // 
            this.editButtonsLayoutPanel.ColumnCount = 2;
            this.editButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.editButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.editButtonsLayoutPanel.Controls.Add(this.editButton, 0, 0);
            this.editButtonsLayoutPanel.Controls.Add(this.deleteButton, 1, 0);
            this.editButtonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButtonsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.editButtonsLayoutPanel.Name = "editButtonsLayoutPanel";
            this.editButtonsLayoutPanel.RowCount = 1;
            this.editButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.editButtonsLayoutPanel.Size = new System.Drawing.Size(59, 24);
            this.editButtonsLayoutPanel.TabIndex = 0;
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.Location = new System.Drawing.Point(1, 1);
            this.editButton.Margin = new System.Windows.Forms.Padding(1);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(27, 22);
            this.editButton.TabIndex = 0;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(30, 1);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(28, 22);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // prendaLabel
            // 
            this.prendaLabel.AutoSize = true;
            this.prendaItemLayoutPanel.SetColumnSpan(this.prendaLabel, 2);
            this.prendaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prendaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prendaLabel.Location = new System.Drawing.Point(68, 0);
            this.prendaLabel.Name = "prendaLabel";
            this.prendaLabel.Size = new System.Drawing.Size(149, 30);
            this.prendaLabel.TabIndex = 1;
            this.prendaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prendaUnitarioLabel
            // 
            this.prendaUnitarioLabel.AutoSize = true;
            this.prendaUnitarioLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prendaUnitarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prendaUnitarioLabel.Location = new System.Drawing.Point(223, 0);
            this.prendaUnitarioLabel.Name = "prendaUnitarioLabel";
            this.prendaUnitarioLabel.Size = new System.Drawing.Size(64, 30);
            this.prendaUnitarioLabel.TabIndex = 2;
            this.prendaUnitarioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serviciosLabel
            // 
            this.serviciosLabel.AutoSize = true;
            this.serviciosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviciosLabel.Location = new System.Drawing.Point(93, 30);
            this.serviciosLabel.Name = "serviciosLabel";
            this.serviciosLabel.Size = new System.Drawing.Size(124, 30);
            this.serviciosLabel.TabIndex = 4;
            this.serviciosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // servicioUnitarioLabel
            // 
            this.servicioUnitarioLabel.AutoSize = true;
            this.servicioUnitarioLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicioUnitarioLabel.Location = new System.Drawing.Point(223, 30);
            this.servicioUnitarioLabel.Name = "servicioUnitarioLabel";
            this.servicioUnitarioLabel.Size = new System.Drawing.Size(64, 30);
            this.servicioUnitarioLabel.TabIndex = 5;
            this.servicioUnitarioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prendaTotalLabel
            // 
            this.prendaTotalLabel.AutoSize = true;
            this.prendaTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prendaTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prendaTotalLabel.Location = new System.Drawing.Point(433, 0);
            this.prendaTotalLabel.Name = "prendaTotalLabel";
            this.prendaTotalLabel.Size = new System.Drawing.Size(64, 30);
            this.prendaTotalLabel.TabIndex = 8;
            this.prendaTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prendaDescuentoLabel
            // 
            this.prendaDescuentoLabel.AutoSize = true;
            this.prendaDescuentoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prendaDescuentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prendaDescuentoLabel.Location = new System.Drawing.Point(293, 0);
            this.prendaDescuentoLabel.Name = "prendaDescuentoLabel";
            this.prendaDescuentoLabel.Size = new System.Drawing.Size(64, 30);
            this.prendaDescuentoLabel.TabIndex = 7;
            this.prendaDescuentoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prendaSubtotalLabel
            // 
            this.prendaSubtotalLabel.AutoSize = true;
            this.prendaSubtotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prendaSubtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prendaSubtotalLabel.Location = new System.Drawing.Point(363, 0);
            this.prendaSubtotalLabel.Name = "prendaSubtotalLabel";
            this.prendaSubtotalLabel.Size = new System.Drawing.Size(64, 30);
            this.prendaSubtotalLabel.TabIndex = 3;
            this.prendaSubtotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // servicioDescuentoLabel
            // 
            this.servicioDescuentoLabel.AutoSize = true;
            this.servicioDescuentoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicioDescuentoLabel.Location = new System.Drawing.Point(293, 30);
            this.servicioDescuentoLabel.Name = "servicioDescuentoLabel";
            this.servicioDescuentoLabel.Size = new System.Drawing.Size(64, 30);
            this.servicioDescuentoLabel.TabIndex = 9;
            this.servicioDescuentoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // servicioSubtotalLabel
            // 
            this.servicioSubtotalLabel.AutoSize = true;
            this.servicioSubtotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicioSubtotalLabel.Location = new System.Drawing.Point(363, 30);
            this.servicioSubtotalLabel.Name = "servicioSubtotalLabel";
            this.servicioSubtotalLabel.Size = new System.Drawing.Size(64, 30);
            this.servicioSubtotalLabel.TabIndex = 6;
            this.servicioSubtotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // servicioTotalLabel
            // 
            this.servicioTotalLabel.AutoSize = true;
            this.servicioTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicioTotalLabel.Location = new System.Drawing.Point(433, 30);
            this.servicioTotalLabel.Name = "servicioTotalLabel";
            this.servicioTotalLabel.Size = new System.Drawing.Size(64, 30);
            this.servicioTotalLabel.TabIndex = 10;
            this.servicioTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrendaItemDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.prendaItemLayoutPanel);
            this.Name = "PrendaItemDisplay";
            this.Size = new System.Drawing.Size(500, 40);
            this.prendaItemLayoutPanel.ResumeLayout(false);
            this.prendaItemLayoutPanel.PerformLayout();
            this.editButtonsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel prendaItemLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel editButtonsLayoutPanel;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label prendaLabel;
        private System.Windows.Forms.Label prendaUnitarioLabel;
        private System.Windows.Forms.Label prendaSubtotalLabel;
        private System.Windows.Forms.Label serviciosLabel;
        private System.Windows.Forms.Label servicioUnitarioLabel;
        private System.Windows.Forms.Label servicioSubtotalLabel;
        private System.Windows.Forms.Label prendaDescuentoLabel;
        private System.Windows.Forms.Label prendaTotalLabel;
        private System.Windows.Forms.Label servicioDescuentoLabel;
        private System.Windows.Forms.Label servicioTotalLabel;
    }
}
