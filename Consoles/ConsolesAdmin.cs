using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
	public class ConsolesAdmin
	{
		public List<console> GetConsoles()
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					return db.consoles.Include (x => x.company1).ToList ();
				}
			}
			catch (Exception)
			{
				throw new Exception ("There are no consoles registered.");
			}
		}

		public console GetConsole(int ID)
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					return db.consoles.FirstOrDefault (x => x.ID == ID);
				}
			}
			catch (Exception)
			{
				throw new Exception ("Something happened while getting the console's info");
			}
		}

		public void AddConsole(console console)
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					Validate (console);
					if (db.consoles.Any (x => x.Short_Name == console.Short_Name))
						throw new ArgumentException ("The console's short name already exists");
					db.consoles.Add (console);
					db.SaveChanges ();
					ListUpdated?.Invoke ();
				}
			}
			catch (ArgumentException)
			{
				throw;
			}
			catch (Exception)
			{
				throw new Exception ("Something wrong happened while adding a new console");
			}
		}

		public void RemoveConsole(console console)
		{
			using (db_consolesEntities db = new db_consolesEntities ())
			{
				if (db.consoles.FirstOrDefault (x => x.ID == console.ID) != null)
				{
					db.Entry (console).State = System.Data.EntityState.Deleted;
					db.SaveChanges ();
					ListUpdated?.Invoke ();
				}
			}
		}

		public void Update(console console)
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					Validate (console);
					db.Entry (console).State = System.Data.EntityState.Modified;
					db.SaveChanges ();
					ListUpdated?.Invoke ();
				}
			}
			catch (ArgumentException)
			{ throw; }
			catch (Exception)
			{
				throw new Exception ("Something wrong happened while updating the console's info.");
			}
		}

		public static void Validate(console console)
		{
			if (string.IsNullOrWhiteSpace (console.Console_Name))
				throw new ArgumentException ("It's necesary to enter the console's name");
			if (console.Console_Name.Length > 50)
				throw new ArgumentException ("Console's name has to be smaller than 50 characters");
			if (string.IsNullOrWhiteSpace (console.Short_Name))
				throw new ArgumentException ("It's necesary to enter the console's short name");
			if (console.Short_Name.Length > 20)
				throw new ArgumentException ("Console's short name has to be smaller than 20 characters.");
			if (console.Company == 0)
				throw new ArgumentException ("It's necesary to enter the console's company");
		}

		public event Action ListUpdated;
	}
}