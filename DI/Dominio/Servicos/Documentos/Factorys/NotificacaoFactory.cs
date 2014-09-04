namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Infra.Notificaoes;
    using Entidades;

    public class NotificacaoFactory : INotificacaoFactory
    {
        private readonly INotificacao[] _notificacoes;

        public NotificacaoFactory(params INotificacao[] notificacoes)
        {
            _notificacoes = notificacoes;
        }

        public INotificacao ObterNotificacao(TipoDocumento tipo)
        {
            return _notificacoes.FirstOrDefault(e => e.AplicavelQuando(tipo));
        }
    }
}
