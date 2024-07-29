using System.Data;
using Dapper;

namespace PizzaParty.Models
{
    public class PersonRepository : IPersonRepository
    {

        private readonly IDbConnection _conn;

       
        public PersonRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<PizzaPerson> GetAllPeople()
        {
            return _conn.Query<PizzaPerson>("SELECT * FROM PIZZA_PEOPLE;");
        }

        public PizzaPerson GetPerson(int id)
        {
            return _conn.QuerySingle<PizzaPerson>("SELECT * FROM PIZZA_PEOPLE WHERE CUSTOMERID = @id", new { id });
        }

        public void UpdatePerson(PizzaPerson person)
        {
            _conn.Execute("UPDATE PIZZA_PEOPLE SET Name = @name, Eventsize = @eventsize, Age = @age, Address = @address, Gender = @gender WHERE CustomerID = @id",
            new { name = person.Name, eventsize = person.EventSize, age = person.Age, address = person.Address, gender = person.Gender, id = person.CustomerID });
        }

        public IEnumerable<PizzaPerson> GetCategories()
        {
            return (IEnumerable<PizzaPerson>)_conn.Query<PizzaPerson>("SELECT * FROM events;");
        }

        public PizzaPerson AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new PizzaPerson();
            product.Categories = categoryList;
            return product;
        }

        public void InsertPerson(PizzaPerson personToInsert)
        {
            _conn.Execute("INSERT INTO pizza_people (CUSTOMERID, NAME, ADDRESS, EVENTSIZE, AGE, GENDER) VALUES (@customerID, @name, @address, @eventsize, @age, @gender);",
                new { customerID = personToInsert.CustomerID, name = personToInsert.Name, address = personToInsert.Address, eventsize = personToInsert.EventSize, age = personToInsert.Age, gender = personToInsert.Gender,  });
        }

        public void DeletePerson(PizzaPerson person)
        {
            _conn.Execute("DELETE FROM PIZZA_PEOPLE WHERE CustomerID = @id;", new { id = person.CustomerID });

        }


    }






}
