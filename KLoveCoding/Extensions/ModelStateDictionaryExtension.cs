using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace KLoveCoding.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static void Merge(this ModelStateDictionary modelState, List<string> dictionary)
        {
            foreach (var item in dictionary)
            {
                modelState.AddModelError("", item);
            }
        }
    }
}