using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MenuDemo.Models;
using WebGrease.Css.Extensions;

namespace MenuDemo.Helpers.Html
{
    public static class MenuHelpers
    {
        #region Menus

        #region Horizontal Menu

        public static HtmlString HorizontalMenu(this HtmlHelper helper,
            IEnumerable<MenuItem> items)
        {
            if (items == null || !items.Any())
            {
                return new HtmlString(String.Empty);
            }
            var ul = new TagBuilder("ul");
            ul.AddCssClass("list-inline list-unstyled");

            var sb = new StringBuilder();
            items.ForEach(e => CreateMenuItem(e, sb));

            ul.InnerHtml = sb.ToString();

            return new HtmlString(ul.ToString(TagRenderMode.Normal));
        }

        #endregion

        #region Vertical Menu

        public static HtmlString VerticalMenu(this HtmlHelper helper,
            IEnumerable<MenuItem> items)
        {
            if (items == null || !items.Any())
                return new HtmlString(String.Empty);

            var ul = new TagBuilder("ul");
            ul.AddCssClass("list-unstyled");

            var sb = new StringBuilder();
            items.ForEach(e => CreateMenuItem(e, sb));

            ul.InnerHtml = sb.ToString();

            return new HtmlString(ul.ToString(TagRenderMode.Normal));
        }

        #endregion


        private static void CreateMenuItem(MenuItem menuItem, StringBuilder sb)
        {
            if (String.IsNullOrEmpty(menuItem.Url))
            {
                var li = new TagBuilder("li")
                {
                    InnerHtml = String.Format("<i class=\"fa fa-fw fa-{0}\"></i> {1}",
                        menuItem.Icon, menuItem.Title)
                };
                sb.Append(li.ToString(TagRenderMode.Normal));
            }
            else
            {
                var li = new TagBuilder("li")
                {
                    InnerHtml =
                        String.Format("<a href=\"{0}\" title=\"{1}\"><i class=\"fa fa-fw fa-{2}\"></i> {3}</a>",
                        menuItem.Url, menuItem.Description, menuItem.Icon, menuItem.Title)
                };
                sb.Append(li.ToString(TagRenderMode.Normal));
            }
        }

        #endregion

        #region Toolbar

        public static HtmlString Toolbar(this HtmlHelper helper,
            IEnumerable<MenuItem> items)
        {
            if (items == null || !items.Any())
                return new HtmlString(String.Empty);

            var ul = new TagBuilder("ul");
            ul.AddCssClass("list-inline list-unstyled toolbar");

            var sb = new StringBuilder();
            items.ForEach(e => CreateToolbarItem(e, sb));

            ul.InnerHtml = sb.ToString();
            return new HtmlString(ul.ToString(TagRenderMode.Normal));
        }

        private static void CreateToolbarItem(MenuItem menuItem, StringBuilder sb)
        {
            if (String.IsNullOrEmpty(menuItem.Url))
            {
                var li = new TagBuilder("li")
                {
                    InnerHtml = String.Format("<i title=\"{0}\" class=\"fa fa-{1}\"></i>",
                        menuItem.Description, menuItem.Icon)
                };
                sb.Append(li.ToString(TagRenderMode.Normal));
            }
            else
            {
                var li = new TagBuilder("li")
                {
                    InnerHtml =
                        String.Format("<a class=\"btn btn-default btn-sm\" href=\"{0}\" " +
                            "title=\"{1}\"><i class=\"fa fa-{2}\"></i></a>",
                        menuItem.Url, menuItem.Description, menuItem.Icon)
                };
                sb.Append(li.ToString(TagRenderMode.Normal));
            }
        }
        #endregion

    }
}