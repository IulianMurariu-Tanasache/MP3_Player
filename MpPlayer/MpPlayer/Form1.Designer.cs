namespace MpPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoad = new System.Windows.Forms.Button();
            this.listBoxMusic = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(602, 330);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(171, 54);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // listBoxMusic
            // 
            this.listBoxMusic.AllowDrop = true;
            this.listBoxMusic.FormattingEnabled = true;
            this.listBoxMusic.ItemHeight = 15;
            this.listBoxMusic.Location = new System.Drawing.Point(27, 21);
            this.listBoxMusic.Name = "listBoxMusic";
            this.listBoxMusic.Size = new System.Drawing.Size(559, 289);
            this.listBoxMusic.TabIndex = 2;
            this.listBoxMusic.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragAndDrop);
            this.listBoxMusic.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxEnter);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(394, 330);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(145, 54);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(602, 21);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(176, 23);
            this.textBoxSearch.TabIndex = 4;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxMusic);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonLoad;
        private ListBox listBoxMusic;
        private Button buttonDelete;
        private TextBox textBoxSearch;
    }
}