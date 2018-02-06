using System.Collections.Generic;
using iexperience.Entities;

namespace iexperience.Services
{
    public interface ICompanyService
    {
        bool SaveCompany(Company c);
        Company GetCompany(int companyId);
        IEnumerable<Company> GetAllCompanies();
    }
}
