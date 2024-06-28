using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class AudioBook: Item
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public AudioBook(string name, int duration, DateTime createdAt)
        {
            Name = name;
            Duration = duration;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return "Tip: Sesli Kitab," + "Ad: " + Name + "," + "Muddeti (deqiqe): " + Duration + ", Daxil olma vaxti: " + CreatedAt;
        }
    }
}
