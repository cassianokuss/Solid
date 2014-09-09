namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Entidades;

    public class FabricaDeProcessadorDeDocumentoImpl : FabricaDeProcessadorDeDocumento
    {
        private readonly ProcessadorDeDocumento[] _processadoresDeDocumentos;

        public FabricaDeProcessadorDeDocumentoImpl(params ProcessadorDeDocumento[] processadoresDeDocumentos)
        {
            _processadoresDeDocumentos = processadoresDeDocumentos;
        }

        public ProcessadorDeDocumento ObterProcessaDocumento(TipoDocumento tipo)
        {
            return _processadoresDeDocumentos.FirstOrDefault(e => e.AplicarQuando(tipo));
        }
    }
}
