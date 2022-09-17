using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using EjercicioCanellaAPI.Models;

namespace EjercicioCanellaAPI.Connection
{
    public class GestionVehiculo
    {
        public SqlConnection connection;
        public SqlTransaction transaction;
        public string error;

        public GestionVehiculo()
        {
            this.connection = DBConnection.GetConnection();
        }

        public bool NewVehiculo(Vehiculo vehiculo)
        {
            SqlCommand comm = new()
            {
                Connection = connection,
                CommandText = "EXEC new_vehiculo @placa, @marca, @modelo, @anio, @color, @preciorenta;"
            };
            comm.Parameters.AddWithValue("@placa", vehiculo.Placa);
            comm.Parameters.AddWithValue("@marca", vehiculo.Marca);
            comm.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
            comm.Parameters.AddWithValue("@anio", vehiculo.Anio);
            comm.Parameters.AddWithValue("@color", vehiculo.Color);
            comm.Parameters.AddWithValue("@preciorenta", vehiculo.PrecioRenta);
            try
            {
                return comm.ExecuteNonQuery() >= 1;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
                System.Diagnostics.Debug.WriteLine("ex.Message" + ex.Message);
                return false;
            }
        }

        public List<Vehiculo> ListVehiculos()
        {
            List<Vehiculo> countries = new();
            SqlCommand comm = new()
            {
                Connection = connection,
                CommandText = "EXEC get_vehiculos;"
            };
            SqlDataReader records = comm.ExecuteReader();
            while (records.Read())
            {
                Vehiculo country = new Vehiculo()
                {
                    Placa = records.GetString(0),
                    Marca = records.GetString(1),
                    Modelo = records.GetString(2),
                    Anio = records.GetInt32(3),
                    Color = records.GetString(4),
                    PrecioRenta = records.GetDecimal(5)
                };
                countries.Add(country);
            }
            records.Close();
            return countries;
        }

        public Vehiculo GetVehiculo(string placa)
        {
            Vehiculo vehiculo = new();
            SqlCommand comm = new()
            {
                Connection = connection,
                CommandText = "EXEC get_vehiculo_by_placa @placa;"
            };
            comm.Parameters.AddWithValue("@placa", placa);
            SqlDataReader record = comm.ExecuteReader();
            if (record.Read())
            {
                vehiculo = new Vehiculo()
                {
                    Placa = record.GetString(0),
                    Marca = record.GetString(1),
                    Modelo = record.GetString(2),
                    Anio = record.GetInt32(3),
                    Color = record.GetString(4),
                    PrecioRenta = record.GetDecimal(5)
                };
                return vehiculo;
            }

            record.Close();
            return vehiculo;
        }

        public bool UpdateVehiculo(Vehiculo vehiculo)
        {
            SqlCommand comm = new()
            {
                Connection = connection,
                CommandText = "EXEC update_vehiculo @placa, @marca, @modelo, @anio, @color, @preciorenta;"
            };
            comm.Parameters.AddWithValue("@placa", vehiculo.Placa);
            comm.Parameters.AddWithValue("@marca", vehiculo.Marca);
            comm.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
            comm.Parameters.AddWithValue("@anio", vehiculo.Anio);
            comm.Parameters.AddWithValue("@color", vehiculo.Color);
            comm.Parameters.AddWithValue("@preciorenta", vehiculo.PrecioRenta);
            try
            {
                return comm.ExecuteNonQuery() >= 1;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
                System.Diagnostics.Debug.WriteLine("ex.Message" + ex.Message);
                return false;
            }
        }

        public bool DeleteVehiculo(string placa)
        {
            SqlCommand comm = new()
            {
                Connection = connection,
                CommandText = "EXEC delete_vehiculo @placa"
            };
            comm.Parameters.AddWithValue("@placa", placa);

            try
            {
                return comm.ExecuteNonQuery() >= 1;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
                System.Diagnostics.Debug.WriteLine("ex.Message" + ex.Message);
                return false;
            }
        }
    }
}
