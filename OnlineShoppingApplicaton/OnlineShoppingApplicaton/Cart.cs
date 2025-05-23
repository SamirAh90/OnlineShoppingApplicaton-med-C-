namespace OnlineShoppingApplicaton
{
    // Cart Class
    public class Cart
    {
        // En lista som håller reda på alla artiklar i kundvagnen
        public List<CartItem> cartItems = new List<CartItem>();


        /// <summary>
        // Metod för att lägga till en bok i kundvagnen
        /// </summary>
        public void AddBook(BookClass book, int quantity)
        {
            // Flaggar för att kontrollera om boken redan finns i kundvagnen
            bool bookFound = false;

            // Loopar igenom alla boker i kundvagnen
            foreach (var bookItem in cartItems)
            {
                // Om boken redan finns i kundvagnen (baserat på ID)
                if (bookItem.Book.Id == book.Id)
                {
                    // Uppdaterar antalet av boken i kundvagnen
                    bookItem.Quantity += quantity;

                    // Sätter flaggan till true för att indikera att boken hittades
                    bookFound = true;

                    // Bryter loopen eftersom boken redan är uppdaterad
                    break;
                }
            }

            // Om boken inte redan fanns i kundvagnen, lägg till den som en ny artikel
            if (!bookFound)
            {
                cartItems.Add(new CartItem(book, quantity));
            }
        }

        /// <summary>
        // Metod för att ta bort en bok från kundvagnen baserat på dess ID
        /// </summary>
        public void RemoveBook(int bookId)
        {
            // Variabel för att hålla den artikel som ska tas bort
            CartItem? bookToRemove = null;

            // Loopar igenom alla booken i kundvagnen
            foreach (var bookItem in cartItems)
            {
                // Om boken med det angivna ID:t hittas
                if (bookItem.Book.Id == bookId)
                {
                    // Sätter den hittade booken som den som ska tas bort
                    bookToRemove = bookItem;
                    break; // Avslutar loopen eftersom boken har hittats
                }
            }

            // Om en book att ta bort har hittats
            if (bookToRemove != null)
            {
                // Ta bort artikeln från kundvagnen
                cartItems.Remove(bookToRemove);
                Console.WriteLine("Boken har tagits bort från kundvagnen.");
            }
            else
            {
                // Om boken inte fanns i kundvagnen, skriv ut ett meddelande
                Console.WriteLine("Boken hittades inte i kundvagnen.");
            }
        }


        /// <summary>
        // Metod för att beräkna det totala beloppet för alla artiklar i kundvagnen
        /// </summary> 
        public decimal GetTotalAmount()
        {
            // Variabel för att hålla det totala beloppet
            decimal totalAmount = 0;

            // Loopar igenom alla artiklar i kundvagnen
            foreach (var book in cartItems)
            {
                // Lägger till priset för den aktuella artikeln (bokens pris * mängd) till det totala beloppet
                totalAmount += book.Book.Price * book.Quantity;
            }

            // Returnera det totala beloppet
            return totalAmount;
        }

        /// <summary>
        //  Metod för att visa innehållet i kundvagnen
        /// </summary> 

        public void DisplayCart()
        {
            // Om kundvagnen är tom
            if (cartItems.Count == 0)
            {
                // Skriver ut ett meddelande om att kundvagnen är tom
                Console.WriteLine("\n--- Din Kundvagn ---");
                Console.WriteLine("Böcker i kundvagnen:");
                return; // Avslutar metoden här om kundvagnen är tom
            }

            // Skriver ut rubrik för kundvagnen
            Console.WriteLine("\nDin Kundvagn:");

            // Loopar igenom alla artiklar i kundvagnen
            foreach (var book in cartItems)
            {
                // Skriver ut titel på boken, mängd och pris per enhet med korrekt format
                Console.WriteLine($"Boknamn: {book.Book.Title} - antal bok: {book.Quantity} x {book.Book.Price:C}");
            }
        }


        /// <summary>
        // Metod för att genomföra kassan (checkout), skriva kvitto och avsluta beställningen
        /// </summary> 

        public void Checkout()
        {
            decimal totalAmount = 0; // Variabel för att hålla koll på det totala beloppet

            // Skriver ut rubriken för kvittot
            Console.WriteLine("\n--- Kvitto ---");
            Console.WriteLine("Böcker köpta:");

            // Loopar igenom alla böcker i kundvagnen
            foreach (var book in cartItems)
            {
                // Uppdaterar försäljningsräkningen för varje bok baserat på den mängd som köpts
                book.Book.SalesCount += book.Quantity;

                // Beräknar det totala beloppet för den aktuella boken (pris * mängd)
                decimal bookTotalPrice = book.Quantity * book.Book.Price;
                totalAmount += bookTotalPrice;

                // Skriver ut information om varje bok i kvittot
                Console.WriteLine($"Boknamn: {book.Book.Title} - antal bok: {book.Quantity} x {book.Book.Price:C} = {bookTotalPrice:C}");
            }

            // Skriver ut det totala beloppet för hela köpet
            Console.WriteLine("\nTotal belopp: " + totalAmount.ToString("C"));

            // Tömar kundvagnen efter genomfört köp
            cartItems.Clear();

            // Skriver ut ett meddelande som bekräftar att beställningen har genomförts
            Console.WriteLine("\nDin beställning är nu genomförd. Tack för ditt köp!");
        }


    }


}
