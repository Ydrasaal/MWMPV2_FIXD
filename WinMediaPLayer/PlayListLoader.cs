using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMediaPLayer.Models;

namespace WinMediaPLayer
{
    class PlayListLoader
    {
        private List<PlaylistModel> plBase = new List<PlaylistModel>();

        public PlayListLoader()
        {
            string[] filePaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\Playlists", "*.bmp");
            for (int it = 0; filePaths[it] != null; it++)
            {
                MessageBox.Show(filePaths.ToString());
            }
            
        }
    }
}
