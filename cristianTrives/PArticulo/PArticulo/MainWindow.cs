using System;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		MySqlConnection mySqlConnection = new MySqlConnection (
			"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"
		);

		mySqlConnection.Open ();
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from articulo";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

		mySqlDataReader.Read ();
		Type[] types = new Type[mySqlDataReader.FieldCount];
		for (int i= 0; i<mySqlDataReader.FieldCount; i++) {
			Console.WriteLine (mySqlDataReader.GetValue (i).GetType ());
			treeViewArticulo.AppendColumn (mySqlDataReader.GetName (i), new CellRendererText (),"text",i);
			types.SetValue (mySqlDataReader.GetValue (i).GetType (), i);


		
		}
		Console.WriteLine ("array types " + types.ToString ());
		ListStore listStore = new ListStore (types);

		do {
			Console.WriteLine(mySqlDataReader.GetValue(3));

			string nombreArticulo = mySqlDataReader.GetString(1);

			Decimal precio = mySqlDataReader.GetDecimal(3);

			listStore.AppendValues(mySqlDataReader.GetValue(0),nombreArticulo,mySqlDataReader.GetValue(2),precio);


			
		} while(mySqlDataReader.Read());

		treeViewArticulo.Model = listStore;



		mySqlDataReader.Close ();
		mySqlConnection.Close ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
