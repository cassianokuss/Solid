namespace DI.Dominio.Servicos.Documentos.Fabricas
{
    using Infra.Notificaoes;
    using Entidades;

    public interface FabricaDeNotificador
    {
        Notificador ObterNotificador(TipoDocumento tipo);
    }
}
