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
    [XmlRoot]
    public class Playlist
    {
        private List<String> _pathList; // lista de path-uri absolute? pentru fiecare melodie din playlist
        private string _name; //numele playlist-ului

        [XmlAttribute("PathList")]
        ///<value>Reprezinta o lista de path-uri absolute, fiecare path fiind asociat cu o melodie din playlist.</value>
        public List<String> PathList { 
            get { return _pathList; } 
            set { _pathList = value; }
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
            _pathList = new List<String>();
        }

        /// <summary>
        /// Adauga o noua melodie in playlist.
        /// </summary>
        /// <param name="path">Path al melodiei</param>
        public void AddSong(String path)
        {
            _pathList.Add(path);
        }

        /// <summary>
        /// Sterge din playlist o melodie.
        /// </summary>
        /// <param name="path">Numele melodiei ce trebuie scoasa din lista.</param>
        /// <exception cref="Exception">Eroare ce apare daca melodia ce trebuia stearsa nu e in playlist.</exception>
        public void RemoveSong(String name)
        {
            foreach(String songPath in _pathList)
            {
                if(songPath.Contains(name))
                {
                    _pathList.Remove(songPath);
                    break;
                }
            }
            //trebuie o eroare custom i guess
            throw new Exception("No song with this name in playlist");
        }

        /// <summary>
        /// Serializeaza obiectul playlist intr-un fisier XML.
        /// </summary>
        /// <returns>Continutul fisierului XML ce va 2 tag-uri: 
        /// <list type="bullet">
        ///     <item>Name->Numele playlist-ului;</item>
        ///     <item>PathList->Lista de path-uri pentru fiecare melodie;</item>
        /// </list>
        /// </returns>
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
        /// <remarks>
        /// Fisierul XML trebuie sa aiba acelasi format ca cel descris la functia de Serializare.
        /// </remarks>
        public static Playlist FromXml(String filepath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Playlist));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (Playlist)ser.Deserialize(sr);
            }
        }

    }
}
