
namespace OnlineShoppingApplicaton
{
    // Definierar en klass för att representera ett objekt i kundvagnen
    public class CartItem
    {
        // Egenskap som representerar den bok som är en del av kundvagnen
        public BookClass Book { get; set; }

        // Egenskap för att hålla koll på mängden av denna bok i kundvagnen
        public int Quantity { get; set; }

        // Konstruktör som tar emot en bok och mängd, och initialiserar objektet
        public CartItem(BookClass book, int quantity)
        {
            Book = book;       // Tilldelar den bok som hör till denna kundvagnsartikel
            Quantity = quantity; // Tilldelar antal för denna bok
        }
    }
}
