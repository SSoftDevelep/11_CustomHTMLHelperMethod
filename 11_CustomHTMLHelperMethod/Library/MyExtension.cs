using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _11_CustomHTMLHelperMethod.Library
{
    public static class MyExtension
    {
        public static MvcHtmlString Alert (this HtmlHelper helper,string id="alert1", string color = "success",string text="")
        {
            /*
             
                <div role="alert" class="alert alert-success">

            Ut fusce varius nisl ac ipsum gravida vel pretium tellus tincidunt integer eu augue augue nunc elit dolor, luctus placerat.

        </div>
             */

            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("alert alert-" +color);
            tag.GenerateId(id);
            tag.Attributes.Add(new KeyValuePair<string, string>("role", "alert"));

            tag.SetInnerText(text);


            return MvcHtmlString.Create(tag.ToString());

        }

        //public static MvcHtmlString AlertFor<TModel,TProperty>(this HtmlHelper<TModel> helper,System.Linq.Expressions.Expression<Func<TModel,TProperty>> expression,object htmlAttributes)
        //{ 

        //}
    }
}