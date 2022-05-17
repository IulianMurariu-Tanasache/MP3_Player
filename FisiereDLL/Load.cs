using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MpPlayer
{
    /// <summary>
    /// Clasa <c>Load</c> ajuta la manipularea fisierelor ".mp3".
    /// </summary>
    public class Load
    {
        private OpenFileDialog _ofd; //fereastra de selectie a fisierelor
        private List<String> _listOfMusic;//lista ce pastreaza melodiile care au fost incarcate

        ///<_listOfMusic> returneza lista cu melodiile ce au fost incarcate in aplicatie</_listOfMusic>
        public List<String> ListOfMusic
        {
            get { return _listOfMusic; }
        }

        /// <summary>
        /// Constructor ce initializeaza fereastra de selectie a fisierelor .mp3.
        /// Pun pe True, multi-selectia fisierlor si initializez list de tip string in care voi adauga melodiile
        /// </summary>
     
        public Load()
        {
            _ofd = new OpenFileDialog()
            {
                FileName = "",
                Filter = "Text files (*.mp3)|*.mp3",
                Title = "Windows Explorer"
            };
            _ofd.Multiselect = true;
            _listOfMusic = new List<String>();
        }

        /// <summary>
        /// Adaug  atat in listBox-ul de pe interfata, cat si in listOfMusic melodiile
        /// Verific daca o melodie a fost adaugata o data, ca sa nu fie adaug a doua oara
        /// In caz de eroare la deschiderea fisierului o sa arunce eroare, pe care o tratez
        /// </summary>
        /// <param name="listBoxMusic">ListBoxul in care va  fi afisata lista de melodii</param>
        public void LoadMusic(ListBox listBoxMusic)//asta e ok
        {
            try
            {
                if (_ofd.ShowDialog() == DialogResult.OK)
                {
                    _listOfMusic.Clear();
                    foreach (String file in listBoxMusic.Items)
                    {
                        _listOfMusic.Add(file);
                    }
                    foreach (String file in _ofd.FileNames)
                    {
                        bool found = false;
                        foreach (String melody in _listOfMusic)
                        {

                            if (melody.Equals(file))
                            {
                                //MessageBox.Show("duplicate found");
                                found = true;
                            }
                        }
                        if (!found)
                            _listOfMusic.Add(file);
                    }
                    listBoxMusic.Items.Clear();
                    // MessageBox.Show(listOfMusic.ToString());
                    foreach (String melody in _listOfMusic)
                    {
                        listBoxMusic.Items.Add(System.IO.Path.GetFileName(melody));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Aceasta functie sterge melodia pe care o selectez
        /// Am de ales doua optiuni, stergerea melodiei selectate doar din lista de melodii sau stergerea de pe disk
        /// </summary>
        /// <param name="listBoxMusic">Lista in care se afla melodia, pe care o selectez sa o sterg</param>
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

        /// <summary>
        /// Aceasta functie cauta melodii in ListBox si afiseaza toate melodiile care contin string-ul primit ca parametru 
        /// </summary>
        /// <param name="listBoxMusic">Lista in care se afla melodiile si in care caut</param>
        /// <param name="textBoxSearch">TextBoxul unde introduc Stringul pentru a cauta in lista</param>
        public void SearchMusic(ListBox listBoxMusic, TextBox textBoxSearch)//aici filtreaza cum vreau eu
        {
            listBoxMusic.Items.Clear();
            foreach (String str in _listOfMusic)
            {
                if (str.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                {
                    listBoxMusic.Items.Add(str);
                }
            }
        }

        /// <summary>
        /// Aceasta functie permite ca dintr-un fisier sa adaug elemente prin eveniment de tip Drag 
        /// Fisierele de tip '.mp3', vor fi adaugata in listBox si in _listOfMusic
        /// </summary>
        /// <param name="listBox">Lista in care se afla melodiile si in care adug prin DragAndDrop</param>
        /// <param name="e">Este evenimentul, DragAndDrop, care imi permite sa adaug melodiile</param>
        public void DragAndDrop(ListBox listBox, DragEventArgs e)
        {
            string[] s = (string[]) e.Data.GetData(System.IO.Path.GetFileName(DataFormats.FileDrop), false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox.Items.Add(System.IO.Path.GetFileName(s[i]));
        }

        /// <summary>
        /// Aceasta functie permite permite ca sa realizez eveniment de tip Drag
        /// </summary>
        /// /// <param name="e">Lista in care se afla melodiile si in care adug prin DragAndDrop</param>
        public void ListBoxEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
