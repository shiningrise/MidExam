using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.DataAnnotations;
using MidExam.DAL.Util;
using MidExam.DAL.Models;

namespace MidExam.DAL.Util
{
    public static class PageHelper
    {

        /*
        public static bool ValidateSave(Page p, IDbObject obj, NoticeLabel msg, string noticeText)
        {
            var vh = new ValidateHandler();
            return ValidateSave(p, vh, obj, msg, noticeText, "ErrInput");
        }

        public static bool ValidateSave(Page p, ValidateHandler vh, IDbObject obj, NoticeLabel msg, string noticeText, string cssErrInput)
        {
            return ValidateSave(p, vh, obj, msg, noticeText, cssErrInput, () => DbEntry.Save(obj));
        }

        public static bool ValidateSave(Page p, ValidateHandler vh, object obj, NoticeLabel msg, string noticeText,
            string cssErrInput, Action callback)
        {
            var ctx = ModelContext.GetInstance(obj.GetType());
            EnumControls(p, ctx.Info, delegate(MemberHandler mh, WebControl c)
            {
                c.CssClass = "";
            });
            vh.ValidateObject(obj);
            if (vh.IsValid)
            {
                callback();
                if (msg != null)
                {
                    msg.AddNotice(noticeText);
                }
            }
            else
            {
                foreach (string str in vh.ErrorMessages.Keys)
                {
                    if (msg != null)
                    {
                        msg.AddWarning(vh.ErrorMessages[str]);
                    }
                    WebControl c = GetWebControl(p, ctx.Info, str);
                    if (c != null)
                    {
                        c.CssClass = cssErrInput;
                    }
                }
            }
            return vh.IsValid;
        }
        */

        public static WebControl GetWebControl(Page p, string ctlName)
        {
            var c = ClassHelper.GetValue(p, ctlName) as WebControl;
            return c;
        }

        public static WebControl GetWebControl(Page p, string ctlPrefix, string ctlName)
        {
            string cid = string.Format("{0}_{1}", ctlPrefix, ctlName);
            var c = ClassHelper.GetValue(p, cid) as WebControl;
            return c;
        }

        public static void SetState(this WebControl c,RecordState state)
        {
            c.SetValue(state.ToString());
        }

        public static RecordState GetState(this WebControl c)
        {
            return (RecordState)Enum.Parse(typeof(RecordState), c.GetValue());
        }

        public static string GetValue(this WebControl c)
        {
            if (c is TextBox)
            {
                return ((TextBox)c).Text;
            }
            if (c is CheckBox)
            {
                return ((CheckBox)c).Checked.ToString();
            }
            if (c is DropDownList)
            {
                return ((DropDownList)c).SelectedValue;
            }
            if (c is Label)
            {
                return ((Label)c).Text;
            }
            throw new Exception("GetValue()扩展不存在");
            //return GetPropertyInfo(c).GetValue(c, null).ToString();
        }

        public static PropertyInfo GetPropertyInfo(object c)
        {
            var attr = c.GetType().GetAttribute<DefaultPropertyAttribute>(false);
            if (attr != null)
            {
                var pi = c.GetType().GetProperty(attr.Name);
                if (pi != null)
                {
                    return pi;
                }
            }
            throw new NotSupportedException();
        }

        public static void SetValue(this WebControl c, object v)
        {
            if (c is TextBox)
            {
                ((TextBox)c).Text = (v ?? "").ToString();
            }
            else if (c is CheckBox)
            {
                ((CheckBox)c).Checked = (bool)v;
            }
            else if (c is DropDownList)
            {
                // Type t = v.GetType();
                ((DropDownList)c).SelectedValue = v.ToString();
            }
            else if (c is Label)
            {
                ((Label)c).Text = (v ?? "").ToString();
            }
            else GetPropertyInfo(c).SetValue(c, v, null);
        }

        public static ListItem[] GetItems(Type enumType)
        {
            if (!enumType.IsEnum) throw new ArgumentOutOfRangeException();

            var ret = new List<ListItem>();
            foreach (string v in Enum.GetNames(enumType))
            {
                string n = EnumToString(enumType, v);
                var li = new ListItem(n, v);
                ret.Add(li);
            }
            return ret.ToArray();
        }

        public static string EnumToString(Type enumType, string name)
        {
            var os = (DisplayAttribute[])enumType.GetField(name)
                .GetCustomAttributes(typeof(DisplayAttribute), false);
            if (os.Length == 1)
            {
                return os[0].Name;
            }
            return name;
        }
    }
}
