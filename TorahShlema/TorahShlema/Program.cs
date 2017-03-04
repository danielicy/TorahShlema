using HtmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser;

namespace TorahShlema
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlParserUtility parser = new HtmlParserUtility();
            parser.LoadFiles();
        }
    }
}
