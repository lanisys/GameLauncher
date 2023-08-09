namespace GameLauncher
{
    partial class frmLauncher
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panelInstallation = new System.Windows.Forms.Panel();
            this.cmdLancerInstal = new System.Windows.Forms.Button();
            this.cmdParcourir = new System.Windows.Forms.Button();
            this.txtRepInstall = new System.Windows.Forms.TextBox();
            this.lblTitre2 = new System.Windows.Forms.Label();
            this.lblProgression = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNbFic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPourcentage = new System.Windows.Forms.Label();
            this.pbTelechargement = new System.Windows.Forms.ProgressBar();
            this.cmdRetourInstall = new System.Windows.Forms.Button();
            this.panelDemarrage = new System.Windows.Forms.Panel();
            this.cmdCommunaute = new System.Windows.Forms.Button();
            this.cmdQuitter = new System.Windows.Forms.Button();
            this.cmdParam = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdInstaller = new System.Windows.Forms.Button();
            this.cmdJouer = new System.Windows.Forms.Button();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.chkMajAuto = new System.Windows.Forms.CheckBox();
            this.lblTitre3 = new System.Windows.Forms.Label();
            this.cmdRetourUpdate = new System.Windows.Forms.Button();
            this.panelParametre = new System.Windows.Forms.Panel();
            this.lblTitre4 = new System.Windows.Forms.Label();
            this.cmdRetourParam = new System.Windows.Forms.Button();
            this.panelCommunaute = new System.Windows.Forms.Panel();
            this.lblAvis = new System.Windows.Forms.Label();
            this.cmdDeclarerAnomalie = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.cmdRetourCommunaute = new System.Windows.Forms.Button();
            this.panelInstallation.SuspendLayout();
            this.panelDemarrage.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            this.panelParametre.SuspendLayout();
            this.panelCommunaute.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Choix du répertoire d\'installation d\'Exovival Zombie";
            // 
            // panelInstallation
            // 
            this.panelInstallation.Controls.Add(this.cmdLancerInstal);
            this.panelInstallation.Controls.Add(this.cmdParcourir);
            this.panelInstallation.Controls.Add(this.txtRepInstall);
            this.panelInstallation.Controls.Add(this.lblTitre2);
            this.panelInstallation.Controls.Add(this.lblProgression);
            this.panelInstallation.Controls.Add(this.label2);
            this.panelInstallation.Controls.Add(this.lblNbFic);
            this.panelInstallation.Controls.Add(this.label3);
            this.panelInstallation.Controls.Add(this.lblPourcentage);
            this.panelInstallation.Controls.Add(this.pbTelechargement);
            this.panelInstallation.Controls.Add(this.cmdRetourInstall);
            this.panelInstallation.Location = new System.Drawing.Point(280, 12);
            this.panelInstallation.Name = "panelInstallation";
            this.panelInstallation.Size = new System.Drawing.Size(282, 299);
            this.panelInstallation.TabIndex = 12;
            this.panelInstallation.Visible = false;
            // 
            // cmdLancerInstal
            // 
            this.cmdLancerInstal.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdLancerInstal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLancerInstal.Location = new System.Drawing.Point(0, 73);
            this.cmdLancerInstal.Name = "cmdLancerInstal";
            this.cmdLancerInstal.Size = new System.Drawing.Size(282, 30);
            this.cmdLancerInstal.TabIndex = 18;
            this.cmdLancerInstal.Text = "Installer";
            this.cmdLancerInstal.UseVisualStyleBackColor = true;
            this.cmdLancerInstal.Click += new System.EventHandler(this.cmdLancerInstal_Click);
            // 
            // cmdParcourir
            // 
            this.cmdParcourir.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdParcourir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdParcourir.Location = new System.Drawing.Point(0, 40);
            this.cmdParcourir.Name = "cmdParcourir";
            this.cmdParcourir.Size = new System.Drawing.Size(282, 33);
            this.cmdParcourir.TabIndex = 16;
            this.cmdParcourir.Text = "Parcourir";
            this.cmdParcourir.UseVisualStyleBackColor = true;
            this.cmdParcourir.Click += new System.EventHandler(this.cmdParcourir_Click);
            // 
            // txtRepInstall
            // 
            this.txtRepInstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRepInstall.Location = new System.Drawing.Point(0, 20);
            this.txtRepInstall.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtRepInstall.Name = "txtRepInstall";
            this.txtRepInstall.Size = new System.Drawing.Size(282, 20);
            this.txtRepInstall.TabIndex = 15;
            // 
            // lblTitre2
            // 
            this.lblTitre2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre2.Location = new System.Drawing.Point(0, 0);
            this.lblTitre2.Name = "lblTitre2";
            this.lblTitre2.Size = new System.Drawing.Size(282, 20);
            this.lblTitre2.TabIndex = 13;
            this.lblTitre2.Text = "Installation";
            this.lblTitre2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProgression
            // 
            this.lblProgression.BackColor = System.Drawing.Color.Transparent;
            this.lblProgression.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProgression.Location = new System.Drawing.Point(0, 176);
            this.lblProgression.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.lblProgression.Name = "lblProgression";
            this.lblProgression.Size = new System.Drawing.Size(282, 13);
            this.lblProgression.TabIndex = 9;
            this.lblProgression.Text = "Progression";
            this.lblProgression.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblProgression.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "0 / 0 Mo ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Visible = false;
            // 
            // lblNbFic
            // 
            this.lblNbFic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNbFic.Location = new System.Drawing.Point(0, 202);
            this.lblNbFic.Name = "lblNbFic";
            this.lblNbFic.Size = new System.Drawing.Size(282, 13);
            this.lblNbFic.TabIndex = 17;
            this.lblNbFic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNbFic.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "0 Mo/s";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Visible = false;
            // 
            // lblPourcentage
            // 
            this.lblPourcentage.BackColor = System.Drawing.Color.Transparent;
            this.lblPourcentage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPourcentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPourcentage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPourcentage.Location = new System.Drawing.Point(0, 228);
            this.lblPourcentage.Name = "lblPourcentage";
            this.lblPourcentage.Size = new System.Drawing.Size(282, 19);
            this.lblPourcentage.TabIndex = 8;
            this.lblPourcentage.Text = "%";
            this.lblPourcentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPourcentage.Visible = false;
            // 
            // pbTelechargement
            // 
            this.pbTelechargement.BackColor = System.Drawing.Color.Firebrick;
            this.pbTelechargement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTelechargement.ForeColor = System.Drawing.Color.White;
            this.pbTelechargement.Location = new System.Drawing.Point(0, 247);
            this.pbTelechargement.Name = "pbTelechargement";
            this.pbTelechargement.Size = new System.Drawing.Size(282, 19);
            this.pbTelechargement.Step = 1;
            this.pbTelechargement.TabIndex = 7;
            this.pbTelechargement.Visible = false;
            // 
            // cmdRetourInstall
            // 
            this.cmdRetourInstall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdRetourInstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.cmdRetourInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRetourInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRetourInstall.Location = new System.Drawing.Point(0, 266);
            this.cmdRetourInstall.Name = "cmdRetourInstall";
            this.cmdRetourInstall.Size = new System.Drawing.Size(282, 33);
            this.cmdRetourInstall.TabIndex = 6;
            this.cmdRetourInstall.Text = "Retour";
            this.cmdRetourInstall.UseVisualStyleBackColor = true;
            this.cmdRetourInstall.Click += new System.EventHandler(this.cmdRetourInstall_Click);
            // 
            // panelDemarrage
            // 
            this.panelDemarrage.Controls.Add(this.cmdCommunaute);
            this.panelDemarrage.Controls.Add(this.cmdQuitter);
            this.panelDemarrage.Controls.Add(this.cmdParam);
            this.panelDemarrage.Controls.Add(this.cmdUpdate);
            this.panelDemarrage.Controls.Add(this.cmdInstaller);
            this.panelDemarrage.Controls.Add(this.cmdJouer);
            this.panelDemarrage.Location = new System.Drawing.Point(12, 12);
            this.panelDemarrage.Name = "panelDemarrage";
            this.panelDemarrage.Size = new System.Drawing.Size(274, 299);
            this.panelDemarrage.TabIndex = 13;
            // 
            // cmdCommunaute
            // 
            this.cmdCommunaute.BackColor = System.Drawing.Color.Transparent;
            this.cmdCommunaute.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdCommunaute.FlatAppearance.BorderSize = 0;
            this.cmdCommunaute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCommunaute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCommunaute.Image = ((System.Drawing.Image)(resources.GetObject("cmdCommunaute.Image")));
            this.cmdCommunaute.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCommunaute.Location = new System.Drawing.Point(0, 373);
            this.cmdCommunaute.Name = "cmdCommunaute";
            this.cmdCommunaute.Size = new System.Drawing.Size(274, 91);
            this.cmdCommunaute.TabIndex = 15;
            this.cmdCommunaute.Text = "Communauté";
            this.cmdCommunaute.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCommunaute.UseVisualStyleBackColor = false;
            this.cmdCommunaute.Click += new System.EventHandler(this.cmdCommunaute_Click);
            // 
            // cmdQuitter
            // 
            this.cmdQuitter.BackColor = System.Drawing.Color.Firebrick;
            this.cmdQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cmdQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuitter.ForeColor = System.Drawing.Color.White;
            this.cmdQuitter.Location = new System.Drawing.Point(0, 254);
            this.cmdQuitter.Name = "cmdQuitter";
            this.cmdQuitter.Size = new System.Drawing.Size(274, 45);
            this.cmdQuitter.TabIndex = 14;
            this.cmdQuitter.Text = "Quitter";
            this.cmdQuitter.UseVisualStyleBackColor = false;
            this.cmdQuitter.Click += new System.EventHandler(this.cmdQuitter_Click);
            // 
            // cmdParam
            // 
            this.cmdParam.BackColor = System.Drawing.Color.Transparent;
            this.cmdParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdParam.FlatAppearance.BorderSize = 0;
            this.cmdParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdParam.Image = ((System.Drawing.Image)(resources.GetObject("cmdParam.Image")));
            this.cmdParam.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdParam.Location = new System.Drawing.Point(0, 282);
            this.cmdParam.Name = "cmdParam";
            this.cmdParam.Size = new System.Drawing.Size(274, 91);
            this.cmdParam.TabIndex = 13;
            this.cmdParam.Text = "Paramètres";
            this.cmdParam.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdParam.UseVisualStyleBackColor = false;
            this.cmdParam.Click += new System.EventHandler(this.cmdParam_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.BackColor = System.Drawing.Color.Transparent;
            this.cmdUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdUpdate.FlatAppearance.BorderSize = 0;
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
            this.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdUpdate.Location = new System.Drawing.Point(0, 191);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(274, 91);
            this.cmdUpdate.TabIndex = 12;
            this.cmdUpdate.Text = "Propriétés du jeu";
            this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdUpdate.UseVisualStyleBackColor = false;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdInstaller
            // 
            this.cmdInstaller.BackColor = System.Drawing.Color.Transparent;
            this.cmdInstaller.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdInstaller.FlatAppearance.BorderSize = 0;
            this.cmdInstaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInstaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInstaller.Image = ((System.Drawing.Image)(resources.GetObject("cmdInstaller.Image")));
            this.cmdInstaller.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdInstaller.Location = new System.Drawing.Point(0, 95);
            this.cmdInstaller.Name = "cmdInstaller";
            this.cmdInstaller.Size = new System.Drawing.Size(274, 96);
            this.cmdInstaller.TabIndex = 11;
            this.cmdInstaller.Text = "Installer";
            this.cmdInstaller.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdInstaller.UseVisualStyleBackColor = false;
            this.cmdInstaller.Click += new System.EventHandler(this.cmdInstaller_Click);
            // 
            // cmdJouer
            // 
            this.cmdJouer.BackColor = System.Drawing.Color.Transparent;
            this.cmdJouer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdJouer.FlatAppearance.BorderSize = 0;
            this.cmdJouer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdJouer.Image = ((System.Drawing.Image)(resources.GetObject("cmdJouer.Image")));
            this.cmdJouer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdJouer.Location = new System.Drawing.Point(0, 0);
            this.cmdJouer.Name = "cmdJouer";
            this.cmdJouer.Size = new System.Drawing.Size(274, 95);
            this.cmdJouer.TabIndex = 10;
            this.cmdJouer.Text = "Jouer";
            this.cmdJouer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdJouer.UseVisualStyleBackColor = false;
            this.cmdJouer.Click += new System.EventHandler(this.cmdJouer_Click);
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.chkMajAuto);
            this.panelUpdate.Controls.Add(this.lblTitre3);
            this.panelUpdate.Controls.Add(this.cmdRetourUpdate);
            this.panelUpdate.Location = new System.Drawing.Point(17, 317);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(240, 134);
            this.panelUpdate.TabIndex = 14;
            // 
            // chkMajAuto
            // 
            this.chkMajAuto.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMajAuto.AutoSize = true;
            this.chkMajAuto.BackColor = System.Drawing.SystemColors.Control;
            this.chkMajAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkMajAuto.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chkMajAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMajAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMajAuto.Location = new System.Drawing.Point(0, 20);
            this.chkMajAuto.Name = "chkMajAuto";
            this.chkMajAuto.Size = new System.Drawing.Size(240, 30);
            this.chkMajAuto.TabIndex = 15;
            this.chkMajAuto.Text = "Mise à jour automatique";
            this.chkMajAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMajAuto.UseVisualStyleBackColor = false;
            this.chkMajAuto.CheckedChanged += new System.EventHandler(this.chkMajAuto_CheckedChanged);
            // 
            // lblTitre3
            // 
            this.lblTitre3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitre3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre3.Location = new System.Drawing.Point(0, 0);
            this.lblTitre3.Name = "lblTitre3";
            this.lblTitre3.Size = new System.Drawing.Size(240, 20);
            this.lblTitre3.TabIndex = 14;
            this.lblTitre3.Text = "Propriétés du jeu";
            this.lblTitre3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdRetourUpdate
            // 
            this.cmdRetourUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdRetourUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.cmdRetourUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRetourUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRetourUpdate.Location = new System.Drawing.Point(0, 101);
            this.cmdRetourUpdate.Name = "cmdRetourUpdate";
            this.cmdRetourUpdate.Size = new System.Drawing.Size(240, 33);
            this.cmdRetourUpdate.TabIndex = 0;
            this.cmdRetourUpdate.Text = "Retour";
            this.cmdRetourUpdate.UseVisualStyleBackColor = true;
            this.cmdRetourUpdate.Click += new System.EventHandler(this.cmdRetourUpdate_Click);
            // 
            // panelParametre
            // 
            this.panelParametre.Controls.Add(this.lblTitre4);
            this.panelParametre.Controls.Add(this.cmdRetourParam);
            this.panelParametre.Location = new System.Drawing.Point(280, 317);
            this.panelParametre.Name = "panelParametre";
            this.panelParametre.Size = new System.Drawing.Size(216, 134);
            this.panelParametre.TabIndex = 15;
            // 
            // lblTitre4
            // 
            this.lblTitre4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitre4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre4.Location = new System.Drawing.Point(0, 0);
            this.lblTitre4.Name = "lblTitre4";
            this.lblTitre4.Size = new System.Drawing.Size(216, 20);
            this.lblTitre4.TabIndex = 15;
            this.lblTitre4.Text = "Paramètres";
            this.lblTitre4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdRetourParam
            // 
            this.cmdRetourParam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdRetourParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.cmdRetourParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRetourParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRetourParam.Location = new System.Drawing.Point(0, 101);
            this.cmdRetourParam.Name = "cmdRetourParam";
            this.cmdRetourParam.Size = new System.Drawing.Size(216, 33);
            this.cmdRetourParam.TabIndex = 1;
            this.cmdRetourParam.Text = "Retour";
            this.cmdRetourParam.UseVisualStyleBackColor = true;
            this.cmdRetourParam.Click += new System.EventHandler(this.cmdRetourParam_Click);
            // 
            // panelCommunaute
            // 
            this.panelCommunaute.Controls.Add(this.lblAvis);
            this.panelCommunaute.Controls.Add(this.cmdDeclarerAnomalie);
            this.panelCommunaute.Controls.Add(this.lblTitre);
            this.panelCommunaute.Controls.Add(this.cmdRetourCommunaute);
            this.panelCommunaute.Location = new System.Drawing.Point(502, 317);
            this.panelCommunaute.Name = "panelCommunaute";
            this.panelCommunaute.Size = new System.Drawing.Size(216, 134);
            this.panelCommunaute.TabIndex = 16;
            // 
            // lblAvis
            // 
            this.lblAvis.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvis.Location = new System.Drawing.Point(0, 53);
            this.lblAvis.Name = "lblAvis";
            this.lblAvis.Size = new System.Drawing.Size(216, 20);
            this.lblAvis.TabIndex = 18;
            this.lblAvis.Text = "Liste des avis";
            this.lblAvis.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdDeclarerAnomalie
            // 
            this.cmdDeclarerAnomalie.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdDeclarerAnomalie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeclarerAnomalie.Location = new System.Drawing.Point(0, 20);
            this.cmdDeclarerAnomalie.Name = "cmdDeclarerAnomalie";
            this.cmdDeclarerAnomalie.Size = new System.Drawing.Size(216, 33);
            this.cmdDeclarerAnomalie.TabIndex = 17;
            this.cmdDeclarerAnomalie.Text = "Déclarer une anomalie";
            this.cmdDeclarerAnomalie.UseVisualStyleBackColor = true;
            // 
            // lblTitre
            // 
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(0, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(216, 20);
            this.lblTitre.TabIndex = 15;
            this.lblTitre.Text = "Communauté";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdRetourCommunaute
            // 
            this.cmdRetourCommunaute.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdRetourCommunaute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.cmdRetourCommunaute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRetourCommunaute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRetourCommunaute.Location = new System.Drawing.Point(0, 101);
            this.cmdRetourCommunaute.Name = "cmdRetourCommunaute";
            this.cmdRetourCommunaute.Size = new System.Drawing.Size(216, 33);
            this.cmdRetourCommunaute.TabIndex = 1;
            this.cmdRetourCommunaute.Text = "Retour";
            this.cmdRetourCommunaute.UseVisualStyleBackColor = true;
            this.cmdRetourCommunaute.Click += new System.EventHandler(this.cmdRetourCommunaute_Click_1);
            // 
            // frmLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 463);
            this.Controls.Add(this.panelCommunaute);
            this.Controls.Add(this.panelParametre);
            this.Controls.Add(this.panelUpdate);
            this.Controls.Add(this.panelDemarrage);
            this.Controls.Add(this.panelInstallation);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exovival Zombie Launcher";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmLauncher_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLauncher_FormClosing);
            this.Load += new System.EventHandler(this.frmLauncher_Load);
            this.panelInstallation.ResumeLayout(false);
            this.panelInstallation.PerformLayout();
            this.panelDemarrage.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.panelParametre.ResumeLayout(false);
            this.panelCommunaute.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panelInstallation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProgression;
        private System.Windows.Forms.Label lblPourcentage;
        private System.Windows.Forms.ProgressBar pbTelechargement;
        private System.Windows.Forms.Panel panelDemarrage;
        private System.Windows.Forms.Button cmdInstaller;
        private System.Windows.Forms.Button cmdJouer;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.Button cmdRetourUpdate;
        private System.Windows.Forms.Panel panelParametre;
        private System.Windows.Forms.Button cmdRetourParam;
        private System.Windows.Forms.Button cmdRetourInstall;
        private System.Windows.Forms.Button cmdParam;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Label lblTitre2;
        private System.Windows.Forms.Label lblTitre3;
        private System.Windows.Forms.Label lblTitre4;
        private System.Windows.Forms.Button cmdQuitter;
        private System.Windows.Forms.Button cmdLancerInstal;
        private System.Windows.Forms.TextBox txtRepInstall;
        private System.Windows.Forms.Button cmdParcourir;
        private System.Windows.Forms.Label lblNbFic;
        private System.Windows.Forms.CheckBox chkMajAuto;
        private System.Windows.Forms.Button cmdCommunaute;
        private System.Windows.Forms.Panel panelCommunaute;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button cmdRetourCommunaute;
        private System.Windows.Forms.Button cmdDeclarerAnomalie;
        private System.Windows.Forms.Label lblAvis;
    }
}

