using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.SecurityModel;
using Sitecore.Web.UI.WebControls;

namespace Training.framework
{
    public class Database : Training.framework.IDatabase
    {
        protected Sitecore.Data.Database database;
        private string p;

        public bool IgnoreSecurity { get; set; }

        public Database(string p)
        {
            database = Sitecore.Configuration.Factory.GetDatabase(p);
        }

        public Database()
        {
            database = Sitecore.Context.Database;
        }

        public string GetName()
        {
            return database.Name;
        }

        public T GetItem<T>(string path) where T : new()
        {
            var item = database.GetItem(path);
            if (item == null) return default(T);

            var t = new T();

            Assign(item, t);
            return t;
        }

        public IEnumerable<T> GetChildren<T>() where T:new()
        {
            var tattr = typeof(T).GetCustomAttribute<TemplateAttribute>();
            if (tattr == null) return null;
            return Sitecore.Context.Item.Children.Where(i=> i.TemplateID.ToString() == tattr.Name || i.Template.FullName == tattr.Name).Select(Assign<T>);
        }

        public void Create(object obj, string path, string name)
        {
            using (new SecurityDisabler())
            {
                var parent = database.GetItem(path);
                if (parent == null) return;

                var tAttr = obj.GetType().GetCustomAttribute<TemplateAttribute>();
                if (tAttr == null) return;

                ID id;
                Item child;
                if (ID.TryParse(tAttr.Name, out id))
                {
                    child = parent.Add(name, new TemplateID(id));
                }
                else
                {
                    child = ItemUtil.AddFromTemplate(name, tAttr.Name, parent);
                }
                Save(obj, child.ID.ToString()); 
            }
        }
       

        public void Save(object obj, string path)
        {
            using (new SecurityDisabler())
            {
                var item = database.GetItem(path);
                if (item != null)
                {
                    using (new EditContext(item))
                    {
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            if (prop.PropertyType == typeof(string))
                            {
                                item[GetFieldName(prop)] = prop.GetValue(obj).ToString();
                            }
                            else if (prop.PropertyType == typeof(Link))
                            {
                                Link lf = (Link) prop.GetValue(obj);
                                Sitecore.Data.Fields.LinkField field = item.Fields[GetFieldName(prop)];
                                if (field != null)
                                {
                                    lf.Assign(field);
                                }
                            }

                            else if (prop.PropertyType == typeof(Field<string>))
                            {
                                Field<string> fieldObj = (Field<string>) prop.GetValue(obj);

                                item[GetFieldName(prop)] = fieldObj.Data;
                                fieldObj.Render = FieldRenderer.Render(item, GetFieldName(prop));
                            }
                            else if (prop.PropertyType == typeof(Field<Link>))
                            {
                                Field<Link> fieldObj = (Field<Link>)prop.GetValue(obj);

                                Sitecore.Data.Fields.LinkField lf = item.Fields[GetFieldName(prop)];
                                fieldObj.Data.Assign(lf);
                                fieldObj.Render = FieldRenderer.Render(item, GetFieldName(prop));
                            }

                        }
                    }
                } 
            }
        }


        private T Assign<T>(Sitecore.Data.Items.Item item) where T: new()
        {
            T t = new T();
            Assign(item,t);
            return t;

        }

        private void Assign(Sitecore.Data.Items.Item item, object t)
        {
            foreach (var prop in t.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(t, item[GetFieldName(prop)]);
                }

                else if (prop.PropertyType == typeof(Field<string>))
                {
                    prop.SetValue(t,new Field<string>(item[GetFieldName(prop)]) {Render = FieldRenderer.Render(item, GetFieldName(prop))});
                }

                else if(prop.PropertyType == typeof(Link))
                {
                    Sitecore.Data.Fields.LinkField linkField = item.Fields[GetFieldName(prop)];
                    if (linkField != null)
                    {                        
                        prop.SetValue(t, (Link)linkField);
                    }
                }

                else if (prop.PropertyType == typeof(Field<Link>))
                {
                    Sitecore.Data.Fields.LinkField linkField = item.Fields[GetFieldName(prop)];
                    if (linkField != null)
                    {
                        prop.SetValue(t, new Field<Link>((Link)linkField) { Render = FieldRenderer.Render(item,GetFieldName(prop))});
                    }
                }
            }
        }

        private string GetFieldName(PropertyInfo prop)
        {
            var attr = prop.GetCustomAttribute<FieldAttribute>();
            if (attr != null)
            {
                return attr.Name;
            }
            return prop.Name;

        }
    }
}