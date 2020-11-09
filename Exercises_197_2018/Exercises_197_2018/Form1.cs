using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercises_197_2018
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=FaculityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // nakaciti se na bazu podataka
            SqlConnection sqlConnection = new SqlConnection();

            using (SqlConnection dataConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = connectionString;


                List<ExerciseResult> lista = new List<ExerciseResult>();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM ExerciseResults";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    lista.Add(new ExerciseResult(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetInt32(3)));


                }
                sqlConnection.Close();

                foreach (ExerciseResult l in lista)
                {
                    listBoxExercisesResults.Items.Add(l);
                }
            }
            

        }
    }
}
