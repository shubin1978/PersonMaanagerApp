using System.Data;
using Microsoft.Data.Sqlite;
using PersonMaanagerApp.Console;

const string CONNECTION_STRING = @"Data Source=D:\Programming\C#\8-DataBase\SQLite_Test\PersonMaanagerApp\SQL\persons.db;";
var db = new SqliteConnection(CONNECTION_STRING);
db.Open();

var sql = "SELECT * FROM table_persons";
var command = new SqliteCommand(commandText: sql, connection: db);
var result = command.ExecuteReader();
var persons = new List<Person>();
if (result.HasRows)
{
    while (result.Read())
    {
        persons.Add(new Person
        {
            Id = result.GetInt32("id"),
            FirstName = result.GetString(1),
            LastName = result.GetString(2),
            DateOfBirth = result.GetDateTime(3)
        }); 
    }
    
}
db.Close();

foreach (var p in persons)
{
    Console.WriteLine($"{p.Id}: {p.FullName}, {p.Age}");
}