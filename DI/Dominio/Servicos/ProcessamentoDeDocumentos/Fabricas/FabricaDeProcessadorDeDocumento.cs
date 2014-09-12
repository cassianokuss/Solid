namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Fabricas
{
    using Entidades;

    public interface FabricaDeProcessadorDeDocumento
    {
        ProcessadorDeDocumento ObterProcessaDocumento(TipoDocumento tipo);
    }
}
