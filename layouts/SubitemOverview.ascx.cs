namespace Training.layouts
{
    using System;
    using System.Collections.Generic;

    public partial class SubitemOverview : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
        }

        public IEnumerable<Sitecore.Data.Items.Item> GetData()
        {
            return Sitecore.Context.Item.Children;
        }
    }
}