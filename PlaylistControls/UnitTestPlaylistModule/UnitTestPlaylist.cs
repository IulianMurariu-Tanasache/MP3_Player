/**************************************************************************
 *                                                                        *
 *  File:        UnitTestPlaylist.cs                                              *
 *  Copyright:   (c) 2022, Murariu-Tanasache Iulian                       *
 *  E-mail:      iulian.murariu-tanasache@student.tuiasi.ro               *
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
using System;
using PlaylistControls;

namespace UnitTestPlaylistModule
{
    [TestClass]
    public class UnitTestPlaylist
    {
        [TestMethod]
        public void TestAddSong()
        {
            Playlist playlist = new Playlist();
            Assert.IsNotNull(playlist);
            playlist.AddSong("melodie.mp3");
            Assert.IsTrue("melodie.mp3" == playlist.PathList[playlist.PathList.Count - 1]);
            playlist.AddSong("melodie_noua.mp3");
            Assert.IsTrue("melodie_noua.mp3" == playlist.PathList[playlist.PathList.Count - 1]);
        }

        [TestMethod]
        public void TestRemoveSong()
        {
            Playlist playlist = new Playlist();
            Assert.IsNotNull(playlist);
            playlist.AddSong("melodie.mp3");
            playlist.AddSong("melodie_noua.mp3");
            Assert.IsTrue(playlist.PathList.Contains("melodie_noua.mp3"));
            playlist.RemoveSong("melodie_noua.mp3");
            Assert.IsFalse(playlist.PathList.Contains("melodie_noua.mp3"));
        }

        [TestMethod]
        public void TestXMLSerialize()
        {
            Playlist playlist = new Playlist();
            Assert.IsNotNull(playlist);
            playlist.Name = "playlistTest";
            playlist.AddSong("muzica1");
            playlist.AddSong("muzica2");
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Playlist xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" name=\"playlistTest\"><PathList><string>muzica1</string><string>muzica2</string></PathList></Playlist>";
            Assert.AreEqual(xml, playlist.ToXml());
        }

        [TestMethod]
        public void TestXMLDeserialize()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Playlist xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" name=\"playlistTest\"><PathList><string>muzica1</string><string>muzica2</string></PathList></Playlist>";
            Playlist playlist = Playlist.FromXml("F:\\AnuIII\\IP\\Proiect_IP\\MP3_Player\\PlaylistControls\\UnitTestPlaylistModule\\playlistTest.xml");
            Assert.IsNotNull(playlist);
            Assert.AreEqual("playlistTest", playlist.Name);
            Assert.AreEqual(2, playlist.PathList.Count);
            Assert.AreEqual("muzica1", playlist.PathList[0]);
            Assert.AreEqual("muzica2", playlist.PathList[1]);
        }

        [TestMethod]
        public void TestGetFullPath()
        {
            Playlist playlist = new Playlist();
            Assert.IsNotNull(playlist);
            playlist.Name = "playlistTest";
            string fullPath = "F://muzica1";
            playlist.AddSong(fullPath);
            Assert.AreEqual(fullPath, playlist.GetFullPath("muzica1"));
        }
    }
}
