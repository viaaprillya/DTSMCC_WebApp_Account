using API.Models;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> Get();
        Department Get(int id);
        int Post(DepartmentViewModel deptVM);
        int Put(DepartmentEditViewModel deptEVM);
        int Delete(int id);
    }
}
