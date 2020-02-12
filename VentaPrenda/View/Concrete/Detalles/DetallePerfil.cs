using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.DTO;
using VentaPrenda.Model;
using VentaPrenda.View.Abstract;

namespace VentaPrenda.View.Concrete.Detalles
{
    public class DetallePerfil : DetalleModelo
    {
        /*******************************************************************/
        /* ATRIBUTOS                                                       */
        /*******************************************************************/
        /************************* Windows Forms ***************************/
        private System.Windows.Forms.TableLayoutPanel idLayoutPanel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TableLayoutPanel nombreLayoutPanel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TableLayoutPanel permisosLayoutPanel;
        private System.Windows.Forms.Label funcionesLabel;
        private System.Windows.Forms.Label permisosLabel;
        private System.Windows.Forms.Label idDataLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.CheckedListBox funcionesChecklistBox;
        private System.Windows.Forms.CheckedListBox permisosChecklistBox;
        private System.Windows.Forms.TableLayoutPanel detallePerfilLayoutPanel;

        /*******************************************************************/
        private bool _readOnly;
        private PerfilDto _dto;
        private ErrorProvider _errorProvider;
        public override bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                nombreTextBox.ReadOnly = _readOnly;
                funcionesChecklistBox.Enabled = !_readOnly;
                permisosChecklistBox.Enabled = !_readOnly;
            }
        }

        public override object Dto
        {
            get
            {
                _dto.ID = idDataLabel.Text != null && idDataLabel.Text.Length > 0? Convert.ToInt16(idDataLabel.Text) : (short)-1;
                _dto.Nombre = nombreTextBox.Text;
                int i = 0;
                _dto.Permisos = new Permisos
                {
                    Notas = funcionesChecklistBox.GetItemChecked(i++),
                    Clientes = funcionesChecklistBox.GetItemChecked(i++),
                    Balance = funcionesChecklistBox.GetItemChecked(i++),
                    Reportes = funcionesChecklistBox.GetItemChecked(i++),
                    Catalogos = funcionesChecklistBox.GetItemChecked(i++),
                    Descuentos = funcionesChecklistBox.GetItemChecked(i++),
                    Historial = funcionesChecklistBox.GetItemChecked(i++),
                    Usuarios = funcionesChecklistBox.GetItemChecked(i++),
                    Perfiles = funcionesChecklistBox.GetItemChecked(i++),
                    Database = funcionesChecklistBox.GetItemChecked(i++),
                    Ticket = funcionesChecklistBox.GetItemChecked(i++),
                    GenerarNota = permisosChecklistBox.GetItemChecked(i = 0),
                    EditarNota = permisosChecklistBox.GetItemChecked(++i),
                    EliminarNota = permisosChecklistBox.GetItemChecked(++i),
                    GeneraMovimientos = permisosChecklistBox.GetItemChecked(++i),
                    AdmonMovimientos = permisosChecklistBox.GetItemChecked(++i),
                    AdmonClientes = permisosChecklistBox.GetItemChecked(++i),
                    AdmonCatalogos = permisosChecklistBox.GetItemChecked(++i),
                    AdmonUsuarios = permisosChecklistBox.GetItemChecked(++i),
                    AdmonPerfiles = permisosChecklistBox.GetItemChecked(++i),
                };
                return _dto;
            }
            set
            {
                if (value != null && value.GetType() == typeof(PerfilDto))
                    _dto = (PerfilDto)value;
                else
                    throw new Exception("No fue posible asignar el Dto a la instancia de DetallePerfil porque no es del tipo correcto.");
            }
        }
        /*******************************************************************/
        /* CONSTRUCTORES                                                   */
        /*******************************************************************/
        public DetallePerfil()
        {
            InitializeComponent();
            _dto = new PerfilDto();
        }

        public DetallePerfil(ErrorProvider e) : this()
        {
            _errorProvider = e;
        }

        /*******************************************************************/
        /* MÉTODOS                                                         */
        /*******************************************************************/
        public override void Clear()
        {
            nombreTextBox.Text = "";
            foreach(int i in funcionesChecklistBox.CheckedIndices)
            { funcionesChecklistBox.SetItemChecked(i, false); }
            funcionesChecklistBox.ClearSelected();
            foreach (int i in permisosChecklistBox.CheckedIndices)
            { permisosChecklistBox.SetItemChecked(i, false); }
            permisosChecklistBox.ClearSelected();
        }

        public override void Fill(object model)
        {
            Dto = model;
            if(model == null || model.GetType() != typeof(PerfilDto))
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
                PerfilDto p = (PerfilDto)model;
                Visible = false;
                idDataLabel.Text = p.ID.ToString();
                nombreTextBox.Text = p.Nombre;
                int i = 0;
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Notas);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Clientes);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Balance);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Reportes);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Catalogos);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Descuentos);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Historial);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Usuarios);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Perfiles);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Ticket);
                funcionesChecklistBox.SetItemChecked(i++, p.Permisos.Database);
                i = 0;
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.GenerarNota);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.EditarNota);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.EliminarNota);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.GeneraMovimientos);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.AdmonMovimientos);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.AdmonClientes);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.AdmonCatalogos);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.AdmonUsuarios);
                permisosChecklistBox.SetItemChecked(i++, p.Permisos.AdmonPerfiles);
                Visible = true;
            }
        }


        private void InitializeComponent()
        {
            this.detallePerfilLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.idLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.idLabel = new System.Windows.Forms.Label();
            this.idDataLabel = new System.Windows.Forms.Label();
            this.nombreLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.permisosLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.funcionesLabel = new System.Windows.Forms.Label();
            this.permisosLabel = new System.Windows.Forms.Label();
            this.funcionesChecklistBox = new System.Windows.Forms.CheckedListBox();
            this.permisosChecklistBox = new System.Windows.Forms.CheckedListBox();
            this.detallePerfilLayoutPanel.SuspendLayout();
            this.idLayoutPanel.SuspendLayout();
            this.nombreLayoutPanel.SuspendLayout();
            this.permisosLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // detallePerfilLayoutPanel
            // 
            this.detallePerfilLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.detallePerfilLayoutPanel.ColumnCount = 1;
            this.detallePerfilLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detallePerfilLayoutPanel.Controls.Add(this.idLayoutPanel, 0, 0);
            this.detallePerfilLayoutPanel.Controls.Add(this.nombreLayoutPanel, 0, 1);
            this.detallePerfilLayoutPanel.Controls.Add(this.permisosLayoutPanel, 0, 2);
            this.detallePerfilLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detallePerfilLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.detallePerfilLayoutPanel.Name = "detallePerfilLayoutPanel";
            this.detallePerfilLayoutPanel.RowCount = 3;
            this.detallePerfilLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.detallePerfilLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.detallePerfilLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detallePerfilLayoutPanel.Size = new System.Drawing.Size(374, 410);
            this.detallePerfilLayoutPanel.TabIndex = 0;
            // 
            // idLayoutPanel
            // 
            this.idLayoutPanel.ColumnCount = 2;
            this.idLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.idLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.idLayoutPanel.Controls.Add(this.idLabel, 0, 0);
            this.idLayoutPanel.Controls.Add(this.idDataLabel, 1, 0);
            this.idLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.idLayoutPanel.Name = "idLayoutPanel";
            this.idLayoutPanel.RowCount = 1;
            this.idLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.idLayoutPanel.Size = new System.Drawing.Size(364, 34);
            this.idLayoutPanel.TabIndex = 0;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idLabel.Location = new System.Drawing.Point(3, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(103, 34);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idDataLabel
            // 
            this.idDataLabel.AutoSize = true;
            this.idDataLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idDataLabel.Location = new System.Drawing.Point(112, 0);
            this.idDataLabel.Name = "idDataLabel";
            this.idDataLabel.Size = new System.Drawing.Size(249, 34);
            this.idDataLabel.TabIndex = 1;
            this.idDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nombreLayoutPanel
            // 
            this.nombreLayoutPanel.ColumnCount = 2;
            this.nombreLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.nombreLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.nombreLayoutPanel.Controls.Add(this.nombreLabel, 0, 0);
            this.nombreLayoutPanel.Controls.Add(this.nombreTextBox, 1, 0);
            this.nombreLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreLayoutPanel.Location = new System.Drawing.Point(5, 47);
            this.nombreLayoutPanel.Name = "nombreLayoutPanel";
            this.nombreLayoutPanel.RowCount = 1;
            this.nombreLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.nombreLayoutPanel.Size = new System.Drawing.Size(364, 34);
            this.nombreLayoutPanel.TabIndex = 1;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreLabel.Location = new System.Drawing.Point(3, 0);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(103, 34);
            this.nombreLabel.TabIndex = 0;
            this.nombreLabel.Text = "Nombre";
            this.nombreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nombreTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.nombreTextBox.Location = new System.Drawing.Point(112, 7);
            this.nombreTextBox.MaxLength = 32;
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(200, 20);
            this.nombreTextBox.TabIndex = 1;
            this.nombreTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nombreTextBox_Validating);
            this.nombreTextBox.Validated += new System.EventHandler(this.nombreTextBox_Validated);
            // 
            // permisosLayoutPanel
            // 
            this.permisosLayoutPanel.ColumnCount = 2;
            this.permisosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.permisosLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.permisosLayoutPanel.Controls.Add(this.funcionesLabel, 0, 0);
            this.permisosLayoutPanel.Controls.Add(this.permisosLabel, 0, 1);
            this.permisosLayoutPanel.Controls.Add(this.funcionesChecklistBox, 1, 0);
            this.permisosLayoutPanel.Controls.Add(this.permisosChecklistBox, 1, 1);
            this.permisosLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permisosLayoutPanel.Location = new System.Drawing.Point(5, 89);
            this.permisosLayoutPanel.Name = "permisosLayoutPanel";
            this.permisosLayoutPanel.RowCount = 2;
            this.permisosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.permisosLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.permisosLayoutPanel.Size = new System.Drawing.Size(364, 316);
            this.permisosLayoutPanel.TabIndex = 2;
            // 
            // funcionesLabel
            // 
            this.funcionesLabel.AutoSize = true;
            this.funcionesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funcionesLabel.Location = new System.Drawing.Point(3, 0);
            this.funcionesLabel.Name = "funcionesLabel";
            this.funcionesLabel.Size = new System.Drawing.Size(103, 158);
            this.funcionesLabel.TabIndex = 0;
            this.funcionesLabel.Text = "Funciones";
            this.funcionesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // permisosLabel
            // 
            this.permisosLabel.AutoSize = true;
            this.permisosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permisosLabel.Location = new System.Drawing.Point(3, 158);
            this.permisosLabel.Name = "permisosLabel";
            this.permisosLabel.Size = new System.Drawing.Size(103, 158);
            this.permisosLabel.TabIndex = 1;
            this.permisosLabel.Text = "Permisos";
            this.permisosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // funcionesChecklistBox
            // 
            this.funcionesChecklistBox.CheckOnClick = true;
            this.funcionesChecklistBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.funcionesChecklistBox.FormattingEnabled = true;
            this.funcionesChecklistBox.Items.AddRange(new object[] {
            "Notas",
            "Clientes",
            "Gastos",
            "Reportes",
            "Catálogos",
            "Descuentos",
            "Historial",
            "Usuarios",
            "Perfiles",
            "Ticket",
            "BaseDeDatos"});
            this.funcionesChecklistBox.Location = new System.Drawing.Point(112, 3);
            this.funcionesChecklistBox.Name = "funcionesChecklistBox";
            this.funcionesChecklistBox.Size = new System.Drawing.Size(200, 152);
            this.funcionesChecklistBox.TabIndex = 2;
            // 
            // permisosChecklistBox
            // 
            this.permisosChecklistBox.CheckOnClick = true;
            this.permisosChecklistBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.permisosChecklistBox.FormattingEnabled = true;
            this.permisosChecklistBox.Items.AddRange(new object[] {
            "Generar notas",
            "Editar notas",
            "Eliminar notas",
            "Generar gastos",
            "Admón. Gastos",
            "Admón. Clientes",
            "Admón. Catálogos",
            "Admón. Usuarios",
            "Admón. Perfiles"});
            this.permisosChecklistBox.Location = new System.Drawing.Point(112, 161);
            this.permisosChecklistBox.Name = "permisosChecklistBox";
            this.permisosChecklistBox.Size = new System.Drawing.Size(200, 152);
            this.permisosChecklistBox.TabIndex = 3;
            // 
            // DetallePerfil
            // 
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.detallePerfilLayoutPanel);
            this.Name = "DetallePerfil";
            this.Size = new System.Drawing.Size(374, 410);
            this.detallePerfilLayoutPanel.ResumeLayout(false);
            this.idLayoutPanel.ResumeLayout(false);
            this.idLayoutPanel.PerformLayout();
            this.nombreLayoutPanel.ResumeLayout(false);
            this.nombreLayoutPanel.PerformLayout();
            this.permisosLayoutPanel.ResumeLayout(false);
            this.permisosLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        /************************ EventListenners **************************/
        private void nombreTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(nombreTextBox.Text.Length > 32 || nombreTextBox.Text.Length == 0)
            {
                e.Cancel = true;
                nombreTextBox.Select(0, nombreTextBox.Text.Length);
                nombreTextBox.BackColor = System.Drawing.Color.Pink;
                _errorProvider.SetError(nombreTextBox,"Campo obligatorio. Debe contener menos de 32 caracteres.");
            }
            else
            {
                e.Cancel = false;
                _errorProvider.SetError(nombreTextBox, "");
            }
        }

        private void nombreTextBox_Validated(object sender, EventArgs e)
        {
            nombreTextBox.BackColor = SystemColors.Window;
        }
    }
}
