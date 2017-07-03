using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace LMS3
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            //To work with the data in a database, the first step is the connection. 
            //The connection to a database consists of the below-mentioned parameters.
            //1) Database name or Data Source 
            //Each connection can only work with one database at a time.
            //2) Credentials 'username' and 'password'. 
            //This is used to establish a connection to the database.
            
            //Defined a SqlConnection variable 'con' and assigned the data source.
            //Sql Connection uses 'System.Data.SqlClient'
            //CommandType uses 'System.Data'
            //A stored procedure named 'InsertProcedure' is used for insertion.
            //The 'ExecuteNonQuery' method is used in C# to issue any DML statements (insert, delete and update operation) against the database.
            
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\users\vinay joel\documents\visual studio 2010\Projects\LMS3\LMS3\App_Data\LibraryDatabase.mdf;Integrated Security=True;User Instance=True");
            SqlCommand cmd = new SqlCommand("InsertProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name", NameTextBox.Text);
            cmd.Parameters.AddWithValue("author", AuthorTextBox.Text);
            cmd.Parameters.AddWithValue("publisher", PublisherTextBox.Text);
            cmd.Parameters.AddWithValue("category", CategoryDropDownList.SelectedValue);
            cmd.Parameters.AddWithValue("date", DateTextBox.Text);
            cmd.Parameters.AddWithValue("noca", CopiesTextBox.Text);
            cmd.Parameters.AddWithValue("comments", CommentsTextBox.Text);
            con.Open();//Open the connection
            int outputvalue = cmd.ExecuteNonQuery();//Associates the insert procedure and returns non zero value to variable OutputValue if successful.
            if (outputvalue != 0)
            {
                InsertOutputLabel.Text = "Insertion Successful";
            }
            con.Close();//Close the connection
        }
    }
}