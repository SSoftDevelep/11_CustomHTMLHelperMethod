using _11_CustomHTMLHelperMethod.Models;
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

        public static MvcHtmlString AlertFor<TModel,TProperty>(this HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("div");

            tag.AddCssClass("alert");
            tag.Attributes.Add(new KeyValuePair<string,string>("role","alert"));

            var valueGetter = expression.Compile();
            var message = valueGetter(helper.ViewData.Model) as Message;

            if (message.Id == Guid.Empty) message.Id = new Guid();
            if (message.Level < 1) message.Level = 1;
            if (message.Level > 4) message.Level = 4;

            switch (message.Level)
            {
                case 1: tag.AddCssClass("alert-success"); break;
                case 2: tag.AddCssClass("alert-info"); break;
                case 3: tag.AddCssClass("alert-warning"); break;
                case 4: tag.AddCssClass("alert-danger"); break;
                default: break;

            }
            tag.MergeAttributes(new System.Web.Routing.RouteValueDictionary(htmlAttributes));
            tag.SetInnerText(message.Text);
            tag.GenerateId(message.Id.ToString());


            return MvcHtmlString.Create(tag.ToString());

        }
    }
}