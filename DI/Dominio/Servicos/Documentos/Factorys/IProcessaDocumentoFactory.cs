namespace DI.Dominio.Servicos.Documento.Factory
{
    using Entidades;

    public interface IProcessaDocumentoFactory
    {
        IProcessaDocumento ObterProcessaDocumento(TipoDocumento tipo);
    }
}
