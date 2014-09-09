namespace DI.Dominio.Servicos
{
    using Documentos.Factorys;
    using Entidades;

    public class ProcessaImpl : Processa
    {
        private readonly IProcessadorDeDocumentoFactory _processaDocumentoFactory;

        public ProcessaImpl(IProcessadorDeDocumentoFactory processaDocumentoFactory)
        {
            _processaDocumentoFactory = processaDocumentoFactory;
        }

        public void ProcessarDocumento(DocumentoXml documento)
        {
            _processaDocumentoFactory.ObterProcessaDocumento(documento.Tipo).Processar(documento.Conteudo);
        }
    }
}