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
    }
}
