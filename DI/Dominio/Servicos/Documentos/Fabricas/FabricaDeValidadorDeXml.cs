namespace DI.Dominio.Servicos.Documentos.Fabricas
{
    using Validacoes;
    using Entidades;

    public interface FabricaDeValidadorDeXml
    {
        ValidadorDeXml ObterValidador(TipoDocumento tipo);
    }
}
