using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book: Item
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int PageCount { get; set; }

        public Book(string name, string author, int year, int pageCount, DateTime createdAt)
        {
            Name = name;
            Author = author;
            Year = year;
            PageCount = pageCount;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return "Tip : Kitab," + "Ad: " + Name + ", Muellif: " + Author + ", Il: " + Year
                + ", Sehife sayi: " + PageCount + ", Daxil olma vaxti: " + CreatedAt;
        }
    }
}
