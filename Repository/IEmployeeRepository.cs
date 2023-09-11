using Domain;
using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        List<GetAllEmployeeData> GetAll();

    }
}
