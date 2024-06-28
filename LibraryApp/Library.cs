using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Library
    {
        List<Item> items = new List<Item>();
        List<Item> rentItems = new List<Item>();
        public bool AuthSuccess { get; }

        public void showItems()
        {
            int counter = 1;
            
            foreach (Item item in items)
            {
                Console.WriteLine(counter + ". " + item.ToString());

                
               
                counter++;
            }
        }

        public void addBook()
        {
            Console.Write("Ad: ");
            string name = Console.ReadLine();
            Console.Write("Muellif: ");
            string author = Console.ReadLine();
            Console.Write("Il: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Sehife Sayi: ");
            int pageCount = int.Parse(Console.ReadLine());

            items.Add(new Book(name, author, year, pageCount, DateTime.Now));

            Console.WriteLine("Kitab ugurla elave olundu");
        }

        public void addJournal()
        {
            Console.Write("Ad: ");
            string name = Console.ReadLine();
            Console.Write("Sehife Sayi: ");
            int pageCount = int.Parse(Console.ReadLine());

            items.Add(new Journal(name, pageCount, DateTime.Now));

            Console.WriteLine("Jurnal ugurla elave olundu");
        }

        public void addAudioBook()
        {
            Console.Write("Ad: ");
            string name = Console.ReadLine();
            Console.Write("Muddet(deqiqe): ");
            int duration = int.Parse(Console.ReadLine());

            items.Add(new AudioBook(name, duration, DateTime.Now));

            Console.WriteLine("Sesli kitab ugurla elave olundu");
        }
        public void RentTheBook()
        {
            Console.WriteLine("Icare goturmek istediyin kitabi sec");
            this.showItems();
            
            int secilmisKitab = int.Parse(Console.ReadLine());

            if (items.ElementAtOrDefault(secilmisKitab - 1) == null)
            {
                Console.WriteLine("Bu kitab kitabxanada yoxdur");
            }
            else
            {
                Item item = items.ElementAt(secilmisKitab - 1);
                item.RentDate = DateTime.Now;
                rentItems.Add(item);
                items.Remove(item);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Secdiyiniz kitab ugurla secildi: Kitabiniz-"+item.ToString()+ ", Icare tarixi: " + item.RentDate);
                Console.ResetColor();


            }


        }
        public void search()
        {
            Console.WriteLine("Axtarmaq istediyin kitabin adini yaz");
            string secilen = Console.ReadLine();
            List<Item> resultItems = new List<Item>();
            foreach ( var item in items)
            {
                if (item.GetType() == typeof(AudioBook))
                {
                    AudioBook convertedItem = (AudioBook)item;

                    if (convertedItem.Name.Contains(secilen))
                    {
                        resultItems.Add(item);
                    }
                }
                else if (item.GetType() == typeof(Journal))
                {
                    Journal convertedItem = (Journal)item;

                    if (convertedItem.Name.Contains(secilen))
                    {
                        resultItems.Add(item);
                    }
                }
                else if (item.GetType() == typeof(Book))
                {
                    Book convertedItem = (Book)item;

                    if (convertedItem.Name.Contains(secilen))
                    {
                        resultItems.Add(item);
                    }
                    else if(convertedItem.Author.Contains(secilen))
                    {
                        resultItems.Add(item);
                    }
                }
            }
            Console.WriteLine("Axtaris neticeleri :");
            foreach  (var item in resultItems)
            {
                Console.WriteLine(item);
            }
        }

        public void addItem()
        {
            Console.WriteLine("Ne elave etmek isteyirsen ? 1. Kitab, 2. SesliKitab, 3.Jurnal ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addBook(); break;
                case 2:
                   addAudioBook(); break;
                case 3:
                    addJournal(); break;
                
                default:
                    Console.WriteLine("Yanlish secim! Xeta..");
                    break;

            }
        }


        public void showRentBook()
        {

            if (rentItems.Count >= 1)
            {
                int counter = 1;

                foreach (Item item in rentItems)
                {

                    Console.WriteLine(counter + ". " + item.ToString());



                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Kiraye verilen kitab yoxdur");
            }



        }
        public Library()
        {



            items = [
                new Book("Nerdname", "Bilinmir", 1980, 130, DateTime.Now),
                new Journal("Playboy", 69, DateTime.Now),
                new AudioBook("Elxan Elatli - Sesli Humay", 60, DateTime.Now),
            ];

            int wrongAttempts = 0;

            while (!AuthSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Kitabxanaya xosh gelmisiniz. Parolu yaz:");
                string password = Console.ReadLine();

                if (password != "12345")
                {
                    wrongAttempts++;
                    if (wrongAttempts < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Parolu sehv daxil etdiniz");
                        Console.ResetColor();
                    }
                    if (wrongAttempts >= 3)
                    {
                        break;
                    }
                } else

                {
                    AuthSuccess = true;
                    Console.ResetColor();
                    Console.WriteLine("Xosh geldin! Buyur davam et...");
                }

            }
        }
    }
}
