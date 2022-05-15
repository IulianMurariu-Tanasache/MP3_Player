
namespace MP3_Player_Interface
{
    partial class MP3_Player
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
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.buttonVolumeDown = new System.Windows.Forms.Button();
            this.buttonVolumeUp = new System.Windows.Forms.Button();
            this.buttonVolumeMute = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelTimeStart = new System.Windows.Forms.Label();
            this.labelTimeEnd = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxPlaylist = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarTime
            // 
            this.progressBarTime.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBarTime.Location = new System.Drawing.Point(12, 313);
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(498, 14);
            this.progressBarTime.TabIndex = 2;
            this.progressBarTime.Click += new System.EventHandler(this.progressBarTime_Click);
            // 
            // buttonVolumeDown
            // 
            this.buttonVolumeDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonVolumeDown.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.volume_down_50;
            this.buttonVolumeDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVolumeDown.FlatAppearance.BorderSize = 0;
            this.buttonVolumeDown.Location = new System.Drawing.Point(404, 361);
            this.buttonVolumeDown.Name = "buttonVolumeDown";
            this.buttonVolumeDown.Size = new System.Drawing.Size(50, 50);
            this.buttonVolumeDown.TabIndex = 11;
            this.buttonVolumeDown.UseVisualStyleBackColor = false;
            this.buttonVolumeDown.Click += new System.EventHandler(this.buttonVolumeDown_Click);
            // 
            // buttonVolumeUp
            // 
            this.buttonVolumeUp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonVolumeUp.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.volume_up_50;
            this.buttonVolumeUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVolumeUp.FlatAppearance.BorderSize = 0;
            this.buttonVolumeUp.Location = new System.Drawing.Point(460, 362);
            this.buttonVolumeUp.Name = "buttonVolumeUp";
            this.buttonVolumeUp.Size = new System.Drawing.Size(50, 50);
            this.buttonVolumeUp.TabIndex = 10;
            this.buttonVolumeUp.UseVisualStyleBackColor = false;
            this.buttonVolumeUp.Click += new System.EventHandler(this.buttonVolumeUp_Click);
            // 
            // buttonVolumeMute
            // 
            this.buttonVolumeMute.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonVolumeMute.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.volume_mute_50;
            this.buttonVolumeMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVolumeMute.FlatAppearance.BorderSize = 0;
            this.buttonVolumeMute.Location = new System.Drawing.Point(348, 362);
            this.buttonVolumeMute.Name = "buttonVolumeMute";
            this.buttonVolumeMute.Size = new System.Drawing.Size(50, 50);
            this.buttonVolumeMute.TabIndex = 9;
            this.buttonVolumeMute.UseVisualStyleBackColor = false;
            this.buttonVolumeMute.Click += new System.EventHandler(this.buttonVolumeMute_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonStop.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.stop_50;
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.Location = new System.Drawing.Point(292, 361);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(50, 50);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.UseVisualStyleBackColor = false;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonShuffle.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.shuffle_50;
            this.buttonShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShuffle.FlatAppearance.BorderSize = 0;
            this.buttonShuffle.Location = new System.Drawing.Point(12, 362);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(50, 50);
            this.buttonShuffle.TabIndex = 7;
            this.buttonShuffle.UseVisualStyleBackColor = false;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPrevious.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.previous_50;
            this.buttonPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevious.FlatAppearance.BorderSize = 0;
            this.buttonPrevious.Location = new System.Drawing.Point(68, 362);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(50, 50);
            this.buttonPrevious.TabIndex = 6;
            this.buttonPrevious.UseVisualStyleBackColor = false;
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNext.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.next_50;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.Location = new System.Drawing.Point(236, 362);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 50);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPause.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.pause_50;
            this.buttonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPause.FlatAppearance.BorderSize = 0;
            this.buttonPause.Location = new System.Drawing.Point(180, 362);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(50, 50);
            this.buttonPause.TabIndex = 4;
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPlay.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.play_50;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.Location = new System.Drawing.Point(124, 362);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(50, 50);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelTimeStart
            // 
            this.labelTimeStart.AutoSize = true;
            this.labelTimeStart.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTimeStart.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelTimeStart.Location = new System.Drawing.Point(12, 330);
            this.labelTimeStart.Name = "labelTimeStart";
            this.labelTimeStart.Size = new System.Drawing.Size(71, 28);
            this.labelTimeStart.TabIndex = 12;
            this.labelTimeStart.Text = "00:00";
            // 
            // labelTimeEnd
            // 
            this.labelTimeEnd.AutoSize = true;
            this.labelTimeEnd.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTimeEnd.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelTimeEnd.Location = new System.Drawing.Point(456, 330);
            this.labelTimeEnd.Name = "labelTimeEnd";
            this.labelTimeEnd.Size = new System.Drawing.Size(71, 28);
            this.labelTimeEnd.TabIndex = 13;
            this.labelTimeEnd.Text = "00:00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlistToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.loadFromDirectoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 27);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.playlistToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(65, 23);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // loadFromDirectoryToolStripMenuItem
            // 
            this.loadFromDirectoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.loadFromDirectoryToolStripMenuItem.Name = "loadFromDirectoryToolStripMenuItem";
            this.loadFromDirectoryToolStripMenuItem.Size = new System.Drawing.Size(149, 23);
            this.loadFromDirectoryToolStripMenuItem.Text = "Load From Directory";
            this.loadFromDirectoryToolStripMenuItem.Click += new System.EventHandler(this.loadFromDirectoryToolStripMenuItem_Click);
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.Location = new System.Drawing.Point(12, 37);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(498, 264);
            this.listBoxPlaylist.TabIndex = 15;
            // 
            // MP3_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(522, 420);
            this.Controls.Add(this.listBoxPlaylist);
            this.Controls.Add(this.labelTimeEnd);
            this.Controls.Add(this.labelTimeStart);
            this.Controls.Add(this.buttonVolumeDown);
            this.Controls.Add(this.buttonVolumeUp);
            this.Controls.Add(this.buttonVolumeMute);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.progressBarTime);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MP3_Player";
            this.Text = "MP3 Player";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonVolumeMute;
        private System.Windows.Forms.Button buttonVolumeUp;
        private System.Windows.Forms.Button buttonVolumeDown;
        private System.Windows.Forms.Label labelTimeStart;
        private System.Windows.Forms.Label labelTimeEnd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.ToolStripMenuItem loadFromDirectoryToolStripMenuItem;
    }
}

