/**************************************************************************
 *                                                                        *
 *  File:        Header.cs                                                *
 *  Copyright:   (c) 2022, Zaharia Teodor Mihai                           *
 *  E-mail:      teodor-mihai.zaharia@student.tuiasi.ro                   *
 *  Description: Library for the controls of a music player.              *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ControlulInterfeteiNameSpace
{
    /// <summary>
    /// Clasa singleton care se ocupa de controlul interfetei.
    /// </summary>
    public class ControlulInterfetei
    {
        /// <summary>
        /// Variabila pentru instanta clasei.
        /// </summary>
        private static ControlulInterfetei _instance;
        /// <summary>
        /// Instanta a Windows Media Player.
        /// </summary>
        private WMPLib.WindowsMediaPlayer _wplayer;
        /// <summary>
        /// Variabila care este adevarata cand am apasat pauza.
        /// </summary>
        private bool _paused = false;
        /// <summary>
        /// Variabila care este adevarata cand player-ul functioneaza.
        /// </summary>
        private bool _playing = false;
        /// <summary>
        /// Lista de piese din playlist-ul curent.
        /// </summary>
        private List<string> _list;
        /// <summary>
        /// Proprietate care seteaza sau returneaza momentul actual din piesa
        /// </summary>
        public int Time
        {
            get
            {
                return (int)(_wplayer.controls.currentPosition);
            }
            set { _wplayer.controls.currentPosition = (double)(value); }
        }
        /// <summary>
        /// Proprietate care returneaza lungimea melodiei.
        /// </summary>
        public int FullDuration
        {
            get
            {
                return (int)(_wplayer.currentMedia.duration);
            }
        }
        /// <summary>
        /// Constructor privat al clasei.
        /// </summary>
        private ControlulInterfetei()
        {
            _wplayer = new WMPLib.WindowsMediaPlayer();
        }
        /// <summary>
        /// Functie care are rolul de constructor public.
        /// </summary>
        /// <returns>Instanta clasei</returns>
        public static ControlulInterfetei Instance()
        {
            if (_instance == null)
            {
                _instance = new ControlulInterfetei();
            }
            return _instance;
        }
        /// <summary>
        /// Functie prin care adaugam cantecele intr-un playlist nou.
        /// </summary>
        /// <param name="l"></param>
        public void AddSongs(List<String> l)
        {
            _list = l;
            WMPLib.IWMPMedia media;
            foreach (string file in l)
            {
                if (file == "" || file == null)
                    throw new ArgumentException("No path given.");
                media = _wplayer.newMedia(file);
                _wplayer.currentPlaylist.appendItem(media);
            }
            Stop();
        }
        /// <summary>
        /// Functie prin care eliminam cantece dintr-un playlist.
        /// </summary>
        /// <param name="l"></param>
        public void RemoveSongs(List<String> l)
        {
            WMPLib.IWMPMedia media;
            foreach (string file in l.ToList())
            {
                if (file == "" || file == null)
                    throw new ArgumentException("No path given.");
                media = _wplayer.currentPlaylist.get_Item(_list.IndexOf(file));
                _wplayer.currentPlaylist.removeItem(media);
                _list.Remove(file);
            }
        }
        /// <summary>
        /// Functie care porneste piesa curenta.
        /// </summary>
        public void Play()
        {
            _wplayer.controls.play();
            _wplayer.currentMedia.name = _wplayer.currentMedia.name;
            _playing = true;
            _paused = false;
        }
        /// <summary>
        /// Functie care porneste piesa data prin parametru.
        /// </summary>
        /// <param name="music"></param>
        public void Play(string music)
        {
            int index = _list.IndexOf(music);
            if (_list.IndexOf(music) == -1)
                throw new ArgumentException("The song is not in the playlist.");
            WMPLib.IWMPMedia media = _wplayer.currentPlaylist.get_Item(index);
            _wplayer.controls.playItem(media);
            _playing = true;
            _paused = false;
        }
        /// <summary>
        /// Functie care pune pauza la muzica.
        /// </summary>
        public void Pause()
        {
            if (_playing == true)
            {
                if (_paused == false)
                {
                    _wplayer.controls.pause();
                    _paused = true;
                }
                else
                {
                    _wplayer.controls.play();
                    _paused = false;
                }
            }
        }
        /// <summary>
        /// Functie care opreste melodia curenta.
        /// </summary>
        public void Stop()
        {
            _wplayer.controls.stop();
            _playing = false;
            _paused = false;
        }
        /// <summary>
        /// Functie care porneste melodia urmatoare din playlist.
        /// </summary>
        public void Next()
        {
            _wplayer.controls.next();
            _playing = true;
        }
        /// <summary>
        /// Functie care porneste melodia precedenta din playlist.
        /// </summary>
        public void Previous()
        {
            _wplayer.controls.previous();
            _playing = true;
        }
        /// <summary>
        /// Functie care seteaza volumul.
        /// </summary>
        /// <param name="v"></param>
        public void Volume(int v)
        {
            _wplayer.settings.volume = v;
        }
        /// <summary>
        /// Functie care seteaza modul shuffle.
        /// </summary>
        /// <param name="state"></param>
        public void Shuffle(bool state)
        {
            _wplayer.settings.setMode("shuffle", state);
        }
    }
}
