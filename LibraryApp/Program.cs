// See https://aka.ms/new-console-template for more information
using LibraryApp;





Library library = new Library();

if (library.AuthSuccess) {
    showMenu();
}
else {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Uygunsuz cehd sayi. Sag olun");
    Console.ResetColor();
}



void showMenu()
{
    Console.WriteLine("Menyu ile tanish olub sechim edin..");

    Console.WriteLine("1. Kitabxanadakı element(kitablar, səsli kitablar, jurnallar və sair) siyahısı");
    Console.WriteLine("2. Element(kitablar, səsli kitablar, jurnallar və sair) əlavə etmək");
    Console.WriteLine("3. Tələbəyə kitab(kitablar, səsli kitablar, jurnallar və sair) kirayə vermək");
    Console.WriteLine("4. Kitabxanada axtarış etmək");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            library.showItems();
            showMenu();
            break;

        case 2:
            library.addItem();
            showMenu();
            break;
        case 3:
            library.RentTheBook();
            showMenu();
            break;
        case 4:
            library.search();  
            break;
        default:
            Console.WriteLine("Yanlis secim etdiniz..");
            showMenu();
            break;
    }
}





