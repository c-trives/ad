using System;
using Gtk;
using System.Collections;
using System.Collections.Generic;
using PArticulo;

namespace PArticulo
{
	public static class TreeViewHelperStatic
	{
		static TreeView treeView;
		static QueryResult queryResult;
		static ListStore listStore;

		public static QueryResult QueryResult {
			get {
				return queryResult;
			}
			set {
				queryResult = value;
			}
		}	

		public static TreeView TreeView {
			get {
				return treeView;
			}
			set {
				treeView = value;
			}
		}

		public static void fillTreeView(){


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
				listStore.AppendValues (k);

			}

			treeView.Model = listStore;


		}

		public static void refreshTreeView(){

			listStore =(ListStore) treeView.Model;
			listStore.Clear ();

			IEnumerable<IList> values = queryResult.Rows;

			foreach (IList k in values) {
				listStore.AppendValues (k);

			}


		}
	}
}

