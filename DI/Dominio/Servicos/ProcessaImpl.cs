namespace DI.Dominio.Servicos
{
    using Documentos.Factorys;
    using Entidades;

    public class ProcessaImpl : Processa
    {
        private readonly FabricaDeProcessadorDeDocumento _processaDocumento;

        public ProcessaImpl(FabricaDeProcessadorDeDocumento processaDocumento)
        {
            _processaDocumento = processaDocumento;
        }

        public void ProcessarDocumento(DocumentoXml documento)
        {
            _processaDocumento.ObterProcessaDocumento(documento.Tipo).Processar(documento.Conteudo);
        }
    }
}