using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using pruebaPartners.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PersonasDao
    {
        private readonly IConfiguration _configuration;

        public PersonasDao(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Personas> GetPersonas()
        {
            var response = new List<Personas>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SELECTPERSONAS";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Connection = connection;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    connection.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error sql" + ex.Message);
            }

            return response;
        }
        public List<Personas> GetPersonasById(string NoIdentificador)
        {
            var response = new List<Personas>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlParameter[] parametri = new SqlParameter[1];
                    parametri[0] = new SqlParameter("@NOIDENTIFICACION", SqlDbType.VarChar);
                    parametri[0].Value = NoIdentificador;
                    
                    cmd.CommandText = "SELECTPERSONASBYID";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parametri);
                    cmd.Connection = connection;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    connection.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error sql" + ex.Message);
            }

            return response;
        }
        public void InsertPersonas(Personas personas)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "INSERTPERSONAS";
                    cmd.Parameters.Add("@NOMBRES", SqlDbType.NVarChar, 150).Value = personas.Nombres;
                    cmd.Parameters.Add("@APELLIDOS", SqlDbType.NVarChar, 150).Value = personas.Apellidos;
                    cmd.Parameters.Add("@NOIDENTIFICACION", SqlDbType.NVarChar, 20).Value = personas.NoIdentificacion;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 50).Value = personas.Email == null ? "" : personas.Email;
                    cmd.Parameters.Add("@TIPOIDENTIFICACION", SqlDbType.NVarChar, 10).Value = personas.TipoIdentificacion;
                    cmd.Parameters.Add("@NOMBRESYAPELLIDOS", SqlDbType.NVarChar, 150).Value = personas.NombresyApellidos;
                    cmd.Parameters.Add("@IDENTIFICACIONYNOIDENTIFICACION", SqlDbType.NVarChar, 150).Value = personas.IdentificacionyNoIdentificacion;
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error sql" + ex.Message);
            }
        }
        public void UpdatePersonas(Personas personas)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UPDATEPERSONAS";
                    cmd.Parameters.Add("@IDENTIFICADOR", SqlDbType.Int).Value = personas.Identificador;
                    cmd.Parameters.Add("@NOMBRES", SqlDbType.NVarChar, 150).Value = personas.Nombres;
                    cmd.Parameters.Add("@APELLIDOS", SqlDbType.NVarChar, 150).Value = personas.Apellidos;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 50).Value = personas.Email;
                    cmd.Parameters.Add("@TIPOIDENTIFICACION", SqlDbType.NVarChar, 10).Value = personas.TipoIdentificacion;
                    cmd.Parameters.Add("@NOMBRESYAPELLIDOS", SqlDbType.NVarChar, 150).Value = personas.NombresyApellidos;
                    cmd.Parameters.Add("@IDENTIFICACIONYNOIDENTIFICACION", SqlDbType.NVarChar, 150).Value = personas.IdentificacionyNoIdentificacion;
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error sql" + ex.Message);
            }
        }
        public void DeletePersonas(Personas personas)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DELETEPERSONAS";
                    cmd.Parameters.Add("@IDENTIFICADOR", SqlDbType.Int).Value = personas.Identificador;
                    cmd.Parameters.Add("@NOIDENTIFICACION", SqlDbType.NVarChar, 20).Value = personas.NoIdentificacion;
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error sql" + ex.Message);
            }
        }
        private Personas MapToValue(SqlDataReader reader)
        {
            return new Personas()
            {
                Identificador = Convert.ToInt32(reader["IDENTIFICADOR"].ToString()),
                Nombres = reader["NOMBRES"].ToString(),
                Apellidos = reader["APELLIDOS"].ToString(),
                NoIdentificacion = reader["NOIDENTIFICACION"].ToString(),
                Email = reader["EMAIL"].ToString(),
                TipoIdentificacion = reader["TIPOIDENTIFICACION"].ToString(),
                FechaCreacion = Convert.ToDateTime(reader["FECHACREACION"].ToString())
            };
        }
    }
}
