using System;
using System.Text;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo paginginfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= paginginfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                //string url = pageUrl(i);
                tag.MergeAttribute("href", "Page" + i);
                tag.InnerHtml = i.ToString();
                if (i == paginginfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}