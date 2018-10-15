using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WordApplication = Microsoft.Office.Interop.Word.Application;

namespace GetPhotoByWOrd
{
    class Program
    {
        public class Worker
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }

        private static Worker currentWorker;
        private static List<Worker> workers;
        private static int photoCounter = 1;
        public 
        static void Main(string[] args)
        {
            var word = new WordApplication();
            object miss = System.Reflection.Missing.Value;
            object path = @"D:\!Work\story-data\word\Фото всех работников ДПМ - копия.doc";
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            var count = docs.Paragraphs.Count;
                        currentWorker = new Worker();
            workers = new List<Worker>();
            var date1 = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                var text = docs.Paragraphs[i + 1].Range.Text.ToString();
                if (currentWorker.Code != null)
                {
                    currentWorker.Name = text.Trim('\a').Trim('\r');
                    workers.Add(currentWorker);
                    currentWorker = new Worker();
                }
                double d;
                if(double.TryParse(text,out d))
                {
                    currentWorker.Code = d.ToString();
                }
                if (i % 100 == 0)
                {
                    Console.WriteLine("construct workers. lines: " + i + " \\ " + count + ": workers count: " + workers.Count);
                }
            }
            var date2 = DateTime.Now;
            var difTIme1 = (date2 - date1).TotalSeconds;
            Console.WriteLine("construct worker complite: workers count: " + workers.Count + " construct time: " + difTIme1 + " sek");

            for (var i = 1; i <= word.ActiveDocument.InlineShapes.Count; i++)
            {
                // closure
                // http://confluence.jetbrains.net/display/ReSharper/Access+to+modified+closure
                var inlineShapeId = i;

                // parameterized thread start
                // http://stackoverflow.com/a/1195915/700926
                var thread = new Thread(() => SaveInlineShapeToFile(inlineShapeId, word));

                // STA is needed in order to access the clipboard
                // http://stackoverflow.com/a/518724/700926
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }

            var date3 = DateTime.Now;
            var difTIme2 = (date3 - date2).TotalSeconds;
            var difTIme21 = (date3 - date1).TotalSeconds;
            Console.WriteLine("load image complite time: " + difTIme2 + " sek");
            Console.WriteLine("total execute time: " + difTIme21 + " sek");
            //for (int i = 0; i < word.ActiveDocument.Shapes.Count; i++)
            //{
            //    var inlineShapeId = i;
            //    Thread thread = new Thread(() => SaveInlineShapeToFile(inlineShapeId, word));
            //    thread.SetApartmentState(ApartmentState.STA);
            //    thread.Start();
            //    thread.Join();
            //}
            docs.Close();
            word.Quit();
        }
        //protected void CopyFromClipboardShape(int inlineShapeId, WordApplication wordApplication)
        //{
        //    object missing = Type.Missing;
        //    object i = inlineShapeId + 1;
        //    var shape = wordApplication.ActiveDocument.Shapes.get_Item(ref i);
        //    shape.Select(ref missing);
        //    wordApplication.Selection.Copy();
        //    Image img = Clipboard.GetImage();
        //    /*...*/
        //}

        protected static void SaveInlineShapeToFile(int inlineShapeId, WordApplication wordApplication)
        {
            // Get the shape, select, and copy it to the clipboard
            var inlineShape = wordApplication.ActiveDocument.InlineShapes[inlineShapeId];
            inlineShape.Select();
            wordApplication.Selection.Copy();
            // var name1 = @"D:\!Work\story-data\word\Images\" + String.Format("img_{0}.png", inlineShapeId);
            // var name2 = @"D:\!Work\story-data\word\Images\" + String.Format("img_{0}.gif", inlineShapeId);
            var worker = workers[photoCounter - 1];
            var name3 = @"D:\!Work\story-data\word\Images\" + String.Format("{0} {1}.jpeg", worker.Code, worker.Name);
            // Check data is in the clipboard
            if (Clipboard.GetDataObject() != null)
            {
                //var data = Clipboard.GetDataObject();

                System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
                if (data != null && data.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
                {
                   
                    Image image = (Image)data.GetData(System.Windows.Forms.DataFormats.Bitmap, true);
                    if (image != null)
                    {
                        //            image.Save(name2, System.Drawing.Imaging.ImageFormat.Gif);
                        image.Save(name3, System.Drawing.Imaging.ImageFormat.Jpeg);
                        photoCounter++;
                        if (photoCounter % 100 == 0)
                        {
                            Console.WriteLine("construct images: " + photoCounter + " \\ " + workers.Count);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("image is null :(");
                    }
                }
                else
                {
                   // Console.WriteLine("The Data In Clipboard is not as image format");
                }
            }
        }
    }
}
