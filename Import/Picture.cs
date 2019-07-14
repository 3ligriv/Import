using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import
{
    public class Picture
    {
        public FileInfo FileInfo { get; set; }
        public bool IsSelected { get; set; }

        public Picture(FileInfo pFileInfo, bool pIsSelected)
        {
            FileInfo = pFileInfo;
            IsSelected = pIsSelected;
        }
    }
}
