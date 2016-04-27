using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.code
{
    public class InsertOptionMovingRestriction
    {
        public void OnMoving(object sender, EventArgs args)
        {
            var item = Sitecore.Events.Event.ExtractParameter<Item>(args, 0);
            //var oldParentID = Sitecore.Events.Event.ExtractParameter<ID>(args, 1);
            var newParentID = Sitecore.Events.Event.ExtractParameter<ID>(args, 2);

            var newParent = item.Database.GetItem(newParentID);
            if (newParent != null)
            {
                if (!newParent[FieldIDs.Branches].Contains(item.TemplateID.ToString()))
                {
                    ((SitecoreEventArgs)args).Result.Cancel = true;
                    SheerResponse.Alert("You are not allowed to copy the item to that location", true);
                }

            }
        }
    }
}