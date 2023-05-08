using System;
using System.IO;
using System.Linq;
using ExifLib;
using MetadataExtractor;

namespace PhotoSorter
{
    internal class JpegParser
    {
        public static OperationResult GetDate(string path)
        {
            using (var reader = new ExifReader(path))
            {
                var date = Format(reader, (ushort)ExifTags.DateTimeOriginal);
                if (date == null)
                {
                    date = Format(reader, (ushort)ExifTags.DateTime);
                }

                try
                {
                    return new OperationResult { Success = true, Value = date };
                }
                catch (Exception exception)
                {
                    return new OperationResult { Success = false, Value = exception.Message };
                }
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
