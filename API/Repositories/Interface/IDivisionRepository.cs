using API.Models;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IDivisionRepository
    {
        List<Division> Get();
        Division Get(int id);
        int Post(DivisionViewModel divVM);
        int Put(Division division);
        int Delete(int id);
    }
}
