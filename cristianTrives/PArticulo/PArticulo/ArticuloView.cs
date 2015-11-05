using System;
using PSerpisAd;
using System.Collections.Generic;
using System.Collections;
using Gtk;
using System.Data;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
			ComboBoxHelper.fill (comboBoxCategoria, queryResult);
			comboBoxCategoria.Active = 0;

		}
		protected void SaveArticulo (object sender, EventArgs e)
		{
			String nombreArticulo = entryNombre.Text;
			int indiceCatArticulo = comboBoxCategoria.Active;
			TreeIter treeIter = new TreeIter ();


			comboBoxCategoria.Model.GetIterFirst (out treeIter);

			for (int j =0; j<indiceCatArticulo; j++) {

				
				comboBoxCategoria.Model.IterNext(ref treeIter);

			}
			IList categoriaModel = (IList) comboBoxCategoria.Model.GetValue (treeIter, 0);

			int categoriaId = int.Parse(categoriaModel [0].ToString());
			decimal precio = Convert.ToDecimal(spinButtonPrecio.Value);
			IList nuevaRow = new List<object>();
			nuevaRow.Add (nombreArticulo);
			nuevaRow.Add (categoriaId);
			nuevaRow.Add (precio);
			PersisterHelper.Save ("Articulo", nuevaRow);

			this.Destroy();
		}


	}
}

