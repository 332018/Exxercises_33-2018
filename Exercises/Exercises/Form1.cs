using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercises
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            

            List<ExerciseResult> exeRes = new List<ExerciseResult>(); 

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM [ ExerciseResults]";

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while(sqlDataReader.Read())
            {
                ExerciseResult exerciseResult = new ExerciseResult();
                exerciseResult.id = sqlDataReader.GetInt32(0);
                exerciseResult.StudentName = sqlDataReader.GetString(1);
                exerciseResult.StudentIndex = sqlDataReader.GetString(2);
                exerciseResult.Points = sqlDataReader.GetInt32(3);
                exeRes.Add(exerciseResult);
            }

            sqlConnection.Close();

            foreach (ExerciseResult exercise in exeRes)
            {
                listBoxExerciseResults.Items.Add(exercise.id + " " + exercise.StudentName + " " + exercise.StudentIndex + " " + exercise.Points + " ");
            }

        }
    }
}
