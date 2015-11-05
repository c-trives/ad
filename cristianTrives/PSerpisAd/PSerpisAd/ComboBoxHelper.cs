using System;
using Gtk;
using System.Collections;

namespace PSerpisAd
{
	public class ComboBoxHelper
	{

		public static void fill(ComboBox comboBox,QueryResult queryResult){

			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (cellRendererText, false);
			comboBox.SetCellDataFunc (cellRendererText, delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {

				IList row = (IList) tree_model.GetValue(iter,0);
				cellRendererText.Text = row[1].ToString();
			});


			ListStore listStore = new ListStore(typeof(IList));
			IList first = new object[]{null,"<sin asignar>"};

			TreeIter treeIterFirst = listStore.AppendValues (first);

			foreach(IList row in queryResult.Rows){

				listStore.AppendValues(row);
			}
			comboBox.Model = listStore;
			comboBox.SetActiveIter (treeIterFirst);
		}
	}
}

