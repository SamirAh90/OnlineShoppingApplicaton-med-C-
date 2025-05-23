namespace OnlineShoppingApplicaton
{
    // Book Class
    // Definierar en klass för en bok
    public class BookClass
    {
        // Egenskap för bokens unika ID
        public int Id { get; set; }

        // Egenskap för bokens titel
        public string Title { get; set; }

        // Egenskap för bokens pris
        public decimal Price { get; set; }

        // Egenskap för bokens ISBN, kan vara null (valfritt)
        public string? ISBN { get; set; }

        // Egenskap för att hålla koll på antalet sålda böcker
        public int SalesCount { get; set; }

        // Konstruktör som initierar objektet med id, titel och pris
        public BookClass(int id, string title, decimal price)
        {
            Id = id;         // Sätt bokens ID
            Title = title;   // Sätt bokens titel
            Price = price;   // Sätt bokens pris
            SalesCount = 0;  // Initialisera antalet sålda böcker till 0
            GenerateISBN();  // Generera ett ISBN för boken
        }
        /// <summary>
        ///  Privat metod för att generera ett slumpmässigt ISBN
        /// </summary>
        public void GenerateISBN()
        {
            // Skapa en instans av Random för att generera slumpmässiga värden
            Random random = new Random();

            // Generera ett slumpmässigt tal mellan 1000000 och 9000000 och konvertera till sträng
            string isbnTemp = random.Next(1000000, 9000000).ToString();

            // Lägg till ett ytterligare slumpmässigt tal mellan 1 och 9 som en sista siffra
            isbnTemp += $"{random.Next(1, 9).ToString()}";

            // Tilldela det genererade ISBN:t till ISBN-egenskapen
            ISBN = isbnTemp;
        }
    }

}