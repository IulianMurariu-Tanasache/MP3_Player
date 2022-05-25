/**************************************************************************
 *                                                                        *
 *  File:        Load.cs                                                  *
 *  Copyright:   (c) 2022, Enache Stefan                                  *
 *  E-mail:      stefan.enache@student.tuiasi.ro                          *
 *  Website:     https://github.com/IulianMurariu-Tanasache/MP3_Player    *
 *  Description: Generates file information headers.                      *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
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
        public List<String> LoadMusic()//asta e ok
        {
            try
            {
                if (_ofd.ShowDialog() == DialogResult.OK)
                {
                    _listOfMusic.Clear();
                    foreach (String file in _ofd.FileNames)
                    {
                        bool found = false;
                        foreach (String melody in _listOfMusic)
                        {

                            if (melody.Equals(System.IO.Path.GetFileName(file)))
                            {
                                //MessageBox.Show("duplicate found");
                                found = true;
                            }
                        }
                        if (!found)
                            _listOfMusic.Add(System.IO.Path.GetFileName(file));


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
            return _listOfMusic;
        }
    

       
        /// <summary>
        /// Aceasta functie cauta melodii in ListBox si afiseaza toate melodiile care contin string-ul primit ca parametru 
        /// </summary>
        /// <param name="listBoxMusic">Lista in care se afla melodiile si in care caut</param>
        /// <param name="textBoxSearch">TextBoxul unde introduc Stringul pentru a cauta in lista</param>
        public List<string> SearchMusic(ListBox listBoxMusic, TextBox textBoxSearch, List<string> songs)//aici filtreaza cum vreau eu
        {
            listBoxMusic.Items.Clear();
            List<string> list = new List<string>();
            foreach (String str in songs)
            {
                if (str.ToUpper().Contains(textBoxSearch.Text.ToUpper()))
                {
                   listBoxMusic.Items.Add(System.IO.Path.GetFileName(str));
                    list.Append(System.IO.Path.GetFileName(str));
                }
            }
            return list;
        }

        /// <summary>
        /// Aceasta functie permite ca dintr-un fisier sa adaug elemente prin eveniment de tip Drag 
        /// Fisierele de tip '.mp3', vor fi adaugata in listBox si in _listOfMusic
        /// </summary>
        /// <param name="listBox">Lista in care se afla melodiile si in care adug prin DragAndDrop</param>
        /// <param name="e">Este evenimentul, DragAndDrop, care imi permite sa adaug melodiile</param>
        public List<String> DragAndDrop(DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(System.IO.Path.GetFileName(DataFormats.FileDrop), false);
            _listOfMusic.Clear();
            foreach (String files in filePath)
            {
                bool found = false;
                foreach (String melody in _listOfMusic)
                    if (melody.Equals(System.IO.Path.GetFileName(files)))
                    {
                        //MessageBox.Show("duplicate found");
                        found = true;
                    }
                if (!found)
                    _listOfMusic.Add(files);

            }
            return _listOfMusic;
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
