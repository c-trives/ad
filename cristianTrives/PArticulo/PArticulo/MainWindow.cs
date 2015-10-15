using System;
using Gtk;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		CellRendererText cellRendererText = new CellRendererText ();

		for (int i= 0; i<queryResult.ColumNames.Length; i++) {
			int column = i;
			treeViewArticulo.AppendColumn(queryResult.ColumNames.GetValue(i).ToString(), cellRendererText , 
			                              delegate(TreeViewColumn treeColumn, CellRenderer cell, TreeModel treeModel, TreeIter iter){

				IList row = (IList) treeModel.GetValue(iter,0);
				cellRendererText.Text = row[column].ToString();

			});

		}

		ListStore listStore = new ListStore (typeof(IList));

		IEnumerable<IList> values = queryResult.Rows;


		foreach (IList k in values) {
			listStore.AppendValues (k);

		}

		treeViewArticulo.Model = listStore;

	/**	IDbConnection dbConection = App.Instance.DbConnection;


		IDbCommand dbCommand = dbConection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";
		IDataReader dataReader = dbCommand.ExecuteReader ();

	


		MiClassDb miDbClass = new MiClassDb (dataReader);
		CellRendererText cellRendererText = new CellRendererText ();
		string[] columnNames = miDbClass.showColumnNames ();
		for (int i= 0; i<columnNames.Length; i++) {
		

			int column = i;
			treeViewArticulo.AppendColumn(columnNames[i], cellRendererText , 
			                              delegate(TreeViewColumn treeColumn, CellRenderer cell, TreeModel treeModel, TreeIter iter){

				IList row = (IList) treeModel.GetValue(iter,0);
				cellRendererText.Text = row[column].ToString();

			});

		
		}
		ListStore listStore = new ListStore (typeof(IList));

		IList values = miDbClass.getValues ();

		foreach (IList k in values) {

			listStore.AppendValues (k);
		
		}

			
		

		treeViewArticulo.Model = listStore;
		dataReader.Close ();
		dbConection.Close ();
*/
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
