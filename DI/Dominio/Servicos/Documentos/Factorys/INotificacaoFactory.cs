namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Infra.Notificaoes;
    using Entidades;

    public interface INotificacaoFactory
    {
        INotificacao ObterNotificacao(TipoDocumento tipo);
    }
}
