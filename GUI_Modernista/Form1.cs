using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GUI_Modernista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMaximizar.Visible = false;
            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnRestaurar.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = true;
        }

        private void BtnrpVentas_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void BtnrpCompras_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void BtnrpPagos_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AbrirFormHija(object formHija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }

        private void Btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new productos());
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new inicio());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnInicio_Click(null,e);
        }
    }
}
