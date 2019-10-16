using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.Controller;
using VentaPrenda.DTO;
using VentaPrenda.Exceptions;
using VentaPrenda.View.Abstract;

namespace VentaPrenda.View.Concrete
{
    public partial class LoginForm : Form, ILoginView
    {
        private TableLayoutPanel loginTablePanel;
        private Label loginLabel;
        private TableLayoutPanel usuarioTablePanel;
        private Label usuarioLabel;
        private TextBox usuarioTextBox;
        private TableLayoutPanel contraTablePanel;
        private Label contraLabel;
        private TextBox contraTextBox;
        private Button loginButton;

        /************************** ATRIBUTOS ******************************/
        public AccountController Controller { get; set; }

        /*************************** MÉTODOS *******************************/
        public LoginDto RequestCredentials()
        {
            usuarioTextBox.Focus();
            if( ShowDialog() == DialogResult.OK)
            {
                return new LoginDto {
                    Usuario = usuarioTextBox.Text,
                    Contraseña = contraTextBox.Text
                };
            }
            else
            { throw new ViewClosedException(this.GetType()); }
        }

        public void WrongCredentials()
        {
            contraTextBox.Text = "";
            MessageBox.Show(
                "El nombre de usuario o contraseña son incorrectos.",
                "Datos inválidos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand);
            usuarioTextBox.Focus();
        }

        public void BlockedUser()
        {
            this.contraTextBox.Text = "";
            MessageBox.Show(
                "El usuario solicitado se encuentra bloqueado.",
                "Usuario bloqueado.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            this.usuarioTextBox.Focus();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoginField_Changed(object sender, EventArgs e)
        {
            loginButton.Enabled = usuarioTextBox.Text.Length > 0 && contraTextBox.Text.Length > 0;
        }

        /********************** GETTERS & SETTERS **************************/

        public LoginForm()
        {
            InitializeComponent();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.loginLabel = new System.Windows.Forms.Label();
            this.usuarioTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.usuarioTextBox = new System.Windows.Forms.TextBox();
            this.contraTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.contraLabel = new System.Windows.Forms.Label();
            this.contraTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginTablePanel.SuspendLayout();
            this.usuarioTablePanel.SuspendLayout();
            this.contraTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTablePanel
            // 
            this.loginTablePanel.ColumnCount = 1;
            this.loginTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.loginTablePanel.Controls.Add(this.loginLabel, 0, 0);
            this.loginTablePanel.Controls.Add(this.usuarioTablePanel, 0, 1);
            this.loginTablePanel.Controls.Add(this.contraTablePanel, 0, 2);
            this.loginTablePanel.Controls.Add(this.loginButton, 0, 3);
            this.loginTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginTablePanel.Location = new System.Drawing.Point(0, 0);
            this.loginTablePanel.Name = "loginTablePanel";
            this.loginTablePanel.RowCount = 4;
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.loginTablePanel.Size = new System.Drawing.Size(317, 145);
            this.loginTablePanel.TabIndex = 0;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginLabel.Location = new System.Drawing.Point(3, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(311, 36);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Ingresa tu nombre de usuario y contraseña";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usuarioTablePanel
            // 
            this.usuarioTablePanel.ColumnCount = 2;
            this.usuarioTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.usuarioTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.usuarioTablePanel.Controls.Add(this.usuarioLabel, 0, 0);
            this.usuarioTablePanel.Controls.Add(this.usuarioTextBox, 1, 0);
            this.usuarioTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarioTablePanel.Location = new System.Drawing.Point(3, 39);
            this.usuarioTablePanel.Name = "usuarioTablePanel";
            this.usuarioTablePanel.RowCount = 1;
            this.usuarioTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.usuarioTablePanel.Size = new System.Drawing.Size(311, 30);
            this.usuarioTablePanel.TabIndex = 1;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.AutoSize = true;
            this.usuarioLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarioLabel.Location = new System.Drawing.Point(3, 0);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(102, 30);
            this.usuarioLabel.TabIndex = 0;
            this.usuarioLabel.Text = "Usuario";
            this.usuarioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usuarioTextBox
            // 
            this.usuarioTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.usuarioTextBox.Location = new System.Drawing.Point(111, 5);
            this.usuarioTextBox.Name = "usuarioTextBox";
            this.usuarioTextBox.Size = new System.Drawing.Size(141, 20);
            this.usuarioTextBox.TabIndex = 1;
            this.usuarioTextBox.TextChanged += new System.EventHandler(this.LoginField_Changed);
            // 
            // contraTablePanel
            // 
            this.contraTablePanel.ColumnCount = 2;
            this.contraTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.contraTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.contraTablePanel.Controls.Add(this.contraLabel, 0, 0);
            this.contraTablePanel.Controls.Add(this.contraTextBox, 1, 0);
            this.contraTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contraTablePanel.Location = new System.Drawing.Point(3, 75);
            this.contraTablePanel.Name = "contraTablePanel";
            this.contraTablePanel.RowCount = 1;
            this.contraTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contraTablePanel.Size = new System.Drawing.Size(311, 30);
            this.contraTablePanel.TabIndex = 2;
            // 
            // contraLabel
            // 
            this.contraLabel.AutoSize = true;
            this.contraLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contraLabel.Location = new System.Drawing.Point(3, 0);
            this.contraLabel.Name = "contraLabel";
            this.contraLabel.Size = new System.Drawing.Size(102, 30);
            this.contraLabel.TabIndex = 0;
            this.contraLabel.Text = "Contraseña";
            this.contraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contraTextBox
            // 
            this.contraTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.contraTextBox.Location = new System.Drawing.Point(111, 5);
            this.contraTextBox.Name = "contraTextBox";
            this.contraTextBox.PasswordChar = '•';
            this.contraTextBox.Size = new System.Drawing.Size(141, 20);
            this.contraTextBox.TabIndex = 1;
            this.contraTextBox.TextChanged += new System.EventHandler(this.LoginField_Changed);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.Enabled = false;
            this.loginButton.Location = new System.Drawing.Point(108, 115);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Iniciar sesión";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 145);
            this.Controls.Add(this.loginTablePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta Prenda";
            this.loginTablePanel.ResumeLayout(false);
            this.loginTablePanel.PerformLayout();
            this.usuarioTablePanel.ResumeLayout(false);
            this.usuarioTablePanel.PerformLayout();
            this.contraTablePanel.ResumeLayout(false);
            this.contraTablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        
    }
}
