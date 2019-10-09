using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaPrenda.View.Abstract;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using VentaPrenda.DAO.Concrete;

namespace VentaPrenda.View.Concrete.Detalles
{
    public partial class DetalleBaseDeDatos : DetalleModelo
    {
        private static readonly string BackupsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Backups";

        public DetalleBaseDeDatos()
        {
            InitializeComponent();
            RefrescarListaDeArchivos();
        }

        private void RefrescarListaDeArchivos()
        {
            try
            {
                archivosListBox.Items.Clear();
                eliminarButton.Enabled = false;
                restaurarButton.Enabled = false;
                foreach (string file in Directory.GetFiles(BackupsPath))
                { archivosListBox.Items.Add(Path.GetFileName(file)); }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al leer la carpeta de respaldos.\n\n" + e.Message + "\n\nError: " + e.GetType(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void IniciarRespaldoButton_Click(object sender, EventArgs e)
        {
            string fileName = MySqlDbContext.Backup(BackupsPath);
            RefrescarListaDeArchivos();
            archivosListBox.SelectedItem = archivosListBox.Items.Contains(fileName) ? fileName : null;
        }

        public void RestaurarButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está a punto de restaurar la base de datos.\n\nSe perderá toda la información almacenada actualmente y será reemplazada por el contenido del siguiente archivo de respaldo: " + archivosListBox.SelectedItem + ".\n\n¿Desea continuar?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MySqlDbContext.Restore(BackupsPath + "\\" + archivosListBox.SelectedItem);
                    MessageBox.Show("Se restauró la base de datos.",
                            "Correcto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar restaurar la base de datos.\n\n" + ex.Message + "\n\nError: " + e.GetType(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se eliminará el archivo de respaldo " + archivosListBox.SelectedItem + "\n\n¿Estas seguro?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                File.Delete(BackupsPath + "\\" + archivosListBox.SelectedItem);
                RefrescarListaDeArchivos();
            }
        }

        private void ArchivosListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            eliminarButton.Enabled = archivosListBox.SelectedItem != null;
            restaurarButton.Enabled = archivosListBox.SelectedItem != null;

        }

        private void SeleccionarButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (MySqlDbContext.ValidateBackupFile(openFileDialog.FileName))
                {
                    try
                    { File.Copy(openFileDialog.FileName, BackupsPath + "\\" + Path.GetFileName(openFileDialog.FileName)); }
                    catch (IOException ioe)
                    {
                        MessageBox.Show("Ocurrió un error al copiar el archivo seleccionado.\n\n" + ioe.Message + "\n\nError: " + ioe.GetType(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no tiene el formato correcto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            RefrescarListaDeArchivos();
        }

        private void ArchivosButton_Click(object sender, EventArgs e)
        { Process.Start("explorer.exe", BackupsPath); }
    }
}
