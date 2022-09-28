using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class RegionRepository : IRegionRepository
    {

        MyContext myContext;

        public RegionRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = myContext.Regions.Find(id);
            myContext.Regions.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Region> Get()
        {
            var data = myContext.Regions.ToList();
            return data;
        }

        public Region Get(int id)
        {
            var data = myContext.Regions.Find(id);
            return data;
        }

        public int Post(RegionViewModel regVM)
        {
            Region region = new Region();
            region.Name = regVM.Name;
            region.DivisionId = regVM.DivisionId;
            myContext.Regions.Add(region);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(RegionEditViewModel regVM)
        {
            Region region = new Region();
            region.Id = regVM.Id;
            region.Name = regVM.Name;
            region.DivisionId = regVM.DivisionId;
            var data = myContext.Regions.Find(region.Id);
            data.Name = region.Name;
            data.DivisionId = region.DivisionId;
            myContext.Regions.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }

}
