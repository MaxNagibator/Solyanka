using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class Form1 : Form
    {
        private Thread _thread;
        private string _path;
        private string _sortedPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void uiStartButton_Click(object sender, EventArgs e)
        {
            _path = uiFolderPathTextBox.Text;
            _sortedPath = uiSortedFolderPathTextBox.Text;
            uiStartButton.Enabled = false;
            uiStopButton.Enabled = true;
            _thread = new Thread(Sort);
            _thread.Start();
        }

        private void Sort()
        {
            var di = new DirectoryInfo(_path);
            var extList = di.GetFiles().Select(x=>x.Extension).Distinct().ToList();
            var count = extList.Count;
            uiSortProgressBar.Maximum = count;
            uiSortProgressBar.Value = 0;
            uiSortProgressBar.Step = 1;
            foreach (var ext2 in extList.OrderBy(x=>String.IsNullOrEmpty(x)))
            {
                var ext = ext2;
                FileInfo[] files;
                if (String.IsNullOrEmpty(ext))
                {
                    ext = "none extention";
                    files = di.GetFiles();
                }
                else
                {
                    ext = ext2.Substring(1);
                    files = di.GetFiles("*." + ext);
                }
                var path = Path.Combine(_sortedPath, ext);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var file in files)
                {
                    var filePath = Path.Combine(path, file.Name);
                    if (!File.Exists(filePath))
                    {
                        file.MoveTo(filePath);
                    }
                    else
                    {
                        var file2 = new FileInfo(filePath);
                        if(!FilesAreEqualByHash(file, file2))
                        {
                            filePath = MakeUnique(filePath);
                            file.MoveTo(filePath);
                        }
                    }
                }
                uiSortProgressBar.PerformStep();
            }
            uiStartButton.Enabled = true;
            uiStopButton.Enabled = false;
        }

        private void uiStopButton_Click(object sender, EventArgs e)
        {
            uiStartButton.Enabled = true;
            uiStopButton.Enabled = false;
            _thread.Abort();
        }
        static bool FilesAreEqualByHash(FileInfo first, FileInfo second)
        {
            byte[] firstHash;
            using (FileStream fs = File.OpenRead(first.FullName))
            {
                firstHash = MD5.Create().ComputeHash(fs);
            }
            byte[] secondHash;
            using (FileStream fs = File.OpenRead(second.FullName))
            {
                secondHash = MD5.Create().ComputeHash(fs);
            }
            for (int i = 0; i < firstHash.Length; i++)
            {
                if (firstHash[i] != secondHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string MakeUnique(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                    return path;

                path = Path.Combine(dir, fileName + " " + i + fileExt);
            }
        }
    }
}
