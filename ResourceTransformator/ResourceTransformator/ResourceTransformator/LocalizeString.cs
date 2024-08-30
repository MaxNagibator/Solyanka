using CsvHelper.Configuration.Attributes;

namespace ResourceTransformator
{
    internal class LocalizeString(string key, string value)
    {
        [Index(0)]
        public string Key { get; } = key;

        [Index(1)]
        public string Value { get; } = value;
    }
}
