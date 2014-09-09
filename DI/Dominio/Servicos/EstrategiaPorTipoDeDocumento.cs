namespace DI.Dominio.Servicos
{
    using Entidades;

    public interface EstrategiaPorTipoDeDocumento
    {
        bool AplicavelQuando(TipoDocumento tipo); 
    }
}