using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.framework
{
    public class Field<T>
    {
        public T Data { get; set; }
        public string Render { get; internal set; }

        public Field(T t)
        {
            Data = t;
        }
    
    
        public static implicit operator Field<T>(T t)
        {
            return new Field<T>(t);
        }

    }
}