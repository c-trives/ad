using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;


namespace PSerpisAd
{
	public class PersisterHelper
	{
		public static QueryResult Get(string selectText)
		{
			IDbConnection dbConnection = App.Instance.DbConnection;
			if (dbConnection.State.ToString () == "Closed") {

				dbConnection.Open ();
			}
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

		public static void Save (string tabla,IList row){

			QueryResult queryResult = Get ("select * from " + tabla);

			IDbConnection dbConnection = App.Instance.DbConnection;

			if (dbConnection.State.ToString () == "Closed") {

				dbConnection.Open ();
			}
			IDbCommand dbCommand = dbConnection.CreateCommand ();

			//CODIGO NUEVO insert generico,saltandose id(Autoincrement)

			string command = "insert into "+tabla+"(";

			for (int k =1; k <queryResult.ColumNames.Length; k++) {
				if (k != 1) {
					command += ",";
				}

				command += queryResult.ColumNames.GetValue(k);

			}
			command +=") values (@";

			for (int j =1; j <queryResult.ColumNames.Length; j++) {
				if (j != 1) {
					command += ",@";
				}

				command += queryResult.ColumNames.GetValue (j);

			}
			command += ");";

			//


			//dbCommand.CommandText = "insert into "+tabla +"("+queryResult.ColumNames.GetValue(1)+","+queryResult.ColumNames.GetValue(2)+","+queryResult.ColumNames.GetValue(3)+") values (@"+queryResult.ColumNames.GetValue(1)+",@"+queryResult.ColumNames.GetValue(2)+",@"+queryResult.ColumNames.GetValue(3)+");";
			dbCommand.CommandText = command;

			for(int j=0; j<row.Count;j++){
				IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
				dbDataParameter.ParameterName = queryResult.ColumNames.GetValue(j+1).ToString();
				dbDataParameter.Value = row[j];
				dbCommand.Parameters.Add(dbDataParameter);
			}

			dbCommand.ExecuteNonQuery ();
			dbCommand.Dispose ();
			dbConnection.Close ();

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

