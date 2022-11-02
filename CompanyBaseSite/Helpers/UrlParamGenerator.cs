using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseSiteEshop.Helpers
{
    public static class UrlParamGenerator
    {
        public static string GetUrlParam(string title)
        {
            title = ReplaceCharachter(title, '@');
            title = ReplaceCharachter(title, '#');
            title = ReplaceCharachter(title, '$');
            title = ReplaceCharachter(title, '&');
            title = ReplaceCharachter(title, '^');
            title = ReplaceCharachter(title, '/');
            title = ReplaceCharachter(title, ']');
            title = ReplaceCharachter(title, '[');
            title = ReplaceCharachter(title, '%');
            title = ReplaceCharachter(title, '?');
            title = ReplaceCharachter(title, '؟');
            title = ReplaceCharachter(title, '!');

            return title.Replace(' ', '-');
        }
        public static string ReplaceCharachter(string title, char charachter)
        {
            if (title.Contains(charachter))
                return title.Replace(charachter, '-');
            return title;
        }
    }
}