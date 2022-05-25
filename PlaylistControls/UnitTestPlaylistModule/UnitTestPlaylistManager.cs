/**************************************************************************
 *                                                                        *
 *  File:        UnitTestPlaylistManager.cs                                              *
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistControls;

namespace UnitTestPlaylistModule
{
    [TestClass]
    public class UnitTestPlaylistManager
    {
        [TestMethod]
        public void TestAddPlaylist()
        {
            PlaylistManager playlistManager = new PlaylistManager();
            Assert.IsNotNull(playlistManager);
            Playlist playlist1 = new Playlist("playlist1");
            Playlist playlist2 = new Playlist("playlist2");
            playlistManager.AddPlaylist(playlist1);
            Assert.AreSame(playlist1, playlistManager.Playlists[0]);
            playlistManager.AddPlaylist(playlist2);
            Assert.AreSame(playlist2, playlistManager.Playlists[1]);
        }

        [TestMethod]
        public void TestRemovePlaylist()
        {
            PlaylistManager playlistManager = new PlaylistManager();
            Assert.IsNotNull(playlistManager);
            Playlist playlist1 = new Playlist("playlist1");
            Playlist playlist2 = new Playlist("playlist2");
            playlistManager.AddPlaylist(playlist1);
            playlistManager.AddPlaylist(playlist2);
            playlistManager.RemovePlaylist(playlist1.Name);
            Assert.AreEqual(1, playlistManager.Playlists.Count);
            Assert.IsFalse(playlistManager.Playlists.Contains(playlist1));
        }

        [TestMethod]
        public void TestSetCurrentPlaylist()
        {
            PlaylistManager playlistManager = new PlaylistManager();
            Assert.IsNotNull(playlistManager);
            Playlist playlist1 = new Playlist("playlist1");
            Playlist playlist2 = new Playlist("playlist2");
            playlistManager.AddPlaylist(playlist1);
            playlistManager.AddPlaylist(playlist2);
            playlistManager.SetCurrentPlaylist(playlist1.Name);
            Assert.AreEqual(playlist1, playlistManager.CurrentPlaylist);
        }
    }
}
