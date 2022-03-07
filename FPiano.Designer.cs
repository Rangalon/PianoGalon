
namespace PianoGalon
{
    partial class FPiano
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmsExercice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMidiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pbMusicScore = new System.Windows.Forms.PictureBox();
            this.pbPiano = new System.Windows.Forms.PictureBox();
            this.cmsProfils = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExercices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSave = new System.Windows.Forms.Timer(this.components);
            this.btnNext = new PianoGalon.KPathButton();
            this.btnPrev = new PianoGalon.KPathButton();
            this.btnClose = new PianoGalon.KPathButton();
            this.btnMinimize = new PianoGalon.KPathButton();
            this.kpButton = new PianoGalon.KProfilButton();
            this.keButton = new PianoGalon.KExerciceButton();
            this.kesButton = new PianoGalon.KExercicesButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsExercice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusicScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPiano)).BeginInit();
            this.cmsProfils.SuspendLayout();
            this.cmsExercices.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrev, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbMusicScore, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbPiano, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnMinimize, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kpButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.keButton, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.kesButton, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1725, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmsExercice
            // 
            this.cmsExercice.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsExercice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.importMidiToolStripMenuItem,
            this.newToolStripMenuItem2,
            this.editToolStripMenuItem1});
            this.cmsExercice.Name = "cmsExercice";
            this.cmsExercice.Size = new System.Drawing.Size(222, 116);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(221, 28);
            this.importToolStripMenuItem.Text = "Import  Mscx";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // importMidiToolStripMenuItem
            // 
            this.importMidiToolStripMenuItem.Name = "importMidiToolStripMenuItem";
            this.importMidiToolStripMenuItem.Size = new System.Drawing.Size(221, 28);
            this.importMidiToolStripMenuItem.Text = "Import Midi";
            this.importMidiToolStripMenuItem.Click += new System.EventHandler(this.importMidiToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(221, 28);
            this.newToolStripMenuItem2.Text = "New";
            this.newToolStripMenuItem2.Click += new System.EventHandler(this.newToolStripMenuItem2_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(221, 28);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // pbMusicScore
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbMusicScore, 8);
            this.pbMusicScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMusicScore.Location = new System.Drawing.Point(1, 78);
            this.pbMusicScore.Margin = new System.Windows.Forms.Padding(1);
            this.pbMusicScore.Name = "pbMusicScore";
            this.tableLayoutPanel1.SetRowSpan(this.pbMusicScore, 3);
            this.pbMusicScore.Size = new System.Drawing.Size(1723, 514);
            this.pbMusicScore.TabIndex = 2;
            this.pbMusicScore.TabStop = false;
            this.pbMusicScore.Click += new System.EventHandler(this.pbMusicScore_Click);
            this.pbMusicScore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMusicScore_MouseClick);
            // 
            // pbPiano
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbPiano, 8);
            this.pbPiano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPiano.Location = new System.Drawing.Point(1, 594);
            this.pbPiano.Margin = new System.Windows.Forms.Padding(1);
            this.pbPiano.Name = "pbPiano";
            this.pbPiano.Size = new System.Drawing.Size(1723, 173);
            this.pbPiano.TabIndex = 0;
            this.pbPiano.TabStop = false;
            // 
            // cmsProfils
            // 
            this.cmsProfils.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsProfils.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem});
            this.cmsProfils.Name = "cmsProfils";
            this.cmsProfils.Size = new System.Drawing.Size(194, 60);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.newToolStripMenuItem.Text = "New Profil";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cmsExercices
            // 
            this.cmsExercices.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsExercices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.newToolStripMenuItem1,
            this.editToolStripMenuItem2});
            this.cmsExercices.Name = "cmsExercices";
            this.cmsExercices.Size = new System.Drawing.Size(133, 88);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 28);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(132, 28);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(132, 28);
            this.editToolStripMenuItem2.Text = "Edit";
            this.editToolStripMenuItem2.Click += new System.EventHandler(this.editToolStripMenuItem2_Click);
            // 
            // tmrSave
            // 
            this.tmrSave.Enabled = true;
            this.tmrSave.Interval = 10000;
            this.tmrSave.Tick += new System.EventHandler(this.tmrSave_Tick);
            // 
            // btnNext
            // 
            this.btnNext.ButtonType = PianoGalon.KPathButton.EButtonType.Next;
            this.btnNext.Location = new System.Drawing.Point(1476, 1);
            this.btnNext.Margin = new System.Windows.Forms.Padding(1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 75);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "kImageButton2";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.ButtonType = PianoGalon.KPathButton.EButtonType.Prev;
            this.btnPrev.Location = new System.Drawing.Point(997, 1);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 75);
            this.btnPrev.TabIndex = 16;
            this.btnPrev.Text = "kImageButton2";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnClose
            // 
            this.btnClose.ButtonType = PianoGalon.KPathButton.EButtonType.Close;
            this.btnClose.Location = new System.Drawing.Point(1647, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 75);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "kImageButton2";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.ButtonType = PianoGalon.KPathButton.EButtonType.Minimize;
            this.btnMinimize.Location = new System.Drawing.Point(1, 1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 75);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.Text = "kImageButton1";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // kpButton
            // 
            this.kpButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kpButton.ContextMenuStrip = this.cmsProfils;
            this.kpButton.Location = new System.Drawing.Point(78, 1);
            this.kpButton.Margin = new System.Windows.Forms.Padding(1);
            this.kpButton.MaximumSize = new System.Drawing.Size(250, 75);
            this.kpButton.MinimumSize = new System.Drawing.Size(250, 75);
            this.kpButton.Name = "kpButton";
            this.kpButton.Profil = null;
            this.kpButton.Size = new System.Drawing.Size(250, 75);
            this.kpButton.TabIndex = 13;
            this.kpButton.Text = "kProfilButton1";
            this.kpButton.UseVisualStyleBackColor = true;
            this.kpButton.Click += new System.EventHandler(this.kProfilButton1_Click);
            // 
            // keButton
            // 
            this.keButton.Exercice = null;
            this.keButton.Location = new System.Drawing.Point(1074, 1);
            this.keButton.Margin = new System.Windows.Forms.Padding(1);
            this.keButton.MaximumSize = new System.Drawing.Size(400, 75);
            this.keButton.MinimumSize = new System.Drawing.Size(400, 75);
            this.keButton.Name = "keButton";
            this.keButton.Size = new System.Drawing.Size(400, 75);
            this.keButton.TabIndex = 14;
            this.keButton.Text = "kExerciceButton1";
            this.keButton.UseVisualStyleBackColor = true;
            this.keButton.Click += new System.EventHandler(this.kExerciceButton1_Click);
            // 
            // kesButton
            // 
            this.kesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kesButton.Exercices = null;
            this.kesButton.Location = new System.Drawing.Point(501, 1);
            this.kesButton.Margin = new System.Windows.Forms.Padding(1);
            this.kesButton.MaximumSize = new System.Drawing.Size(400, 75);
            this.kesButton.MinimumSize = new System.Drawing.Size(400, 75);
            this.kesButton.Name = "kesButton";
            this.kesButton.Size = new System.Drawing.Size(400, 75);
            this.kesButton.TabIndex = 15;
            this.kesButton.Text = "kExercicesButton1";
            this.kesButton.UseVisualStyleBackColor = true;
            this.kesButton.Click += new System.EventHandler(this.kExercicesButton1_Click);
            // 
            // FPiano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1725, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FPiano";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.cmsExercice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMusicScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPiano)).EndInit();
            this.cmsProfils.ResumeLayout(false);
            this.cmsExercices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbPiano;
        private System.Windows.Forms.Timer tmrSave;
        private System.Windows.Forms.PictureBox pbMusicScore;
        private System.Windows.Forms.ContextMenuStrip cmsExercices;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsExercice;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMidiToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsProfils;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private KPathButton btnClose;
        private KPathButton btnMinimize;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private KProfilButton kpButton;
        private KExerciceButton keButton;
        private KExercicesButton kesButton;
        private KPathButton btnNext;
        private KPathButton btnPrev;
    }
}

