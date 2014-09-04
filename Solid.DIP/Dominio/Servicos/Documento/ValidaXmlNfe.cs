using System;

namespace Solid.DIP.Dominio.Servicos.Documento
{
    public class ValidaXmlNfe
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