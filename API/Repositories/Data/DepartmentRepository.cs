using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class DepartmentRepository : IDepartmentRepository

    {
        MyContext myContext;

        public DepartmentRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = myContext.Departments.Find(id);
            myContext.Departments.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Department> Get()
        {
            var data = myContext.Departments.ToList();
            return data;
        }

        public Department Get(int id)
        {
            var data = myContext.Departments.Find(id);
            return data;
        }

        public int Post(DepartmentViewModel deptVM)
        {
            Department department = new Department();
            department.Name = deptVM.Name;
            department.DivisionId = deptVM.DivisionId;
            myContext.Departments.Add(department);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(DepartmentEditViewModel deptVM)
        {
            Department department = new Department();
            department.Id = deptVM.Id;
            department.Name = deptVM.Name;
            department.DivisionId = deptVM.DivisionId;
            var data = myContext.Departments.Find(department.Id);
            data.Name = department.Name;
            data.DivisionId = department.DivisionId;
            myContext.Departments.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
