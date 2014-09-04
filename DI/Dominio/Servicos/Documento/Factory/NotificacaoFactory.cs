namespace DI.Dominio.Servicos.Documento.Factory
{
    using System.Linq;
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
            return _notificacoes.FirstOrDefault(e => e.EnviarQuando(tipo));
        }
    }
}
