using Microsoft.AspNetCore.Mvc;
using EjercicioCanellaAPI.Connection;
using EjercicioCanellaAPI.Models;

namespace EjercicioCanellaAPI.Controllers
{
    [Route("api/v1/vehiculo")]
    [ApiController]
    public class VehiculoController : Controller
    {
        private GestionVehiculo datos = new GestionVehiculo();

        [HttpPost]
        public ActionResult PostVehiculo(Vehiculo vehiculo)
        {
            System.Diagnostics.Debug.WriteLine("POST vehiculo");
            var response = datos.NewVehiculo(vehiculo);
            if (response)
                return Ok();

            return BadRequest();
        }

        [HttpGet]
        public IEnumerable<Vehiculo> GetVehiculos()
        {
            System.Diagnostics.Debug.WriteLine("GET vehiculos");
            List<Vehiculo> list = datos.ListVehiculos();
            return list;
        }

        /*[HttpGet]
        public ActionResult<Vehiculo> GetVehiculoByPlaca(string placa)
        {
            System.Diagnostics.Debug.WriteLine("GET vehiculo: " + placa);
            Vehiculo vehiculo = datos.GetVehiculo(placa);
            return vehiculo;
        }*/

        [HttpPut]
        public ActionResult PutVehiculo(Vehiculo vehiculo)
        {
            System.Diagnostics.Debug.WriteLine("PUT vehiculo");
            var response = datos.UpdateVehiculo(vehiculo);
            if (response)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        public ActionResult DeleteVehiculo(string placa)
        {
            System.Diagnostics.Debug.WriteLine("PUT vehiculo");
            var response = datos.DeleteVehiculo(placa);
            if (response)
                return Ok();

            return BadRequest();
        }
    }
}