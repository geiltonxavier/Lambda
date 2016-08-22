using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lambda.Core.Business.Abstract;
using Lambda.Core.DTO;
using Lambda.Core.Entities;
using Lambda.Web.Infraestrutura.Filtros;
using Ninject;

namespace Lambda.Web.Controllers
{

    [Autorizacao]
    public class EmpresaController : Controller
    {
        [Inject]
        public IBusiness<Empresa> EmpresaBusiness { get; set; }


        public ActionResult Index()
        {
            var empresaList = EmpresaBusiness.Consulta.ToList();
            return View(empresaList);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Empresa empresa)
        {
            var result = new ResultadoSimplesDTO();
            result.Sucesso = false;
            if (ModelState.IsValid)
            {
                try
                {
                    EmpresaBusiness.Inserir(empresa);
                    TempData["Mensagem"] = "Empresa inserida com sucesso";
                    result.Sucesso = true;
                    result.MsgResposta = "#Empresa";
                    return Json(result);
                }
                catch (Exception ex)
                {
                    result.MsgResposta = ex.Message;
                    return Json(result);
                }
            }
            return View(empresa);



        }

        public ActionResult Editar(string id)
        {
            var empresa = EmpresaBusiness.RetornarPorID(id);
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {
            var result = new ResultadoSimplesDTO();
            result.Sucesso = false;
            if (ModelState.IsValid)
            {
                try
                {
                    EmpresaBusiness.Alterar(empresa);
                    TempData["Mensagem"] = "Empresa alterada com sucesso";
                    result.Sucesso = true;
                    result.MsgResposta = "#Empresa";
                    return Json(result);
                }
                catch (Exception ex)
                {
                    result.MsgResposta = ex.Message;
                    return Json(result);
                }
            }
            return View(empresa);



        }

        [HttpPost]
        public ActionResult Excluir(string id)
        {
            try
            {
                EmpresaBusiness.Excluir(id);
                TempData["Mensagem"] = "Empresa excluída com sucesso";
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao excluir empresa. Detalhes: " + ex.Message;
            }
            return Json("");
        }

      
    }
}