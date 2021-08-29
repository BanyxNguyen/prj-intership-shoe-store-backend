using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Attributes
{
    [AttributeUsage( AttributeTargets.Field |AttributeTargets.Property)]
    public class GenerateTableAtrribute : Attribute
    {
        public bool IsHide { get; set; } = false;
    }
}
