using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PSerpisAd
{
	public class App
	{
		private static App instance = new App();
		private IDbConnection dbConnection;


		private App ()
		{


		}

		public static App Instance{
			get{

				return instance;
			}
		}

		public IDbConnection DbConnection {
			get { 
				
				return dbConnection;


			}
			set {
				dbConnection = value;
		
			}
		}
	}
}

