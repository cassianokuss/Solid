namespace DI.Dominio.Servicos.Documentos.Fabricas
{
    using Entidades;
    using Validadores;

    public interface FabricaDeValidadorDeXml
    {
        ValidadorDeXml ObterValidador(TipoDocumento tipo);
    }
}
