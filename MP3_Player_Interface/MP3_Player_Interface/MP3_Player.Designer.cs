
using System;

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
            this.components = new System.ComponentModel.Container();
            this.buttonVolumeDown = new System.Windows.Forms.Button();
            this.buttonVolumeUp = new System.Windows.Forms.Button();
            this.buttonVolumeMute = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelTimeCurrent = new System.Windows.Forms.Label();
            this.labelTimeEnd = new System.Windows.Forms.Label();
            this.listBoxPlaylist = new System.Windows.Forms.ListBox();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadPlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxPlaylists = new System.Windows.Forms.ListBox();
            this.contextMenuStripPlaylists = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelCurrentSong = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVolumeDown
            // 
            this.buttonVolumeDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonVolumeDown.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.volume_down_50;
            this.buttonVolumeDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVolumeDown.FlatAppearance.BorderSize = 0;
            this.buttonVolumeDown.Location = new System.Drawing.Point(402, 405);
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
            this.buttonVolumeUp.Location = new System.Drawing.Point(458, 406);
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
            this.buttonVolumeMute.Location = new System.Drawing.Point(346, 406);
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
            this.buttonStop.Location = new System.Drawing.Point(290, 405);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(50, 50);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonShuffle.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.shuffle_50;
            this.buttonShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShuffle.FlatAppearance.BorderSize = 0;
            this.buttonShuffle.Location = new System.Drawing.Point(10, 406);
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
            this.buttonPrevious.Location = new System.Drawing.Point(66, 406);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(50, 50);
            this.buttonPrevious.TabIndex = 6;
            this.buttonPrevious.UseVisualStyleBackColor = false;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNext.BackgroundImage = global::MP3_Player_Interface.Properties.Resources.next_50;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.Location = new System.Drawing.Point(234, 406);
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
            this.buttonPause.Location = new System.Drawing.Point(178, 406);
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
            this.buttonPlay.Location = new System.Drawing.Point(122, 406);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(50, 50);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelTimeCurrent
            // 
            this.labelTimeCurrent.AutoSize = true;
            this.labelTimeCurrent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTimeCurrent.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelTimeCurrent.Location = new System.Drawing.Point(11, 374);
            this.labelTimeCurrent.Name = "labelTimeCurrent";
            this.labelTimeCurrent.Size = new System.Drawing.Size(44, 19);
            this.labelTimeCurrent.TabIndex = 12;
            this.labelTimeCurrent.Text = "00:00";
            // 
            // labelTimeEnd
            // 
            this.labelTimeEnd.AutoSize = true;
            this.labelTimeEnd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTimeEnd.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelTimeEnd.Location = new System.Drawing.Point(470, 374);
            this.labelTimeEnd.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelTimeEnd.Name = "labelTimeEnd";
            this.labelTimeEnd.Size = new System.Drawing.Size(44, 19);
            this.labelTimeEnd.TabIndex = 13;
            this.labelTimeEnd.Text = "00:00";
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.AllowDrop = true;
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.Location = new System.Drawing.Point(178, 53);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(336, 264);
            this.listBoxPlaylist.TabIndex = 15;
            this.listBoxPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragAndDrop);
            this.listBoxPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxEnter);
            // 
            // trackBarTime
            // 
            this.trackBarTime.LargeChange = 10;
            this.trackBarTime.Location = new System.Drawing.Point(15, 329);
            this.trackBarTime.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.trackBarTime.Maximum = 10000;
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(499, 45);
            this.trackBarTime.TabIndex = 16;
            this.trackBarTime.TickFrequency = 10;
            this.trackBarTime.Scroll += new System.EventHandler(this.trackBarTime_Scroll);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(105, 27);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(409, 20);
            this.textBoxSearch.TabIndex = 18;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // loadFromDirectoryToolStripMenuItem
            // 
            this.loadFromDirectoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loadFromDirectoryToolStripMenuItem.Name = "loadFromDirectoryToolStripMenuItem";
            this.loadFromDirectoryToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.loadFromDirectoryToolStripMenuItem.Text = "Load From Directory";
            this.loadFromDirectoryToolStripMenuItem.Click += new System.EventHandler(this.loadFromDirectoryToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPlaylistsToolStripMenuItem,
            this.savePlaylistsToolStripMenuItem,
            this.loadFromDirectoryToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(522, 24);
            this.menuStrip.TabIndex = 14;
            this.menuStrip.Text = "menuStrip1";
            // 
            // loadPlaylistsToolStripMenuItem
            // 
            this.loadPlaylistsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loadPlaylistsToolStripMenuItem.Name = "loadPlaylistsToolStripMenuItem";
            this.loadPlaylistsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.loadPlaylistsToolStripMenuItem.Text = "Load Playlists";
            this.loadPlaylistsToolStripMenuItem.Click += new System.EventHandler(this.loadPlaylistsToolStripMenuItem_Click);
            // 
            // savePlaylistsToolStripMenuItem
            // 
            this.savePlaylistsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.savePlaylistsToolStripMenuItem.Name = "savePlaylistsToolStripMenuItem";
            this.savePlaylistsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.savePlaylistsToolStripMenuItem.Text = "Save Playlists";
            this.savePlaylistsToolStripMenuItem.Click += new System.EventHandler(this.savePlaylistsToolStripMenuItem_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSongToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(138, 26);
            // 
            // deleteSongToolStripMenuItem
            // 
            this.deleteSongToolStripMenuItem.Name = "deleteSongToolStripMenuItem";
            this.deleteSongToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteSongToolStripMenuItem.Text = "Delete Song";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Search a song:";
            // 
            // listBoxPlaylists
            // 
            this.listBoxPlaylists.FormattingEnabled = true;
            this.listBoxPlaylists.Location = new System.Drawing.Point(15, 53);
            this.listBoxPlaylists.Name = "listBoxPlaylists";
            this.listBoxPlaylists.Size = new System.Drawing.Size(157, 264);
            this.listBoxPlaylists.TabIndex = 20;
            this.listBoxPlaylists.SelectedIndexChanged += new System.EventHandler(this.listBoxPlaylists_SelectedIndexChanged);
            // 
            // contextMenuStripPlaylists
            // 
            this.contextMenuStripPlaylists.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStripPlaylists.Name = "contextMenuStripPlaylists";
            this.contextMenuStripPlaylists.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripPlaylists.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripPlaylists_Opening);
            // 
            // labelCurrentSong
            // 
            this.labelCurrentSong.AutoSize = true;
            this.labelCurrentSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentSong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCurrentSong.Location = new System.Drawing.Point(81, 374);
            this.labelCurrentSong.Name = "labelCurrentSong";
            this.labelCurrentSong.Size = new System.Drawing.Size(147, 16);
            this.labelCurrentSong.TabIndex = 21;
            this.labelCurrentSong.Text = "<< No songs playing >>";
            this.labelCurrentSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MP3_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(522, 468);
            this.Controls.Add(this.labelCurrentSong);
            this.Controls.Add(this.listBoxPlaylists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.trackBarTime);
            this.Controls.Add(this.listBoxPlaylist);
            this.Controls.Add(this.labelTimeEnd);
            this.Controls.Add(this.labelTimeCurrent);
            this.Controls.Add(this.buttonVolumeDown);
            this.Controls.Add(this.buttonVolumeUp);
            this.Controls.Add(this.buttonVolumeMute);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MP3_Player";
            this.Text = "MP3 Player";
            this.Load += new System.EventHandler(this.MP3_Player_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonVolumeMute;
        private System.Windows.Forms.Button buttonVolumeUp;
        private System.Windows.Forms.Button buttonVolumeDown;
        private System.Windows.Forms.Label labelTimeCurrent;
        private System.Windows.Forms.Label labelTimeEnd;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromDirectoryToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteSongToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPlaylists;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlaylists;
        private System.Windows.Forms.ToolStripMenuItem loadPlaylistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePlaylistsToolStripMenuItem;
        private System.Windows.Forms.Label labelCurrentSong;
        private System.Windows.Forms.Timer timer;
    }
}
