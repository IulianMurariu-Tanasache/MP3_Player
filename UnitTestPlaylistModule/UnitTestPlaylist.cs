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
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Playlist xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" PathList=\"muzica1 muzica2\" name=\"playlistTest\" />";
            Assert.AreEqual(xml, playlist.ToXml());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestForException()
        {
            Playlist playlist = new Playlist();
            Assert.IsNotNull(playlist);
            playlist.RemoveSong("aaaaaa");
        }
    }
}
