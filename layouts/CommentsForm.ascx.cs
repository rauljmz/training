namespace Training.layouts
{
    using System;
    using Training.framework;
    using Training.code.model;

    public partial class CommentsForm : System.Web.UI.UserControl
    {
        public IDatabase Database { get; set; }
        private void Page_Load(object sender, EventArgs e)
        {
            Database = new Database("master");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var comment = new Comment()
            {
                Author =  txtAuthor.Text,
                CommentText = txtContent.Text,
                Link = new Link(txtWebsite.Text)
            };

            Database.Create(comment, Sitecore.Context.Item.ID.ToString(), Sitecore.DateUtil.IsoNow);

            Sitecore.Web.WebUtil.ReloadPage();
        }
    }
}