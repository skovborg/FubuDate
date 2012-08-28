using System;
using System.Linq.Expressions;
using FubuCore.Reflection;
using FubuLocalization;
using FubuMVC.Core.UI;
using FubuMVC.Core.View;
using HtmlTags;

namespace FubuDate
{
    public static class FubuPageExtensions
    {
        public static HtmlTag EditField<T>(this IFubuPage<T> page, Expression<Func<T, object>> expression) where T : class
        {
            var accessor = expression.ToAccessor();

            var label = page.LabelFor(expression);
            var textbox = page.InputFor(expression)

                                .Id(accessor.FieldName)
                                .NoClosingTag();
            label
                .Attr("for", accessor.FieldName)
                .After(textbox);
            return label;
        }

        public static HtmlTag Submit(this IFubuPage page, string title)
        {
            return new HtmlTag("input").Attr("type", "submit").Title(title).Attr("value", title);
        }

        public static HtmlTag Link<T>(this IFubuPage page) where T : class, new()
        {
            return page.LinkTo<T>().Text(StringToken.FromType<T>());
        }
    }
}