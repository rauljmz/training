using Sitecore.Data.Items;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Training.code
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        public Item Item { get; set; }

        public NameValueCollection Parameters { get; set; }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var datasource = Attributes["sc_datasource"];
            Item = string.IsNullOrEmpty(datasource) ? Sitecore.Context.Item :
                Sitecore.Context.Database.GetItem(datasource) ?? Sitecore.Context.Item;

            Parameters = WebUtil.ParseUrlParameters(Attributes["sc_parameters"]);

            
            foreach(var key in Parameters.AllKeys)
            {
                var prop = this.GetType().GetProperty(key);
                if (prop != null)
                {
                    prop.SetValue(this, Parameters[key]);
                }
            }
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            using (new ContextItemSwitcher(Item))
            {
                base.Render(writer);
            }
        }
    }
}