using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpPlayer
{
    class Load
    {
        private OpenFileDialog ofd;
        private List<String> listOfMusic;
        public Load()
        {
            ofd = new OpenFileDialog()
            {

                FileName = "",
                Filter = "Text files (*.mp3)|*.mp3",
                Title = "Windows Explorer"
            };
            ofd.Multiselect = true;
            listOfMusic = new List<String>();
            
        }
        public void LoadMusic(ListBox listBoxMusic)//asta e ok
        {
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    listOfMusic.Clear();
                    foreach (String file in listBoxMusic.Items)
                    {
                        listOfMusic.Add(file);

                    }
                    foreach (String file in ofd.FileNames)
                    {
                        bool found = false;
                        foreach (String melody in listOfMusic)
                        {

                            if (melody.Equals(System.IO.Path.GetFileName(file)))
                            {
                                //MessageBox.Show("duplicate found");
                                found = true;
                            }
                        }
                        if (!found)
                            listOfMusic.Add(System.IO.Path.GetFileName(file));


                    }
                    listBoxMusic.Items.Clear();
                    // MessageBox.Show(listOfMusic.ToString());
                    foreach (String melody in listOfMusic)
                    {

                        listBoxMusic.Items.Add(melody);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
        public void DeleteMusic(ListBox listBoxMusic)
        {
            String path = @"E:/Music";
            DirectoryInfo di = new DirectoryInfo(path);
            if (MessageBox.Show("    Delete from disk?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    if (file.Name.Contains(listBoxMusic.SelectedItem.ToString()))
                    {
                        file.Delete();
                        MessageBox.Show("File was deleted");
                    }
                }
                listBoxMusic.Items.Remove(listBoxMusic.SelectedItem);
            }
            else
            {
                listBoxMusic.Items.Remove(listBoxMusic.SelectedItem);
            }
        }
        public void SearchMusic(ListBox listBoxMusic, TextBox textBoxSearch)//aici filtreaza cum vreau eu
        {
            listBoxMusic.Items.Clear();
            foreach (String str in listOfMusic)
            {
                if (str.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                {
                    listBoxMusic.Items.Add(str);
                }
            }
        }
        public void DragAndDrop(ListBox listBox, DragEventArgs e)
        {
            string[] s = (string[]) e.Data.GetData(System.IO.Path.GetFileName(DataFormats.FileDrop), false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox.Items.Add(System.IO.Path.GetFileName(s[i]));
        }
        public void ListBoxEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

    }
}
