using System;
using PSerpisAd;
using System.Collections;
using System.Collections.Generic;


namespace PCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void onSaveCategoriaActivated (object sender, EventArgs e)
		{
			string nombreCategoria = entryCategoriaNombre.Text;
			IList nuevaRow = new List<object>();
			nuevaRow.Add (nombreCategoria);
			PersisterHelper.Save ("Categoria", nuevaRow);

			this.Destroy ();
		}
	}
}

