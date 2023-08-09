using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncher
{
    public partial class frmAPropos : Form
    {
        public frmAPropos()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // envoi d'un mail
            System.Diagnostics.Process.Start("mailto:" + linkLabel1.Text);
        }

        private void frmAPropos_Load(object sender, EventArgs e)
        {
            label3.Text = label3.Text + Application.ProductVersion.ToString();
            string path = "";
            RegistryKey Nkey = Registry.CurrentUser;
            try
            {
                RegistryKey valKey = Nkey.OpenSubKey("Software\\éx0tic\\exovival zombie", true);
                if (valKey == null)
                {
                    Nkey.CreateSubKey("Software\\éx0tic\\exovival zombie");
                    valKey = Nkey.OpenSubKey("Software\\éx0tic\\exovival zombie", true);
                }
                if (valKey != null)
                {
                    // liste des cle de registre du jeu :
                    // path => chemin complet du repertoire du jeu
                    // majauto => 0/1 si mise à jour automatique au lancement
                    //
                    path = (string)valKey.GetValue("path");
                }
                if (!(path is null))
                    label4.Text = label4.Text + System.Diagnostics.FileVersionInfo.GetVersionInfo(path + Const.Exe).ProductVersion; // ou FileVersion
            }
            catch { }
            //label4.Text = label4.Text + System.Diagnostics.FileVersionInfo.GetVersionInfo(@"C:\Users\solac\Documents\Exovival Zombie\Game\Exovival Zombie\Exovival Zombie.exe").ProductVersion; // ou FileVersion
        }

    }
}
