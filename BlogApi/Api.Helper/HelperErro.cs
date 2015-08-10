using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Helper
{
    public static class HelperErro
    {
        public static string GeraMensagemErro(Exception ex)
        {
            if (ex != null)
            {
                string mensagem = string.Empty;

                if (ex is System.Data.Entity.Validation.DbEntityValidationException)
                    mensagem = Exibe_Validacao((System.Data.Entity.Validation.DbEntityValidationException)ex);
                else if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    mensagem = ex.InnerException.InnerException.Message;
                else
                    mensagem = ex.Message;

                return mensagem;
            }
            else
                return "Sem informações de Erro!";

        }

        private static string Exibe_Validacao(System.Data.Entity.Validation.DbEntityValidationException exception)
        {
            string msg = string.Empty;

            foreach (System.Data.Entity.Validation.DbEntityValidationResult falha in exception.EntityValidationErrors)
            {
                foreach (System.Data.Entity.Validation.DbValidationError erro in falha.ValidationErrors)
                {
                    msg += Environment.NewLine + erro.ErrorMessage;
                }
            }

            return msg;
        }

    }
}
