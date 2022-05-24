/**************************************************************************
 *                                                                        *
 *  File:        UnitTest1.cs                                          *
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpPlayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace TestForLoads
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Load()
        {
            Load load = new Load();
            Assert.IsNotNull(load);
            Assert.AreEqual(load.ListOfMusic.Count, 0);

        }

        [TestMethod]
        public void SearchMusic1()
        {
            Load load = new Load();
            Assert.IsNotNull(load);
            ListBox listBox = new ListBox();
            TextBox textBoxMusic = new TextBox();
            List<string> songs = new List<string>();
            textBoxMusic.Text = "da";
            songs.Add("dadada");
            songs.Add("nununu");
            listBox.Items.Add(songs);
            load.SearchMusic(listBox, textBoxMusic, songs);
            Assert.AreEqual(listBox.Items.Count, 1);
            Assert.AreEqual(listBox.Items[0], "dadada");

        }
        [TestMethod]
        public void SearchMusic2()
        {
            Load load = new Load();
            Assert.IsNotNull(load);
            ListBox listBox = new ListBox();
            TextBox textBoxMusic = new TextBox();
            List<string> songs = new List<string>();
            textBoxMusic.Text = "dandiaconescu";
            songs.Add("dadada");
            songs.Add("nununu");
            listBox.Items.Add(songs);
            load.SearchMusic(listBox, textBoxMusic, songs);
            Assert.AreEqual(listBox.Items.Count, 0);

        }
        [TestMethod]
        public void DragMusic1()
        {
            DataObject data = new DataObject();
            data.SetFileDropList(new System.Collections.Specialized.StringCollection { "dada" });
            int key = 0;
            int x = 10;
            int y = 10;
            DragEventArgs e = new DragEventArgs(data, key, x, y, DragDropEffects.All, DragDropEffects.Move);
            ListBox listBox = new ListBox();
            List<string> songs = new List<string>();

            Load load = new Load();
            Assert.IsNotNull(load);
            load.DragAndDrop(e);
            Assert.AreEqual(load.ListOfMusic.Count, 1);
            Assert.AreEqual(load.ListOfMusic[0], "dada");

        }
        [TestMethod]
        public void DragMusic2()
        {
            DataObject data = new DataObject();
            data.SetFileDropList(new System.Collections.Specialized.StringCollection {});
            int key = 0;
            int x = 10;
            int y = 10;
            DragEventArgs e = new DragEventArgs(data, key, x, y, DragDropEffects.All, DragDropEffects.Move);
            ListBox listBox = new ListBox();
            List<string> songs = new List<string>();

            Load load = new Load();
            Assert.IsNotNull(load);
            load.DragAndDrop(e);
            Assert.AreEqual(load.ListOfMusic.Count, 0);
            //Assert.AreEqual(load.ListOfMusic[0], "dada");
        }

    }
 }
