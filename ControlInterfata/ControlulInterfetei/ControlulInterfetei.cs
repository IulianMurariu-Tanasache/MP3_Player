using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlulInterfeteiNamespace
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
        /// Proprietate a carei valoare schimba momentul in care esti in melodie.
        /// </summary>
         public int Time
        {
            get
            {
                return (int)((_wplayer.controls.currentPosition));
            }
            set { _wplayer.controls.currentPosition = (double)(value); }
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
        /// Functie prin care adaugam cantecele din playlist-ul curent.
        /// </summary>
        /// <param name="l"></param>
        public void AddSongs(List<String> l)
        {
            _list = l;
            WMPLib.IWMPPlaylist playlist = _wplayer.playlistCollection.newPlaylist("Songs");
            WMPLib.IWMPMedia media;
            foreach (string file in l)
            {
                media = _wplayer.newMedia(file);
                playlist.appendItem(media);
            }
            _wplayer.currentPlaylist = playlist;
            Stop();
        }
        /// <summary>
        /// Functie care porneste piesa curenta.
        /// </summary>
        public void Play()
        {
            _wplayer.controls.play();
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

        public int FullDuration
        {
            get { return (int)_wplayer.currentMedia.duration; }
        }
    }
}
