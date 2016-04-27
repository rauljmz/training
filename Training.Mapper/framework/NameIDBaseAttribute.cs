using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.framework
{
    public class NameIDBaseAttribute : Attribute
    {
        public string Name;
        public ID Id;
        public NameIDBaseAttribute(string name)
        {
            if (ID.IsID(name))
            {
                Id = ID.Parse(name);
            }
            Name = name;
        }

        public NameIDBaseAttribute(ID id)
        {
            Id = id;
        }
    }
}