using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public class ValidationDictionary : GenericValidationDictionary
    {
        private Dictionary<string, List<string>> _dictionary;

        public ValidationDictionary()
        {
            _dictionary = new Dictionary<string, List<string>>();
        }

        public void AddError(string key, string errorMessage)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = new List<string>();
            }
            _dictionary[key].Add(errorMessage);
        }
        public bool isValid
        {
            get {
                return !(_dictionary.Count > 0); 
            }
        }

        public Dictionary<string, List<string>> Errors
        {
            get { return _dictionary; }
        }
    }
}
