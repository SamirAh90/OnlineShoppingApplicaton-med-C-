/*  Kort information om programmet:
 
    Detta C#-konsolprogram är en konsolapplikation för en onlinebutik för böcker som erbjuder funktioner för både administratörer och köpare.

    För administratörer:
    1 - Visar alla böcker – Lista alla böcker som finns i lager.
    2- Lägger till en bok – Lägg till nya böcker med titel, pris och ID.
    3- Tar bort en bok – Ta bort en specifik bok baserat på dess ID.
    4- Visar försäljningsdata – Visa antalet sålda exemplar av varje bok.
    5- Visa mest populära böcker – Identifiera och visa böcker med högst försäljning.
    7- Går tillbaka till huvudmenyn – Avsluta administratörsmenyn.

    För köpare:
    1- Visar alla böcker till salu – Bläddra bland tillgängliga böcker i lager.
    2- Lägger till böcker i kundvagnen – Lägg till valfritt antal av en bok i kundvagnen.
    3- Tar bort böcker från kundvagnen – Ta bort en bok från kundvagnen med hjälp av dess ID.
    4- Visar kundvagnen – Visa innehållet i kundvagnen.
    5- Visar totalbelopp – Beräkna och visa totalbeloppet med eventuell rabatt.
    6- Går till kassan – Välj betalningsmetod och genomför köpet.
    7- Återgå till huvudmenyn – Avsluta köparmenyn.

    Kommentarer:
    1- Enkelradskommentarer
    2- Flerradskommentarer
    3- Grundläggande XML kommentarer - för metoder

    Utvecklare:

    Samir Ahmad, student vid Institutionen för Datavetenskap, Högskolan Dalarna.
    Ludwig Lindfors, student vid Institutionen för Datavetenskap, Högskolan Dalarna.

    Läs projektetsrapport för detaljerad information.
 */

// Programmet börjar härifrån.
namespace OnlineShoppingApplicaton
{
    public class Program
    {
        /// <summary>
        /// Main metod för hela programmet.
        /// </summary>

        public static void Main(string[] args)
        {
            // Skapar instanser av BookManager och Cart för att hantera böcker och varukorgen
            BookManager bookManager = new BookManager();
            Cart cart = new Cart();
            bool running = true;

            // Startar en evig loop som presenterar huvudmenyn för användaren
            while (running)
            {
                // Rensar konsolen för att ge ett rent utseende när programmet startar
                Console.Clear();

                // Sätter textfärgen för rubriken till cyan.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t══════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("\t\t\t\t\t  Välkommen till Cheap Cheating Shoppers ");
                Console.WriteLine("\t\t\t══════════════════════════════════════════════════════════════════════════\n");
                Console.ResetColor(); // Återställer textfärgen till standard efter rubriken

                // Sätter textfärgen för beskrivningen till grön.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\t Cheap Cheating Shoppers erbjuder ett brett utbud av böcker");
                Console.WriteLine("\t\t\t Enkel bokhantering, beställning och leverans via vår användarvänliga app");



                Console.ResetColor(); // Återställer textfärgen till standard

                // Lägger till en separator i gult för att ge menyn lite struktur.
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t══════════════════════════════════════════════════════════════════════════\n");
                Console.ResetColor(); // Återställ textfärgen till standard


                // Skriver ut huvudmenyn med alternativ
                Console.WriteLine("\nVälkommen till Huvudmenyn!");
                Console.WriteLine("Vänligen välj ett alternativ för att fortsätta:");
                Console.WriteLine("1. Administratör - Hantera böcker och försäljning");
                Console.WriteLine("2. Köpare - Utforska våra böcker och gör ett köp");
                Console.WriteLine("3. Avsluta - Stäng applikationen");
                Console.Write("Vad vill du göra? Ange ditt val: ");

                // Läser användarens val från konsolen
                var choice = Console.ReadLine();

                // Hanterar användarens val med if-else
                if (choice == "1")
                {
                    // Om användaren väljer 1, går administratörsmenyn igång
                    AdminMenu(bookManager);

                }
                else if (choice == "2")
                {
                    // Om användaren väljer 2, går köparens meny igång
                    BuyerMenu(bookManager, cart);

                }
                else if (choice == "3")
                {
                    // Avslutar programmet
                    //Sätter textfärgen för till röd.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nProgrammet avslutas om 2 sekunder...");
                    Thread.Sleep(2000); // Vänter för 2 sekunder 
                    running = false; // Stop the main loop
                    Console.ResetColor(); // Återställ textfärgen till standard
                    Console.Beep(); // skappar beep ljud
                    break;
                }
                else
                {
                    // Om användaren anger ett ogiltigt val, får de ett felmeddelande och menyn visas på nytt
                    Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                }

                if (running)
                {
                    Console.WriteLine("\nTryck på en tangent för att fortsätta...");
                    Console.ReadKey(); // Väntar på användarens input innan loopen fortsätter
                }
            }

        }


