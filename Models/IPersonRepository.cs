namespace PizzaParty.Models
{
    public interface IPersonRepository
    {
        
        public IEnumerable<PizzaPerson> GetAllPerson();
        //public IEnumerable<PizzaPerson> GetCategories();
        public PizzaPerson GetPerson(int id);
        //public PizzaPerson AssignCategory();
        public void InsertPerson(PizzaPerson personToInsert);
        public void DeletePerson(PizzaPerson person);
        public void UpdatePerson(PizzaPerson person);







    }



}







