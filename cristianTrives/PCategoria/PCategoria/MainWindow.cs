using System;
using Gtk;
using PSerpisAd;
using PCategoria;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		QueryResult query = PersisterHelper.Get ("select * from Categoria");
		TreeViewHelper treeViewHelper = new TreeViewHelper (treeViewCategoria,query);
		treeViewHelper.fillTreeView ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void onNewCategoriaActivated (object sender, EventArgs e)
	{
		new CategoriaView ();
	}

	protected void onRefreshActionActivated (object sender, EventArgs e)
	{

		QueryResult query = PersisterHelper.Get ("select * from Categoria");
		TreeViewHelper treeViewHelper = new TreeViewHelper (treeViewCategoria,query);
		treeViewHelper.refreshTreeView ();

	}

}
