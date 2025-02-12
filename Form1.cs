using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanValentin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSI_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acepto Acepto = new Acepto();
            Acepto.Show();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rechazo Rechazo = new Rechazo();
            Rechazo.Show();

            // Definir el nombre del programa como variable
            string programToRun = "powershell.exe";

            // Ruta al archivo .ps1
            string scriptPath = @"C:\Users\cesar\Downloads\xd.ps1"; // Asegúrate de que la ruta sea correcta

            // Ejecutar PowerShell sin mostrar la consola
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = programToRun;
            startInfo.Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"";
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process.Start(startInfo);
        }
    }
}
