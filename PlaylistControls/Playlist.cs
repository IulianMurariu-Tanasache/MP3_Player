/**************************************************************************
 *                                                                        *
 *  File:        Playlist.cs                                              *
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


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace PlaylistControls
{
    /// <summary>
    /// Clasa <c>Playlist</c> reprezinta o coletie de melodii.
    /// </summary>
    [XmlRoot(ElementName = "Playlist")]
    public class Playlist
    {
        private List<string> _pathList; // lista de path-uri absolute? pentru fiecare melodie din playlist
        private string _name; //numele playlist-ului

        ///<value>Reprezinta o lista de path-uri absolute, fiecare path fiind asociat cu o melodie din playlist.</value>
        public List<string> PathList { 
            get { return _pathList; } 
            set { _pathList = value; }
        }

        ///<value>O proprietate special creata pentru a serializa lista de string-uri cu ',' intre melodii</value>
        [XmlElement(ElementName = "Songs")]
        public string SongSerializer
        {
            get { return String.Join(",", _pathList); }
            set { _pathList = value.Split(',').ToList(); }
        }

        [XmlAttribute("name")]
        ///<value>Reprezinta numele playlist-ului</value>
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// Constructor ce initializeaza si numele playlist-ului.
        /// </summary>
        /// <param name="name">Numele playlist-ului</param>
        public Playlist(string name) : this()
        {
            this._name = name; 
        }

        /// <summary>
        /// Constructor fara parametrii, initializeaza lista de melodii. 
        /// </summary>
        public Playlist()
        {
            _pathList = new List<string>();
        }

        /// <summary>
        /// Adauga o noua melodie in playlist.
        /// </summary>
        /// <param name="path">Path al melodiei</param>
        public void AddSong(string path)
        {
            _pathList.Add(path);
        }

        /// <summary>
        /// Functie pentru a obtine path-ul complet al unei melodii
        /// </summary>
        /// <param name="name">Path absolut al melodiei</param>
        /// <returns></returns>
        public string GetFullPath(string name)
        {
            foreach(string song in _pathList)
            {
                if(song.Contains(name))
                    return song;
            }
            return null;
        }

        /// <summary>
        /// Adauga mai multe melodii in playlist
        /// </summary>
        /// <param name="paths">Lista ed path-uri ale melodilor</param>
        public void AddSongs(string[] paths)
        {
            foreach (String path in paths)
                _pathList.Add(path);
        }

        /// <summary>
        /// Sterge din playlist o melodie.
        /// </summary>
        /// <param name="path">Numele melodiei ce trebuie scoasa din lista.</param>
        /// <exception cref="Exception">Eroare ce apare daca melodia ce trebuia stearsa nu e in playlist.</exception>
        public void RemoveSong(string name)
        {
            foreach(String songPath in _pathList)
            {
                if(songPath.Contains(name))
                {
                    _pathList.Remove(songPath);
                    return;
                }
            }
            //throw new Exception("No song with this name in playlist");
        }

        /// <summary>
        /// Serializeaza obiectul playlist intr-un fisier XML.
        /// </summary>
        /// <returns>Continutul fisierului XML serializat din playlist</returns>
        public string ToXml() 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Playlist));
            string xmlString = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, this);
                    xmlString = sww.ToString();
                }
            }

            return xmlString;

        }

        /// <summary>
        /// Proceseaza un fisier XML si returneaza un obiect nou Playlist.
        /// </summary>
        /// <param name="filepath">Path-ul fisierului XML ce trebuie deserializat.</param>
        /// <returns>Obiect Playlist cu datele specificate in XML.</returns>
        public static Playlist FromXml(string filepath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Playlist));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (Playlist)ser.Deserialize(sr);
            }
        }

    }
}
