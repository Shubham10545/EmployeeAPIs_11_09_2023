using Domain;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public List<GetAllEmployeeData> GetAll()
        {
            var result = (from E in this._appDbContext.Employee
                          join C in this._appDbContext.Country on E.CountryId equals C.Id
                          join S in this._appDbContext.State on C.Id equals S.CountryId
                          join CP in this._appDbContext.City on S.Id equals CP.StateId

                          select new GetAllEmployeeData
                          {
                              Id = E.Id,
                              FirstName = E.FirstName,
                              LastName = E.LastName,
                              Email = E.Email,
                              Gender = E.Gender,
                              MaritalStatus = E.MaritalStatus,
                              BirthDate = E.BirthDate,
                              Salary = E.Salary,
                              Address = E.Address,
                              ZipCode = E.ZipCode,
                              Hobbies = E.Hobbies,
                              Country = C.CountryName,
                              State = S.StateName,
                              City = CP.CityName,
                              Password = E.Password
                          }).ToList();

            return result;
        }
    }

}