namespace PizzaParty.Models
{
    public class Events
    {

        public int EventID { get; set; }
        public int CustomerID { get; set; }
        public string EventTheme { get; set; }
        public int EventSize { get; set; }
        public IEnumerable<Events> Categories { get; internal set; }




    }


}
