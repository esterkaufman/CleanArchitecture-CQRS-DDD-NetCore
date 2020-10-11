using Moj.Keshet.Domain.ExampleModels;
using Moj.Keshet.Domain.Models.Common;
using System.Collections.Generic;
using System.Linq;


namespace Moj.Keshet.Domain.ExampleModels.CodeTables
{
    public class GetCodeTableResponse : Response
    {
        public List<CodeTablePair> CodeTableDictionary { get; set; }

        public string Context { get; set; }

        public List<CodeTablePair> SortedCodeTableDictionary { get { return CodeTableDictionary.OrderBy(a => a.Value).ToList(); } }

        public List<CodeTablePair> SortedByKeyCodeTableDictionary { get { return CodeTableDictionary.OrderBy(a => a.Key).ToList(); } }

        public int GetKey(string value)
        {
            var codeTablePair = CodeTableDictionary.Find(node => node.Value == value);
            if (codeTablePair == null)
            {
                //LogDebug<GetCodeTableResponse>("GetCodeTableResponse.GetKey failed in {0} on value {1}", Context, value);
                throw new KeyNotFoundException();
            }
            return codeTablePair.Key;
        }

        public bool TryGetKey(string value, out int? key)
        {
            key = null;
            var codeTablePair = CodeTableDictionary.Find(node => node.Value == value);
            if (codeTablePair == null) return false;
            key = codeTablePair.Key;
            return true;
        }

        public string GetValue(int key)
        {
            var codeTablePair = CodeTableDictionary.Find(node => node.Key == key);
            if (codeTablePair == null)
            {
                //LogDebug<GetCodeTableResponse>("GetCodeTableResponse.GetValue failed in {0} on value {1}", Context, key);
                throw new KeyNotFoundException();
            }
            return codeTablePair.Value;
        }

        public string GetSafeValue(int key)
        {
            var codeTablePair = CodeTableDictionary.Find(node => node.Key == key);
            if (codeTablePair == null) return string.Empty;
            return codeTablePair.Value;
        }

        public string GetSafeValue(int? key)
        {
            if (!key.HasValue)
                return string.Empty;
            return GetSafeValue(key.Value);
        }

        public string GetSafeValueAsNull(int key)
        {
            var codeTablePair = CodeTableDictionary.Find(node => node.Key == key);
            if (codeTablePair == null) return null;
            return codeTablePair.Value;
        }

        public bool TryGetValue(int key, out string value)
        {
            value = null;
            var codeTablePair = CodeTableDictionary.Find(node => node.Key == key);
            if (codeTablePair == null) return false;
            value = codeTablePair.Value;
            return true;
        }
    }
}