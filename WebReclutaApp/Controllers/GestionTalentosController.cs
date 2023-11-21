using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebReclutaApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf.Xfa;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Security.Permissions;
using System.Diagnostics.Eventing.Reader;

namespace WebReclutaApp.Controllers
{
    public class GestionTalentos : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GestionTalentos(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RequisicionesTalento()
        {
            ListadoPuestos();
            ListadoEmpresas();
            ListadoDepartamentos();
            ListadoTipos();
            ListadoModalidades();
            List<RequisicionesTalento> ListaRequisicionesTalento = new List<RequisicionesTalento>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_REQ_TALENTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        RequisicionesTalento clsRequisicionesTalento = new RequisicionesTalento();
                        clsRequisicionesTalento.Folio = Convert.ToString(dataReader["ReT_Folio"]);
                        clsRequisicionesTalento.Puesto = Convert.ToString(dataReader["ReT_Puesto"]);
                        clsRequisicionesTalento.Empresa = Convert.ToString(dataReader["ReT_Empresa"]);
                        clsRequisicionesTalento.Departamento = Convert.ToString(dataReader["ReT_Departamento"]);
                        clsRequisicionesTalento.Oficina = Convert.ToString(dataReader["ReT_Oficina"]);
                        clsRequisicionesTalento.Tipo = Convert.ToString(dataReader["ReT_Tipo"]);
                        clsRequisicionesTalento.Modalidad = Convert.ToString(dataReader["ReT_Modalidad"]);
                        clsRequisicionesTalento.Descripcion = Convert.ToString(dataReader["ReT_Descripcion"]);
                        ListaRequisicionesTalento.Add(clsRequisicionesTalento);
                    }
                }
                connection.Close();
                return View(ListaRequisicionesTalento);
            }
        }

        [HttpPost]
        public IActionResult RequisicionesTalento(string clave, string puesto, string empresa, string departamento, string oficina, string tipo, string modalidad, string descripcion, string estatus, IFormFile[] archivos)
        {
            List<RequisicionesTalento> ListaRequisicionesTalento = new List<RequisicionesTalento>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (String.IsNullOrEmpty(clave))
                {                                 
                    using (SqlCommand command = new SqlCommand("SELECT 'RET'+RIGHT('00000'+CONVERT(VARCHAR,Fol_Requerimientos+1),5) XFOLIO FROM dbo.WREC_FOLIOS", connection))
                    {
                        clave = (string)command.ExecuteScalar();

                    }
                    using (SqlCommand command = new SqlCommand("UPDATE [WREC_FOLIOS] SET Fol_Requerimientos=Fol_Requerimientos+1", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                using (SqlCommand command = new SqlCommand("SubmitReq_Talento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@clave", String.IsNullOrEmpty(clave) ? "" : clave);
                    command.Parameters.AddWithValue("@puesto", String.IsNullOrEmpty(puesto) ? "" : puesto);
                    command.Parameters.AddWithValue("@empresa", String.IsNullOrEmpty(empresa) ? "" : empresa);
                    command.Parameters.AddWithValue("@departamento", String.IsNullOrEmpty(departamento) ? "" : departamento);
                    command.Parameters.AddWithValue("@oficina", String.IsNullOrEmpty(oficina) ? "" : oficina);
                    command.Parameters.AddWithValue("@tipo", String.IsNullOrEmpty(tipo) ? "" : tipo);
                    command.Parameters.AddWithValue("@modalidad", String.IsNullOrEmpty(modalidad) ? 0 : modalidad);
                    command.Parameters.AddWithValue("@descripcion", String.IsNullOrEmpty(descripcion) ? "" : descripcion);
                    command.Parameters.AddWithValue("@estatus", String.IsNullOrEmpty(estatus) ? 1 : estatus);
                    command.ExecuteNonQuery();
                }
                for (int i = 0; i < archivos.Length; i++)
                {
                    Archivos archivo = new Archivos();
                    archivo.Fecha_Entrada = DateTime.Now;
                    archivo.Nombre_Archivo = Path.GetFileNameWithoutExtension(archivos[i].FileName);
                    archivo.Extension = Path.GetExtension(archivos[i].FileName);
                    archivo.Formato = MimeMapping.MimeUtility.GetMimeMapping(archivos[i].FileName);
                    double tamanio = archivos[i].Length;
                    tamanio = tamanio / 1000000.0;
                    archivo.Tamanio = Math.Round(tamanio, 2);
                    Stream fs = archivos[i].OpenReadStream();
                    BinaryReader br = new BinaryReader(fs);
                    archivo.Archivo = br.ReadBytes((Int32)fs.Length);
                    string sql = "insert into WREC_ARCHIVOS(Nombre_Archivo, Extension, Formato, Fecha_Entrada, Archivo, Tamanio, Folio_relacion) values " +
                            "(@nombreArchivo, @extension, @formato, @fechaEntrada, @archivo, @tamanio, @foliorelacion)";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@nombreArchivo", SqlDbType.VarChar, 100).Value = archivo.Nombre_Archivo;
                        cmd.Parameters.Add("@extension", SqlDbType.VarChar, 5).Value = archivo.Extension;
                        cmd.Parameters.Add("@formato", SqlDbType.VarChar, 200).Value = archivo.Formato;
                        cmd.Parameters.Add("@fechaEntrada", SqlDbType.DateTime).Value = archivo.Fecha_Entrada;
                        cmd.Parameters.Add("@archivo", SqlDbType.Image).Value = archivo.Archivo;
                        cmd.Parameters.Add("@tamanio", SqlDbType.Float).Value = archivo.Tamanio;
                        cmd.Parameters.Add("@foliorelacion", SqlDbType.Float).Value = clave;
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_REQ_TALENTOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        RequisicionesTalento clsRequisicionesTalento = new RequisicionesTalento();
                        clsRequisicionesTalento.Folio = Convert.ToString(dataReader["ReT_Folio"]);
                        clsRequisicionesTalento.Puesto = Convert.ToString(dataReader["ReT_Puesto"]);
                        clsRequisicionesTalento.Empresa = Convert.ToString(dataReader["ReT_Empresa"]);
                        clsRequisicionesTalento.Departamento = Convert.ToString(dataReader["ReT_Departamento"]);
                        clsRequisicionesTalento.Oficina = Convert.ToString(dataReader["ReT_Oficina"]);
                        clsRequisicionesTalento.Tipo = Convert.ToString(dataReader["ReT_Tipo"]);
                        clsRequisicionesTalento.Modalidad = Convert.ToString(dataReader["ReT_Modalidad"]);
                        clsRequisicionesTalento.Descripcion = Convert.ToString(dataReader["ReT_Descripcion"]);
                        ListaRequisicionesTalento.Add(clsRequisicionesTalento);
                    }
                }
                connection.Close();
            }
            return View(ListaRequisicionesTalento);
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
        public object ListadoPuestos()
        {
            List<Puestos> PuestosList = new List<Puestos>();
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
                        PuestosList.Add(clsPuestos);
                    }
                }
                ViewData["Puestos"] = new SelectList(PuestosList.ToList(), "Clave", "Nombre");
                connection.Close();
                return ViewData["Puestos"];
            }
        }
        public object ListadoTipos()
        {
            List<Tipos> TiposList = new List<Tipos>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_TIPOS", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Tipos clsTipos = new Tipos();
                        clsTipos.Clave = Convert.ToString(dataReader["Tps_Clave"]);
                        clsTipos.Nombre = Convert.ToString(dataReader["Tps_Nombre"]);
                        TiposList.Add(clsTipos);
                    }
                }
                ViewData["Tipos"] = new SelectList(TiposList.ToList(), "Clave", "Nombre");
                connection.Close();
                return ViewData["Tipos"];
            }
        }
        public object ListadoDepartamentos()
        {
            List<Departamentos> DepartamentosList = new List<Departamentos>();
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
                        DepartamentosList.Add(clsDepartamentos);
                    }
                }
                ViewData["Departamentos"] = new SelectList(DepartamentosList.ToList(), "Clave", "Nombre");
                connection.Close();
                return ViewData["Departamentos"];
            }
        }
        public object ListadoModalidades()
        {
            List<Modalidades> ModalidadesList = new List<Modalidades>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.WREC_MODALIDADES", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Modalidades clsModalidades = new Modalidades();
                        clsModalidades.Clave = Convert.ToString(dataReader["Mod_Clave"]);
                        clsModalidades.Nombre = Convert.ToString(dataReader["Mod_Nombre"]);
                        ModalidadesList.Add(clsModalidades);
                    }
                }
                ViewData["Modalidades"] = new SelectList(ModalidadesList.ToList(), "Clave", "Nombre");
                connection.Close();
                return ViewData["Modalidades"];
            }
        }
        public JsonResult ListadoOficinas(string cid)
        {
            List<SelectListItem> OficinasList = new List<SelectListItem>();
            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM WREC_OFICINAS WHERE Ofi_Empresa = '" + cid + "'", connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        OficinasList.Add(new SelectListItem { Text = dataReader["Ofi_Nombre"].ToString(), Value = dataReader["Ofi_Clave"].ToString() });
                    }
                }
                connection.Close();
                return Json(OficinasList);
            }
        }

        //[HttpPost]
        //public JsonResult InsertarArchivos(IFormFile[] archivos)
        //{
        //    Respuesta_Json respuesta = new Respuesta_Json();
        //    try
        //    {
        //       for (int i = 0; i < archivos.Length; i++)
        //       {
        //            Archivos archivo = new Archivos();

        //            archivo.Fecha_Entrada = DateTime.Now;
        //            archivo.Nombre_Archivo = Path.GetFileNameWithoutExtension(archivos[i].FileName);
        //            archivo.Extension = Path.GetExtension(archivos[i].FileName);
        //            archivo.Formato = MimeMapping.MimeUtility.GetMimeMapping(archivos[i].FileName);

        //            double tamanio = archivos[i].Length;
        //            tamanio = tamanio / 1000000.0;
        //            archivo.Tamanio = Math.Round(tamanio, 2);

        //            Stream fs = archivos[i].OpenReadStream();
        //            BinaryReader br = new BinaryReader(fs);
        //            archivo.Archivo = br.ReadBytes((Int32)fs.Length);
        //            string connectionString = Configuration["ConnectionStrings:ConexionWebRecluta"];
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                string sql = "insert into WREC_ARCHIVOS(Nombre_Archivo, Extension, Formato, Fecha_Entrada, Archivo, Tamanio, Folio_relacion) values " +
        //                    "(@nombreArchivo, @extension, @formato, @fechaEntrada, @archivo, @tamanio, @foliorelacion)";
        //                using (SqlCommand cmd = new SqlCommand(sql, connection))
        //                {
        //                    cmd.Parameters.Add("@nombreArchivo", SqlDbType.VarChar, 100).Value = archivo.Nombre_Archivo;
        //                    cmd.Parameters.Add("@extension", SqlDbType.VarChar, 5).Value = archivo.Extension;
        //                    cmd.Parameters.Add("@formato", SqlDbType.VarChar, 200).Value = archivo.Formato;
        //                    cmd.Parameters.Add("@fechaEntrada", SqlDbType.DateTime).Value = archivo.Fecha_Entrada;
        //                    cmd.Parameters.Add("@archivo", SqlDbType.Image).Value = archivo.Archivo;
        //                    cmd.Parameters.Add("@tamanio", SqlDbType.Float).Value = archivo.Tamanio;
        //                    cmd.Parameters.Add("@foliorelacion", SqlDbType.Float).Value = clave;
        //                    cmd.ExecuteNonQuery();
        //                }
        //                connection.Close();
        //            }
        //        }
        //        respuesta.Codigo = 1;
        //        respuesta.Mensaje_Respuesta = "Se insertaron correctamente los archivos en la base de datos";
        //    }
        //    catch (Exception ex)
        //    {
        //        respuesta.Codigo = 0;
        //        respuesta.Mensaje_Respuesta = ex.ToString();
        //    }
        //    return Json(respuesta);
        //}
    }
}