        /// <summary>
        /// Metod för att vissa huvudmenyn och hantera olika funktionaliet för administrator.
        /// </summary>
        static void AdminMenu(BookManager bookManager)
        {
            while (true)
            {   // Välkomnar administratören
                Console.WriteLine("\nVälkommen till Administratörsmenyn!");
                Console.WriteLine("Här kan du hantera böcker och se försäljningsdata.");
                Console.WriteLine("1. Visa alla böcker");
                Console.WriteLine("2. Lägg till en bok");
                Console.WriteLine("3. Ta bort en bok");
                Console.WriteLine("4. Visa försäljningsdata");
                Console.WriteLine("5. Visa mest populära böcker baserat på försäljning");
                Console.WriteLine("6. Gå tillbaka till huvudmenyn");
                Console.Write("Vänligen ange ditt val: ");  // Uppmanar administratören att göra ett val
                string? adminChoice = Console.ReadLine(); // Läser in användarens val som en sträng, kan vara null om användaren inte skriver något men hanteras med else sats. 

                if (adminChoice == "1")
                {
                    // Visar alla böcker i lagar
                    Console.WriteLine("\n\n\t\t\t\t    ****  Tillgängliga Böcker i Lager  **** ");
                    Console.WriteLine("=========================================================================================================");
                    bookManager.DisplayBooks();  // Anropar metoden för att visa alla böcker
                    Console.WriteLine("=========================================================================================================\n");
                }
                else if (adminChoice == "2")
                {
                    // Lägger till bok
                    bool validInput = false;  // Flagga för att kontrollera om inmatningarna är giltiga
                    int attempts = 0;  // Räknar antalet försök att ange korrekt information

                    while (!validInput)  // Fortsätt tills vi får korrekt inmatning eller användaren väljer att avsluta
                    {
                        // Om antalet försök är större än 3, ge användaren möjlighet att avsluta
                        if (attempts >= 3)
                        {
                            Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                            string? exitChoice = Console.ReadLine();
                            if (exitChoice?.ToLower() == "ja")
                            {
                                // Om användaren väljer att avsluta, gå tillbaka till huvudmenyn
                                return;
                            }
                            else
                            {
                                // Om användaren inte vill avsluta, återställ försöken och fortsätt
                                attempts = 0;
                                Console.WriteLine("Försök igen.");
                            }
                        }

                        Console.Write("Ange boktitel: ");
                        string? title = Console.ReadLine();

                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("Titel kan inte vara tomt.");
                            attempts++;  // Öka antalet försök
                            continue;  // Om titeln är tom, fortsätt fråga efter en ny titel
                        }

                        Console.Write("Ange bokpris: ");  // Ber administratören att ange bokpris
                        string? input = Console.ReadLine();  // Läs inmatningen för bokpris

                        // Kontrollera om inmatningen för pris är null eller tom
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Error: Bokpris kan inte vara tomt.");
                            attempts++;  // Öka antalet försök
                            continue;  // Om priset är tomt, fortsätt fråga efter ett nytt pris
                        }

                        decimal price = 0;  // Deklarera price utanför try-blocket för att vara tillgänglig senare
                        try
                        {
                            price = decimal.Parse(input);  // Försök att konvertera inmatningen till ett decimalvärde

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Fel: Ogiltigt prisformat.");
                            attempts++;  // Öka antalet försök
                            continue;  // Om priset inte kan konverteras till ett korrekt format, fortsätt fråga efter ett nytt pris
                        }

                        // Om både titel och pris är giltiga, skapa boken och sätt validInput till true för att avsluta loopen
                        int bookId = bookManager.GetNextBookId();  // Hämtar nästa bok-ID
                        bookManager.AddBook(new BookClass(bookId, title, price));  // Lägger till boken
                        validInput = true;  // Sätt flaggan till true för att avsluta loopen
                    }
                }

