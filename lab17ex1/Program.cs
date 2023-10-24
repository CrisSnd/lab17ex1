// See https://aka.ms/new-console-template for more information


/*• Un produs este caracterizat de
• Id (unic)
• Nume : string
• Stoc: int
• Producator
• Categorie
• Eticheta
• O categorie va fi caracterizata de:
• Id (unic)
• Nume : string
• Pictograma – sub forma unui sir de
caractere reprezentand url-ul imaginii
corespunzatoare
• NavigationProperty / FK- ce lipseste?

• Eticheta este caracterizata de :
• Id(unic)
• Cod de bare (sub forma unui Guid)
• Pret : double
• NavigationProperty / FK- ce lipseste?
• Producatorii vor fi caracterizati de
• Id(unic)
• Nume
• Adresa : string
• CUI : string
• NavigationProperty- ce lipseste?

Stabiliti relatiile dintre clase
2. Realizati diagrama uml
3. Stabiliti relatiile dintre entitati (1-
1,1-*,*-*)
4. Stabiliti Navigation Property-urile si
FK-urile necesare
5. Creeati DB-ul, DBContext-ul, precum
si o functie statica seedDB/resetDB

• Scrieti urmatoarele functii
• Adaugare de categorie
• Adaugare de producator
• Modificarea pretului unui produs
• Obtinerea valorii totale a stocului
magazinului
• Obtinearea valorii stocului de la un
anumit producator oferit ca parametru
• Obtinerea valorii totale a stocului per
categorie
• Suplimentar
• Adaugare de produs
• Va adauga automat si eticheta
• Obtinerea valorii stocului per categorie
per producator */

using lab17ex1.Models;

//Seed();
using var context = new ShopDbContext();
Console.WriteLine(context.GetValoareStoc(1));
context.AdaugaProdus("iPad", 100, 15000,1);


static void Seed()
{
    using var context = new ShopDbContext();

    var apple = new Producator
    {
        Adresa = "China",
        CUI = Guid.NewGuid().ToString(),
        Nume = "Apple"
    };
     context.Add(apple);

    var iPhone = new Produs
    {
        Nume = "IPhone",
        Producator = apple,
        Stoc=10
    };

    context.Add(iPhone);

    var eticheta = new Eticheta
    {
        Produs = iPhone,
        Pret = 7000,

    };

    context.Add(eticheta);


    var telefoane = new Categorie
    {
        Nume = "Telefoane",
        Pictograma="apple.com"

    };
    context.Add(telefoane);

    var electronice = new Categorie
    {
        Nume = "Electronice",
        Pictograma = "bla"

    };
    context.Add(electronice);

    iPhone.Categorii.Add(telefoane);
    iPhone.Categorii.Add(electronice);

    context.SaveChanges();
}

