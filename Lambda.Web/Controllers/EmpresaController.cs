using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lambda.Core.Business.Abstract;
using Lambda.Core.DTO;
using Lambda.Core.Entities;

namespace Lambda.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public IBusiness<Empresa> EmpresaBusiness { get; set; } 
        public ActionResult Index()
        {
            var listaEmpresas = EmpresaBusiness.Consulta.ToList();
            return View(listaEmpresas);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Empresa empresa)
        {
            var resultado = new ResultadoSimplesDTO();
            resultado.Sucesso = false;
            if (ModelState.IsValid)
            {
                try
                {
                    resultado.Sucesso = true;
                    resultado.MsgResposta = "#Empresa";
                    return Json(resultado);
                }
                catch (Exception ex)
                {
                    resultado.MsgResposta = ex.Message;
                    return Json(resultado);
                }
            }

            return View(empresa);
        }
    }
}