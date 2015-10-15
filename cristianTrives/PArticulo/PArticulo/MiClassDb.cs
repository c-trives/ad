using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace PArticulo
{
	public class MiClassDb
	{
		IDataReader dataReader = null;

		public MiClassDb (IDataReader dataReader2)
		{
			dataReader = dataReader2;
			dataReader.Read();


		}

		public String[] showColumnNames(){
			List<string> columnNames = new List<string> ();
			int count = dataReader.FieldCount;
			for (int index = 0; index < count; index++)
				columnNames.Add (dataReader.GetName (index));
			return columnNames.ToArray ();

		}

	public IList getValues(){

			List<object> values = new List<object> ();

			int numeroColumnas = dataReader.FieldCount;

			do{
				List<object> row = new List<object> ();
				for (int j=0; j< numeroColumnas; j++) {
					row.Add(dataReader[j]);
				}
				values.Add(row);
			} while(dataReader.Read());

			return values;

		}

	}
}

