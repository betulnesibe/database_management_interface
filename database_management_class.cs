using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms; //to be able to use the windows forms
using Microsoft.Data.SqlClient;  //to be able to use the sqlclient package to connect the sql server to the project
using System.Data; 

namespace lawoffice_cet301final
{
    class database_management_class
    {

        //taking databases from the server into a list
        public List<String> get_server_databases() 
        {
            //creating an empty list to store the databases in the server
            List<String> server_databases= new List<String>();

            //creating an sqlconnection class with the parameters of data source= the SQL server on my computer,
            //initial catalog= a random database to be chosen as default,
            //integrated security and trustservercertificate=true to be able to connect to the server
            SqlConnection the_connection = new SqlConnection("Data source= DESKTOP-865SBQC\\SQLEXPRESS;Initial Catalog=Cet301;Integrated Security=True;TrustServerCertificate=True");

            //creating an sql query to execute to be able to reach the databases in the server excluding the system databases
            string sql_query_for_databases = "SELECT name FROM master.sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";

            //creating a sqlcommand with two parameters, one is the query to be executed, other is the created sqlconnection to the server
            SqlCommand database_command = new SqlCommand(sql_query_for_databases, the_connection);

            //opening the connection, in other words connecting to the server
            the_connection.Open();

            //creating a sqldatareader class to get tge data when the command is executed
            SqlDataReader the_reader;

            //using the sqlcommand class's executereader method to get the data and assigning it to the created sqldatareader
            the_reader = database_command.ExecuteReader();

            //try and catch block to add the databases into the list
            try
            {
                //as long as there is a thing to read in the sqldatareader
                while (the_reader.Read()) 
                {
                    //adding the data taking from the sqldatareader to the list
                    server_databases.Add(the_reader.GetString(0));//gives the 0th column in a string form
                }
            }
            //if an error occurs a message box will be shown with the error message
            catch(Exception error_message)
            {
                MessageBox.Show(error_message.Message);
            }
            //when the process is completed the sqldatareader and sqlconnection is closed
            //if they are not closed, the program may face with a timeout
            finally
            {
                the_reader.Close();
                the_connection.Close();
            }
            //returning the list consisting of databases on the server
            return server_databases;
        }


        //connecting to the chosen database
        public SqlConnection connecting(String selected_database)
        {
            //try and catch block to create the connection
            try
            {
                //creating an sqlconnection class with the parameters of data source= the SQL server on my computer,
                //initial catalog= a random database to be chosen as default,
                //integrated security and trustservercertificate=true to be able to connect to the server
                SqlConnection the_connection = new SqlConnection("Data source= DESKTOP-865SBQC\\SQLEXPRESS;Initial Catalog=" + selected_database + ";Integrated Security=True;TrustServerCertificate=True");

                //if connection is successful, it is returned
                return the_connection;
            }

            //if connection is failed, an error message showed and null value is returned
            catch(Exception error_message)
            {
                MessageBox.Show(error_message.Message);
                return null;
            }
        }


        //executing the commands in the connected server and/or database with the query
        public void commanding(String sql_query, SqlConnection the_connection)
        {
            //try and catch block to execute the command
            try
            {
                //creating a sqlcommand with two parameters, one is the query to be executed, other is the created sqlconnection to the server
                SqlCommand the_command = new SqlCommand(sql_query, the_connection);

                //opening the connection, in other words connecting to the server
                the_connection.Open();

                //executing the sqlcommand with its executenonquery method, so that the database is changed according to query
                the_command.ExecuteNonQuery();
            }

            //if execution is failed, an error message is shown
            catch (Exception error_message)
            {
                MessageBox.Show(error_message.Message);
                
            }

            //when the execution is completed the sqlconnection is closed to avoid timeouts or other problems
            finally
            {
                the_connection.Close();
            }
        }


