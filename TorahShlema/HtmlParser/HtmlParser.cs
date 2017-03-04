
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Xml;


namespace HtmlParser
{
    public class HtmlParserUtility
    {
        string[] _files;
        public int LoadFiles()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"SourceFiles\Torah\Cantillated"); 
            _files = Directory.GetFiles(path);

            foreach (string file in _files)
            {

              

                HtmlWeb doc = new HtmlWeb();
               
                var loadedDoc = doc.Load(file);
                var html = loadedDoc.DocumentNode.InnerHtml;

                HtmlNodeCollection nodeCollection = loadedDoc.DocumentNode.SelectNodes("//p/text()");

                string chapteNumberr;
                string verseNumber;
                string verse;

                if (nodeCollection != null)
                {
                    foreach (HtmlNode node in nodeCollection)
                    {
                      
                        try {
                        chapteNumberr = node.PreviousSibling.InnerText.Split(',')[0];
                        verseNumber = node.PreviousSibling.InnerText.Split(',')[1];
                            verse = node.InnerText.Replace("\n", "");
                                }
                        catch { }

                    }

                }


            }

                return 0;
        }
    }
}
