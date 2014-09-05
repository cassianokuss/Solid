namespace DI.Dominio.Servicos.Documentos.Validacoes
{
    using System;
    using Entidades;

    public class ValidaXmlCte : IValidaXml
    {
        public void Validar(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                throw new Exception("Documento Inválido!");
            }

            ValidarEstruturaDoXml(documento);
            ValidarConteudoDoXml(documento);
        }

        public bool AplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }

        public void ValidarEstruturaDoXml(string documento)
        {
            if (!documento.ToLower().Contains("cte"))
            {
                throw new Exception("Documento não é XML!");
            }
        }

        public void ValidarConteudoDoXml(string documento)
        {
            if (!documento.Contains("Numero"))
            {
                throw new Exception("XML inválido!");
            }
        }
    }
}