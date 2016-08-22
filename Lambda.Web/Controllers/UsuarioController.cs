using System;
using System.Linq;
using System.Web.Mvc;
using Lambda.Core.Business.Abstract;
using Lambda.Core.DTO;
using Lambda.Core.Entities;
using Lambda.Core.Entities.Enum;
using Lambda.Web.Infraestrutura.Extension;
using Lambda.Web.Infraestrutura.Filtros;
using Ninject;

namespace Lambda.Web.Controllers
{
    [Autorizacao(Grupo.Admin)]
    public class UsuarioController : Controller
    {
        [Inject]
        public IUsuarioBusiness UsuarioBusiness { get; set; }
        public ActionResult Index()
        {
            var usuarioList = UsuarioBusiness.Consulta.ToList();
            return View(usuarioList);
        }

        public ActionResult Inserir()
        {
            ViewBag.Grupo = Grupo.Usuario.ToSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Usuario usuario)
        {
            ViewBag.Grupo = Grupo.Admin.ToSelectList();
            var result = new ResultadoSimplesDTO();
            result.Sucesso = false;
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioBusiness.Inserir(usuario);
                    TempData["mensagem"] = "Usuário inserido com sucesso";
                    result.Sucesso = true;
                    result.MsgResposta = "#Usuario";
                    return Json(result);
                }
                catch (Exception ex)
                {
                    result.MsgResposta = ex.Message;
                    return Json(result);
                }
            }
            return View(usuario);
        }

        public ActionResult Editar(string id)
        {
            ViewBag.Grupo = Grupo.Admin.ToSelectList();
            var empresa = UsuarioBusiness.RetornarPorID(id);
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            ViewBag.Grupo = Grupo.Admin.ToSelectList();
            var result = new ResultadoSimplesDTO();
            result.Sucesso = false;
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioBusiness.Alterar(usuario);
                    TempData["mensagem"] = "Usuário alterado com sucesso";
                    result.Sucesso = true;
                    result.MsgResposta = "#Usuario";
                    return Json(result);
                }
                catch (Exception ex)
                {
                    result.MsgResposta = ex.Message;
                    return Json(result);
                }
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Excluir(string id)
        {
            try
            {
                UsuarioBusiness.Excluir(id);
                TempData["Mensagem"] = "Usuário excluído com sucesso";
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = "Erro ao excluir usuário. Detalhes:" + ex.Message;
            }
            return Json("");
        }
    }
}