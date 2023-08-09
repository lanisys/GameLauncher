using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GameLauncher
{
    public enum Panels { PanelDemarrage, PanelInstallation, PanelUpdate, PanelParametre, PanelCommunaute };
    public partial class frmLauncher : Form
    {
        #region Membre
        private long byteDebut, byteFin, byteTotal;
        private string total;
        private string mLocal;  // nom en local du fichier en cours de téléchargement
        // parametres du jeu
        string mParamPath;
        string mRepJeu = @"\exovival zombie"; // sous-repertoire obligatoire pour mettre le jeu
        int mMAJauto;
        bool mPlay;     // true si clic sur Jouer (false si installer)
        //
        private WebClient mWebClient;
        private Dynamic mFichier; // local
        private Dynamic mArboRef; // ref sur serveur
        private Dynamic mHoro;      // horodate serveur du fichier en cours téléchargement, pour mise a jour en local
        private int mNbRef, mIndRef;
        //
        // fonte specifique au launcher
        PrivateFontCollection mPfc;
        #endregion
        #region Form
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        public frmLauncher()
        {
            
            InitializeComponent();
            // met à dispo la fonte pour tous les labels
            mPfc = new PrivateFontCollection();
            //int fontLength = Properties.Resources.BAUHS93.Length;
            //byte[] fontdata = Properties.Resources.BAUHS93;
            int fontLength = Properties.Resources.SecularOneRegular.Length;
            byte[] fontdata = Properties.Resources.SecularOneRegular;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);
            mPfc.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);
            //Application.SetCompatibleTextRenderingDefault(true); // utile ??
        }
        private void frmLauncher_Load(object sender, EventArgs e)
        {
            lblPourcentage.Text = "";
            mFichier = new Dynamic();
            mArboRef = new Dynamic();
            mHoro = new Dynamic();
            mParamPath = "";
            mMAJauto = 0;
            // lecture des parametres du jeu dans la base de registre
            LectureParamJeu();
            //
            cmdJouer.Visible = (mParamPath != "");
            cmdInstaller.Visible = (mParamPath == "");
            chkMajAuto.Checked = (mMAJauto == 1);
            //
            panelDemarrage.Dock = DockStyle.Fill;
            panelInstallation.Dock = DockStyle.Fill;
            panelUpdate.Dock = DockStyle.Fill;
            panelParametre.Dock = DockStyle.Fill;
            panelCommunaute.Dock = DockStyle.Fill;
            //
            // changer la fonte de chaque label
            foreach(Control pan in this.Controls)
                foreach(Control ctr in pan.Controls)
                    if(ctr is Label)
                        // changer police
                        ((Label)ctr).Font = new Font(mPfc.Families[0], ((Label)ctr).Font.Size);
                    else if(ctr is Button)
                        ((Button)ctr).Font = new Font(mPfc.Families[0], ((Button)ctr).Font.Size);
            //
            AffPanel(Panels.PanelDemarrage);
        }
        private void frmLauncher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!panelInstallation.Visible)
                return;
            bool annuler = (MessageBox.Show("Etes-vous sûr d'annuler le téléchargement et de quitter ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            if (annuler)
            {
                if(mWebClient != null)
                    mWebClient.CancelAsync();
                //
                if (!mPlay)
                {
                    // install en cours : suppression des fichiers copies + base de registre
                    try
                    {
                        Directory.Delete(txtRepInstall.Text, true);
                    }
                    catch
                    { 
                    }
                    // suppression dans la base de registre
                    SuppressionParamJeu();
                }
            }
            //
            e.Cancel = !annuler;
        }
        private void frmLauncher_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            frmAPropos apropos = new frmAPropos();
            apropos.ShowDialog();
            e.Cancel = true;
        }
        #endregion
        #region Panels
        private void AffPanel(Panels panel)
        {
            panelDemarrage.Visible = (panel == Panels.PanelDemarrage);
            panelInstallation.Visible = (panel == Panels.PanelInstallation);
            panelUpdate.Visible = (panel == Panels.PanelUpdate);
            panelParametre.Visible = (panel == Panels.PanelParametre);
            panelCommunaute.Visible = (panel == Panels.PanelCommunaute);
        }
        private void cmdRetourUpdate_Click(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelDemarrage);
        }
        private void cmdRetourInstall_Click(object sender, EventArgs e)
        {
            bool annuler = true;
            try
            {
                annuler = (MessageBox.Show("Etes-vous sûr d'annuler le téléchargement et\r\nretourner au menu principal ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                if (annuler)
                {
                    if(mWebClient != null)
                        mWebClient.CancelAsync();
                    //
                    if(!mPlay)
                    {
                        // install en cours : suppression des fichiers copies + base de registre
                        Directory.Delete(txtRepInstall.Text, true);
                        // suppression dans la base de registre
                        SuppressionParamJeu();
                    }
                }
                else
                {
                    // ne pas revenir au menu principal
                    return;
                }
            }
            catch
            { }
            LectureParamJeu();
            cmdJouer.Visible = (mParamPath != "");
            cmdInstaller.Visible = (mParamPath == "");
            AffPanel(Panels.PanelDemarrage);
        }
        private void cmdRetourParam_Click(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelDemarrage);
        }
        private void cmdInstaller_Click(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelInstallation);
            mPlay = false;
            LireFichierRef();
            txtRepInstall.Text = mParamPath;
            if (txtRepInstall.Text == "")
                txtRepInstall.Text = "C:\\Program Files\\éx0tic Company";
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelUpdate);
        }
        private void cmdParam_Click(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelParametre);
            //Lnk lien = new Lnk();
            //string s = lien.GetFilename(@"C:\Users\Poupougne42\Desktop\raccourci.lnk");
            //MessageBox.Show(s);
        }
        private void cmdCommunaute_Click(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelCommunaute);
        }
        private void cmdQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdJouer_Click(object sender, EventArgs e)
        {
            int nbRef, nbLocal, pos, lgRacine;
            Dynamic tmpRef, tmpLocal;
            tmpRef = new Dynamic();
            tmpLocal = new Dynamic();
            lgRacine = mParamPath.Length;
            txtRepInstall.Text = mParamPath;
            mPlay = true;
            // lire les fichiers locaux et comparer aux fichiers de reference, si differences : telecharger la mise a jour
            mFichier.Let("");
            LireDossier(mParamPath);
            LireFichierRef();
            // comparer mFichier et mArbo
            nbLocal = mFichier.Dcount(Const.bFM);
            for (int iLocal = nbLocal; iLocal > 1; iLocal--)
            {
                mFichier.Field(Const.bFM, iLocal, ref tmpRef);
                pos = mArboRef.Locate(tmpRef.ToString().Substring(lgRacine).Replace('\\', '/'), Const.bFM);
                if (pos > 0)
                {
                    // fichiers identiques : supprimer de mArboRef et mFichier
                    mArboRef.Delete(pos);
                    mFichier.Delete(iLocal);
                }
            }
            if (mFichier.GetLen() == 0 && mArboRef.GetLen() == 0)
            {
                // local et serveur idem : pas de mise a jour a faire
                // lancer le jeu
                Jouer();
            }
            else
            {
                if (mMAJauto == 0)
                {
                    bool annuler = (MessageBox.Show("Les fichiers du jeu sont manquant / inexistant / obsolète.\r\nVoulez-vous ré-installer le jeu au dernier emplacement connu ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
                    if (annuler)
                        return;
                }
                // differences : mettre a jour avant de lancer le jeu
                // supprimer ce qui reste de mFichier : ne sert plus ou va etre mis a jour
                foreach (Dynamic fl in mFichier)
                {
                    fl.Field(Const.bPipe, 1, ref tmpLocal);
                    if(tmpLocal.GetLen() > 0)
                        File.Delete(tmpLocal.ToString());
                }
                nbRef = mArboRef.Dcount(Const.bFM);
                if (nbRef > 0)
                {
                    // charger/installer les fichiers restant de mArboRef
                    AffPanel(Panels.PanelInstallation);
                    txtRepInstall.Enabled = false;
                    cmdParcourir.Enabled = false;
                    cmdLancerInstal.Enabled = false;
                    //
                    // copie des fichiers + maj base de registre
                    lblProgression.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    lblNbFic.Visible = true;
                    lblPourcentage.Visible = true;
                    pbTelechargement.Visible = true;
                    //
                    mNbRef = nbRef;
                    mIndRef = 1;
                    Dynamic f = new Dynamic();
                    Dynamic tmp = new Dynamic();
                    //
                    mArboRef.Field(Const.bFM, mIndRef, ref tmp);
                    tmp.Field(Const.bPipe, 1, ref f);
                    tmp.Field(Const.bPipe, 2, ref mHoro);
                    // telecharger
                    DownloadFichier(f.ToString());
                }
                else
                {
                    Jouer();
                }
            }
        }
        #endregion
        #region FichiersLocaux
        private void cmdParcourir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRepInstall.Text = folderBrowserDialog1.SelectedPath; // recup chemin
            }
        }
        private void LireDossier(string repertoire)
        {
            try
            {
                foreach (string fichier in Directory.EnumerateFiles(repertoire))
                {
                    //FileInfo fi = new FileInfo(fichier); // fi.Length = taille en octets
                    mFichier.Concat(Const.cFM + fichier + Const.cPipe + File.GetLastWriteTime(fichier).ToString("yyyyMMddHHmmss"));
                }
                foreach (string fichier in Directory.EnumerateDirectories(repertoire))
                {
                    LireDossier(fichier);
                }
            }
            catch
            { }
        }
        #endregion
        #region BaseRegistre
        private void LectureParamJeu()
        {
            string path;
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
                    if (!(path is null))
                    {
                        mParamPath = path;
                    }
                    else
                    {
                        //valKey.SetValue("path", "c:\temp");
                        mParamPath = "";
                    }
                    //
                    if (valKey.GetValue("majauto") != null)
                    {
                        int tmp = (int)valKey.GetValue("majauto");
                        mMAJauto = tmp;
                    }
                    //
                    valKey.Close();
                }
            }
            catch
            { }
            finally
            {
                Nkey.Close();
            }
        }
        private void EcritureParamJeu()
        {
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
                    valKey.SetValue("path", mParamPath);
                    valKey.SetValue("majauto", mMAJauto);
                    //
                    valKey.Close();
                }
            }
            catch
            { }
            finally
            {
                Nkey.Close();
            }
        }
        private void SuppressionParamJeu()
        {
            RegistryKey Nkey = Registry.CurrentUser;
            try
            {
                RegistryKey valKey = Nkey.OpenSubKey("Software\\éx0tic\\exovival zombie", true);
                if (valKey != null)
                {
                    // liste des cle de registre du jeu :
                    // path => chemin complet du repertoire du jeu
                    // majauto => 0/1 si mise à jour automatique au lancement
                    //
                    valKey.DeleteValue("path");
                    valKey.DeleteValue("majauto");
                    //
                    valKey.Close();
                }
            }
            catch
            { }
            finally
            {
                Nkey.Close();
            }
        }
        #endregion
        #region DownloadSync
        private void LireFichierRef()
        {
            try
            {
                var webClient = new WebClient();
                // lecture arbo.txt depuis la page php
                byte[] arr = webClient.DownloadData(new Uri("https://www.lanisys.fr/arbo.php"));
                mArboRef.Let(Encoding.GetEncoding(0).GetString(arr));
                mNbRef = mArboRef.Dcount(Const.bFM);
                mIndRef = 0;
            }
            catch
            {
                MessageBox.Show("Erreur réseau : vérifiez votre connexion internet et votre débit");
            }
        }
        #endregion
        #region DownloadAsync
        private void DownloadFichier(string fic)
        {
            byteDebut = 0;
            byteFin = 0;
            byteTotal = 0;
            total = "";
            string webfic = fic.Replace("/", "\\");
            string localfic = txtRepInstall.Text + fic;
            if (!Directory.Exists(Path.GetDirectoryName(localfic)))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localfic));
                }
                catch
                {
                    // erreur de droits UAC le plus souvent si on arrive ici...
                    MessageBox.Show("Erreur de création de répertoire sur le disque : " + Path.GetDirectoryName(localfic) + "\r\nMerci d'utiliser un répertoire non protégé par Windows\r\n(ne pas utiliser C:\\Program Files, etc.).", "Installation", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            mLocal = localfic;
            timer1.Enabled = true;
            //var webClient = new WebClient();
            mWebClient = new WebClient();
            mWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            mWebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            mWebClient.DownloadFileAsync(new Uri("https://www.lanisys.fr/Exovival%20Zombie/" + webfic), localfic);
            // Exovival Zombie Installeur 1.0.exe       index.html
            //
            // lecture arbo.txt
            //byte[] arr = webClient.DownloadData(new Uri("https://www.lanisys.fr/arbo.php"));
            //Dynamic arbo = new Dynamic();
            //arbo.Let(arr.ToString());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            long debit;
            if (byteDebut != byteFin)
            {
                debit = byteFin - byteDebut;
                label3.Text = FormatterNombre(debit) + "/s";
                label2.Text = FormatterNombre(byteFin) + " / " + total;
                byteDebut = byteFin;
            }
        }
        private void cmdLancerInstal_Click(object sender, EventArgs e)
        {
            int lg = txtRepInstall.Text.ToString().Length;
            if (lg > mRepJeu.Length && txtRepInstall.Text.ToString().Substring(lg - mRepJeu.Length) != mRepJeu)
                txtRepInstall.Text = txtRepInstall.Text + mRepJeu;
            //
            // copie des fichiers + maj base de registre
            lblProgression.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            lblNbFic.Visible = true;
            lblPourcentage.Visible = true;
            pbTelechargement.Visible = true;
            //
            mIndRef = 1;
            Dynamic f = new Dynamic();
            Dynamic tmp = new Dynamic();
            //
            mArboRef.Field(Const.bFM, mIndRef, ref tmp);
            tmp.Field(Const.bPipe, 1, ref f);
            tmp.Field(Const.bPipe, 2, ref mHoro);
            // telecharger
            DownloadFichier(f.ToString());
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbTelechargement.Value = e.ProgressPercentage;
            lblPourcentage.Text = e.ProgressPercentage.ToString() + " %";
            if (lblNbFic.Text == "")
            {
                lblNbFic.Text = mIndRef.ToString() + " / " + mNbRef.ToString();
            }
            byteFin = e.BytesReceived;
            if (byteTotal == 0)
            {
                byteTotal = e.TotalBytesToReceive;
                total = FormatterNombre(byteTotal);
            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            pbTelechargement.Value = 100;
            lblPourcentage.Text = pbTelechargement.Value.ToString() + " %";
            if (lblNbFic.Text == "")
            {
                lblNbFic.Text = mIndRef.ToString() + " / " + mNbRef.ToString();
            }
            if (byteTotal == 0)
            {
                byteTotal = byteFin;
                total = FormatterNombre(byteTotal);
            }
            byteFin = byteTotal;
            long debit;
            if (byteDebut != byteFin)
            {
                debit = byteFin - byteDebut;
                label3.Text = FormatterNombre(debit) + "/s";
                label2.Text = FormatterNombre(byteFin) + " / " + total;
                byteDebut = byteFin;
            }
            //
            timer1.Enabled = false;
            label2.Text = FormatterNombre(byteFin) + " / " + total;
            Application.DoEvents();
            // si arret, ne pas passer au fichier suivant
            if (e.Cancelled)
                return;
            // mettre a jour l'horodate du fichier telecharge
            File.SetLastWriteTime(mLocal, IconvDateTime(mHoro.ToString()));
            System.Threading.Thread.Sleep(100);
            // donwload la suite
            mIndRef++;
            lblNbFic.Text = "";
            if (mIndRef <= mNbRef)
            {
                Dynamic tmp = new Dynamic();
                Dynamic f = new Dynamic();
                mArboRef.Field(Const.bFM, mIndRef, ref tmp);
                tmp.Field((byte)'|', 1, ref f);
                tmp.Field((byte)'|', 2, ref mHoro);
                DownloadFichier(f.ToString());
            }
            else
            {
                // fin : mise à jour de la base de registre
                mParamPath = txtRepInstall.Text.ToString();
                EcritureParamJeu();
                //
                lblProgression.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                lblNbFic.Visible = false;
                lblPourcentage.Visible = false;
                pbTelechargement.Visible = false;
                //
                if (mPlay)
                {
                    cmdRetourInstall_Click(null, null);
                    Jouer();
                }
            }
        }

        private void chkMajAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMajAuto.CheckState == CheckState.Checked)
                mMAJauto = 1;
            else
                mMAJauto = 0;
            EcritureParamJeu();
        }
        private void cmdRetourCommunaute_Click_1(object sender, EventArgs e)
        {
            AffPanel(Panels.PanelDemarrage);
        }
        private string FormatterNombre(long nombre)
        {
            string resultat = "";
            //
            if (nombre < 1000)
                resultat = nombre.ToString() + " o";
            else if (nombre < 1000000)
                resultat = (nombre / 1000).ToString() + " Ko";
            else if (nombre < 1000000000)
                resultat = (nombre / 1000000).ToString() + "." + ((nombre / 1000000) % 10).ToString("0") + " Mo";
            else
                resultat = (nombre / 1000000000).ToString() + "." + ((nombre / 10000000) % 100).ToString("00") + " Go";
            //
            return resultat;
        }
        private DateTime IconvDateTime(string c)
        {
            int y, m, d, H, M, S;
            // c au format yyyymmddHHMMSS
            y = Int32.Parse(c.Substring(0, 4));
            m = Int32.Parse(c.Substring(4, 2));
            d = Int32.Parse(c.Substring(6, 2));
            H = Int32.Parse(c.Substring(8, 2));
            M = Int32.Parse(c.Substring(10, 2));
            S = Int32.Parse(c.Substring(12, 2));
            return new DateTime(y, m, d, H, M, S);
        }
        private void Jouer()
        {
            // lancer le jeu
            this.WindowState = FormWindowState.Minimized;
            try
            {
                Process.Start(mParamPath + Const.Exe);
            }
            catch
            {
                MessageBox.Show("Erreur au lancement du jeu : fichier introuvable " + mParamPath + Const.Exe);
            }
        }
        #endregion
    }
}