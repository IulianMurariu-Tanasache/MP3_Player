using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlulInterfeteiNamespace
{
    public class ControlulInterfetei
    {
        private static ControlulInterfetei _instance;
        private WMPLib.WindowsMediaPlayer _wplayer;
        private bool _paused = false;
        private bool _playing = false;
        private List<string> _list;
        private int _index = 0;
        private ControlulInterfetei()
        {
            _wplayer = new WMPLib.WindowsMediaPlayer();
        }
        public static ControlulInterfetei Instance()
        {
            if (_instance == null)
            {
                _instance = new ControlulInterfetei();
            }
            return _instance;
        }

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
        }
        public void Play()
        {
            _wplayer.controls.play();
            _playing = true;
        }

        public void Play(string music)
        {
            int index = _list.IndexOf(music);
            WMPLib.IWMPMedia media = _wplayer.currentPlaylist.get_Item(index);
            _wplayer.controls.playItem(media);
            _playing = true;
        }

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

        public void Stop()
        {
            _wplayer.controls.stop();
            _playing = false;
            _paused = false;
        }

        public void Next()
        {
            _wplayer.controls.next();
            _playing = true;
        }

        public void Previous()
        {
            _wplayer.controls.previous();
            _playing = true;
        }

        public void Volume(int v)
        {
            _wplayer.settings.volume = v;
        }
        public int Time 
        {
            get{
                return (int)((_wplayer.controls.currentPosition * 1000) / _wplayer.currentMedia.duration);
            }
            set { _wplayer.controls.currentPosition = (double)(value* _wplayer.currentMedia.duration)/1000; }
        }

        public void Shuffle(bool state)
        {
            _wplayer.settings.setMode("shuffle", state);
        }
    }
}
