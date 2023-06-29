namespace DictionaryReplacer
{
    public class DictionaryReplacerClass
    {
        public string ReplaceFromDictionary(string value, Dictionary<string, string> dictionary)
        {
            if (value == null || dictionary == null)
            {
                throw new ArgumentNullException("String value can not be null.");
            }

            if (dictionary.ContainsValue(null))
            {
                throw new ArgumentNullException("Dictionary can not contain null in keys or values.");
            }

            foreach (var k1 in dictionary.Keys)
            {
                value = value.Replace($"${k1}$", dictionary[k1]);
            }

            return value;
        }
    }
}