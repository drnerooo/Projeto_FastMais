using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public interface GenericValidationDictionary
    {
        void AddError(string key, string ErrorMessage);

        bool isValid { get; }

        Dictionary<string, List<string>> Errors { get; }
    }
}
