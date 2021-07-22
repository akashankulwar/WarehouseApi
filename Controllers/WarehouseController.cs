using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseApi.Models;
using WarehouseApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        WarehouseContext db;

        private readonly WarehouseRepository _warehouseRepository = null;

        public WarehouseController(WarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
            //db = _db;
        }

        // GET: api/<WarehouseController>
        [HttpGet]
        public IEnumerable<WarehouseModels> Get(string warehousename,string modelname)
        {
            return (IEnumerable<WarehouseModels>)_warehouseRepository.GetAllWarehouseData(warehousename, modelname);
        }


        // GET api/<WarehouseController>/5
        [HttpGet("{id}")]
        public IEnumerable<WarehouseModels> Get(int id)
        {
            //return "value";
            return (IEnumerable<WarehouseModels>)_warehouseRepository.GetAllWarehouseDataById(id);
        }

        // POST api/<WarehouseController>
        [HttpPost]
        public async Task <int> Post([FromBody] Makes m)
        {
          return await _warehouseRepository.AddWarehouseData(m);

        }

        // PUT api/<WarehouseController>/5
        [HttpPut("{id}")]
        public async Task <int> Put(int id, [FromBody] Makes m)
        {
            return await _warehouseRepository.UpdateWarehouseData(m);
        }

        // DELETE api/<WarehouseController>/5
        //[HttpDelete("{id}")]
        [HttpDelete("{id},{modelid}")]
        public async Task<WarehouseModels>  Delete(int id,int modelid)
        {
           return await _warehouseRepository.DeleteWarehouse(id, modelid);
          

        }
    }
}
