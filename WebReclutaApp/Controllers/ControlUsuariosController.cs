using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System;
using Microsoft.AspNetCore.Mvc;
using WebReclutaApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf.Xfa;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebReclutaApp.Controllers
{
    public class ControlUsuarios : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ControlUsuarios(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PantallasProgramas()
        {
            List<PantallasProgramas> ListaPantallasProgramas = new List<PantallasProgramas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_PANTALLAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (Convert.ToString(dataReader["Pan_Estatus"]).Equals("1"))
                        {
                            PantallasProgramas clsPantallasProgramas = new PantallasProgramas();
                            clsPantallasProgramas.Clave = Convert.ToString(dataReader["Pan_Clave"]);
                            clsPantallasProgramas.Descripcion = Convert.ToString(dataReader["Pan_Descripcion"]);
                            clsPantallasProgramas.Comentario = Convert.ToString(dataReader["Pan_Comentario"]);
                            ListaPantallasProgramas.Add(clsPantallasProgramas);
                        }
                    }
                }
                connection.Close();
                return View(ListaPantallasProgramas);
            }
        }

        [HttpPost]
        public IActionResult PantallasProgramas(string clave, string descripcion, string comentario, string estatus) {
            List<PantallasProgramas> ListaPantallasProgramas = new List<PantallasProgramas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitPantalla", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@descripcion", String.IsNullOrEmpty(descripcion) ? "" : descripcion);
                    command.Parameters.AddWithValue("@comentario", String.IsNullOrEmpty(comentario) ? "" : comentario);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_PANTALLAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        PantallasProgramas clsPantallasProgramas = new PantallasProgramas();
                        clsPantallasProgramas.Clave = Convert.ToString(dataReader["Pan_Clave"]);
                        clsPantallasProgramas.Descripcion = Convert.ToString(dataReader["Pan_Descripcion"]);
                        clsPantallasProgramas.Comentario = Convert.ToString(dataReader["Pan_Comentario"]);
                        ListaPantallasProgramas.Add(clsPantallasProgramas);
                    }
                }
                connection.Close();
            }
            return View(ListaPantallasProgramas);
        }
        public IActionResult Usuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_ACCESOS WHERE ACC_Nivel = 2", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                            Usuarios clsUsuarios = new Usuarios();
                            clsUsuarios.Clave = Convert.ToString(dataReader["ACC_Usuario"]);
                            clsUsuarios.Nombre = Convert.ToString(dataReader["ACC_Nombre"]);
                            clsUsuarios.Correo = Convert.ToString(dataReader["ACC_Correo"]);
                            ListaUsuarios.Add(clsUsuarios);
                    }
                }
                connection.Close();
                return View(ListaUsuarios);
            }
        }

        [HttpPost]
        public IActionResult Usuarios(string clave, string nombre, string correo, string contrasena, string estatus)
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@correo", String.IsNullOrEmpty(correo) ? "" : correo);
                    command.Parameters.AddWithValue("@contrasena", String.IsNullOrEmpty(contrasena) ? "" : contrasena);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_ACCESOS WHERE ACC_Nivel = 2", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuarios clsUsuario = new Usuarios();
                        clsUsuario.Clave = Convert.ToString(dataReader["ACC_Usuario"]);
                        clsUsuario.Nombre = Convert.ToString(dataReader["ACC_Nombre"]);
                        clsUsuario.Correo = Convert.ToString(dataReader["ACC_Correo"]);
                        ListaUsuarios.Add(clsUsuario);
                    }
                }
                connection.Close();
            }
            return View(ListaUsuarios);
        }
    }
}
