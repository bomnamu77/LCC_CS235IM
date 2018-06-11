using System;
using SQLite;

namespace TermProject {

	public class Event {
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }
		
		[MaxLength(8)]
		public string Month { get; set; }
        public string Day { get; set; }
		public string Name { get; set; }
	}
}

