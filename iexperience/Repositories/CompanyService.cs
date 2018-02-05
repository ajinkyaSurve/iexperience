using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using iexperience.Entities;
using iexperience.Services;

namespace iexperience.Repositories
{
    public class CompanyService : ICompanyService
    {
        private readonly IConnection _conSvc;

        public CompanyService(IConnection conSvc)
        {
            _conSvc = conSvc;
        }

        public bool SaveCompany(Company comp)
        {
            using (var conn = _conSvc.GetConnection())
            {
                //Get company collection
                conn.Open();

                SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Company"
                + " (CompanyName, CompanyPhoneNumber, CompanyAddress, IsActive)"
                + " VALUES (@CompanyName,@CompanyPhoneNumber,@CompanyAddress,@IsActive)", conn)
                {
                    CommandType = CommandType.Text
                };
                insertSQL.Parameters.AddWithValue("CompanyName", comp.CompanyName);
                insertSQL.Parameters.AddWithValue("CompanyPhoneNumber", comp.CompanyPhoneNumber);
                insertSQL.Parameters.AddWithValue("CompanyAddress", comp.CompanyAddress);
                insertSQL.Parameters.AddWithValue("IsActive", comp.IsActive);
                try
                {
                    insertSQL.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public List<Company> GetAllCompanies()
        {
            List<Company> cmp = new List<Company>();
            using (var conn = _conSvc.GetConnection())
            {
                //Get company collection
                conn.Open();

                string selectSQL = "SELECT * FROM Company";

                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(selectSQL, conn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Company c = new Company();
                                c.CompanyId = Convert.ToInt32(rdr["CompanyId"]);
                                c.CompanyName = Convert.ToString(rdr["CompanyName"]);
                                c.CompanyAddress = Convert.ToString(rdr["CompanyAddress"]);
                                c.CompanyPhoneNumber = Convert.ToString(rdr["CompanyPhoneNumber"]);
                                c.IsActive = Convert.ToBoolean(rdr["IsActive"]);
                                cmp.Add(c);
                            }
                        }
                    }
                    return cmp;
                }
                catch (Exception)
                {
                    return cmp;
                }
            }
        }

        public Company GetCompany(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
