namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Infra.Notificaoes;
    using Entidades;

    public interface FabricaDeNotificador
    {
        Notificador ObterNotificacao(TipoDocumento tipo);
    }
}
