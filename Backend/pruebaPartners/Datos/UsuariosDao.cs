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
    public class UsuariosDao
    {
        private readonly IConfiguration _configuration;

        public UsuariosDao(IConfiguration configuration) {
            _configuration = configuration;
        }

        public List<Usuarios> GetUsuarios()
        {
            var response = new List<Usuarios>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SELECTUSUARIOS";
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
        public List<Usuarios> GetUsuariosById(string usuario)
        {
            var response = new List<Usuarios>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlParameter[] parametri = new SqlParameter[1];
                    parametri[0] = new SqlParameter("@USUARIO", SqlDbType.VarChar);
                    parametri[0].Value = usuario;


                    cmd.CommandText = "SELECTUSUARIOSBYID";
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
        public void InsertUsuarios(Usuarios usuarios)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "INSERTUSUARIOS";
                    cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 150).Value = usuarios.Usuario;
                    cmd.Parameters.Add("@PASSWORD", SqlDbType.NVarChar, 150).Value = usuarios.Password;
                   // cmd.Parameters.Add("@FECHACREACION", SqlDbType.DateTime, 20).Value = usuarios.FechaCreacion;
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
        public void UpdateUsuarios(Usuarios usuarios)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UPDATEUSUARIOS";
                    cmd.Parameters.Add("@IDENTIFICADOR", SqlDbType.Int).Value = usuarios.Identificador;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 150).Value = usuarios.Usuario;
                    cmd.Parameters.Add("@PASSWORD", SqlDbType.NVarChar, 150).Value = usuarios.Password;
                   // cmd.Parameters.Add("@FECHACREACION", SqlDbType.DateTime, 20).Value = usuarios.FechaCreacion;
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
        public void DeleteUsuarios(Usuarios usuarios)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DELETEUSUARIOS";
                    cmd.Parameters.Add("@IDENTIFICADOR", SqlDbType.Int).Value = usuarios.Identificador;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 150).Value = usuarios.Usuario;                    
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
        private Usuarios MapToValue(SqlDataReader reader)
        {
            return new Usuarios()
            {
                Identificador = Convert.ToInt32(reader["IDENTIFICADOR"].ToString()),
                Usuario = reader["USUARIO"].ToString(),
                Password = reader["PASSWORD"].ToString(),
                FechaCreacion = Convert.ToDateTime(reader["FECHACREACION"].ToString())
            };
        }
    }
}
