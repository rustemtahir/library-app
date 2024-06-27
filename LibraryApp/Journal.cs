using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Journal: Item
    {
        public string Name { get; set; }

        public int PageCount { get; set; }

        public Journal(string name, int pageCount, DateTime createAt)
        {
            Name = name;
            PageCount = pageCount;
            CreatedAt = createAt;
        }

        public override string ToString()
        {
            return "Tip: Jurnal," + "Ad: " + Name + "," + "Sehife sayi: " + PageCount + ", Daxil olma vaxti: " + CreatedAt;
        }
    }
}
