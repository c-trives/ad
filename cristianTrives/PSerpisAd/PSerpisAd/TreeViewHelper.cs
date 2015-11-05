using System;
using Gtk;
using System.Collections;
using System.Collections.Generic;

namespace PSerpisAd
{
	public class TreeViewHelper
	{
		TreeView treeView;
		QueryResult queryResult;
		ListStore listStore;
		public TreeViewHelper (TreeView treeViewExt, QueryResult queryResultExt)
		{
			this.treeView = treeViewExt;
			this.queryResult = queryResultExt;
		}

		public void fillTreeView(){

			
			CellRendererText cellRendererText = new CellRendererText ();
		
				for (int i= 0; i<queryResult.ColumNames.Length; i++) {
					int column = i;
					treeView.AppendColumn (queryResult.ColumNames.GetValue (i).ToString (), cellRendererText, 
					                       delegate(TreeViewColumn treeColumn, CellRenderer cell, TreeModel treeModel, TreeIter iter) {

						IList row = (IList)treeModel.GetValue (iter, 0);
						cellRendererText.Text = row [column].ToString ();
					});

			

				}

				listStore = new ListStore (typeof(IList));


				
			
			IEnumerable<IList> values = queryResult.Rows;


			foreach (IList k in values) {
				k.Add (new Gtk.Button());
				listStore.AppendValues (k);

			}

			treeView.Model = listStore;



		}

		public void refreshTreeView(){

			listStore =(ListStore) treeView.Model;
			listStore.Clear ();

			IEnumerable<IList> values = queryResult.Rows;

			foreach (IList k in values) {
				listStore.AppendValues (k);

			}


		}
	}
}

