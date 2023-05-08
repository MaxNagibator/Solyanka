using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            uiOutputTextBox.Text = "";

            var path = uiFolderTextBox.Text;
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

            var destinationForlder = path + @"\Sorted";
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
                var dectinationFile = Path.Combine(destination, moveFile.Name);
                File.Move(moveFile.FullName, dectinationFile);
                if (moveFile.VideoForPhoto != null)
                {
                    var dectinationFile2 = Path.Combine(destination, moveFile.VideoForPhoto.Name);
                    File.Move(moveFile.VideoForPhoto.FullName, dectinationFile2);
                }
            }
        }
    }
}
