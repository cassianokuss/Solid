namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Entidades;

    public interface FabricaDeProcessadorDeDocumento
    {
        ProcessadorDeDocumento ObterProcessaDocumento(TipoDocumento tipo);
    }
}
