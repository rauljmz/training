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
        public void Process(Sitecore.Web.UI.Sheer.ClientPipelineArgs args)
        {
            var guid = args.Parameters[1];
            var newParentID = args.Parameters[5];


            var item = Sitecore.Context.ContentDatabase.GetItem(guid);
            //var oldParentID = Sitecore.Events.Event.ExtractParameter<ID>(args, 1);
            //var newParentID = Sitecore.Events.Event.ExtractParameter<ID>(args, 2);

            var newParent = item.Database.GetItem(newParentID);
            if (newParent != null)
            {
                if (!newParent[FieldIDs.Branches].Contains(item.TemplateID.ToString()))
                {
                    args.AbortPipeline();
                    Sitecore.Context.ClientPage.ClientResponse.Alert("You are not allowed to copy the item to that location");
                }

            }
        }
    }
}