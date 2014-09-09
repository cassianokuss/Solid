namespace DI.Dominio.Servicos.Documentos.Fabricas
{
    using Entidades;

    public interface FabricaDeProcessadorDeDocumento
    {
        ProcessadorDeDocumento ObterProcessaDocumento(TipoDocumento tipo);
    }
}
