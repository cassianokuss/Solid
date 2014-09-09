namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Entidades;

    public class FabricaDeProcessadorDeDocumentoImpl : IProcessadorDeDocumentoFactory
    {
        private readonly ProcessadorDeDocumento[] _processaDocumentos;

        public FabricaDeProcessadorDeDocumentoImpl(params ProcessadorDeDocumento[] processaDocumentos)
        {
            _processaDocumentos = processaDocumentos;
        }

        public ProcessadorDeDocumento ObterProcessaDocumento(TipoDocumento tipo)
        {
            return _processaDocumentos.FirstOrDefault(e => e.AplicavelQuando(tipo));
        }
    }
}