                else if (adminChoice == "3")
                {
                    // Tar bort bok
                    int attempts = 0;  // Räknare för antalet försök

                    while (attempts < 3)  // Låt användaren försöka 3 gånger
                    {
                        Console.Write("Ange bok-ID för att ta bort: ");  // Ber administratören att ange bok-ID för borttagning
                        string? inputBookID = Console.ReadLine();  // Läser inmatningen från användaren

                        // Kontrollera om användaren har angett något
                        if (string.IsNullOrEmpty(inputBookID))
                        {
                            Console.WriteLine("Fel: Bok-ID kan inte vara tomt.");
                            attempts++;  // Öka antalet försök
                            continue;  // Fortsätt loopen för att ge användaren en ny chans
                        }

                        // Försök att konvertera inmatningen till ett heltal
                        if (int.TryParse(inputBookID, out int bookId))
                        {
                            // Kontrollera om bok-ID:t är giltigt (t.ex. finns i systemet)
                            if (bookManager.BookExists(bookId))  // Kontrollerar om boken finns
                            {
                                bookManager.RemoveBook(bookId);  // Tar bort boken med det angivna ID
                                return;  // Avsluta och återgå till huvudmenyn
                            }
                            else
                            {
                                Console.WriteLine("Fel: Boken med angivet ID finns inte.");
                                attempts++;  // Öka antalet försök
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fel: Ogiltigt bok-ID. Vänligen ange ett giltigt heltal.");
                            attempts++;  // Öka antalet försök
                        }

                        // Kontrollera om användaren har försökt 3 gånger och fråga om de vill återvända till huvudmenyn
                        if (attempts >= 3)
                        {
                            Console.WriteLine("För många misslyckade försök. Vill du återvända till huvudmenyn? (ja/nej)");
                            string? exitChoice = Console.ReadLine();
                            if (exitChoice?.ToLower() == "ja")
                            {
                                return;  // Om användaren vill återgå till huvudmenyn
                            }
                            else
                            {
                                attempts = 0;  // Återställ försöken och ge användaren en ny chans
                                Console.WriteLine("Försök igen.");
                            }
                        }
                    }
                }

                else if (adminChoice == "4")
                {
                    // Visa försäljningsdata
                    Console.WriteLine("\nFörsäljningsdata:");  // Skriver ut rubrik för försäljningsdata
                    foreach (var book in bookManager.GetAllBooks())  // Loopar igenom alla böcker
                    {
                        Console.WriteLine($"\n{book.Title} - Sålda: {book.SalesCount} enheter");  // Visar boktitel och antalet sålda enheter
                    }
                }
                else if (adminChoice == "5")
                {
                    // Visa mest populära böcker baserat på försäljning
                    bookManager.DisplayMostPopularBooks();  // Anropar metoden för att visa de mest populära böckerna
                }
                else if (adminChoice == "6")
                {
                    // Gå tillbaka till huvudmenyn
                    break;  // Avslutar loopen och går tillbaka till huvudmenyn
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Vänligen försök igen.");  // Hanterar ogiltigt val
                }
            }
        }


