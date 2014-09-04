using DI.Dominio.Entidades;

namespace DI.Dominio.Servicos.Documento
{
    using System;

    public class ValidaXmlNfe : IValidaXml
    {
        private string _documento;

        public void Validar(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                throw new Exception("Documento Inválido!");
            }

            _documento = documento;

            ValidarEstruturaDoXml();
            ValidarConteudoDoXml();
        }

        public bool ValidarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe;
        }

        private void ValidarEstruturaDoXml()
        {
            if (!_documento.ToLower().Contains("nfe"))
            {
                throw new Exception("Documento não é XML!");
            }
        }

        private void ValidarConteudoDoXml()
        {
            if (!_documento.Contains("Numero"))
            {
                throw new Exception("XML inválido!");
            }
        }
    }
}