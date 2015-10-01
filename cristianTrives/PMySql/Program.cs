using System;
using MySql.Data.MySqlClient;

namespace PMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Database=dbprueba;Data Source=localhost;User Id=root;Password = sistemas"
				);
			mySqlConnection.Open();

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "select * from articulo";
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
			showColumnNames (mySqlDataReader);
			show(mySqlDataReader);
		



			mySqlDataReader.Close ();

			mySqlConnection.Close ();
		}

		public static void showColumnNames(MySqlDataReader mySqlDataReader){
		
			int numeroColumnas = mySqlDataReader.FieldCount;
			string nombreColumnas = null;
			for (int i=0; i < numeroColumnas; i++) {
			
				nombreColumnas += "Columna "+i+" :"+ mySqlDataReader.GetName (i)+ " ";
			
			}

			Console.WriteLine (nombreColumnas);

		}

		public static void show(MySqlDataReader mySqlDataReader){
		
			int numeroRegistro = mySqlDataReader.VisibleFieldCount;
			Console.WriteLine ("");
			int numeroColumnas = mySqlDataReader.FieldCount;
			string fila = null;
			for (int i=0; i <= numeroRegistro; i++) {
				mySqlDataReader.Read ();
				for (int j=0; j< numeroColumnas; j++) {


					fila += mySqlDataReader.GetName (j)+": " +mySqlDataReader.GetValue (j).ToString () + " ";


				}
				Console.WriteLine (fila);
				fila = null;
			}
		
		}
	}
}
