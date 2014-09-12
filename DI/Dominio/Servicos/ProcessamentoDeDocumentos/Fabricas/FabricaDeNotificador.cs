namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Fabricas
{
    using Entidades;
    using Notificadores;

    public interface FabricaDeNotificador
    {
        Notificador ObterNotificador(TipoDocumento tipo);
    }
}
