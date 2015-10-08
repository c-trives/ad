using System;
using Gtk;
using System.Data;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		IDbConnection dbConection = App.Instance.DbConnection;

		//dbConection.Open ();
		IDbCommand dbCommand = dbConection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";
		IDataReader dataReader = dbCommand.ExecuteReader ();

		/**mySqlDataReader.Read ();
		Type[] types = new Type[mySqlDataReader.FieldCount];
		for (int i= 0; i<mySqlDataReader.FieldCount; i++) {
			Console.WriteLine (mySqlDataReader.GetValue (i).GetType ());
			treeViewArticulo.AppendColumn (mySqlDataReader.GetName (i), new CellRendererText(),"text",i);
			if(mySqlDataReader.GetValue (i).GetType ().ToString() == "System.Decimal") {
				double prueba = 0;
				types.SetValue(prueba.GetType(),i);
			}else{
				types.SetValue (mySqlDataReader.GetValue (i).GetType (), i);
			}
			


		
		}

		ListStore listStore = new ListStore (types);

		do {
			Console.WriteLine(mySqlDataReader.GetValue(3));

			string nombreArticulo = mySqlDataReader.GetString(1);

			Decimal precio = mySqlDataReader.GetDecimal(3);
			double x = (double)precio;
			listStore.AppendValues(mySqlDataReader.GetValue(0),nombreArticulo,mySqlDataReader.GetValue(2),x);


			
		} while(mySqlDataReader.Read());

		treeViewArticulo.Model = listStore;
*/


		SqlClass sqlClass = new SqlClass (dataReader);
		Type[] types = sqlClass.getTypes ();
		Type[] types2 = new Type[types.Length];
		for (int i= 0; i<types.Length; i++) {
		
			types2[i] = types [i].ToString().GetType();
			treeViewArticulo.AppendColumn (dataReader.GetName (i), new CellRendererText(),"text",i);
		
		}
		ListStore listStore = new ListStore (types2);

		String[,] values = sqlClass.getValues ();

		for (int k=0; k < values.GetLength(0); k++) {
			String[] row = new String[values.GetLength(1)];
			for (int l=0; l< values.GetLength(1); l++) {

				row[l] = values [k,l];

			}
			listStore.AppendValues (row);
		}

		treeViewArticulo.Model = listStore;
		dataReader.Close ();
		dbConection.Close ();

		}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void onClick (object sender, EventArgs e)
	{

	}
}
