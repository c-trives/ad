using System;
using Gtk;

namespace PSerpisTrivesGenericGraphics
{


	public partial class DialogGeneric : Gtk.Dialog
	{

		public delegate void EventHandler(object sender, EventArgs args) ;
		public event EventHandler ThrowEvent = delegate{};

		public DialogGeneric (String texto)
		{
			this.Build ();
			labelDialog.Text = texto;
		}



		protected void ButtonOkClicked (object sender, EventArgs e)
		{
				ThrowEvent (this, new EventArgs ());
				this.Destroy ();
		}

		protected void ButtonCancelClicked (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	
	}
}

