using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.framework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : NameIDBaseAttribute
    {
        public FieldAttribute(string name): base(name)
        {
        }

        public FieldAttribute(Sitecore.Data.ID id): base(id)
        {
        }
    }
}