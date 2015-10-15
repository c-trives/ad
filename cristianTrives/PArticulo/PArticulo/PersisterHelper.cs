using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;


namespace PArticulo
{
	public class PersisterHelper
	{
		public static QueryResult Get(string selectText)
		{
			IDbConnection dbConnection = App.Instance.DbConnection;
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = selectText;
			IDataReader dataReader = dbCommand.ExecuteReader ();

			QueryResult queryResult = new QueryResult ();

			queryResult.ColumNames = getColumnNames (dataReader);

			
			int numeroColumnas = dataReader.FieldCount;
			List<IList> values = new List<IList> ();
			while (dataReader.Read()) {

				values.Add(getValues(dataReader));
			}
			queryResult.Rows = values;

			dataReader.Close ();
			dbConnection.Close ();
	
			return queryResult;
		}



		private static string[] getColumnNames(IDataReader dataReader) {
			List<string> columnNames = new List<string> ();
			int count = dataReader.FieldCount;
			for (int index = 0; index < count; index++)
				columnNames.Add (dataReader.GetName (index));
			return columnNames.ToArray ();
		}

		private static Type[] getTypes(int count) {
			List<Type> types = new List<Type> ();
			for (int index = 0; index < count; index++)
				types.Add (typeof(string));
			return types.ToArray ();
		}

		private static IList getValues(IDataReader dataReader) {
			List<object> values = new List<object> ();
			int count = dataReader.FieldCount;
			for (int index = 0; index < count; index++) {
				values.Add (dataReader [index]);
			}
			return values;
		}
	}
}

