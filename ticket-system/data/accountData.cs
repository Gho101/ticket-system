using System.IO;
using System.Text;

namespace ticket_system.data
{
    /// <summary>
    /// accountData will set up an text file for the accountsController to store and organize account data into. 
    /// </summary>
    public class accountData
    {
        static void creat(string name, string type)
        {
            StreamWriter data = new StreamWriter("Account_Data.txt");
            writeData(data, name, type);//writeData will be placed here
            data.Close();
        }

        static void writeData(StreamWriter data, string name, string type )
        {
            //here i will have account data be writen in the text file
            //should be called only for creating new accounts 
            //id, fName, lName, rank
            data.WriteLine(name, type);
            //List<string> list = new List<string>();
        }

        static void deleteData(StreamWriter data, int id)
        {
            //This will be the area that account data will be
        }
    }
}
