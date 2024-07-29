using Dapper;
using System.Data;

namespace PizzaParty.Models
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _conn;

        public EventRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Events> GetAllEvents()
        {
            return _conn.Query<Events>("SELECT * FROM EVENTS;");
        }

        public Events GetEvent(int id)
        {
            if(id == 0)
            {
                throw new Exception("the id is 0");
            }
            var result = _conn.Query<Events>("SELECT * FROM EVENTS WHERE eventID = @id", new { id = id }).FirstOrDefault();
            if(result == null)
            {
                throw new Exception("No event found with the given ID.");
            }
            return result;
            
        }

        public void UpdateEvent(Events eventToUpdate)
        {
            _conn.Execute("UPDATE EVENTS SET Eventsize = @eventsize, customerID = @customerID, EventTheme = @eventTheme WHERE eventID = @eventID",
            new { eventID = eventToUpdate.EventID, eventsize = eventToUpdate.EventSize, customerID = eventToUpdate.CustomerID, eventTheme = eventToUpdate.EventTheme });
        }
        public IEnumerable<Events> GetCategories()
        {
            return (IEnumerable<Events>)_conn.Query<Events>("SELECT * FROM events;");
        }

        public Events AssignCategory()
        {
            var eventList = GetCategories();
            var party = new Events();
            party.Categories = eventList;
            return party;
        }

        public void InsertEvent(Events eventToInsert)
        {
            _conn.Execute("INSERT INTO EVENTS (EVENTID, CUSTOMERID, EVENTTHEME, EVENTSIZE) VALUES (@eventID, @customerID, @eventTheme, @eventsize);",
                new { eventID = eventToInsert.EventID, customerID = eventToInsert.CustomerID, eventTheme = eventToInsert.EventTheme, eventsize = eventToInsert.EventSize });
        }

        public void DeleteEvent(Events party)
        {
            _conn.Execute("DELETE FROM EVENTS WHERE EventID = @id;", new { id = party.EventID });

        }




    }


















}

