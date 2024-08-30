using System.Xml.Linq;

namespace ResourceTransformator
{
    internal static class XmlPomogator
    {
        public static List<LocalizeString> ParseLocalizeResource(string path)
        {
            var input = File.ReadAllText(path);
            XDocument doc = XDocument.Parse(input);
            var localize = new List<LocalizeString>();
            var dataList = doc.Descendants("data");
            foreach (var data in dataList)
            {
                var localizeKey = data.Attribute("name")?.Value;
                if (localizeKey == null)
                {
                    throw new Exception("key not found: " + data.ToString());
                }
                var type = data.Attribute("type")?.Value;
                if (type != null && type.StartsWith("System.Resources"))
                {
                    Console.WriteLine("skip: " + localizeKey);
                    continue;
                }

                var values = data.Descendants("value");
                if (values.Count() == 0)
                {
                    throw new Exception("zero values: " + data.ToString());
                }

                if (values.Count() > 1)
                {
                    throw new Exception("not single values: " + data.ToString());
                }
                var localizeValue = values.First().Value;
                localize.Add(new LocalizeString(localizeKey, localizeValue));
            }
            return localize;
        }

        internal static void Write(List<LocalizeString> resourceList2, string path)
        {
            var input = File.ReadAllText(path);
            XDocument doc = XDocument.Parse(input);
            var dataList = doc.Descendants("data");
            var asd = resourceList2.GroupBy(x => x.Key).Where(x => x.Count() > 1).Select(x => x.Key).ToArray();
            var dict = resourceList2.ToDictionary(x => x.Key, x => x.Value);
            foreach (var data in dataList)
            {
                var localizeKey = data.Attribute("name")?.Value;
                if (localizeKey == null)
                {
                    throw new Exception("key not found: " + data.ToString());
                }
                var type = data.Attribute("type")?.Value;
                if (type != null && type.StartsWith("System.Resources"))
                {
                    Console.WriteLine("skip: " + localizeKey);
                    continue;
                }
                var values = data.Descendants("value");
                if (values.Count() == 0)
                {
                    throw new Exception("zero values: " + data.ToString());
                }

                if (values.Count() > 1)
                {
                    throw new Exception("not single values: " + data.ToString());
                }

                var localizeValue = values.First();

                if (!dict.ContainsKey(localizeKey))
                {
                    Console.WriteLine("key not found in localize scv file: " + localizeKey);
                    continue;
                }

                var value = dict[localizeKey];
                localizeValue.Value = value;
            }
            doc.Save(path);
        }
    }
}
