using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    public class DatabaseHelper
    {
        private string data;
        private static DatabaseHelper databaseConnection;

        private DatabaseHelper() => Console.WriteLine("Подключение к БД");

        public static DatabaseHelper GetConncetion()
        {
            if (databaseConnection == null)
            {
                databaseConnection = new DatabaseHelper();
            }
            return databaseConnection;
        }

        public string SelectData() => data;
        public void InsertData (string d)
        {
            Console.WriteLine($"Новые данные: {d}, внесены в БД");
            data = d;
        }
    }



    class Program
    {

        static void Main(string[] args)
        {
            //DatabaseHelper connection = new DatabaseHelper();

            DatabaseHelper.GetConncetion().InsertData("123");

            DatabaseHelper someCooncetion = new DatabaseHelper.GetConncetion();

            Console.WriteLine($"Выборака данных из БД {DatabaseHelper.GetConncetion().SelectData()}");

            Console.WriteLine($"Выборака данных из БД2 {someCooncetion.SelectData()}"); 
            Console.ReadKey();

        }
    }
}
