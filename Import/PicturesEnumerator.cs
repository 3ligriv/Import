using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Import
{
    public class PicturesEnumerator
    {
        public List<Tuple<FileInfo, bool>> Pictures { get; private set; }
        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                if (SearchThread == null)
                {
                    path = value;
                }
                else if (SearchThread.ThreadState != ThreadState.Running)
                {
                    path = value;
                }
            }
        }
        public bool ExcludeJPEG { get; private set; }
        public int NbPics { get; private set; }
        public int NbPicsSelected { get; private set; }
        private frm_Main MainForm;
        public Thread SearchThread { get; private set; }

        public PicturesEnumerator(string pPath, bool pExcludeJPEG, frm_Main pMain)
        {
            Pictures = new List<Tuple<FileInfo, bool>>();
            SearchThread = null;
            MainForm = pMain;
            path = pPath;
            ExcludeJPEG = pExcludeJPEG;
            NbPics = 0;
            NbPicsSelected = 0;
        }

        public void Search()
        {
            if (SearchThread == null)
            {
                SearchThread = new Thread(List)
                {
                    IsBackground = true,
                    Name = "Pictures searching"
                };
                SearchThread.Start(this);
            }
        }

        private static void List(Object pPicturesEnumerator)
        {
            PicturesEnumerator picturesEnumerator;
            try
            {
                picturesEnumerator = (PicturesEnumerator)pPicturesEnumerator;
            }
            catch (Exception exc)
            {
                frm_Main.LogError("Error while retrieving pictures:", exc);
                Thread.CurrentThread.Abort();
                return;
            }
            string[] filesExtensions = { ".3fr", ".ari", ".arw", ".srf", ".sr2", ".bay", ".cri", ".crw", ".cr2", ".cr3", ".cap", ".iiq", ".eip", ".dcs", ".dcr", ".drf", ".k25", ".kdc", ".dng", ".erf", ".fff",
                ".mef", ".mdc", ".mos", ".mrw", ".nef", ".nrw", ".orf", ".pef", ".ptx", ".pxn", ".R3D", ".raf", ".raw", ".rw2", ".raw", ".rwl", ".dng", ".rwz", ".srw", ".x3f", "*.jpg", "*.jpeg" };
            List<string> files = filesExtensions.AsParallel().SelectMany(searchPattern => Directory.EnumerateFiles(picturesEnumerator.Path, searchPattern, SearchOption.AllDirectories)).ToList();
            foreach (var file in files)
            {
                picturesEnumerator.Pictures.Add(new Tuple<FileInfo, bool>(new FileInfo(file), true));
                ++picturesEnumerator.NbPics;
                ++picturesEnumerator.NbPicsSelected;
                picturesEnumerator.MainForm.UpdateSearchResults(picturesEnumerator.NbPicsSelected, picturesEnumerator.NbPics);
            }
        }
    }
}
