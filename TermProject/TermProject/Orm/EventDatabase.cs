using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;

namespace TermProject
{
	public class EventDatabase : SQLiteConnection
	{
		static object locker = new object ();

		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "EventDB.db3";
				
#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else
				
#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
#else
				
#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		
				
#endif
				return path;	
			}
		}

		public EventDatabase (string path) : base (path)
		{
			// create the tables
			CreateTable<Event> ();
		}

        public IEnumerable<Event> GetEvents () 
		{
			lock (locker) {
				return (from i in Table<Event> () select i).ToList ();
			}
		}
		
        public Event GetEvent (int id)
		{
			lock (locker) {
                return Table<Event>().FirstOrDefault(x => x.Id == id);
			}
		}
        public IEnumerable<Event> GetEventsByMonth(string  month)
        {
            lock (locker)
            {
                return (from i in Table<Event>() where i.Month.Equals(month) select i).ToList();
            }
        }
        public int SaveEvent (Event item) 
		{
			lock (locker) {
				if (item.Id != 0) {
					Update (item);
					return item.Id;
				} else {
					return Insert (item);
				}
			}
		}
		
//		public int DeleteStock(int id) 
//		{
//			lock (locker) {
//				return Delete<Stock> (new Stock () { Id = id });
//			}
//		}
        public int DeleteEvent(Event stock) 
		{
			lock (locker) {
                return Delete<Event> (stock.Id);
			}
		}
	}
}