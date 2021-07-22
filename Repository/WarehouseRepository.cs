using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseApi.Models;

namespace WarehouseApi.Repository
{
    public class WarehouseRepository
    {
        private readonly WarehouseContext _context = null;

        public WarehouseRepository(WarehouseContext context)
        {
            _context = context;
        }




        public IQueryable<WarehouseModels> GetAllWarehouseData(string warehousename,string modelname)
        {
            // var warehousemodels ;

            IQueryable<WarehouseModels> warehousemodels = null;;

            if (warehousename == null && modelname == null)
            {
                 warehousemodels = from a in _context.Makes
                                      join b in _context.Models
                                      on a.id equals b.makeId

                                      select new WarehouseModels
                                      {
                                          WarehouseId = a.id,
                                          Warehousename = a.name,
                                          modelidnumber = b.id,
                                          modelmakeid = a.id,
                                          modelname = b.name,
                                          modelId = b.modelId
                                      };

              //  return warehousemodels;
            }

            else if ((warehousename != null && modelname == null))
            {
                 warehousemodels = from a in _context.Makes
                                      join b in _context.Models
                                      on a.id equals b.makeId
                                      where a.name == warehousename 
                                      select new WarehouseModels
                                      {
                                          WarehouseId = a.id,
                                          Warehousename = a.name,
                                          modelidnumber = b.id,
                                          modelmakeid = a.id,
                                          modelname = b.name,
                                          modelId = b.modelId
                                      };

              //  return warehousemodels;
            }

            else if ((warehousename == null && modelname != null))
            {
                 warehousemodels = from a in _context.Makes
                                      join b in _context.Models
                                      on a.id equals b.makeId
                                      where b.name == modelname
                                      select new WarehouseModels
                                      {
                                          WarehouseId = a.id,
                                          Warehousename = a.name,
                                          modelidnumber = b.id,
                                          modelmakeid = a.id,
                                          modelname = b.name,
                                          modelId = b.modelId
                                      };

              // return warehousemodels;
            }

            else if((warehousename != null && modelname != null))
            {
                 warehousemodels = from a in _context.Makes
                                      join b in _context.Models
                                      on a.id equals b.makeId
                                      where a.name== warehousename && b.name==modelname
                                      select new WarehouseModels
                                      {
                                          WarehouseId = a.id,
                                          Warehousename = a.name,
                                          modelidnumber = b.id,
                                          modelmakeid = a.id,
                                          modelname = b.name,
                                          modelId = b.modelId
                                      };

              // return warehousemodels;
            }

            return warehousemodels;
        }


        public IQueryable<WarehouseModels> GetAllWarehouseDataById(int makeid)
        {

            var warehousemodels = from a in _context.Makes
                                  join b in _context.Models
                                  on a.id equals b.makeId
                                  where a.id == makeid 
                                  select new WarehouseModels
                                  {
                                      WarehouseId = a.id,
                                      Warehousename = a.name,
                                      modelidnumber = b.id,
                                      modelmakeid = a.id,
                                      modelname = b.name,
                                      modelId = b.modelId
                                  };

            return warehousemodels;
        }

        public async Task<WarehouseModels> DeleteWarehouse(int makeid, int modelid)
        {
           // int result = 0;

            var warehouseTodelete = from a in _context.Makes
                                    join b in _context.Models
                                    on a.id equals b.makeId
                                    where a.id == makeid && b.modelId == modelid
                                    select new WarehouseModels
                                    {
                                        WarehouseId = a.id,
                                        Warehousename = a.name,
                                        modelidnumber = b.id,
                                        modelmakeid = a.id,
                                        modelname = b.name,
                                        modelId = b.modelId
                                    };

            _context.Remove(warehouseTodelete);

            //Commit the transaction
            await _context.SaveChangesAsync();
          //  _context.SaveChangesAsync();
            return null;
        }
    
      public async Task<int> AddWarehouseData(Makes wm)
        {
            await _context.AddAsync(wm);
            await _context.SaveChangesAsync();
            return wm.id;
        }

        public async Task <int> UpdateWarehouseData(Makes wm)
        {
            _context.Entry(wm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return wm.id;
        }

        


    }
}
