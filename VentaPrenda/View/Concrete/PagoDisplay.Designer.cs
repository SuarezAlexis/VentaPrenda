namespace VentaPrenda.View.Concrete
{
    partial class PagoDisplay
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
            this.pagoDisplayLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editButonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.fechaLabel = new System.Windows.Forms.Label();
            this.metodoLabel = new System.Windows.Forms.Label();
            this.montoLabel = new System.Windows.Forms.Label();
            this.pagoDisplayLayoutPanel.SuspendLayout();
            this.editButonsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagoDisplayLayoutPanel
            // 
            this.pagoDisplayLayoutPanel.ColumnCount = 4;
            this.pagoDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.pagoDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pagoDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pagoDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pagoDisplayLayoutPanel.Controls.Add(this.editButonsLayoutPanel, 0, 0);
            this.pagoDisplayLayoutPanel.Controls.Add(this.fechaLabel, 1, 0);
            this.pagoDisplayLayoutPanel.Controls.Add(this.metodoLabel, 2, 0);
            this.pagoDisplayLayoutPanel.Controls.Add(this.montoLabel, 3, 0);
            this.pagoDisplayLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagoDisplayLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.pagoDisplayLayoutPanel.Name = "pagoDisplayLayoutPanel";
            this.pagoDisplayLayoutPanel.RowCount = 1;
            this.pagoDisplayLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pagoDisplayLayoutPanel.Size = new System.Drawing.Size(496, 35);
            this.pagoDisplayLayoutPanel.TabIndex = 0;
            // 
            // editButonsLayoutPanel
            // 
            this.editButonsLayoutPanel.ColumnCount = 2;
            this.editButonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.editButonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.editButonsLayoutPanel.Controls.Add(this.editButton, 0, 0);
            this.editButonsLayoutPanel.Controls.Add(this.deleteButton, 1, 0);
            this.editButonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButonsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.editButonsLayoutPanel.Name = "editButonsLayoutPanel";
            this.editButonsLayoutPanel.RowCount = 1;
            this.editButonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.editButonsLayoutPanel.Size = new System.Drawing.Size(59, 29);
            this.editButonsLayoutPanel.TabIndex = 0;
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(3, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(23, 23);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "E";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(32, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(24, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // fechaLabel
            // 
            this.fechaLabel.AutoSize = true;
            this.fechaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fechaLabel.Location = new System.Drawing.Point(68, 0);
            this.fechaLabel.Name = "fechaLabel";
            this.fechaLabel.Size = new System.Drawing.Size(137, 35);
            this.fechaLabel.TabIndex = 1;
            this.fechaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metodoLabel
            // 
            this.metodoLabel.AutoSize = true;
            this.metodoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metodoLabel.Location = new System.Drawing.Point(211, 0);
            this.metodoLabel.Name = "metodoLabel";
            this.metodoLabel.Size = new System.Drawing.Size(137, 35);
            this.metodoLabel.TabIndex = 2;
            this.metodoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // montoLabel
            // 
            this.montoLabel.AutoSize = true;
            this.montoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.montoLabel.Location = new System.Drawing.Point(354, 0);
            this.montoLabel.Name = "montoLabel";
            this.montoLabel.Size = new System.Drawing.Size(139, 35);
            this.montoLabel.TabIndex = 3;
            this.montoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PagoDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pagoDisplayLayoutPanel);
            this.Name = "PagoDisplay";
            this.Size = new System.Drawing.Size(496, 35);
            this.pagoDisplayLayoutPanel.ResumeLayout(false);
            this.pagoDisplayLayoutPanel.PerformLayout();
            this.editButonsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pagoDisplayLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel editButonsLayoutPanel;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label fechaLabel;
        private System.Windows.Forms.Label metodoLabel;
        private System.Windows.Forms.Label montoLabel;
    }
}
