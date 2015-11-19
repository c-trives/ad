using System;
using Gtk;
using System.Collections;
using System.Collections.Generic;
using Gdk;
using PSerpisAd;
using PSerpisTrivesGenericGraphics;

namespace PSerpisTrives
{
	public class TreeViewHelperGenericGraphic
	{
		TreeView treeView;
		QueryResult queryResult;
		ListStore listStore;
		string tabla;

		public TreeViewHelperGenericGraphic (TreeView treeViewExt, QueryResult queryResultExt,string tabla)
		{
			this.treeView = treeViewExt;
			this.queryResult = queryResultExt;
			this.tabla = tabla;
		}

		bool response;

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
			treeView.AppendColumn ("Editar", new Gtk.CellRendererPixbuf (), "pixbuf", 1);


			treeView.AppendColumn ("Eliminar",new Gtk.CellRendererPixbuf(),"pixbuf",2);


			listStore = new ListStore (typeof(IList),typeof(Gdk.Pixbuf),typeof(Gdk.Pixbuf));




			IEnumerable<IList> values = queryResult.Rows;



			Pixbuf pixbufDelete = new Pixbuf (this.GetType ().Assembly, "PSerpisTrives.delete.png");

			Pixbuf pixbufEdit = new Pixbuf (this.GetType ().Assembly, "PSerpisTrives.edit.png");


			foreach (IList k in values) {
				listStore.AppendValues (k,pixbufEdit,pixbufDelete);
			}

			treeView.Model = listStore;





			treeView.RowActivated += (delegate(object o, RowActivatedArgs args){


				string tituloRow = args.Column.Title;

				if(tituloRow == "Editar"){


					Console.WriteLine(tituloRow + " prueba path:" +args.Path);



				

					TreeIter treeIter = new TreeIter();

					treeView.Model.GetIter(out treeIter,args.Path);

					IList row = (IList) treeView.Model.GetValue(treeIter,0);
					int id = int.Parse(row [0].ToString());
					QueryResult queryResultGet = PersisterHelper.Get("select * from " + tabla + "where id="+id);

				}

				if(tituloRow == "Eliminar"){



					Console.WriteLine(tituloRow + " prueba path:" +args.Path);

					TreeIter treeIter = new TreeIter();

					treeView.Model.GetIter(out treeIter,args.Path);

					IList row = (IList) treeView.Model.GetValue(treeIter,0);
					int id = int.Parse(row [0].ToString());

					MessageDialog messageDialog = new MessageDialog(new Gtk.Window("Dialog"), 
					                                                DialogFlags.DestroyWithParent,
					                                                MessageType.Question, 
					                                                ButtonsType.YesNo, "¿Esta seguro que desea eliminar?");

					ResponseType result = (ResponseType)messageDialog.Run ();

					if (result == ResponseType.Yes){
						
						messageDialog.Destroy();
						PersisterHelper.Delete(tabla,id);
					
					}
					else{
						messageDialog.Destroy();

					}
				}

			});


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

