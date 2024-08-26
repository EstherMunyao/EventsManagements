using Dapper;
using EventsGQL.Models;
using Microsoft.Data.SqlClient;

namespace EventsGQL;

public class Query
{
    static readonly String connectionstring = "server = (localdb)\\mssqllocaldb; Database = EventsDb; Trusted_Connection = True;";

    public List<EventsItem> GetEventsItems(){
        using (var connection = new SqlConnection(connectionstring)) 
{        
    var sql = "SELECT * FROM EventsItems";     
	
    // Use the Query method to execute the query and return a list of objects    
    var books = connection.Query<EventsItem>(sql).ToList();
    return books;
}
    }
public EventsItem? GetEventsItem(int id){
  using (var connection = new SqlConnection(connectionstring)) 
{    
    // Create a query that retrieves all books with an author name of "John Smith"    
    var sql = "SELECT * FROM EventsItems WHERE id = @id ";     
	
    // Use the Query method to execute the query and return a list of objects    
    var books = connection.QuerySingle<EventsItem>(sql, new {id});
    return books;
}   
}
}
