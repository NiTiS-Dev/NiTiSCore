using System;
using System.Collections;
using System.Collections.Generic;
using NiTiS.Core.Additions;
using NiTiS.Core.Attributes;

namespace NiTiS.Core.Collections
{
    [Obsolete]
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public class ValueSet : IEnumerable<KeyValuePair<string,string>> ,IEnumerable
    {
        private readonly Dictionary<string, string> values = new Dictionary<string, string>();
        public static ValueSet FromString(string text)
        {
            ValueSet valueSet = new ValueSet();
            if (text is null) { return valueSet; }
            int index = 0;
            foreach(string line in text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                index++;
                string[] items = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if(items.Length >= 2)
                {
                    valueSet.values[items[0].TrimWhiteSpaceFromStartAndEnd()] = items[1].TrimWhiteSpaceFromStartAndEnd();
                }
                else
                {
                    throw new Exception("Error when parse on {index} line");
                }
            }
            return valueSet;
        }
        public string WriteToString()
        {
            string text = "";
            foreach(KeyValuePair<string, string> item in values)
            {
                text += item.Key.FormatForValueSet().TrimWhiteSpaceFromStartAndEnd() + " : " + item.Value.FormatForValueSet().TrimWhiteSpaceFromStartAndEnd() + "\r\n";
            }
            return text;
        }
        public void ReadFromString(string text)
        {
            if (text is null) return;
            this.Clear();
            foreach (KeyValuePair<string,string> valuePair in FromString(text))
            {
                this[valuePair.Key] = valuePair.Value;
            }
        }
        public void Clear() => values.Clear();
        public void Put(string name, string item)
        {
            if (!String.IsNullOrWhiteSpace(item) || !String.IsNullOrWhiteSpace(item))
            {
                values[name] = item;
            }
        }
        public string Read(string name)
        {
            return values.ContainsKey(name) ? values[name] : "";
        }
        public string this[string name]
        {
            get
            {
                return values[name] ?? "";
            }
            set
            {
                values[name] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return values.GetEnumerator();
        }
        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
}
