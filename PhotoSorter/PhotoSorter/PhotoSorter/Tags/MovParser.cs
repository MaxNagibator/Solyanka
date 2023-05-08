using System;
using MetadataExtractor;

namespace PhotoSorter
{
    internal class MovParser
    {
        public static OperationResult GetDate(string path)
        {
            try
            {
                var dateTimeOrigin = 36867;
                var dateTime = 306;

                //"\"Вт июл 05 17:26:44 2022\""
                //    { (16 tags)}

                var metadata = ImageMetadataReader.ReadMetadata(path);
                string dateOrig = null;
                string date = null;
                foreach (var directory in metadata)
                {
                    if (directory.Name == "QuickTime Movie Header")
                    {
                        foreach (var tag in directory.Tags)
                        {
                            if (tag.Name == "Created")
                            {
                                date = tag.Description;
                            }
                        }
                    }
                    if (directory.Name == "QuickTime Metadata Header")
                    {
                        foreach (var tag in directory.Tags)
                        {
                            if (tag.Name == "Creation Date")
                            {
                                dateOrig = tag.Description;
                            }
                        }
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
