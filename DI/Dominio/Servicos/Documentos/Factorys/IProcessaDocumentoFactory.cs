namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Entidades;

    public interface IProcessaDocumentoFactory
    {
        IProcessaDocumento ObterProcessaDocumento(TipoDocumento tipo);
    }
}
