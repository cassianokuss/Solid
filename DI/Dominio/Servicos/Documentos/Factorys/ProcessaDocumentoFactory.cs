namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Entidades;

    public class ProcessaDocumentoFactory : IProcessaDocumentoFactory
    {
        private readonly IProcessaDocumento[] _processaDocumentos;

        public ProcessaDocumentoFactory(params IProcessaDocumento[] processaDocumentos)
        {
            _processaDocumentos = processaDocumentos;
        }

        public IProcessaDocumento ObterProcessaDocumento(TipoDocumento tipo)
        {
            return _processaDocumentos.FirstOrDefault(e => e.AplicavelQuando(tipo));
        }
    }
}
