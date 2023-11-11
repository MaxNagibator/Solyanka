using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetadataExtractor.Formats.Photoshop;

namespace PhotoSorter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void uiSortButton_Click(object sender, EventArgs e)
        {
            var path = uiFolderTextBox.Text;
            var destinationForlder = path + @"\Sorted";
            Sort(path, destinationForlder);
        }

        private void Sort(string path, string destinationForlder)
        {
            uiOutputTextBox.Text = "";
            var directoryInfo = new DirectoryInfo(path);
            var fileExtensions = uiFileTypeTextBox.Text.Split(',').Select(x => "." + x.ToLower()).ToArray();
            var fileList = directoryInfo.GetFiles().Where(x => fileExtensions.Contains(x.Extension.ToLower()))
                .Select(x => new SortedFile { Name = x.Name, FullName = x.FullName, Extension = x.Extension.ToLower() })
                .ToList();

            uiMainProgressBar.Value = 0;
            uiMainProgressBar.Maximum = fileList.Count() * 2;

            // видосы вконец, чтоб раскидать вместе с фотками
            foreach (var fileInfo in fileList.OrderBy(x => x.Extension == ".mov"))
            {
                uiMainProgressBar.Value++;
                try
                {
                    var fileName = fileInfo.Name;
                    var ext = fileInfo.Extension;
                    OperationResult getDateResult;
                    if (ext == ".jpg" || ext == ".jpeg")
                    {
                        getDateResult = JpegParser.GetDate(fileInfo.FullName);
                    }
                    else if (ext == ".heic")
                    {
                        getDateResult = HeicParser.GetDate(fileInfo.FullName);
                    }
                    else if (ext == ".mov")
                    {
                        getDateResult = MovParser.GetDate(fileInfo.FullName);
                    }
                    else
                    {
                        uiOutputTextBox.Text += "skip type " + ext + Environment.NewLine;
                        continue;
                    }
                    if (getDateResult.Success)
                    {
                        DateTime? date = null;
                        if (getDateResult.Value != null)
                        {
                            try
                            {
                                date = DateTime.ParseExact(getDateResult.Value, "yyyy:MM:dd HH:mm:ss", null);
                            }
                            catch (Exception exception)
                            {
                            }
                            try
                            {
                                date = DateTime.ParseExact(getDateResult.Value, "ddd MMM dd HH:mm:ss yyyy", null);
                            }
                            catch (Exception exception)
                            {
                            }

                            try
                            {
                                date = DateTime.ParseExact(getDateResult.Value, "ddd MMM dd HH:mm:ss zzz yyyy", null);
                            }
                            catch (Exception exception)
                            {
                            }
                        }

                        if (date == null)
                        {
                            uiOutputTextBox.Text += $"date '{date}' not parsed: " + Environment.NewLine;
                        }
                        else
                        {
                            fileInfo.Date = date.Value;
                        }

                    }
                    else
                    {
                        var ifVideoForPhoto = false;
                        if (ext == ".mov")
                        {
                            var searched = fileName.ToLower().Replace(".mov", ".heic");
                            var f = fileList.FirstOrDefault(x => x.Name.ToLower() == searched);
                            if (f != null)
                            {
                                f.VideoForPhoto = fileInfo;
                                ifVideoForPhoto = true;
                            }
                        }

                        if (!ifVideoForPhoto)
                        {
                            uiOutputTextBox.Text += getDateResult.Value + Environment.NewLine;
                        }
                    }
                }
                catch (Exception exception)
                {
                    uiOutputTextBox.Text += exception.Message + Environment.NewLine;
                }
            }

            uiOutputTextBox.Text += fileList.Count.ToString();

            var forMove = fileList.Where(x => x.Date != null);
            uiMainProgressBar.Value += (fileList.Count() - forMove.Count());
            foreach (var moveFile in forMove)
            {
                uiMainProgressBar.Value++;
                var subFolder = moveFile.Date.Value.ToString("yyyy");
                var subFolder2 = moveFile.Date.Value.ToString("yy.MM");
                var destination = Path.Combine(destinationForlder, subFolder, subFolder2);
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }

                var dectinationFile = GetDestFile(moveFile.Name, destination);
                File.Move(moveFile.FullName, dectinationFile);
                if (moveFile.VideoForPhoto != null)
                {
                    var dectinationFile2 = GetDestFile(moveFile.VideoForPhoto.Name, destination);
                    File.Move(moveFile.VideoForPhoto.FullName, dectinationFile2);
                }
            }

            if (uiIncludeSubdirCheckBox.Checked)
            {
                var subPaths = Directory.GetDirectories(path);
                foreach (var subPath in subPaths)
                {
                    var directoryInfo2 = new DirectoryInfo(subPath);
                    Sort(subPath, destinationForlder);
                }
            }
        }

        private static string GetDestFile(string moveFileName, string destination)
        {
            var dectinationFile = Path.Combine(destination, moveFileName);
            while (File.Exists(dectinationFile))
            {
                var dotIndex = moveFileName.LastIndexOf(".");
                var origName = moveFileName;
                var postfix = "";
                if (dotIndex != -1)
                {
                    origName = moveFileName.Substring(0, dotIndex);
                    postfix = moveFileName.Substring(dotIndex);

                }
                bool up = false;
                if (origName.EndsWith(")") && origName.Contains("("))
                {
                    var i1 = origName.LastIndexOf("(");
                    var i2 = origName.LastIndexOf(")");
                    var number = origName.Substring(i1 + 1, i2 - i1 - 1);
                    if (int.TryParse(number, out int num))
                    {
                        num++;
                        // превращаем img_123(2) в img_123(3), или img_123 в img_123(2)
                        origName = origName.Substring(0, i1) + "(" + num + ")";
                        up = true;
                    }
                }
                if (up == false)
                {
                    origName = origName + "(2)";
                }
                moveFileName = origName + postfix;
                dectinationFile = Path.Combine(destination, moveFileName);
            }

            return dectinationFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = uiFolderTextBox.Text;
            var directoryInfo = new DirectoryInfo(path);
            var fileList = directoryInfo.GetFiles();
            foreach (var file in fileList)
            {
                var newName = file.FullName.Substring(0, file.FullName.Length - file.Extension.Length) + "_2"+ file.Extension;
                File.Move(file.FullName, newName);
            }
        }
    }
}
