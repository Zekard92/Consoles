using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
	public class CompaniesAdmin
	{
		public List<company> GetCompanies()
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					return db.companies.ToList ();
				}
			}
			catch (Exception)
			{
				throw new Exception ("There are no companies registered.");
			}
		}

		public company GetCompany(int ID)
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					return db.companies.FirstOrDefault (x => x.ID == ID);
				}
			}
			catch (Exception)
			{
				throw new Exception ("Something wrong happened while getting the console's info.");
			}
		}

		public void AddCompany(company company)
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					Validate (company);
					db.companies.Add (company);
					db.SaveChanges ();
					ListUpdated?.Invoke ();
				}
			}
			catch (ArgumentException)
			{ throw; }
			catch (Exception ex)
			{
				throw new Exception ("Something wrong happened while adding a new company.");
			}
		}

		public void RemoveCompany(company company)
		{
			using (db_consolesEntities db = new db_consolesEntities ())
			{
				if (db.companies.FirstOrDefault (x => x.ID == company.ID) != null)
				{
					db.Entry (company).State = System.Data.EntityState.Deleted;
					db.SaveChanges ();
					ListUpdated?.Invoke ();
				}
			}
		}

		public void UpdateCompany(company company)
		{
			try
			{
				using (db_consolesEntities db = new db_consolesEntities ())
				{
					Validate (company);
					db.Entry (company).State = System.Data.EntityState.Modified;
					db.SaveChanges ();
					ListUpdated?.Invoke ();
				}
			}
			catch (ArgumentException)
			{ throw; }
			catch (Exception)
			{
				throw new Exception ("Something wrong happened while updating the company's info.");
			}
		}

		public void Validate(company company)
		{
			if (string.IsNullOrWhiteSpace (company.Company_Name))
				throw new ArgumentException ("It's necesary to enter the company's name");
			if (company.Founded == new DateTime (1, 1, 1))
				throw new ArgumentException ("It's necesary to enter the company's foundation date");
		}

		public event Action ListUpdated;
	}
}