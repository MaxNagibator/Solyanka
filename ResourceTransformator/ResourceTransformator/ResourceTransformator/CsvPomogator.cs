using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ResourceTransformator
{
    internal static class CsvPomogator
    {
        static CsvConfiguration CsvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ";",
        };

        internal static List<LocalizeString> ParseLocalizeResource(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CsvConfig))
            {
                var localize = csv.GetRecords<LocalizeString>().ToList();
                return localize;
            }
        }

        internal static void WriteCsv(List<LocalizeString> resourceList, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            using (var csv = new CsvWriter(writer, CsvConfig))
            {
                csv.WriteRecords(resourceList);
            }
        }
    }
}
