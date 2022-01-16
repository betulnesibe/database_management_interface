using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  //to be able to use the sqlclient package to connect the sql server to the project



namespace lawoffice_cet301final
{
    public partial class Form1 : Form
    {
        //creating public values to be able to use them in the sub-methods
        //two string values to store the selected database and table
        String selected_database;
        String selected_table;

        //an integer value to use as identifier of the operation
        int operation = 0;

        //a dataset value to store the dataset 
        DataSet the_dataset = new DataSet();

        //two integers to store the clicked row and column value
        int row = 0;
        int column = 0;

        //a list to store the entered input to the textboxes
        List<TextBox> inputs = new List<TextBox>();

        //a class consisting of functions that the program will do (including connection to the server) is created to have a neat code
        //an object from that class is created to be able to use it in the codes
        database_management_class sql_server = new database_management_class();


        public Form1()
        {
            InitializeComponent();
        }


        //codes about what will happen when the page is first shown
        private void Form1_Shown(object sender, EventArgs e)
        {
            //showing the connection panel and hiding the main panel in the opening screen
            main_panel.Hide();
            connection_panel.Show();

            //ok_btn is hided and showed when insert, update, or delete is selected
            ok_btn.Hide();

            //showing the databases on the list box
            //calling the public method from the created class to get the databases list from the server and assigning them to a new created list
            List<String> server_databases = sql_server.get_server_databases();

            //adding each item in the list created by the return value of the function to the databases listbox by changing them to strings
            for (int i = 0; i < server_databases.Count; i++)
            {
                databases_listbox.Items.Add(server_databases[i].ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        //codes about what will happen when the user choses the database and presses the connect button
        private void connect_btn_Click(object sender, EventArgs e)
        {
            //updating the selected database value in the public variable
            selected_database = databases_listbox.SelectedItem.ToString();

            //updating the page view by showing the main panel and hiding the databases list panel
            main_panel.Show();
            connection_panel.Hide();
            
            //changing the label on the main panel to show the selected database
            selecteddb_label.Text = "Selected Database\n"+ selected_database;

            //creating a list for the tables on the database
            //calling the public function from the created class to get the tables list from the database and assigning them to a new created list
            List<String> database_tables = sql_server.get_database_tables(selected_database);

            //adding each item in the list created by the return value of the function to the tables listbox by changing them to strings
            for (int i = 0; i < database_tables.Count; i++)
            {
                tables_listbox.Items.Add(database_tables[i].ToString());
            }
        }


        //code to change the grid view when a table is selected from the tables listbox
        private void tables_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clearing the datagridview by changing it datasource value to null
            dataGridView1.DataSource = null;

            //updating the selected table value in the public variable
            selected_table = tables_listbox.SelectedItem.ToString();

            //calling the public function from the created class to get the data of the chosen table and assigning it to the public dataset variable
            the_dataset = sql_server.show_table(selected_database,selected_table);

            //changing the datasource of the datagridview to the updated dataset
            dataGridView1.DataSource=the_dataset;

            //changing the datamember of the datagridview to indicate the selected table (the dataset contains data under the datamember)
            dataGridView1.DataMember = selected_table; 

            //clearing and hiding the panel and ok button that are shown during the update, insert, and delete operations
            //otherwise the panel display of the previous table will be visible even when the table changed to another
            changedisplay_panel.Controls.Clear();
            changedisplay_panel.Hide();
            ok_btn.Hide();
        }


        //to show the chosen row and column data
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview sends the argument e regarding the cell the user interacts with
            //assigning rowindex and columnindex from the argument to public variables
            row = e.RowIndex;
            column = e.ColumnIndex;

            //changing the display of labels that shows row and column values
            rowdisplay_label.Text = "Row: " + row.ToString();
            columndisplay_label.Text = "Column: " + column.ToString();

            //try and catch to avoid display errors deriving from non-valued cells
            try
            {
                //if there is a value in the cell, it is shown in the label
                contentdisplay_label.Text = "Content: " + dataGridView1.Rows[row].Cells[column].Value.ToString();
            }
            catch
            {
                //if there is no value in the cell, only content text is shown
                contentdisplay_label.Text = "Content: ";
            }
        }


        //code about what will happen when insert button is clicked to insert values
        private void insert_btn_Click(object sender, EventArgs e)
        {
            //showing the ok button along with the panel created for the operations
            //to avoid any previous data panel is cleared and made scrollable
            ok_btn.Show();
            changedisplay_panel.Show();
            changedisplay_panel.Controls.Clear();
            changedisplay_panel.AutoScroll = true;

            //assigning a value to represent the operation to public variable
            operation = 1;

            //creating a blank area to be filled with data to be inserted inside the panel created for this purpose
            //an integer variable is created to show the columns count of the selected table and the data is taken from the public variable, dataset
            int column_number = the_dataset.Tables[selected_table].Columns.Count;

            //displaying the blank area with the proper textboxes and column names
            for(int i=0; i<column_number; i++)
            {
                //adding column names as labels
                //creating a new label to show the column name
                Label column_name = new Label();

                //setting the label's text to column name taken from the datagridview
                column_name.Text = dataGridView1.Columns[i].DataPropertyName.ToString();

                //setting label's location, size, and name values
                column_name.Location = new Point(50 * i, 5);
                column_name.Size = new Size(50, 15);
                column_name.Name = dataGridView1.Columns[i].DataPropertyName.ToString();

                //adding the label to the panel designed for this purpose
                changedisplay_panel.Controls.Add(column_name);
                
                //adding cell spaces as textboxes
                //creating a new textbox to have an user interactive area
                TextBox cell_input = new TextBox();

                //setting textbox's location, size, and name values
                cell_input.Location = new Point(50 * i, 25);
                cell_input.Size = new Size(50, 10);
                cell_input.Name = dataGridView1.Columns[i].DataPropertyName.ToString();

                //adding the textbox to the panel designed for this purpose
                changedisplay_panel.Controls.Add(cell_input);

                //adding the created textbox to the public variable to use its values later
                inputs.Add(cell_input);
            }
        }


        //code about what will happen when update button is clicked to update values
        private void update_btn_Click(object sender, EventArgs e)
        {
            //showing the ok button along with the panel created for the operations
            //to avoid any previous data panel is cleared and made scrollable
            ok_btn.Show();
            changedisplay_panel.Show();
            changedisplay_panel.Controls.Clear();
            changedisplay_panel.AutoScroll = true;

            //assigning a value to represent the operation to public variable
            operation = 2;

            //creating a blank area to be filled with data from the table to be updated inside the panel created for this purpose
            //an integer variable is created to show the columns count of the selected table and the data is taken from the public variable, dataset
            int column_number = the_dataset.Tables[selected_table].Columns.Count;

            //displaying the blank area with the proper textboxes and column names
            for (int i = 0; i < column_number; i++)
            {
                //adding column names as labels
                //creating a new label to show the column name
                Label column_name = new Label();

                //setting the label's text to column name taken from the datagridview
                column_name.Text = dataGridView1.Columns[i].DataPropertyName.ToString();

                //setting label's location, size, and name values
                column_name.Location = new Point(50 * i, 5);
                column_name.Size = new Size(50, 15);
                column_name.Name = dataGridView1.Columns[i].DataPropertyName.ToString();

                //adding the label to the panel designed for this purpose
                changedisplay_panel.Controls.Add(column_name);

                //adding cell spaces as textboxes
                //creating a new textbox to have an user interactive area
                TextBox cell_input = new TextBox();

                //setting textbox's location, size, and name values
                cell_input.Location = new Point(50 * i, 25);
                cell_input.Size = new Size(50, 10);
                cell_input.Name = dataGridView1.Columns[i].DataPropertyName.ToString();

                //setting textbox's text value to the table's value
                cell_input.Text = the_dataset.Tables[selected_table].Rows[row][i].ToString();

                //adding the textbox to the panel designed for this purpose
                changedisplay_panel.Controls.Add(cell_input);

                //adding the created textbox to the public variable to use its values later
                inputs.Add(cell_input);
            }
        }


        //code about what will happen when delete button is clicked to delete values
        private void delete_btn_Click(object sender, EventArgs e)
        {
            //showing the ok button along with the panel created for the operations
            //to avoid any previous data panel is cleared and made scrollable
            ok_btn.Show();
            changedisplay_panel.Show();
            changedisplay_panel.Controls.Clear();
            changedisplay_panel.AutoScroll = true;

            //assigning a value to represent the operation to public variable
            operation = 3;

            //creating a blank area to be filled with data from the table to be deleted inside the panel created for this purpose
            //an integer variable is created to show the columns count of the selected table and the data is taken from the public variable, dataset
            int column_number = the_dataset.Tables[selected_table].Columns.Count;

            //displaying the blank area with the proper textboxes and column names
            for (int i = 0; i < column_number; i++)
            {
                //adding column names as labels
                //creating a new label to show the column name
                Label column_name = new Label();

                //setting the label's text to column name taken from the datagridview
                column_name.Text = dataGridView1.Columns[i].DataPropertyName.ToString();

                //setting label's location, size, and name values
                column_name.Location = new Point(50 * i, 5);
                column_name.Size = new Size(50, 15);
                column_name.Name = dataGridView1.Columns[i].DataPropertyName.ToString();

                //adding the label to the panel designed for this purpose
                changedisplay_panel.Controls.Add(column_name);

                //adding cell spaces as textboxes
                //creating a new textbox to have an user interactive area
                TextBox cell_input = new TextBox();

                //setting textbox's location, size, and name values
                cell_input.Location = new Point(50 * i, 25);
                cell_input.Size = new Size(50, 10);
                cell_input.Name = dataGridView1.Columns[i].DataPropertyName.ToString();

                //setting textbox's text value to the table's value
                cell_input.Text = the_dataset.Tables[selected_table].Rows[row][i].ToString();

                //adding the textbox to the panel designed for this purpose
                changedisplay_panel.Controls.Add(cell_input);

                //adding the created textbox to the public variable to use its values later
                inputs.Add(cell_input);
            }
        }


        //code about what will happen when ok button is clicked to confirm changes
        private void ok_btn_Click(object sender, EventArgs e)
        {
            //calling the public function from the created class to create the connection to the server using the public selected database variable
            SqlConnection the_connection = sql_server.connecting(selected_database);

            //insert operation
            if (operation == 1){
                //creating a string to store the sql query for inserting and assigning it to the first part of insert query
                //there is no need to specify the columns to be inserted since all the columns except the id columns will be inserted either as null or with value
                String sql_query = "insert into " + selected_table + " values ( ";

                //a for loop to move through the inputs list which consists of the textboxes to generate the sql query
                //loop starts from 1 to avoid the primary key (id column) insertion
                for (int i=1; i < inputs.Count; i++)
                {
                    //checking if the data type of the column is int, since int values are added directly inside the paranthesis
                    if (the_dataset.Tables[selected_table].Columns[i].DataType == typeof(int))
                    {
                        sql_query = sql_query + inputs[i].Text;
                    }

                    //data from columns with data other than integer is added inside quotation marks
                    else
                    {
                        sql_query = sql_query + " ' " + inputs[i].Text + " ' ";
                    }

                    //a comma is added after values except for the last value
                    if (i<inputs.Count - 1)
                    {
                        sql_query = sql_query + " , ";
                    }
                }

                //sql query is completed
                sql_query = sql_query + " ) ";

                //calling the public function from the created class to execute the generated sql query to the connection
                sql_server.commanding(sql_query, the_connection);

                //hiding the ok button, clearing and hiding the panel 
                ok_btn.Hide();
                changedisplay_panel.Controls.Clear();
                changedisplay_panel.Hide();

                //deleting the values inside the public variable of inputs to avoid override
                inputs.Clear();
            }


            //update operation
            else if (operation == 2){
                //creating a string to store the sql query for updating and assigning it to the first part of update query
                String sql_query = "update " + selected_table + " set ";

                //a for loop to move through the inputs list which consists of textboxes to generate the sql query
                //loop starts from 1 to avoid the primary key (id column) changes
                for (int i=1; i < inputs.Count; i++)
                {
                    //the column name of the selected table and cell and equal sign is added to sql query
                    sql_query = sql_query + dataGridView1.Columns[i].DataPropertyName.ToString() + " = ";

                    //checking if the data type of the column is int, since int values are added directly inside the paranthesis
                    if (the_dataset.Tables[selected_table].Columns[i].DataType ==  typeof(int))
                    {
                        sql_query = sql_query + inputs[i].Text;
                    }

                    //data from columns with data other than integer is added inside quotation marks
                    else
                    {
                        sql_query = sql_query + " ' " + inputs[i].Text + " ' ";
                    }

                    //a comma is added after values except for the last value
                    if (i < inputs.Count - 1)
                    {
                        sql_query = sql_query + " , ";
                    }
                }

                //sql query is completed indicating where the change is going to occur
                //in other words the name of the id column and equal sign and id value of selected cell is added to the sql query
                sql_query = sql_query + " where " + dataGridView1.Columns[0].DataPropertyName.ToString() + " = " + inputs[0].Text;

                //calling the public function from the created class to execute the generated sql query to the connection
                sql_server.commanding(sql_query, the_connection);

                //hiding the ok button, clearing and hiding the panel 
                ok_btn.Hide();
                changedisplay_panel.Controls.Clear();
                changedisplay_panel.Hide();

                //deleting the values inside the public variable of inputs to avoid override
                inputs.Clear();
            }

            //delete operation
            else if (operation == 3)
            {
                //creating a string to store the sql query for deleting and assigning it to the first part of delete query
                String sql_query = "delete from " + selected_table +" where ";

                //the name of the id column and equal sign and id value of selected cell is added to the sql query
                sql_query = sql_query + dataGridView1.Columns[0].DataPropertyName.ToString() + " = " + inputs[0].Text;

                //calling the public function from the created class to execute the generated sql query to the connection
                sql_server.commanding(sql_query, the_connection);

                //hiding the ok button, clearing and hiding the panel 
                ok_btn.Hide();
                changedisplay_panel.Controls.Clear();
                changedisplay_panel.Hide();

                //deleting the values inside the public variable of inputs to avoid override
                inputs.Clear();
            }

            //a messagebox is shown when the operation is completed
            MessageBox.Show("Completed");

            //datagridview display is updated according to the changes
            //clearing the datagridview by changing it datasource value to null
            dataGridView1.DataSource = null;

            //updating the selected table value in the public variable
            selected_table = tables_listbox.SelectedItem.ToString();

            //calling the public function from the created class to get the data of the chosen table and assigning it to the public dataset variable
            the_dataset = sql_server.show_table(selected_database, selected_table);

            //changing the datasource of the datagridview to the updated dataset
            dataGridView1.DataSource = the_dataset;

            //changing the datamember of the datagridview to indicate the selected table (the dataset contains data under the datamember)
            dataGridView1.DataMember = selected_table;
        }


        //code about what will happen when change database button is clicked
        private void changedb_btn_Click(object sender, EventArgs e)
        {
            //main panel is hided and connection panel is shown
            main_panel.Hide();
            connection_panel.Show();

            //listboxes are cleared
            databases_listbox.Items.Clear();
            tables_listbox.Items.Clear();

            //datagridview is cleared
            dataGridView1.DataSource = null;

            //a string list consisting of the databases on the server is created using the public function from the created class
            List<String> server_databases = sql_server.get_server_databases();

            //adding each item in the list taken from the function to the listbox
            for (int i = 0; i < server_databases.Count; i++)
            {
                databases_listbox.Items.Add(server_databases[i].ToString());
            }
        }


        //code about what will happen when execute select button is clicked
        private void execute_btn_Click(object sender, EventArgs e)
        {
            //updating the selected table value in the public variable
            selected_table = tables_listbox.SelectedItem.ToString();

            //creating a dataset consisting of the data taken from the public function from the created class
            the_dataset = sql_server.select_anything_using_sql(selected_database, user_input.Text, selected_table);

            //datagridview is cleared and updated with the new data
            dataGridView1.DataSource = null;
            dataGridView1.DataMember = null;
            dataGridView1.DataSource = the_dataset;
            dataGridView1.DataMember = selected_table;
        }
    }
}
