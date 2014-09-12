namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Fabricas
{
    using Entidades;
    using Validadores;

    public interface FabricaDeValidadorDeXml
    {
        ValidadorDeXml ObterValidador(TipoDocumento tipo);
    }
}
