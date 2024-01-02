using ParcelTrackerApp.DAL.Interrfaces;
using ParcelTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ParcelTrackerApp.Controllers
{
    public class ParcelController : ApiController
    {
        private readonly IParcelTrackerService _service;
        public ParcelController(IParcelTrackerService service)
        {
            _service = service;
        }
        public ParcelController()
        {
            // Constructor logic, if needed
        }
        [HttpPost]
        [Route("api/Parcel/CreateParcel")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateParcel([FromBody] Parcel model)
        {
            var leaveExists = await _service.GetParcelById(model.Id);
            var result = await _service.CreateParcel(model);
            return Ok(new Response { Status = "Success", Message = "Parcel created successfully!" });
        }


        [HttpPut]
        [Route("api/Parcel/UpdateParcel")]
        public async Task<IHttpActionResult> UpdateParcel([FromBody] Parcel model)
        {
            var result = await _service.UpdateParcel(model);
            return Ok(new Response { Status = "Success", Message = "Parcel updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Parcel/DeleteParcel")]
        public async Task<IHttpActionResult> DeleteParcel(long id)
        {
            var result = await _service.DeleteParcelById(id);
            return Ok(new Response { Status = "Success", Message = "Parcel deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Parcel/GetParcelById")]
        public async Task<IHttpActionResult> GetParcelById(long id)
        {
            var expense = await _service.GetParcelById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Parcel/GetAllParcels")]
        public async Task<IEnumerable<Parcel>> GetAllParcels()
        {
            return _service.GetAllParcels();
        }
    }
}
