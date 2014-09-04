namespace DI.Dominio.Servicos.Documento
{
    using System;
    using Entidades;

    public class ValidaXmlNfce : IValidaXml
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
            return tipo == TipoDocumento.NFCe;
        }

        private void ValidarEstruturaDoXml()
        {
            if (!_documento.ToLower().Contains("nfce"))
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