        //taking tables from the chosen database into a list
        public List<String> get_database_tables(String selected_database)
        {
            //creating an empty list to store the tables in the database
            List<String> database_tables = new List<String>();

            //creating an sqlconnection class with the parameters of data source= the SQL server on my computer,
            //initial catalog= a random database to be chosen as default,
            //integrated security and trustservercertificate=true to be able to connect to the server
            SqlConnection the_connection = new SqlConnection("Data source= DESKTOP-865SBQC\\SQLEXPRESS;Initial Catalog=" + selected_database + ";Integrated Security=True;TrustServerCertificate=True");

            //creating an sql query to execute to be able to reach the tables in the database
            string sql_query_for_tables = "SELECT TABLE_NAME FROM["+ selected_database+"].INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ";

            //creating a sqlcommand with two parameters, one is the query to be executed, other is the created sqlconnection to the server
            SqlCommand tables_command = new SqlCommand(sql_query_for_tables, the_connection);

            //opening the connection, in other words connecting to the server
            the_connection.Open();

            //creating a sqldatareader class to get tge data when the command is executed
            SqlDataReader the_reader;

            //using the sqlcommand class's executereader method to get the data and assigning it to the created sqldatareader
            the_reader = tables_command.ExecuteReader();


            //try and catch block to add the tables on the database into the list
            try
            {
                //as long as there is a thing to read in the sqldatareader
                while (the_reader.Read())
                {
                    //adding the data taking from the sqldatareader to the list
                    database_tables.Add(the_reader.GetString(0));
                }
            }

            //if an error occurs a message box will be shown with the error message
            catch (Exception error_message)
            {
                MessageBox.Show(error_message.Message);
            }

            //when the process is completed the sqldatareader and sqlconnection is closed
            //if they are not closed, the program may face with a timeout
            finally
            {
                the_reader.Close();
                the_connection.Close();
            }

            //returning the list consisting of databases on the server
            return database_tables;
        }


        //implementing the given sql query into the chosen table to be able to show in dataviewgrid if select command is used
        public DataSet select_anything_using_sql (String selected_database, String sql_query, String selected_table)
        {
            //creating a blank dataset class to store the output of the sql command
            DataSet the_dataset= new DataSet();

            //creating an sqlconnection class with the parameters of data source= the SQL server on my computer,
            //initial catalog= a random database to be chosen as default,
            //integrated security and trustservercertificate=true to be able to connect to the server
            SqlConnection the_connection = new SqlConnection("Data source= DESKTOP-865SBQC\\SQLEXPRESS;Initial Catalog=" + selected_database + ";Integrated Security=True;TrustServerCertificate=True");

            //try and catch block to execute the query
            try
            {
                //creating a sqldataadapter which is faster when reading data to fill the dataset created above
                //while creating the connection and query is fed to the sqldataadapter
                SqlDataAdapter the_adapter = new SqlDataAdapter(sql_query,the_connection);

                //filling the dataset with the selected table from the adapter
                the_adapter.Fill(the_dataset,selected_table);

                //returning the created dataset
                return the_dataset;
            }

            //if an error occurs a message box will be shown with the error message and null value is returned
            catch (Exception error_message)
            {
                MessageBox.Show(error_message.Message);
                return null;
            }
        }


        //to show all of the chosen table
        public DataSet show_table(String selected_database, String selected_table)
        {
            //creating a blank dataset class to store the output of the sql command
            DataSet the_dataset = new DataSet();

            //creating an sqlconnection class with the parameters of data source= the SQL server on my computer,
            //initial catalog= a random database to be chosen as default,
            //integrated security and trustservercertificate=true to be able to connect to the server
            SqlConnection the_connection = new SqlConnection("Data source= DESKTOP-865SBQC\\SQLEXPRESS;Initial Catalog=" + selected_database + ";Integrated Security=True;TrustServerCertificate=True");

            //try and catch block to execute the query of select * from
            try
            {
                //creating a string to store the sql query select * from --tablename-- which shows the whole table
                string sql_query = "select * from "+ selected_table;

                //creating a sqldataadapter which is faster when reading data to fill the dataset created above
                //while creating the connection and query is fed to the sqldataadapter
                SqlDataAdapter the_adapter = new SqlDataAdapter(sql_query, the_connection);

                //filling the dataset with the selected table from the adapter
                the_adapter.Fill(the_dataset, selected_table);

                //returning the created dataset
                return the_dataset;
            }

            //if an error occurs a message box will be shown with the error message and null value is returned
            catch (Exception error_message)
            {
                MessageBox.Show(error_message.Message);
                return null;
            }
        }
    }
}
