namespace OnlineShoppingApplicaton
{
    // En klass som hanterar böcker och deras operationer
    public class BookManager
    {
        // En lista för att hålla alla böcker i systemet (lagar)
        public List<BookClass> books = new List<BookClass>();

        // Konstruktör för BookManager-klassen
        public BookManager()
        {
            // Lägger till några standardböcker när applikationen startar
            AddDefaultBooks();
        }

        /// <summary>
        // Metod för att lägga till standardböcker i systemet (lagar)
        /// </summary>
        public void AddDefaultBooks()
        {
            // Lägg till böcker i 'books'-listan med hjälp av 'BookClass'
            books.Add(new BookClass(101, "These are test book names", 125.00m));
            books.Add(new BookClass(102, "My name is Samir", 150.00m));
            books.Add(new BookClass(103, "And I am Ludwig", 180.00m));
            books.Add(new BookClass(104, "We developed this application", 220.00m));
            books.Add(new BookClass(105, "We like to Code", 200.00m));
            books.Add(new BookClass(106, "This code and its film is available", 122.00m));
            books.Add(new BookClass(107, "On YouTube and GitHub", 199.00m));
            books.Add(new BookClass(108, "Don't forget to subscribe", 180.00m));
            books.Add(new BookClass(109, "Any question would be answered on", 123.00m));
            books.Add(new BookClass(110, "YouTube and GitHub comment sections", 128.00m));
        }

        /// <summary>
        // Metod för att lägga till en bok i systemet (lagar)
        /// </summary>
        public void AddBook(BookClass book)
        {
            // Lägger till boken i listan 'books'
            books.Add(book);

            // Skriver ut ett meddelande som bekräftar att boken har lagts till
            Console.WriteLine();
            Console.WriteLine($"\nBoken '{book.Title}' har fått Bok ID '{book.Id}' och den har lagts till i lagret.");
        }


        /// <summary>
        // Metod för att ta bort en bok från systemet baserat på dess ID
        /// </summary>

        public void RemoveBook(int bookId)
        {
            // Hitta boken med det angivna ID:t
            var book = books.Find(b => b.Id == bookId);

            // Om boken finns i listan, ta bort den
            if (book != null)
            {
                books.Remove(book); // Tar bort boken från listan
                Console.WriteLine();
                Console.WriteLine($"\nBoken '{book.Title}' med Book ID '{book.Id}' har blivit borttagen.");
            }
            else
            {
                // Om boken inte finns i listan, skriv ett felmeddelande
                Console.WriteLine("Den angivna boken finns inte i listan.");
            }
        }


        /// <summary>
        /// Hämtar en bok från systemet (lagar) baserat på dess ID.
        /// </summary>
        public BookClass? GetBookById(int bookId) // använder ? då "null" hanteras redan i början av programmet
        {
            // Hittar boken från BookClass och returnera boken med det angivna ID
            return books.Find(book => book.Id == bookId);
        }

        /// <summary>
        /// Kollar om en bok med det angivna ID:t existerar i systemet.
        /// </summary>    
        public bool BookExists(int bookId)
        {
            // Kontrollerar om det finns någon bok med det angivna ID
            return books.Any(book => book.Id == bookId);
        }


        /// <summary>
        /// Hämtar alla böcker från systemet (lagar).
        /// </summary>

        public List<BookClass> GetAllBooks()
        {
            // Returnerar hela listan med böcker
            return books;
        }

        /// <summary>
        /// Hämtar nästa tillgängliga bok-ID, som är ett unikt ID för en ny bok.
        /// </summary>
        public int GetNextBookId()
        {
            // Om listan inte är tom, hämtar det största ID:t och lägger till 1 för nästa bok
            // Om listan är tom, börjar med ID 111

            int nextId = 111; // Startvärde för ID

            if (books.Count > 0)
            {
                // Loopar igenom listan och letar efter det största ID:t
                foreach (var book in books)
                {
                    if (book.Id > nextId)
                    {
                        nextId = book.Id; // Hittar det största ID:t
                    }
                }

                nextId += 1; // Lägger till 1 för nästa bok
            }

            return nextId;
        }


        /// <summary>
        /// Visar alla böcker som finns i systeme (lagar) t i ett användarvänligt format.
        /// </summary>
        public void DisplayBooks()
        {
            // Kontrollerar om listan med böcker är tom
            if (books.Count == 0)
            {
                Console.WriteLine("\nDet finns inga böcker tillgängliga för tillfället.");
                return;
            }

            // Loopar igenom alla böcker och visa deras detaljer
            foreach (var book in books)
            {
                // Skriver ut varje bok med ID, titel, ISBN och pris
                Console.WriteLine($"- Bok-ID: {book.Id,-2} | Titel: {book.Title,-38} | ISBN-nummer: {book.ISBN,-10} | Pris: {book.Price:C}");
            }
        }
        /// <summary>
        /// Visar de mest populära böckerna baserat på försäljningsantalet. Böckerna sorteras i fallande ordning efter försäljningsantal.Använder bubble sortering 
        /// </summary>
        public void DisplayMostPopularBooks()
        {
            // Sorterar böckerna baserat på SalesCount i fallande ordning (Bubble Sort)
            for (int i = 0; i < books.Count; i++)
            {
                for (int j = 0; j < books.Count - 1; j++)
                {
                    // Om försäljningsantalet för den nuvarande boken är mindre än nästa bok, byt plats
                    if (books[j].SalesCount < books[j + 1].SalesCount)
                    {
                        // Byt plats på böckerna j och j + 1
                        BookClass temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }

            // Visar de mest populära böckerna (sorterade efter försäljningsantal)
            Console.WriteLine("\nBöcker med högst försäljning baserat på data:");
            foreach (var book in books)
            {
                // Skriver ut titel och försäljningsantal för varje bok
                Console.WriteLine($"Bok title: {book.Title}, med bok ID '{book.Id}' - Försäljningsantal: {book.SalesCount} enheter");
            }
        }

    }
}
