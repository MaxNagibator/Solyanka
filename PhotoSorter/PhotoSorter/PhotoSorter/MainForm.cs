using ExifLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var path = @"D:\Documents\мои документы\Мои рисунки\photo\Sort\photo";
            var directoryInfo = new DirectoryInfo(path);
            var fileList = directoryInfo.GetFiles().Where(x => x.Extension.ToLower() == ".jpg").ToList();
            var fileDates = new Dictionary<FileInfo, DateTime>();
            foreach (var fileInfo in fileList)
            {
                try
                {
                    using (var reader = new ExifReader(fileInfo.FullName))
                    {
                        //textBox1.Text += Format(reader, (ushort)ExifTags.DateTimeOriginal);
                        var date = Format(reader, (ushort) ExifTags.DateTimeOriginal);
                        if (date == null)
                        {
                            date = Format(reader, (ushort) ExifTags.DateTime);
                        }

                        try
                        {
                            fileDates.Add(fileInfo, DateTime.ParseExact(date, "yyyy:MM:dd HH:mm:ss", null));
                        }
                        catch (Exception exception)
                        {
                            //очень жаль
                        }
                    }
                }
                catch (Exception exception)
                {
                    //очень жаль
                }
            }

            textBox1.Text = fileDates.Count.ToString();

            var destinationForlder = @"D:\Documents\мои документы\Мои рисунки\photo\Sort\photo\Sorted";
            foreach (var fileDate in fileDates)
            {
                var subFolder = fileDate.Value.ToString("yyyy");
                var subFolder2 = fileDate.Value.ToString("yy.MM");
                var destination = Path.Combine(destinationForlder, subFolder, subFolder2);
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                var dectinationFile = Path.Combine(destination, fileDate.Key.Name);
                File.Move(fileDate.Key.FullName, dectinationFile);
            }
        }

        /// <summary>
        /// скопировал с образца
        /// </summary>
        private static string Format(ExifReader reader, ushort tagID, bool isNeedFormatPrefix = false)
        {
            object val;
            if (reader.GetTagValue(tagID, out val))
            {
                // Special case - some doubles are encoded as TIFF rationals. These
                // items can be retrieved as 2 element arrays of {numerator, denominator}
                if (val is double)
                {
                    int[] rational;
                    if (reader.GetTagValue(tagID, out rational))
                        val = string.Format("{0} ({1}/{2})", val, rational[0], rational[1]);
                }

                if (isNeedFormatPrefix)
                {
                    return string.Format("{0}: {1}", Enum.GetName(typeof(ExifTags), tagID), RenderTag(val));
                }

                return RenderTag(val);
            }

            return null;
        }

        /// <summary>
        /// скопировал с образца
        /// </summary>
        private static string RenderTag(object tagValue)
            {
                // Arrays don't render well without assistance.
                var array = tagValue as Array;
                if (array != null)
                {
                    // Hex rendering for really big byte arrays (ugly otherwise)
                    if (array.Length > 20 && array.GetType().GetElementType() == typeof(byte))
                        return "0x" + string.Join("", array.Cast<byte>().Select(x => x.ToString("X2")).ToArray());

                    return string.Join(", ", array.Cast<object>().Select(x => x.ToString()).ToArray());
                }

                return tagValue.ToString();
            }
    
    }
}
