using System;

namespace PhotoSorter
{
    public class SortedFile
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public SortedFile VideoForPhoto { get; set; }
        public DateTime? Date { get; set; }
    }
}