        /// <summary>
        ///  Metod för att vissa huvudmenyn och hantera olika funktionaliet för köparen
        /// </summary>
        static void BuyerMenu(BookManager bookManager, Cart cart)
        {
            while (true)
            {
                // Visar huvudmenyn för köparen
                Console.WriteLine("\nVälkommen till Köparmenyn!");
                Console.WriteLine("1. Visa alla böcker till salu");
                Console.WriteLine("2. Lägg till böcker i kundvagnen");
                Console.WriteLine("3. Ta bort bok från kundvagnen");
                Console.WriteLine("4. Visa kundvagn");
                Console.WriteLine("5. Se totalbelopp");
                Console.WriteLine("6. Gå till kassan");
                Console.WriteLine("7. Återgå till huvudmenyn");
                Console.Write("Vänligen ange ditt val: ");
                string? buyerChoice = Console.ReadLine(); // Läser in användarens val som en sträng, kan vara null om användaren inte skriver något men hanteras med else sats. 

                // Hanterar olika val. 
                if (buyerChoice == "1")
                {
                    // Visar alla böcker som finns tillgängliga i lager
                    Console.WriteLine("\n\n\t\t\t\t    ****  Tillgängliga Böcker i Lager  **** ");
                    Console.WriteLine("=========================================================================================================");
                    bookManager.DisplayBooks(); // Anropa metoden som visar böcker
                    Console.WriteLine("=========================================================================================================\n");
                }
                else if (buyerChoice == "2")
                {
                    bool validInput = false;  // Flaggar för att kontrollera om inmatningarna är giltiga
                    int attempts = 0;  // Räknar antalet försök att ange korrekt information

                    while (!validInput)  // Fortsätter tills vi får korrekt inmatning eller användaren väljer att avsluta
                    {
                        Console.Write("Ange bok-ID: ");
                        string? inputBookID = Console.ReadLine();

                        // Kontrollerar om bok-ID är tomt
                        if (string.IsNullOrEmpty(inputBookID))
                        {
                            Console.WriteLine("Bok-ID kan inte vara tomt.");
                            attempts++;  // Ökar antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Går tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställer försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om bok-ID är tomt, fortsätt fråga efter nytt bok-ID
                        }

                        int bookId = 0;
                        if (!int.TryParse(inputBookID, out bookId))
                        {
                            Console.WriteLine("Fel: Ogiltigt bok-ID format.");
                            attempts++;  // Ökar antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Går tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställer försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om bok-ID inte är ett giltigt heltal, fortsätt fråga efter nytt bok-ID
                        }

                        Console.Write("Ange antal: ");
                        string? inputQuantity = Console.ReadLine();

                        // Kontrollerar om antal är tomt
                        if (string.IsNullOrEmpty(inputQuantity))
                        {
                            Console.WriteLine("Antal kan inte vara tomt.");
                            attempts++;  // Ökar antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Går tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställer försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om antal är tomt, fortsätt fråga efter nytt antal
                        }

                        int quantity = 0;
                        if (!int.TryParse(inputQuantity, out quantity) || quantity <= 0)
                        {
                            Console.WriteLine("Fel: Ogiltigt antal. Ange ett positivt heltal.");
                            attempts++;  // Ökar antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Går tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställer försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om antal inte är ett positivt heltal, fortsätt fråga efter nytt antal
                        }

                        // Hämtar boken baserat på dess ID
                        var book = bookManager.GetBookById(bookId);
                        if (book != null)
                        {
                            // Lägger till boken i kundvagnen
                            cart.AddBook(book, quantity);
                            Console.WriteLine($"Lade till {quantity} exemplar av '{book.Title}' i kundvagnen.");
                            validInput = true;  // Om allt är korrekt, sätt flaggan till true för att avsluta loopen
                        }
                        else
                        {
                            // Hanterar ogiltigt bok-ID
                            Console.WriteLine("Boken hittades inte.");
                            attempts++;  // Öka antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Går tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställ försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                        }
                    }
                }

                else if (buyerChoice == "3")
                {
                    // Tar bort en bok från kundvagnen
                    bool validInput = false;  // Flaggar för att kontrollera om inmatningen är giltig
                    int attempts = 0;  // Räknar antalet försök att ange korrekt information

                    while (!validInput)  // Fortsätter tills vi får korrekt inmatning eller användaren väljer att avsluta
                    {
                        Console.Write("Ange bok-ID för att ta bort från kundvagnen: ");
                        string? inputBookID = Console.ReadLine();  // Läser bok-ID från användaren

                        // Kontrollera om bok-ID är tomt
                        if (string.IsNullOrEmpty(inputBookID))
                        {
                            Console.WriteLine("Bok-ID kan inte vara tomt.");
                            attempts++;  // Ökar antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Går tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställer försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om bok-ID är tomt, fortsätt fråga efter nytt bok-ID
                        }

                        int bookId = 0;
                        if (!int.TryParse(inputBookID, out bookId) || bookId <= 0)
                        {
                            Console.WriteLine("Fel: Ogiltigt bok-ID. Ange ett giltigt positivt heltal.");
                            attempts++;  // Öka antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Gå tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställ försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om bok-ID inte är ett giltigt positivt heltal, fortsätt fråga efter nytt bok-ID
                        }


                        cart.RemoveBook(bookId);  // Anropar metoden som tar bort boken
                        Console.WriteLine($"Boken med ID {bookId} har tagits bort från kundvagnen.");

                        validInput = true;  // Om allt är korrekt, sätter flaggan till true för att avsluta loopen
                    }

                }
                else if (buyerChoice == "4")
                {
                    // Visar innehållet i kundvagnen
                    cart.DisplayCart();
                }
                else if (buyerChoice == "5")
                {
                    // Beräknar och visar totalbeloppet för böckerna i kundvagnen
                    decimal totalAmount = cart.GetTotalAmount();
                    decimal discount = 0;

                    // Tilldelar rabatt om totalen överstiger 200
                    if (totalAmount > 200)
                    {
                        discount = 20; // Fast rabatt på 20
                    }

                    // Visar beloppen
                    Console.WriteLine($"\nTotalbelopp före rabatt: {totalAmount:C}");
                    Console.WriteLine($"Rabatt tillämpad: {discount:C}");
                    Console.WriteLine($"Totalbelopp efter rabatt: {(totalAmount - discount):C}");
                }
                else if (buyerChoice == "6")
                {
                    // Går till kassan för att slutföra köpet
                    decimal totalAmount = cart.GetTotalAmount();
                    decimal discount = totalAmount > 200 ? 20 : 0; // Beräknar rabatt
                    decimal finalAmount = totalAmount - discount;

                    Console.WriteLine($"Totalbelopp att betala: {finalAmount:C}");

                    bool validInput = false;  // Flagga för att kontrollera om inmatningen är giltig
                    int attempts = 0;  // Räknar antalet försök att ange korrekt information

                    while (!validInput)  // Fortsätt tills vi får korrekt inmatning eller användaren väljer att avsluta
                    {
                        // Väljer betalningsmetod
                        Console.WriteLine("\nVälj betalningsmetod:");
                        Console.WriteLine("1. Kreditkort");
                        Console.WriteLine("2. Klarna");
                        Console.WriteLine("3. Kontant vid leverans");
                        Console.Write("Ange ditt val: ");
                        string? paymentChoice = Console.ReadLine();  // Läser in användarens val som en sträng

                        // Kontrollera om inmatningen är tom eller ogiltig
                        if (string.IsNullOrEmpty(paymentChoice))
                        {
                            Console.WriteLine("Du måste välja en betalningsmetod.");
                            attempts++;  // Öka antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Gå tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställ försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                            continue;  // Om inget val görs, fortsätt fråga efter val
                        }

                        string paymentMethod = "";

                        if (paymentChoice == "1")
                        {
                            paymentMethod = "Kreditkort";
                        }
                        else if (paymentChoice == "2")
                        {
                            paymentMethod = "Klarna";
                        }
                        else if (paymentChoice == "3")
                        {
                            paymentMethod = "Kontant vid leverans";
                        }
                        else
                        {
                            paymentMethod = "Ogiltig betalningsmetod";
                        }

                        if (paymentMethod == "Ogiltig betalningsmetod")
                        {
                            // Hanterar ogiltigt val av betalningsmetod
                            Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                            attempts++;  // Öka antalet försök
                            if (attempts >= 3)
                            {
                                Console.WriteLine("För många ogiltiga försök. Vill du återvända till huvudmenyn? (ja/nej)");
                                string? exitChoice = Console.ReadLine();
                                if (exitChoice?.ToLower() == "ja")
                                {
                                    return;  // Gå tillbaka till huvudmenyn
                                }
                                else
                                {
                                    attempts = 0;  // Återställ försöken och fortsätt
                                    Console.WriteLine("Försök igen.");
                                }
                            }
                        }
                        else
                        {
                            // Bekräftar betalningsmetod och slutför köpet
                            Console.WriteLine($"Du har valt {paymentMethod} som betalningsmetod.");
                            cart.Checkout();  // Uppdaterar försäljningsdata som används sedan i administratör statistik
                            Console.WriteLine("Tack för ditt köp!");
                            cart = new Cart();  // Nollställer kundvagnen efter köp
                            validInput = true;  // Sätt flaggan till true för att avsluta loopen
                        }
                    }

                }
                else if (buyerChoice == "7")
                {
                    // Återgår till huvudmenyn
                    break;
                }
                else
                {
                    // Hanterar ogiltigt val
                    Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                }
            }
        }

    }

}