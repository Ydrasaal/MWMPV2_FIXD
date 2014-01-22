using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinMediaPLayer.Models
{
    class PlaylistModel
    {
        //Name, Filename
        private String plName = null;
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

        public String getPathByName(String fileName)
        {
            int index = this.getNameList().IndexOf(fileName);
            String tmp = this.playList[index];
            return tmp;
        }

        public String getPlName()
        {
            return this.plName;
        }

        public void setPlName(String name)
        {
            this.plName = name;
        }

        internal void removeByName(string fileName)
        {
            int index = this.getNameList().IndexOf(fileName);
            MessageBox.Show(index.ToString());
            if (plName != null)
            {
                this.plName.Remove(index, 1);
            }
            if (playList != null) {
                this.playList.RemoveAt(index);
            }
        }

        public int getIndex(string fileName)
        {
            int index = this.getNameList().IndexOf(fileName);
            return index;
        }

        internal void flush()
        {
            this.playList.Clear();
        }
    }
}
