namespace PizzaParty.Models
{
    public interface IEventRepository
    {

        public IEnumerable<Events> GetAllEvents();
        public IEnumerable<Events> GetCategories();
        public Events GetEvent(int id);
        public Events AssignCategory();
        public void InsertEvent(Events eventToInsert);
        public void DeleteEvent(Events party);
        public void UpdateEvent(Events party);

        



                


    }
}







