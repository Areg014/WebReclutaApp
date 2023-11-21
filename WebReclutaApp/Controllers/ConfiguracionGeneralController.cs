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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace WebReclutaApp.Controllers
{
    public class ConfiguracionGeneral : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ConfiguracionGeneral(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CatalogoDocumentos()
        {
            List<Documentos> ListaDocumentos = new List<Documentos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_DOCUMENTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Documentos clsDocumentos = new Documentos();
                        clsDocumentos.Clave = Convert.ToString(dataReader["Doc_Clave"]);
                        clsDocumentos.Nombre = Convert.ToString(dataReader["Doc_Nombre"]);
                        clsDocumentos.Especificaciones = Convert.ToString(dataReader["Doc_Especificaciones"]);
                        ListaDocumentos.Add(clsDocumentos);
                    }
                }
                connection.Close();
                return View(ListaDocumentos);
            }
        }

        [HttpPost]
        public IActionResult CatalogoDocumentos(string clave, string nombre, string especificaciones, string tipo, string estatus)
        {
            List<Documentos> ListaDocumentos = new List<Documentos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitDocumento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@especificaciones", String.IsNullOrEmpty(especificaciones) ? "" : especificaciones);
                    command.Parameters.AddWithValue("@tipo", String.IsNullOrEmpty(tipo) ? "" : tipo);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_DOCUMENTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Documentos clsDocumentos = new Documentos();
                        clsDocumentos.Clave = Convert.ToString(dataReader["Doc_Clave"]);
                        clsDocumentos.Nombre = Convert.ToString(dataReader["Doc_Nombre"]);
                        clsDocumentos.Especificaciones = Convert.ToString(dataReader["Doc_Especificaciones"]);
                        ListaDocumentos.Add(clsDocumentos);
                    }
                }
                connection.Close();
            }
            return View(ListaDocumentos);
        }

        public IActionResult InstitucionesEducativas()
        {
            List<InstitucionesEducativas> ListaInstituciones = new List<InstitucionesEducativas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_INSTITUCIONES", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        InstitucionesEducativas clsInstituciones = new InstitucionesEducativas();
                        clsInstituciones.Clave = Convert.ToString(dataReader["Ins_Clave"]);
                        clsInstituciones.Nombre = Convert.ToString(dataReader["Ins_Nombre"]);
                        ListaInstituciones.Add(clsInstituciones);
                    }
                }
                connection.Close();
                return View(ListaInstituciones);
            }
        }

        [HttpPost]
        public IActionResult InstitucionesEducativas(string clave, string nombre, string estatus)
        {
            List<InstitucionesEducativas> ListaInstituciones = new List<InstitucionesEducativas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitInstitucion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_INSTITUCIONES", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        InstitucionesEducativas clsInstituciones = new InstitucionesEducativas();
                        clsInstituciones.Clave = Convert.ToString(dataReader["Ins_Clave"]);
                        clsInstituciones.Nombre = Convert.ToString(dataReader["Ins_Nombre"]);
                        ListaInstituciones.Add(clsInstituciones);
                    }
                }
                connection.Close();
            }
            return View(ListaInstituciones);
        }
        public IActionResult PuestosReclutamiento()
        {
            List<Puestos> ListaPuestos = new List<Puestos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_PUESTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Puestos clsPuestos = new Puestos();
                        clsPuestos.Clave = Convert.ToString(dataReader["Pst_Clave"]);
                        clsPuestos.Nombre = Convert.ToString(dataReader["Pst_Nombre"]);
                        ListaPuestos.Add(clsPuestos);
                    }
                }
                connection.Close();
                return View(ListaPuestos);
            }
        }

        [HttpPost]
        public IActionResult PuestosReclutamiento(string clave, string nombre, string estatus)
        {
            List<Puestos> ListaPuestos = new List<Puestos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitPuesto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_PUESTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Puestos clsPuestos = new Puestos();
                        clsPuestos.Clave = Convert.ToString(dataReader["Pst_Clave"]);
                        clsPuestos.Nombre = Convert.ToString(dataReader["Pst_Nombre"]);
                        ListaPuestos.Add(clsPuestos);
                    }
                }
                connection.Close();
            }
            return View(ListaPuestos);
        }
        public IActionResult Departamentos()
        {
            List<Departamentos> ListaDepartamentos = new List<Departamentos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_DEPARTAMENTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Departamentos clsDepartamentos = new Departamentos();
                        clsDepartamentos.Clave = Convert.ToString(dataReader["Dep_Clave"]);
                        clsDepartamentos.Nombre = Convert.ToString(dataReader["Dep_Nombre"]);
                        ListaDepartamentos.Add(clsDepartamentos);
                    }
                }
                connection.Close();
                return View(ListaDepartamentos);
            }
        }

        [HttpPost]
        public IActionResult Departamentos(string clave, string nombre, string estatus)
        {
            List<Departamentos> ListaDepartamentos = new List<Departamentos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitDepartamento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_DEPARTAMENTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Departamentos clsDepartamentos = new Departamentos();
                        clsDepartamentos.Clave = Convert.ToString(dataReader["Dep_Clave"]);
                        clsDepartamentos.Nombre = Convert.ToString(dataReader["Dep_Nombre"]);
                        ListaDepartamentos.Add(clsDepartamentos);
                    }
                }
                connection.Close();
            }
            return View(ListaDepartamentos);
        }
        public IActionResult Empresas()
        {
            List<Empresas> ListaEmpresas = new List<Empresas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_EMPRESAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Empresas clsEmpresas = new Empresas();
                        clsEmpresas.Clave = Convert.ToString(dataReader["Emp_Clave"]);
                        clsEmpresas.Nombre = Convert.ToString(dataReader["Emp_Nombre"]);
                        clsEmpresas.Direccion = Convert.ToString(dataReader["Emp_Direccion"]);
                        clsEmpresas.CP = Convert.ToString(dataReader["Emp_CP"]);
                        clsEmpresas.Ciudad = Convert.ToString(dataReader["Emp_Ciudad"]);
                        clsEmpresas.Estado = Convert.ToString(dataReader["Emp_Estado"]);
                        clsEmpresas.RFC = Convert.ToString(dataReader["Emp_RFC"]);
                        ListaEmpresas.Add(clsEmpresas);
                    }
                }
                connection.Close();
                return View(ListaEmpresas);
            }
        }

        [HttpPost]
        public IActionResult Empresas(string clave, string nombre, string direccion, string cp, string ciudad, string estado, string rfc, string estatus)
        {
            List<Empresas> ListaEmpresas = new List<Empresas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitEmpresa", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@direccion", String.IsNullOrEmpty(direccion) ? "" : direccion);
                    command.Parameters.AddWithValue("@cp", String.IsNullOrEmpty(cp) ? "" : cp);
                    command.Parameters.AddWithValue("@ciudad", String.IsNullOrEmpty(ciudad) ? "" : ciudad);
                    command.Parameters.AddWithValue("@estado", String.IsNullOrEmpty(estado) ? "" : estado);
                    command.Parameters.AddWithValue("@rfc", String.IsNullOrEmpty(rfc) ? "" : rfc);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_EMPRESAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Empresas clsEmpresas = new Empresas();
                        clsEmpresas.Clave = Convert.ToString(dataReader["Emp_Clave"]);
                        clsEmpresas.Nombre = Convert.ToString(dataReader["Emp_Nombre"]);
                        clsEmpresas.Direccion = Convert.ToString(dataReader["Emp_Direccion"]);
                        clsEmpresas.CP = Convert.ToString(dataReader["Emp_CP"]);
                        clsEmpresas.Ciudad = Convert.ToString(dataReader["Emp_Ciudad"]);
                        clsEmpresas.Estado = Convert.ToString(dataReader["Emp_Estado"]);
                        clsEmpresas.RFC = Convert.ToString(dataReader["Emp_RFC"]);
                        ListaEmpresas.Add(clsEmpresas);
                    }
                }
                connection.Close();
            }
            return View(ListaEmpresas);
        }

        public IActionResult Oficinas()
        {
            ListadoEmpresas();
            List<Oficinas> ListaOficinas = new List<Oficinas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_OFICINAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Oficinas clsOficinas = new Oficinas();
                        clsOficinas.Clave = Convert.ToString(dataReader["Ofi_Clave"]);
                        clsOficinas.Nombre = Convert.ToString(dataReader["Ofi_Nombre"]);
                        clsOficinas.Direccion = Convert.ToString(dataReader["Ofi_Direccion"]);
                        clsOficinas.CP = Convert.ToString(dataReader["Ofi_CP"]);
                        clsOficinas.Ciudad = Convert.ToString(dataReader["Ofi_Ciudad"]);
                        clsOficinas.Estado = Convert.ToString(dataReader["Ofi_Estado"]);
                        clsOficinas.Empresa = Convert.ToString(dataReader["Ofi_Empresa"]);
                        ListaOficinas.Add(clsOficinas);
                    }
                }
                connection.Close();
                return View(ListaOficinas);
            }
        }

        [HttpPost]
        public IActionResult Oficinas(string clave, string nombre, string direccion, string cp, string ciudad, string estado, string empresa, string estatus)
        {
            List<Oficinas> ListaOficinas = new List<Oficinas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SubmitOficina", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? "" : nombre);
                    command.Parameters.AddWithValue("@direccion", String.IsNullOrEmpty(direccion) ? "" : direccion);
                    command.Parameters.AddWithValue("@cp", String.IsNullOrEmpty(cp) ? "" : cp);
                    command.Parameters.AddWithValue("@ciudad", String.IsNullOrEmpty(ciudad) ? "" : ciudad);
                    command.Parameters.AddWithValue("@estado", String.IsNullOrEmpty(estado) ? "" : estado);
                    command.Parameters.AddWithValue("@empresa", String.IsNullOrEmpty(empresa) ? "" : empresa);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_OFICINAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Oficinas clsOficinas = new Oficinas();
                        clsOficinas.Clave = Convert.ToString(dataReader["Ofi_Clave"]);
                        clsOficinas.Nombre = Convert.ToString(dataReader["Ofi_Nombre"]);
                        clsOficinas.Direccion = Convert.ToString(dataReader["Ofi_Direccion"]);
                        clsOficinas.CP = Convert.ToString(dataReader["Ofi_CP"]);
                        clsOficinas.Ciudad = Convert.ToString(dataReader["Ofi_Ciudad"]);
                        clsOficinas.Estado = Convert.ToString(dataReader["Ofi_Estado"]);
                        clsOficinas.Empresa = Convert.ToString(dataReader["Ofi_Empresa"]);
                        ListaOficinas.Add(clsOficinas);
                    }
                }
                connection.Close();
            }
            return View(ListaOficinas);
        }

        public object ListadoEmpresas()
        {
            List<Empresas> EmpresasList = new List<Empresas>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_EMPRESAS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Empresas clsEmpresas = new Empresas();
                        clsEmpresas.Clave = Convert.ToString(dataReader["Emp_Clave"]);
                        clsEmpresas.Nombre = Convert.ToString(dataReader["Emp_Nombre"]);
                        EmpresasList.Add(clsEmpresas);
                    }
                }
                ViewData["Empresas"] = new SelectList(EmpresasList.ToList(), "Clave", "Nombre");
                connection.Close();
                return ViewData["Empresas"];
            }
        }

    }
}
