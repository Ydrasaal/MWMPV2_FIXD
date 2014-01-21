using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMediaPLayer.Models
{
    class PlaylistModel
    {
        //Name, Filename
        private List<String> playList;

        PlaylistModel()
        {
            this.playList = new List<String>();
        }

        public void addElement(String filepath)
        {
            this.playList.Add(filepath);
        }

        public void removeElement(String filepath)
        {
            this.playList.Remove(filepath);
        }

        public List<String> getPlayList() {
            return this.playList;
        }

        public void setPlayList(List<String> playlist) {
            this.playList = playlist;
        }
    }
}
