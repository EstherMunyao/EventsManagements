using Dapper;
using EventsGQL.Models;
using Microsoft.Data.SqlClient;

namespace EventsGQL;

public class Mutation
{
        static readonly String connectionstring = "server = (localdb)\\mssqllocaldb; Database = EventsDb; Trusted_Connection = True;";

    //inserting 
    public EventsItem? AddEventsItem(EventsItem eventsItem){
        using (var connection = new SqlConnection(connectionstring)) 
{    
        
    var sql = "INSERT INTO EventsItems(Name, IsComplete) OUTPUT INSERTED.* VALUES (@Name, @IsComplete)";     
	
    // Use the Query method to execute the query and return a list of objects    
    var addedEvent = connection.QuerySingle<EventsItem>(sql, eventsItem);
    return addedEvent;
} 
    }

    // Updating
public EventsItem? UpdateEventsItem(int id, string name, bool isComplete)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = "UPDATE EventsItems SET Name = @Name, IsComplete = @IsComplete OUTPUT INSERTED.* WHERE Id = @Id";
                var updatedEvent = connection.QuerySingle<EventsItem>(sql, new { Id = id, Name = name, IsComplete = isComplete });
                return updatedEvent;
            }
        }

    //deleting by id
    public EventsItem? DeleteEventsItem(int Id){
        using (var connection = new SqlConnection(connectionstring)) 
{    
        
    var sql = "DELETE FROM EventsItems OUTPUT DELETED.* WHERE (Id = @Id)";     
	
    // Use the Query method to execute the query and return a list of objects    
    var deletedEvent = connection.QuerySingle<EventsItem>(sql, new { Id = @Id});
    return deletedEvent;
} 
    }

}
