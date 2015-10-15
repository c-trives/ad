using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace PArticulo
{
	public class QueryResult
	{
		string[] columNames;
		IEnumerable <IList> rows;

		public string[] ColumNames {
			get {
				return columNames;
			}
			set {
				columNames = value;
			}
		}

		public IEnumerable<IList> Rows {
			get {
				return rows;
			}
			set {
				rows = value;
			}
		}

	}
}

