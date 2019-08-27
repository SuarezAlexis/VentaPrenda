namespace VentaPrenda.View.Concrete
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.functionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NotasButton = new System.Windows.Forms.Button();
            this.ClientesButton = new System.Windows.Forms.Button();
            this.GastosButton = new System.Windows.Forms.Button();
            this.ReportesButton = new System.Windows.Forms.Button();
            this.HistorialButton = new System.Windows.Forms.Button();
            this.ArreglosButton = new System.Windows.Forms.Button();
            this.DescuentosButton = new System.Windows.Forms.Button();
            this.UsuariosButton = new System.Windows.Forms.Button();
            this.PerfilesButton = new System.Windows.Forms.Button();
            this.secondaryLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.busquedaBox = new System.Windows.Forms.GroupBox();
            this.busquedaLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BusquedaTextBox = new System.Windows.Forms.TextBox();
            this.BusquedaButton = new System.Windows.Forms.Button();
            this.edicionBox = new System.Windows.Forms.GroupBox();
            this.edicionLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.RegresarButton = new System.Windows.Forms.Button();
            this.EditarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listaBox = new System.Windows.Forms.GroupBox();
            this.listGridView = new System.Windows.Forms.DataGridView();
            this.detalleBox = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.fechaLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.usuarioLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.modoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.objetoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.infoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.operationButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.configLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adminLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ColoresButton = new System.Windows.Forms.Button();
            this.PrendasButton = new System.Windows.Forms.Button();
            this.TiposButton = new System.Windows.Forms.Button();
            this.MainLayoutPanel.SuspendLayout();
            this.functionsLayoutPanel.SuspendLayout();
            this.secondaryLayoutPanel.SuspendLayout();
            this.busquedaBox.SuspendLayout();
            this.busquedaLayoutPanel.SuspendLayout();
            this.edicionBox.SuspendLayout();
            this.edicionLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.listaBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.operationButtonsLayoutPanel.SuspendLayout();
            this.configLayoutPanel.SuspendLayout();
            this.adminLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.CausesValidation = false;
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.Controls.Add(this.functionsLayoutPanel, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.secondaryLayoutPanel, 0, 1);
            this.MainLayoutPanel.Controls.Add(this.splitContainer, 0, 2);
            this.MainLayoutPanel.Controls.Add(this.statusStrip, 0, 3);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 4;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(1080, 681);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // functionsLayoutPanel
            // 
            this.functionsLayoutPanel.CausesValidation = false;
            this.functionsLayoutPanel.ColumnCount = 3;
            this.functionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00013F));
            this.functionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.99992F));
            this.functionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.99996F));
            this.functionsLayoutPanel.Controls.Add(this.adminLayoutPanel, 2, 0);
            this.functionsLayoutPanel.Controls.Add(this.operationButtonsLayoutPanel, 0, 0);
            this.functionsLayoutPanel.Controls.Add(this.configLayoutPanel, 1, 0);
            this.functionsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.functionsLayoutPanel.Name = "functionsLayoutPanel";
            this.functionsLayoutPanel.RowCount = 1;
            this.functionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.functionsLayoutPanel.Size = new System.Drawing.Size(1074, 64);
            this.functionsLayoutPanel.TabIndex = 0;
            // 
            // NotasButton
            // 
            this.NotasButton.CausesValidation = false;
            this.NotasButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotasButton.Location = new System.Drawing.Point(3, 3);
            this.NotasButton.Name = "NotasButton";
            this.NotasButton.Size = new System.Drawing.Size(100, 52);
            this.NotasButton.TabIndex = 0;
            this.NotasButton.Text = "Notas";
            this.NotasButton.UseVisualStyleBackColor = true;
            this.NotasButton.Click += new System.EventHandler(this.NotasButton_Click);
            // 
            // ClientesButton
            // 
            this.ClientesButton.CausesValidation = false;
            this.ClientesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientesButton.Location = new System.Drawing.Point(109, 3);
            this.ClientesButton.Name = "ClientesButton";
            this.ClientesButton.Size = new System.Drawing.Size(100, 52);
            this.ClientesButton.TabIndex = 1;
            this.ClientesButton.Text = "Clientes";
            this.ClientesButton.UseVisualStyleBackColor = true;
            this.ClientesButton.Click += new System.EventHandler(this.ClientesButton_Click);
            // 
            // GastosButton
            // 
            this.GastosButton.CausesValidation = false;
            this.GastosButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GastosButton.Location = new System.Drawing.Point(215, 3);
            this.GastosButton.Name = "GastosButton";
            this.GastosButton.Size = new System.Drawing.Size(100, 52);
            this.GastosButton.TabIndex = 2;
            this.GastosButton.Text = "Gastos";
            this.GastosButton.UseVisualStyleBackColor = true;
            this.GastosButton.Click += new System.EventHandler(this.GastosButton_Click);
            // 
            // ReportesButton
            // 
            this.ReportesButton.CausesValidation = false;
            this.ReportesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportesButton.Location = new System.Drawing.Point(321, 3);
            this.ReportesButton.Name = "ReportesButton";
            this.ReportesButton.Size = new System.Drawing.Size(100, 52);
            this.ReportesButton.TabIndex = 3;
            this.ReportesButton.Text = "Reportes";
            this.ReportesButton.UseVisualStyleBackColor = true;
            this.ReportesButton.Click += new System.EventHandler(this.ReportesButton_Click);
            // 
            // HistorialButton
            // 
            this.HistorialButton.CausesValidation = false;
            this.HistorialButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistorialButton.Location = new System.Drawing.Point(427, 3);
            this.HistorialButton.Name = "HistorialButton";
            this.HistorialButton.Size = new System.Drawing.Size(101, 52);
            this.HistorialButton.TabIndex = 4;
            this.HistorialButton.Text = "Historial";
            this.HistorialButton.UseVisualStyleBackColor = true;
            this.HistorialButton.Click += new System.EventHandler(this.HistorialButton_Click);
            // 
            // ArreglosButton
            // 
            this.ArreglosButton.CausesValidation = false;
            this.ArreglosButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArreglosButton.Location = new System.Drawing.Point(3, 3);
            this.ArreglosButton.Name = "ArreglosButton";
            this.ArreglosButton.Size = new System.Drawing.Size(109, 23);
            this.ArreglosButton.TabIndex = 6;
            this.ArreglosButton.Text = "Arreglos";
            this.ArreglosButton.UseVisualStyleBackColor = true;
            this.ArreglosButton.Click += new System.EventHandler(this.ArreglosButton_Click);
            // 
            // DescuentosButton
            // 
            this.DescuentosButton.CausesValidation = false;
            this.DescuentosButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescuentosButton.Location = new System.Drawing.Point(3, 32);
            this.DescuentosButton.Name = "DescuentosButton";
            this.DescuentosButton.Size = new System.Drawing.Size(109, 23);
            this.DescuentosButton.TabIndex = 7;
            this.DescuentosButton.Text = "Descruentos";
            this.DescuentosButton.UseVisualStyleBackColor = true;
            this.DescuentosButton.Click += new System.EventHandler(this.DescuentosButton_Click);
            // 
            // UsuariosButton
            // 
            this.UsuariosButton.CausesValidation = false;
            this.UsuariosButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuariosButton.Location = new System.Drawing.Point(3, 3);
            this.UsuariosButton.Name = "UsuariosButton";
            this.UsuariosButton.Size = new System.Drawing.Size(82, 23);
            this.UsuariosButton.TabIndex = 8;
            this.UsuariosButton.Text = "Usuarios";
            this.UsuariosButton.UseVisualStyleBackColor = true;
            this.UsuariosButton.Click += new System.EventHandler(this.UsuariosButton_Click);
            // 
            // PerfilesButton
            // 
            this.PerfilesButton.CausesValidation = false;
            this.PerfilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PerfilesButton.Location = new System.Drawing.Point(3, 32);
            this.PerfilesButton.Name = "PerfilesButton";
            this.PerfilesButton.Size = new System.Drawing.Size(82, 23);
            this.PerfilesButton.TabIndex = 9;
            this.PerfilesButton.Text = "Perfiles";
            this.PerfilesButton.UseVisualStyleBackColor = true;
            this.PerfilesButton.Click += new System.EventHandler(this.PerfilesButton_Click);
            // 
            // secondaryLayoutPanel
            // 
            this.secondaryLayoutPanel.CausesValidation = false;
            this.secondaryLayoutPanel.ColumnCount = 2;
            this.secondaryLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secondaryLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secondaryLayoutPanel.Controls.Add(this.busquedaBox, 0, 0);
            this.secondaryLayoutPanel.Controls.Add(this.edicionBox, 1, 0);
            this.secondaryLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryLayoutPanel.Location = new System.Drawing.Point(3, 73);
            this.secondaryLayoutPanel.Name = "secondaryLayoutPanel";
            this.secondaryLayoutPanel.RowCount = 1;
            this.secondaryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secondaryLayoutPanel.Size = new System.Drawing.Size(1074, 84);
            this.secondaryLayoutPanel.TabIndex = 1;
            // 
            // busquedaBox
            // 
            this.busquedaBox.Controls.Add(this.busquedaLayoutPanel);
            this.busquedaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busquedaBox.Location = new System.Drawing.Point(3, 3);
            this.busquedaBox.Name = "busquedaBox";
            this.busquedaBox.Size = new System.Drawing.Size(531, 78);
            this.busquedaBox.TabIndex = 0;
            this.busquedaBox.TabStop = false;
            this.busquedaBox.Text = "Búsqueda";
            // 
            // busquedaLayoutPanel
            // 
            this.busquedaLayoutPanel.ColumnCount = 2;
            this.busquedaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.busquedaLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.busquedaLayoutPanel.Controls.Add(this.BusquedaTextBox, 0, 0);
            this.busquedaLayoutPanel.Controls.Add(this.BusquedaButton, 1, 0);
            this.busquedaLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busquedaLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.busquedaLayoutPanel.Name = "busquedaLayoutPanel";
            this.busquedaLayoutPanel.RowCount = 1;
            this.busquedaLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.busquedaLayoutPanel.Size = new System.Drawing.Size(525, 59);
            this.busquedaLayoutPanel.TabIndex = 0;
            // 
            // BusquedaTextBox
            // 
            this.BusquedaTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BusquedaTextBox.Location = new System.Drawing.Point(64, 19);
            this.BusquedaTextBox.Name = "BusquedaTextBox";
            this.BusquedaTextBox.Size = new System.Drawing.Size(213, 20);
            this.BusquedaTextBox.TabIndex = 0;
            // 
            // BusquedaButton
            // 
            this.BusquedaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BusquedaButton.Location = new System.Drawing.Point(395, 18);
            this.BusquedaButton.Name = "BusquedaButton";
            this.BusquedaButton.Size = new System.Drawing.Size(75, 23);
            this.BusquedaButton.TabIndex = 1;
            this.BusquedaButton.Text = "Buscar";
            this.BusquedaButton.UseVisualStyleBackColor = true;
            // 
            // edicionBox
            // 
            this.edicionBox.CausesValidation = false;
            this.edicionBox.Controls.Add(this.edicionLayoutPanel);
            this.edicionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edicionBox.Location = new System.Drawing.Point(540, 3);
            this.edicionBox.Name = "edicionBox";
            this.edicionBox.Size = new System.Drawing.Size(531, 78);
            this.edicionBox.TabIndex = 1;
            this.edicionBox.TabStop = false;
            this.edicionBox.Text = "Edición";
            // 
            // edicionLayoutPanel
            // 
            this.edicionLayoutPanel.CausesValidation = false;
            this.edicionLayoutPanel.ColumnCount = 6;
            this.edicionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.edicionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.edicionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.edicionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.edicionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.edicionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.edicionLayoutPanel.Controls.Add(this.NuevoButton, 1, 0);
            this.edicionLayoutPanel.Controls.Add(this.RegresarButton, 0, 0);
            this.edicionLayoutPanel.Controls.Add(this.EditarButton, 2, 0);
            this.edicionLayoutPanel.Controls.Add(this.GuardarButton, 3, 0);
            this.edicionLayoutPanel.Controls.Add(this.EliminarButton, 4, 0);
            this.edicionLayoutPanel.Controls.Add(this.LimpiarButton, 5, 0);
            this.edicionLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edicionLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.edicionLayoutPanel.Name = "edicionLayoutPanel";
            this.edicionLayoutPanel.RowCount = 1;
            this.edicionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.edicionLayoutPanel.Size = new System.Drawing.Size(525, 59);
            this.edicionLayoutPanel.TabIndex = 0;
            // 
            // NuevoButton
            // 
            this.NuevoButton.CausesValidation = false;
            this.NuevoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NuevoButton.Location = new System.Drawing.Point(90, 3);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(81, 53);
            this.NuevoButton.TabIndex = 1;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // RegresarButton
            // 
            this.RegresarButton.CausesValidation = false;
            this.RegresarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegresarButton.Location = new System.Drawing.Point(3, 3);
            this.RegresarButton.Name = "RegresarButton";
            this.RegresarButton.Size = new System.Drawing.Size(81, 53);
            this.RegresarButton.TabIndex = 0;
            this.RegresarButton.Text = "Regresar";
            this.RegresarButton.UseVisualStyleBackColor = true;
            this.RegresarButton.Click += new System.EventHandler(this.RegresarButton_Click);
            // 
            // EditarButton
            // 
            this.EditarButton.CausesValidation = false;
            this.EditarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditarButton.Location = new System.Drawing.Point(177, 3);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(81, 53);
            this.EditarButton.TabIndex = 2;
            this.EditarButton.Text = "Editar";
            this.EditarButton.UseVisualStyleBackColor = true;
            this.EditarButton.Click += new System.EventHandler(this.EditarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GuardarButton.Location = new System.Drawing.Point(264, 3);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(81, 53);
            this.GuardarButton.TabIndex = 3;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // EliminarButton
            // 
            this.EliminarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EliminarButton.Location = new System.Drawing.Point(351, 3);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(81, 53);
            this.EliminarButton.TabIndex = 4;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.CausesValidation = false;
            this.LimpiarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimpiarButton.Location = new System.Drawing.Point(438, 3);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(84, 53);
            this.LimpiarButton.TabIndex = 5;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.CausesValidation = false;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(3, 163);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.CausesValidation = false;
            this.splitContainer.Panel1.Controls.Add(this.listaBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.CausesValidation = false;
            this.splitContainer.Panel2.Controls.Add(this.detalleBox);
            this.splitContainer.Size = new System.Drawing.Size(1074, 485);
            this.splitContainer.SplitterDistance = 536;
            this.splitContainer.TabIndex = 2;
            // 
            // listaBox
            // 
            this.listaBox.CausesValidation = false;
            this.listaBox.Controls.Add(this.listGridView);
            this.listaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaBox.Location = new System.Drawing.Point(0, 0);
            this.listaBox.Name = "listaBox";
            this.listaBox.Size = new System.Drawing.Size(536, 485);
            this.listaBox.TabIndex = 0;
            this.listaBox.TabStop = false;
            this.listaBox.Text = "Lista";
            // 
            // listGridView
            // 
            this.listGridView.AllowUserToAddRows = false;
            this.listGridView.AllowUserToDeleteRows = false;
            this.listGridView.AllowUserToOrderColumns = true;
            this.listGridView.AllowUserToResizeRows = false;
            this.listGridView.CausesValidation = false;
            this.listGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGridView.Location = new System.Drawing.Point(3, 16);
            this.listGridView.MultiSelect = false;
            this.listGridView.Name = "listGridView";
            this.listGridView.ReadOnly = true;
            this.listGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.listGridView.RowTemplate.ReadOnly = true;
            this.listGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listGridView.ShowEditingIcon = false;
            this.listGridView.Size = new System.Drawing.Size(530, 466);
            this.listGridView.TabIndex = 0;
            this.listGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListGridView_CellDoubleClick);
            // 
            // detalleBox
            // 
            this.detalleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalleBox.Location = new System.Drawing.Point(0, 0);
            this.detalleBox.Name = "detalleBox";
            this.detalleBox.Size = new System.Drawing.Size(534, 485);
            this.detalleBox.TabIndex = 0;
            this.detalleBox.TabStop = false;
            this.detalleBox.Text = "Detalle";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaLabel,
            this.usuarioLabel,
            this.modoLabel,
            this.objetoLabel,
            this.infoLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 657);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1080, 24);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // fechaLabel
            // 
            this.fechaLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.fechaLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.fechaLabel.Name = "fechaLabel";
            this.fechaLabel.Size = new System.Drawing.Size(81, 19);
            this.fechaLabel.Text = "dd/MM/aaaa";
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.usuarioLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(64, 19);
            this.usuarioLabel.Text = "Username";
            // 
            // modoLabel
            // 
            this.modoLabel.AutoSize = false;
            this.modoLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.modoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.modoLabel.Name = "modoLabel";
            this.modoLabel.Size = new System.Drawing.Size(100, 19);
            this.modoLabel.Text = "Modo";
            this.modoLabel.ToolTipText = "Modo de acceso";
            // 
            // objetoLabel
            // 
            this.objetoLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.objetoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.objetoLabel.Name = "objetoLabel";
            this.objetoLabel.Size = new System.Drawing.Size(47, 19);
            this.objetoLabel.Text = "Objeto";
            // 
            // infoLabel
            // 
            this.infoLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.infoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(48, 19);
            this.infoLabel.Text = "Estatus";
            this.infoLabel.ToolTipText = "Estado del registro seleccionado";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 200;
            this.errorProvider.ContainerControl = this;
            // 
            // operationButtonsLayoutPanel
            // 
            this.operationButtonsLayoutPanel.ColumnCount = 5;
            this.operationButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.operationButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.operationButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.operationButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.operationButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.operationButtonsLayoutPanel.Controls.Add(this.HistorialButton, 4, 0);
            this.operationButtonsLayoutPanel.Controls.Add(this.ReportesButton, 3, 0);
            this.operationButtonsLayoutPanel.Controls.Add(this.GastosButton, 2, 0);
            this.operationButtonsLayoutPanel.Controls.Add(this.ClientesButton, 1, 0);
            this.operationButtonsLayoutPanel.Controls.Add(this.NotasButton, 0, 0);
            this.operationButtonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationButtonsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.operationButtonsLayoutPanel.Name = "operationButtonsLayoutPanel";
            this.operationButtonsLayoutPanel.RowCount = 1;
            this.operationButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.operationButtonsLayoutPanel.Size = new System.Drawing.Size(531, 58);
            this.operationButtonsLayoutPanel.TabIndex = 0;
            // 
            // configLayoutPanel
            // 
            this.configLayoutPanel.ColumnCount = 3;
            this.configLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.configLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.configLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.configLayoutPanel.Controls.Add(this.ArreglosButton, 0, 0);
            this.configLayoutPanel.Controls.Add(this.DescuentosButton, 0, 1);
            this.configLayoutPanel.Controls.Add(this.PrendasButton, 1, 0);
            this.configLayoutPanel.Controls.Add(this.ColoresButton, 1, 1);
            this.configLayoutPanel.Controls.Add(this.TiposButton, 2, 0);
            this.configLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configLayoutPanel.Location = new System.Drawing.Point(540, 3);
            this.configLayoutPanel.Name = "configLayoutPanel";
            this.configLayoutPanel.RowCount = 2;
            this.configLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.configLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.configLayoutPanel.Size = new System.Drawing.Size(348, 58);
            this.configLayoutPanel.TabIndex = 1;
            // 
            // adminLayoutPanel
            // 
            this.adminLayoutPanel.ColumnCount = 2;
            this.adminLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33533F));
            this.adminLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33233F));
            this.adminLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33233F));
            this.adminLayoutPanel.Controls.Add(this.UsuariosButton, 0, 0);
            this.adminLayoutPanel.Controls.Add(this.PerfilesButton, 0, 1);
            this.adminLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminLayoutPanel.Location = new System.Drawing.Point(894, 3);
            this.adminLayoutPanel.Name = "adminLayoutPanel";
            this.adminLayoutPanel.RowCount = 2;
            this.adminLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.adminLayoutPanel.Size = new System.Drawing.Size(177, 58);
            this.adminLayoutPanel.TabIndex = 2;
            // 
            // ColoresButton
            // 
            this.ColoresButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColoresButton.Location = new System.Drawing.Point(118, 32);
            this.ColoresButton.Name = "ColoresButton";
            this.ColoresButton.Size = new System.Drawing.Size(109, 23);
            this.ColoresButton.TabIndex = 8;
            this.ColoresButton.Text = "Colores";
            this.ColoresButton.UseVisualStyleBackColor = true;
            this.ColoresButton.Click += new System.EventHandler(this.ColoresButton_Click);
            // 
            // PrendasButton
            // 
            this.PrendasButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrendasButton.Location = new System.Drawing.Point(118, 3);
            this.PrendasButton.Name = "PrendasButton";
            this.PrendasButton.Size = new System.Drawing.Size(109, 23);
            this.PrendasButton.TabIndex = 9;
            this.PrendasButton.Text = "Prendas";
            this.PrendasButton.UseVisualStyleBackColor = true;
            this.PrendasButton.Click += new System.EventHandler(this.PrendasButton_Click);
            // 
            // TiposButton
            // 
            this.TiposButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TiposButton.Location = new System.Drawing.Point(233, 3);
            this.TiposButton.Name = "TiposButton";
            this.TiposButton.Size = new System.Drawing.Size(112, 23);
            this.TiposButton.TabIndex = 10;
            this.TiposButton.Text = "Tipos de prenda";
            this.TiposButton.UseVisualStyleBackColor = true;
            this.TiposButton.Click += new System.EventHandler(this.TiposButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1080, 681);
            this.Controls.Add(this.MainLayoutPanel);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentaPrenda";
            this.MainLayoutPanel.ResumeLayout(false);
            this.MainLayoutPanel.PerformLayout();
            this.functionsLayoutPanel.ResumeLayout(false);
            this.secondaryLayoutPanel.ResumeLayout(false);
            this.busquedaBox.ResumeLayout(false);
            this.busquedaLayoutPanel.ResumeLayout(false);
            this.busquedaLayoutPanel.PerformLayout();
            this.edicionBox.ResumeLayout(false);
            this.edicionLayoutPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.listaBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.operationButtonsLayoutPanel.ResumeLayout(false);
            this.configLayoutPanel.ResumeLayout(false);
            this.adminLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel functionsLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel secondaryLayoutPanel;
        private System.Windows.Forms.GroupBox busquedaBox;
        private System.Windows.Forms.GroupBox edicionBox;
        private System.Windows.Forms.TableLayoutPanel busquedaLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel edicionLayoutPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox listaBox;
        private System.Windows.Forms.GroupBox detalleBox;
        private System.Windows.Forms.DataGridView listGridView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button NotasButton;
        private System.Windows.Forms.Button ClientesButton;
        private System.Windows.Forms.Button GastosButton;
        private System.Windows.Forms.Button ReportesButton;
        private System.Windows.Forms.Button HistorialButton;
        private System.Windows.Forms.Button ArreglosButton;
        private System.Windows.Forms.Button DescuentosButton;
        private System.Windows.Forms.Button UsuariosButton;
        private System.Windows.Forms.Button PerfilesButton;
        private System.Windows.Forms.TextBox BusquedaTextBox;
        private System.Windows.Forms.Button BusquedaButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Button RegresarButton;
        private System.Windows.Forms.Button EditarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.ToolStripStatusLabel usuarioLabel;
        private System.Windows.Forms.ToolStripStatusLabel fechaLabel;
        private System.Windows.Forms.ToolStripStatusLabel modoLabel;
        private System.Windows.Forms.ToolStripStatusLabel infoLabel;
        private System.Windows.Forms.ToolStripStatusLabel objetoLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TableLayoutPanel configLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel operationButtonsLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel adminLayoutPanel;
        private System.Windows.Forms.Button PrendasButton;
        private System.Windows.Forms.Button ColoresButton;
        private System.Windows.Forms.Button TiposButton;
    }
}