namespace DI.Dominio.Servicos.Documentos.Validacoes
{
    using System;
    using Entidades;

    public class ValidadorDeXmlNfce : ValidadorDeXml
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
            return tipo == TipoDocumento.NFCe;
        }

        public void ValidarEstruturaDoXml(string documento)
        {
            if (!documento.ToLower().Contains("nfce"))
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