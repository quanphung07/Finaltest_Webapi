namespace FinalTestApi.Models
{
    public class Connection
    {
        public Connection()
        {
            ConnStr="Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
        }
        public string ConnStr{get;set;}
        
    }
}