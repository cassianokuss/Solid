namespace DI.Dominio.Servicos.Documentos.Fabricas
{
    using Infra.Notificadores;
    using Entidades;

    public interface FabricaDeNotificador
    {
        Notificador ObterNotificador(TipoDocumento tipo);
    }
}
