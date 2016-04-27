using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.framework
{
    public class Link
    {
        public string URL { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Text { get; set; }

        public Link(string url)
        {
            URL = url;
            Type = "external";
            Target = "_blank";
            Text = url;
        }

        public static implicit operator Link(Sitecore.Data.Fields.LinkField lf)
        {
            return new Link(lf.Url) { Type = lf.LinkType , Target = lf.Target , Text = lf.Text };
        }

        public void Assign(Sitecore.Data.Fields.LinkField lf)
        {
            lf.Url = this.URL;
            lf.LinkType = this.Type;
            lf.Text = this.Text;
            lf.Target = this.Target;
        }
    }
}