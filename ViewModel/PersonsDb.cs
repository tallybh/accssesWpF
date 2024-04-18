using Model;
using System.Data.OleDb;
using System.Security.Cryptography.X509Certificates;

namespace ViewModel
{
    public class PersonsDb:BaseDb
    {

        public PersonsDb():base("Persons")
        {
            
        }

        public PersonList SelectALL()
        {
            string query = "SELECT * from " + _tableName;
            PersonList lst = Select(query);
            return lst;
        }

        public Person CheckLogin(string userName, string password)
        {
            string query = $"SELECT * from {_tableName} where userName = {userName} and password = {password}";
            PersonList lst = Select(query);
            return lst.FirstOrDefault();
        }

        public Person SelectByID(int id)
        {
            string query = string.Format("SELECT * from {0} WHERE id = {1}", _tableName, id);
            PersonList lst = Select(query);
            return lst.FirstOrDefault();
        }


        private PersonList Select(string query)
        {
            PersonList list = new PersonList();
            using (OleDbConnection connection = new OleDbConnection(_connString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = new OleDbCommand(query, connection);
                reader = command.ExecuteReader();
                Person p;
                while (reader.Read())
                {
                    p = new Person();
                    p.Id = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    //get more properties
                    //if fk go to adressdb and get adress
                    //int adressId = reader.GetInt32(2);
                    //p.Adress  = adressDb.GetById(adressId);

                    list.Add(p);
                }
                return list;
            }
        }

    }
}