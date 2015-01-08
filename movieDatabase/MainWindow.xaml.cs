using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace movieDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tenging vid gagnagrunn (tengistrengur) - sqlitePrufa gagnagrunnurinn er i bin/Debug
        string dbConnectionString = @"Data Source=sqlitePrufa.sqlite;Version=3;"; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Fyrsti takkinn");

            // Bua til nyjan gagnagrunn
            //SQLiteConnection.CreateFile ("sqlitePrufa.sqlite");

            // Bua til tengingu vid gagnagrunn
            SQLiteConnection m_dbConnection = new SQLiteConnection(dbConnectionString);
            try
            {
                // Opna gagnagrunn
                m_dbConnection.Open();

                //// Bua til nyja toflu - dalkarnir heita 'name' og 'score'
                //string createTable = "create table highscores (name varchar(20), score int)";
                //SQLiteCommand command = new SQLiteCommand(createTable, m_dbConnection);
                //command.ExecuteNonQuery();  // Thetta kemur alltaf a eftir hverri SQL-skipun
                //// Bua til nyja toflu
                //string insertInto = "insert into highscores (name, score) values ('Me', 3000)";
                //command = new SQLiteCommand(insertInto, m_dbConnection);
                //command.ExecuteNonQuery();
                //// Bua til nyja toflu
                //insertInto = "insert into highscores (name, score) values ('Myself', 6000)";
                //command = new SQLiteCommand(insertInto, m_dbConnection);
                //command.ExecuteNonQuery();
                //// Setja inn i toflu - dalkarnir heita 'name' og 'score'
                //insertInto = "insert into highscores (name, score) values ('And I', 9001)";
                //command = new SQLiteCommand(insertInto, m_dbConnection);
                //command.ExecuteNonQuery();

                // Velja ur toflu til ad birta
                string Query = "select * from highscores order by score desc";
                SQLiteCommand queryCommand = new SQLiteCommand(Query, m_dbConnection);
                SQLiteDataReader reader = queryCommand.ExecuteReader();

                // Birta i console a medan eitthvad er ad lesast ur grunninum
                while (reader.Read())
                {
                    MessageBox.Show("Name: " + reader["name"] + "\tScore: " + reader["score"]);

                    //Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
