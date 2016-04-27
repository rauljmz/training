using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.framework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TemplateAttribute:NameIDBaseAttribute
    {
        public TemplateAttribute(string name) : base(name)
        {
        }
    }
}