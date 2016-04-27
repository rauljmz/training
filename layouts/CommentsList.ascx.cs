namespace Training.layouts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Training.framework;
    using Training.code.model;

    public partial class CommentsList : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
        }

        public IEnumerable<Comment> rpComments_GetData()
        {
            return new Database().GetChildren<Comment>();
        }
    }
}