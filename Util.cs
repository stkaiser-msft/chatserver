using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markdig;
using Ganss.XSS;

namespace chatserver
{
    public class Util
    {
        public static string MdToHtml(string input)
        {
            string output;
            HtmlSanitizer hs = new HtmlSanitizer();
            try
            {
                output = hs.Sanitize(Markdown.ToHtml(input));
            }
            catch (Exception) {
                output = "Error rendering message";
            }
            return output;
            
        }

        public static string Sanitize(string input)
        {
            string output;
            HtmlSanitizer hs = new HtmlSanitizer();
            try
            {
                output = hs.Sanitize(input);
            }
            catch (Exception)
            {
                output = "Sanitizer error";
            }
            return output;

        }
    }
}
