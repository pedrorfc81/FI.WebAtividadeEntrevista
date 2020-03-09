using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DAL.Clientes
{
    /// <summary>
    /// Classe de acesso a dados de Beneficiário
    /// </summary>
    internal class DaoBeneficiario : AcessoDados
    {
        /// <summary>
        /// Inclui novos beneficiários
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <param name="beneficiarios">Lista do objeto beneficiário</param>
        /// <returns></returns>
        internal void Incluir(long idCliente, List<DML.Beneficiario> beneficiarios)
        {
            foreach (DML.Beneficiario beneficiario in beneficiarios)
            {
                List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

                parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF));
                parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome));
                parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", idCliente));

                base.Executar("FI_SP_IncBenef", parametros);
            }
        }

        /// <summary>
        /// Verifica se já existe CPF cadastrado em beneficiário para o cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="id"></param>
        /// <param name="CPF"></param>
        /// <returns></returns>
        internal bool VerificarExistencia(long idCliente, long id, string CPF)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", CPF.Replace(".", "").Replace("-", "")));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", id));
            parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", idCliente));

            DataSet ds = base.Consultar("FI_SP_VerificaBenef", parametros);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica se já existe CPF cadastrado em beneficiário para o cliente
        /// </summary>
        /// <param name="idCliente">Id do Cliente</param>
        /// <param name="beneficiarios">Lista de objeto beneficiário</param>
        /// <returns></returns>
        internal bool VerificarExistencia(long idCliente, List<DML.Beneficiario> beneficiarios)
        {
            foreach (DML.Beneficiario beneficiario in beneficiarios)
            {
                List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

                parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF.Replace(".", "").Replace("-", "")));
                parametros.Add(new System.Data.SqlClient.SqlParameter("Id", beneficiario.Id));
                parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", idCliente));

                DataSet ds = base.Consultar("FI_SP_VerificaBenef", parametros);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Listar beneficiários cadastrados para o cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <returns></returns>
        internal List<DML.Beneficiario> Listar(long idCliente)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", idCliente));

            DataSet ds = base.Consultar("FI_SP_ConsBenef", parametros);
            List<DML.Beneficiario> beneficiarios = Converter(ds);

            return beneficiarios;
        }

        /// <summary>
        /// Altera beneficiários
        /// </summary>
        /// <param name="beneficiarios">Lista de obejo beneficiário</param>
        internal void Alterar(List<DML.Beneficiario> beneficiarios)
        {
            foreach (Beneficiario beneficiario in beneficiarios)
            {
                List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

                parametros.Add(new System.Data.SqlClient.SqlParameter("ID", beneficiario.Id));
                parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF));
                parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome));

                base.Executar("FI_SP_AltBenef", parametros);
            }
        }

        /// <summary>
        /// Exclui lista de beneficiário
        /// </summary>
        /// <param name="ids">Ids dos beneficiários a serem excluídos</param>
        internal void Excluir(List<long> ids)
        {
            foreach (long id in ids)
            {
                List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

                parametros.Add(new System.Data.SqlClient.SqlParameter("Id", id));

                base.Executar("FI_SP_DelBenef", parametros);
            }
        }

        /// <summary>
        /// Excluir todos beneficiários de um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        internal void ExcluirLote(long idCliente)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();
            parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", idCliente));

            base.Executar("FI_SP_DelBenef", parametros);
        }

        /// <summary>
        /// Convesão do objeto beneficiário da base para classe
        /// </summary>
        /// <param name="ds">Data set do beneficiário</param>
        /// <returns></returns>
        private List<Beneficiario> Converter(DataSet ds)
        {
            List<DML.Beneficiario> lista = new List<DML.Beneficiario>();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DML.Beneficiario beneficiario = new DML.Beneficiario();
                    beneficiario.Id = row.Field<long>("Id");
                    beneficiario.CPF = row.Field<string>("CPF");
                    beneficiario.Nome = row.Field<string>("Nome");
                    beneficiario.IdCliente = row.Field<long>("IdCliente");
                    lista.Add(beneficiario);
                }
            }

            return lista;
        }
    }
}
