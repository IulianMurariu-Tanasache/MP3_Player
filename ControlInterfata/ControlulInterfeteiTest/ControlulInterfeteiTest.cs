using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ControlulInterfeteiNameSpace;
using System.IO;

namespace ControlulInterfeteiTest
{
    [TestClass]
    public class ControlulInterfeteiTest
    {
        private List<string> _list = new List<string>();
        private ControlulInterfetei _controlulInterfetei = ControlulInterfetei.Instance();
        [TestMethod]
        public void TestAddSongs()
        {
            _list = new List<string>();
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Nothing Else Matters.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica - The Unforgiven.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Enter Sandman.mp3");
            _controlulInterfetei.AddSongs(_list);
        }
        [TestMethod]
        public void TestRemonveSongs()
        {
            _list = new List<string>();
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Nothing Else Matters.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica - The Unforgiven.mp3");
            _list.Add(Directory.GetCurrentDirectory() + "/Metallica_ Enter Sandman.mp3");
            _controlulInterfetei.RemoveSongs(_list);
        }
        [TestMethod]
        public void TestPlayCuParametru()
        {
            _controlulInterfetei.Play(Directory.GetCurrentDirectory() + "/Metallica_ Noting Else Matters.mp3");
        }
    }
}
