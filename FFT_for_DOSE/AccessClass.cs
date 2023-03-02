using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFT_For_DOSE
{
    public class AccessClass
    {

        private string connectionString;
        private OleDbConnection connection;


        public AccessClass(string connectionString)
        {
            this.connectionString = connectionString;
            this.connection = new OleDbConnection(connectionString);
        }

        public void Open()
        {
            if (this.connection.State != System.Data.ConnectionState.Open)
            {
                this.connection.Open();
            }
        }

        public void Close()
        {
            if (this.connection.State != System.Data.ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }

        public OleDbCommand CreateCommand(string commandText)
        {
            OleDbCommand command = new OleDbCommand(commandText, this.connection);
            return command;
        }

        public DataTable SelectSQL(OleDbCommand command, string name1, string value1)
        {
            command.Parameters.Clear(); //清除舊資料
            this.AddWithValue(command, name1, value1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }


        public string readOneDataSQL(OleDbCommand command, string name1, string value1, string returnNane)
        {
            command.Parameters.Clear(); //清除舊資料
            this.AddWithValue(command, name1, value1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            { return reader[returnNane].ToString(); }
            else { return "-1"; }
        }

        public void AddWithValue(OleDbCommand command, string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }
    }
}
