
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action newAction;
	private global::Gtk.Action refreshAction;
	private global::Gtk.Action newCategoria;
	private global::Gtk.VBox vbox1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TreeView treeViewCategoria;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.newAction = new global::Gtk.Action ("newAction", null, null, "gtk-new");
		w1.Add (this.newAction, null);
		this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
		w1.Add (this.refreshAction, null);
		this.newCategoria = new global::Gtk.Action ("newCategoria", null, null, "gtk-new");
		w1.Add (this.newCategoria, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='refreshAction' action='refreshAction'/><toolitem name='newCategoria' action='newCategoria'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeViewCategoria = new global::Gtk.TreeView ();
		this.treeViewCategoria.CanFocus = true;
		this.treeViewCategoria.Name = "treeViewCategoria";
		this.GtkScrolledWindow.Add (this.treeViewCategoria);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w4.Position = 1;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.refreshAction.Activated += new global::System.EventHandler (this.onRefreshActionActivated);
		this.newCategoria.Activated += new global::System.EventHandler (this.onNewCategoriaActivated);
	}
}