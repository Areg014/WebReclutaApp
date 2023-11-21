using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
using System;
using Microsoft.AspNetCore.Mvc;
using WebReclutaApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace WebReclutaApp.Controllers
{
    public class InicioController : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InicioController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string usuario, string clave)
        {
            List<Logins> ListaLogins = new List<Logins>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_LOGINS WHERE Log_Usuario='" + usuario.ToLower() + "'", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Logins clsLogins = new Logins();
                        clsLogins.Usuario = Convert.ToString(dataReader["Log_Usuario"]);
                        clsLogins.Clave = Convert.ToString(dataReader["Log_Clave"]);
                        ListaLogins.Add(clsLogins);
                    }
                }
                connection.Close();
                for(int i=0; i<ListaLogins.Count; i++)
                {
                    if (ListaLogins.ElementAt(i).Clave.Equals(clave)){
                        return View("Index");
                    }
                }
            }
            return View("Error");
        }
    }
}
