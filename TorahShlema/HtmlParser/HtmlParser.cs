
using EllisWeb.Gematria;
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
using TorahShlema.Models.Models;

namespace HtmlParser
{
    public class HtmlParserUtility
    {
        string[] _files;
        public int LoadFiles()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"SourceFiles\Torah\Cantillated\Unkulus"); 
            _files = Directory.GetFiles(path);

            foreach (string file in _files)
            {
                HtmlWeb doc = new HtmlWeb();
               
                var loadedDoc = doc.Load(file);
               
                HtmlNodeCollection nodeCollection = loadedDoc.DocumentNode.SelectNodes("//td");

                Torah torah;
                int firstposition, lastposition,lenght;
                if (nodeCollection != null)
                {
                    foreach (HtmlNode node in nodeCollection)
                    {
                        torah = new Torah();
                        try
                        {
                            if (!string.IsNullOrEmpty(node.InnerText))
                            {
                                lastposition = node.InnerText.Length- node.InnerText.IndexOf('׃')-1  ;

                                //indicates where to start text from
                                firstposition = node.InnerText.IndexOf(',')+1 ;
                                lenght = node.InnerText.Length  - firstposition-lastposition-3;
                                torah.HebVerse = node.InnerText.Replace("\n", "").Substring(firstposition, lenght);
                                torah.Unkulus = node.NextSibling.InnerText.Replace("\n", "").Replace(".", "");
                                torah.ChapterNUmber = Calculator.GetNumericGematriaValue(node.ChildNodes[3].InnerText.Split(',')[0]); //node.InnerText.Replace("\n", ""),GematriaType.Absolute);
                                torah.VerseNumber = Calculator.GetNumericGematriaValue(node.ChildNodes[3].InnerText.Split(',')[1]);
                                torah.divition = node.InnerText.Substring(node.InnerText.IndexOf('{'), 3);
                            }
                               
                        }
                        catch { }

                    }
                }
            }
                return 0;
        }
    }

        
  
}
