using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ControlulInterfeteiNameSpace;
using System.IO;
using System.Diagnostics;

namespace ControlulInterfeteiTest
{
    [TestClass]
    public class ControlulInterfeteiTest
    {
        private List<string> _list = new List<string>();
        private ControlulInterfetei _controlulInterfetei = ControlulInterfetei.Instance();
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddSongs()
        {
            _list = new List<string>();
            _list.Add(null);
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica - The Unforgiven.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Enter Sandman.mp3");
            _controlulInterfetei.AddSongs(_list);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemonveSongs()
        {
            _list = new List<string>();
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Nothing Else Matters.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica - The Unforgiven.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Enter Sandman.mp3");
            _controlulInterfetei.RemoveSongs(_list);
        }
        [TestMethod]
        public void TestSongLength()
        {
            _list = new List<string>();
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Nothing Else Matters.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica - The Unforgiven.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Enter Sandman.mp3");
            _controlulInterfetei.AddSongs(_list);
            _controlulInterfetei.Play();
            _controlulInterfetei.Next();
            _controlulInterfetei.Previous();
            Assert.AreEqual(385,_controlulInterfetei.FullDuration);
        }
        [TestMethod]
        public void TestTime()
        {
            _controlulInterfetei.Time = 370;
            Stopwatch sw = new Stopwatch();
            System.Threading.Thread.Sleep(5);
            Assert.AreEqual(370 + sw.Elapsed.TotalSeconds , _controlulInterfetei.Time);
        }
        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestPlayCuParametru()
        {
            _controlulInterfetei.Play(Directory.GetCurrentDirectory() + "/Metallica_ Noting Else Matters.mp3");
        }
    }
}
