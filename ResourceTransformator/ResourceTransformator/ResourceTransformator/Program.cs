using ResourceTransformator;
using System.Text;

Console.WriteLine("Hello, World!");


var dir = "E:\\bobgroup\\repo\\Solyanka\\ResourceTransformator\\ExampleFiles";

var toCsv = true;
if (toCsv)
{
    var resourceList = XmlPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.resx"));
    CsvPomogator.WriteCsv(resourceList, Path.Combine(dir, "Resource.csv"));

    resourceList = XmlPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.en.resx"));
    CsvPomogator.WriteCsv(resourceList, Path.Combine(dir, "Resource.en.csv"));
}
else
{
    var resourceList2 = CsvPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.csv"));
    XmlPomogator.Write(resourceList2, Path.Combine(dir, "Resource.resx"));

    resourceList2 = CsvPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.en.csv"));
    XmlPomogator.Write(resourceList2, Path.Combine(dir, "Resource.resx"));
}