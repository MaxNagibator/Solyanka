using System;
using MetadataExtractor;
using System.Linq;

namespace PhotoSorter
{
    internal class HeicParser
    {
        public static OperationResult GetDate(string path)
        {
            try
            {
                var dateTimeOrigin = 36867;
                var dateTime = 306;

                var metadata = ImageMetadataReader.ReadMetadata(path);
                string dateOrig = null;
                string date = null;
                foreach (var directory in metadata)
                {
                    if (directory.Name == "Exif SubIFD")
                    {
                        dateOrig = directory.Tags.FirstOrDefault(tag => tag.Type == dateTimeOrigin)?.Description;
                    }
                    if (directory.Name == "Exif IFD0")
                    {
                        date = directory.Tags.FirstOrDefault(tag => tag.Type == dateTime)?.Description;
                    }
                }
                var value = dateOrig ?? date;
                if (value == null)
                {
                    return new OperationResult { Success = false, Value = "tag date not found" };
                }

                return new OperationResult { Success = true, Value = value };
            }
            catch (Exception exception)
            {
                return new OperationResult { Success = false, Value = exception.Message };
            }
        }
    }
}
