using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Incluir novos beneficiários para um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <param name="beneficiarios">Lista de objeto beneficiário</param>
        public void Incluir(long idCliente, List<DML.Beneficiario> beneficiarios)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            beneficiario.Incluir(idCliente, beneficiarios);
        }

        /// <summary>
        /// Altera uma lista de beneficiário
        /// </summary>
        /// <param name="beneficiarios">Lista de objeto beneficiário</param>
        public void Alterar(List<DML.Beneficiario> beneficiarios)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            beneficiario.Alterar(beneficiarios);
        }

        /// <summary>
        /// Exclui uma lista de beneficiário
        /// </summary>
        /// <param name="ids">Lista de id de beneficiário</param>
        public void Excluir(List<long> ids)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            beneficiario.Excluir(ids);
        }

        /// <summary>
        /// Exclui todos beneficiários de um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        public void ExcluirLote(long idCliente)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            beneficiario.ExcluirLote(idCliente);
        }

        /// <summary>
        /// Lista os beneficiários de um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <returns></returns>
        public List<DML.Beneficiario> Listar(long idCliente)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            return beneficiario.Listar(idCliente);
        }

        /// <summary>
        /// Verifica existencia de CPF
        /// </summary>
        /// <param name="idCliente">id do cliente</param>
        /// <param name="beneficiarios">Lista de ojeto beneficiário</param>
        /// <returns></returns>
        public bool VerificarExistencia(long idCliente, List<DML.Beneficiario> beneficiarios)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            return beneficiario.VerificarExistencia(idCliente, beneficiarios);
        }

        /// <summary>
        /// Verifica existencia de CPF
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <param name="id">Id do beneficiário</param>
        /// <param name="CPF">CPF</param>
        /// <returns></returns>
        public bool VerificarExistencia(long idCliente, long id, string CPF)
        {
            DAL.Clientes.DaoBeneficiario beneficiario = new DAL.Clientes.DaoBeneficiario();
            return beneficiario.VerificarExistencia(idCliente, id, CPF);
        }
    }
}
