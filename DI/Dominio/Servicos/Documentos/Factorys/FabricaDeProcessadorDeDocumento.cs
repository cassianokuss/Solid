namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Entidades;

    public interface IProcessadorDeDocumentoFactory
    {
        ProcessadorDeDocumento ObterProcessaDocumento(TipoDocumento tipo);
    }
}
