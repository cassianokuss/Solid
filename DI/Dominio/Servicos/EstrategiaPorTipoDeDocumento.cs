namespace DI.Dominio.Servicos
{
    using Entidades;

    public interface EstrategiaPorTipoDeDocumento
    {
        bool AplicarQuando(TipoDocumento tipo); 
    }
}