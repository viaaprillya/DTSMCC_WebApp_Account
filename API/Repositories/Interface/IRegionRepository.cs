using API.Models;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IRegionRepository
    {
        List<Region> Get();
        Region Get(int id);
        int Post(RegionViewModel regVM);
        int Put(RegionEditViewModel regVM);
        int Delete(int id);
    }
}
