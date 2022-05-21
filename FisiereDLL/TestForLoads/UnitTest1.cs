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
using System.Windows;

namespace TestForLoads
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void LoadMusic()
        {
            Load load = new Load();
            Assert.IsNotNull(load);
            Assert.IsFalse(load.ListOfMusic.Contains(".mp3") == false);
            load.LoadMusic();
            Assert.IsTrue(load.ListOfMusic.Contains(".mp3") == true);
        }
    }
}
