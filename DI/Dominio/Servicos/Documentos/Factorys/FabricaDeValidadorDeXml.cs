namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Validacoes;
    using Entidades;

    public interface FabricaDeValidadorDeXml
    {
        ValidadorDeXml ObterValidador(TipoDocumento tipo);
    }
}
