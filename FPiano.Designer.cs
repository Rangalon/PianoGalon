
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
            this.pbMusicScore = new System.Windows.Forms.PictureBox();
            this.pbPiano = new System.Windows.Forms.PictureBox();
            this.cmsProfils = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExercices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSave = new System.Windows.Forms.Timer(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new PianoGalon.KPathButton();
            this.flpExercice = new PianoGalon.KFlowLayoutPanel();
            this.flpProfils = new PianoGalon.KFlowLayoutPanel();
            this.flpExercices = new PianoGalon.KFlowLayoutPanel();
            this.label1 = new PianoGalon.KLabel();
            this.btnMinimize = new PianoGalon.KPathButton();
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
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpExercice, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbMusicScore, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbPiano, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.flpProfils, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpExercices, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMinimize, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1725, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmsExercice
            // 
            this.cmsExercice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.importMidiToolStripMenuItem,
            this.newToolStripMenuItem2});
            this.cmsExercice.Name = "cmsExercice";
            this.cmsExercice.Size = new System.Drawing.Size(145, 70);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.importToolStripMenuItem.Text = "Import  Mscx";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // importMidiToolStripMenuItem
            // 
            this.importMidiToolStripMenuItem.Name = "importMidiToolStripMenuItem";
            this.importMidiToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.importMidiToolStripMenuItem.Text = "Import Midi";
            this.importMidiToolStripMenuItem.Click += new System.EventHandler(this.importMidiToolStripMenuItem_Click);
            // 
            // pbMusicScore
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbMusicScore, 4);
            this.pbMusicScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMusicScore.Location = new System.Drawing.Point(1, 181);
            this.pbMusicScore.Margin = new System.Windows.Forms.Padding(1);
            this.pbMusicScore.Name = "pbMusicScore";
            this.tableLayoutPanel1.SetRowSpan(this.pbMusicScore, 3);
            this.pbMusicScore.Size = new System.Drawing.Size(1723, 439);
            this.pbMusicScore.TabIndex = 2;
            this.pbMusicScore.TabStop = false;
            this.pbMusicScore.Click += new System.EventHandler(this.pbMusicScore_Click);
            this.pbMusicScore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMusicScore_MouseClick);
            // 
            // pbPiano
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbPiano, 4);
            this.pbPiano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPiano.Location = new System.Drawing.Point(1, 622);
            this.pbPiano.Margin = new System.Windows.Forms.Padding(1);
            this.pbPiano.Name = "pbPiano";
            this.pbPiano.Size = new System.Drawing.Size(1723, 145);
            this.pbPiano.TabIndex = 0;
            this.pbPiano.TabStop = false;
            // 
            // cmsProfils
            // 
            this.cmsProfils.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem});
            this.cmsProfils.Name = "cmsProfils";
            this.cmsProfils.Size = new System.Drawing.Size(130, 48);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.newToolStripMenuItem.Text = "New Profil";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cmsExercices
            // 
            this.cmsExercices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.newToolStripMenuItem1});
            this.cmsExercices.Name = "cmsExercices";
            this.cmsExercices.Size = new System.Drawing.Size(99, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // tmrSave
            // 
            this.tmrSave.Enabled = true;
            this.tmrSave.Interval = 10000;
            this.tmrSave.Tick += new System.EventHandler(this.tmrSave_Tick);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(144, 22);
            this.newToolStripMenuItem2.Text = "New";
            this.newToolStripMenuItem2.Click += new System.EventHandler(this.newToolStripMenuItem2_Click);
            // 
            // btnClose
            // 
            this.btnClose.ButtonType = PianoGalon.KPathButton.EButtonType.Close;
            this.btnClose.Location = new System.Drawing.Point(1665, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 58);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "kImageButton2";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flpExercice
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flpExercice, 2);
            this.flpExercice.ContextMenuStrip = this.cmsExercice;
            this.flpExercice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpExercice.Enabled = false;
            this.flpExercice.Location = new System.Drawing.Point(863, 61);
            this.flpExercice.Margin = new System.Windows.Forms.Padding(1);
            this.flpExercice.Name = "flpExercice";
            this.flpExercice.Size = new System.Drawing.Size(861, 118);
            this.flpExercice.TabIndex = 9;
            // 
            // flpProfils
            // 
            this.flpProfils.ContextMenuStrip = this.cmsProfils;
            this.flpProfils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProfils.Location = new System.Drawing.Point(61, 1);
            this.flpProfils.Margin = new System.Windows.Forms.Padding(1);
            this.flpProfils.Name = "flpProfils";
            this.flpProfils.Size = new System.Drawing.Size(800, 58);
            this.flpProfils.TabIndex = 7;
            // 
            // flpExercices
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flpExercices, 2);
            this.flpExercices.ContextMenuStrip = this.cmsExercices;
            this.flpExercices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpExercices.Enabled = false;
            this.flpExercices.Location = new System.Drawing.Point(1, 61);
            this.flpExercices.Margin = new System.Windows.Forms.Padding(1);
            this.flpExercices.Name = "flpExercices";
            this.flpExercices.Size = new System.Drawing.Size(860, 118);
            this.flpExercices.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(863, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 58);
            this.label1.TabIndex = 10;
            // 
            // btnMinimize
            // 
            this.btnMinimize.ButtonType = PianoGalon.KPathButton.EButtonType.Minimize;
            this.btnMinimize.Location = new System.Drawing.Point(1, 1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(58, 58);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.Text = "kImageButton1";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
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
        private KFlowLayoutPanel flpProfils;
        private System.Windows.Forms.ContextMenuStrip cmsProfils;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private KFlowLayoutPanel flpExercices;
        private KFlowLayoutPanel flpExercice;
        private KLabel label1;
        private KPathButton btnClose;
        private KPathButton btnMinimize;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
    }
}

