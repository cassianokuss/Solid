namespace DI.Dominio.Servicos
{
    using DI.Dominio.Entidades;

    public interface IEstrategiaTipoDocumento
    {
        bool AplicavelQuando(TipoDocumento tipo); 
    }
}