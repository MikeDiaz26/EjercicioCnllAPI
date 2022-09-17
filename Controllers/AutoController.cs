using EjercicioCanellaAPI.Connection;
using EjercicioCanellaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioCanellaAPI.Controllers
{
    [Route("api/v1/auto")]
    [ApiController]
    public class AutoController : Controller
    {
        private GestionVehiculo datos = new GestionVehiculo();

        [HttpGet]
        public ActionResult<Vehiculo> GetVehiculoByPlaca(string placa)
        {
            System.Diagnostics.Debug.WriteLine("GET vehiculo: " + placa);
            Vehiculo vehiculo = datos.GetVehiculo(placa);
            return vehiculo;
        }
    }
}
