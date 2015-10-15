using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace PArticulo
{
	public class SqlClass
	{
		private	MySqlDataReader mySqlDataReader = null;

		public SqlClass (MySqlDataReader mySqlDataReader2)
		{
			mySqlDataReader = mySqlDataReader2;
			mySqlDataReader.Read();


		}
		public SqlClass (IDataReader dataReader)
		{
			mySqlDataReader = (MySqlDataReader) dataReader;
			mySqlDataReader.Read();


		}

		public int numberColumn(){
		
			return mySqlDataReader.FieldCount;
		
		}

		public String[] showColumnNames(){
			List<string> columnNames = new List<string> ();
			int count = mySqlDataReader.FieldCount;
		for (int index = 0; index < count; index++)
				columnNames.Add (mySqlDataReader.GetName (index));
		return columnNames.ToArray ();
		
		}

		public Type[] getTypes(){

			Type[] types = new Type[mySqlDataReader.FieldCount];

			for (int i= 0; i<mySqlDataReader.FieldCount; i++) {

				if(mySqlDataReader.GetValue (i).GetType ().ToString() == "System.Decimal") {
					double prueba = 0;
					types.SetValue(prueba.GetType(),i);
				}else{
					types.SetValue (mySqlDataReader.GetValue (i).GetType (), i);
				}
			
			
			}

			return types;

		}

		public Type[] getTypesString(){

			Type[] types = new Type[mySqlDataReader.FieldCount];

			for (int i= 0; i<mySqlDataReader.FieldCount; i++) {
					types.SetValue (mySqlDataReader.GetValue (i).GetType ().ToString(), i);
			}

			return types;

		}

		public String[,] getValues(){

			int numeroRegistro = mySqlDataReader.VisibleFieldCount;
			int numeroColumnas = mySqlDataReader.FieldCount;
			Console.WriteLine ("numero registro "+numeroRegistro);
			String[,] values = new String[numeroRegistro,numeroColumnas];


			for (int i=0; i < numeroRegistro; i++) {

				for (int j=0; j< numeroColumnas; j++) {
					Console.WriteLine("Value row "+ i+": "+mySqlDataReader.GetValue (j).ToString ());
					values[i,j] = mySqlDataReader.GetValue (j).ToString ();


				}
				Console.WriteLine ("ciclo numero " + i);


				mySqlDataReader.Read ();
			}
			return values;
		}
	}

}

