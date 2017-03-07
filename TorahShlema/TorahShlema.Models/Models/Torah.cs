using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorahShlema.Models.Models
{
    public class Torah
    {
        public int BookId { get; set; }

        public int ChapterNUmber { get; set; }

        public string HebVerse { get; set; }

        public string Unkulus { get; set; }

        public int VerseNumber { get; set; }

        public string divition { get; set; }
    }
}
