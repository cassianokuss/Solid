namespace DI.Dominio.Servicos
{
    using Documento.Factory;

    using Entidades;

    public class Processa : IProcessa
    {
        private readonly IProcessaDocumentoFactory _processaDocumentoFactory;

        public Processa(IProcessaDocumentoFactory processaDocumentoFactory)
        {
            _processaDocumentoFactory = processaDocumentoFactory;
        }

        public void ProcessarDocumento(DocumentoXml documento)
        {
            _processaDocumentoFactory.ObterProcessaDocumento(documento.Tipo).Processar(documento.Conteudo);
        }
    }
}