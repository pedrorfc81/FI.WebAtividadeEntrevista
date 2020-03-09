using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        // GET: Beneficiario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(long idCliente, List<Beneficiario> beneficiarios)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                foreach (Beneficiario beneficiario in beneficiarios)
                {
                    if (!new BoCliente().ValidaCPF(beneficiario.CPF))
                    {
                        return Json("CPF inválido");
                    }
                    if (bo.VerificarExistencia(beneficiario.IdCliente, beneficiario.Id, beneficiario.CPF))
                    {
                        return Json("CPF já cadastrado");
                    }
                }

                bo.Incluir(idCliente, beneficiarios);

                return Json("Cadastro de beneficiários efetuado com sucesso");
            }
        }

        [HttpPost]
        public JsonResult Alterar(List<Beneficiario> beneficiarios)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                foreach (Beneficiario beneficiario in beneficiarios)
                {
                    if (!new BoCliente().ValidaCPF(beneficiario.CPF))
                    {
                        return Json("CPF inválido");
                    }
                    if (bo.VerificarExistencia(beneficiario.IdCliente, beneficiario.Id, beneficiario.CPF))
                    {
                        return Json("CPF já cadastrado para outro beneficiário");
                    }
                }

                bo.Alterar(beneficiarios);

                return Json("Cadastro de beneficiários alterado com sucesso");
            }
        }

        [HttpPost]
        public JsonResult BeneficiarioList(long idCliente)
        {
            try
            {
                List<Beneficiario> beneficiarios = new BoBeneficiario().Listar(idCliente);

                //Return result to jTable
                return Json(new { Result = "OK", Records = beneficiarios });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}