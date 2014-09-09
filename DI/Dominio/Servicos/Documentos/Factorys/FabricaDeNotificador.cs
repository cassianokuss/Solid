namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Infra.Notificaoes;
    using Entidades;

    public interface FabricaDeNotificador
    {
        Notificacao ObterNotificacao(TipoDocumento tipo);
    }
}
