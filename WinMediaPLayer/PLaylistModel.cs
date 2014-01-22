using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMediaPLayer.Models
{
    class PlaylistModel
    {
        //Name, Filename
        private ObservableCollection<String> playList;

        public PlaylistModel()
        {
            this.playList = new ObservableCollection<String>();
        }

        public void addElement(String filepath)
        {
            this.playList.Add(filepath);
        }

        public void removeElement(String filepath)
        {
            this.playList.Remove(filepath);
        }

        public ObservableCollection<String> getPlayList()
        {
            return this.playList;
        }

        public void setPlayList(ObservableCollection<String> playlist)
        {
            this.playList = playlist;
        }

        public List<String> getNameList()
        {
            var tmp = new List<String>();

            foreach (String element in this.playList) {
                tmp.Add(Path.GetFileName (element));
            }
            return tmp;
        }
    }
}
