namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Infra.Notificaoes;
    using Entidades;

    public class FabricaDeNotificadorImpl : FabricaDeNotificador
    {
        private readonly INotificacao[] _notificacoes;

        public FabricaDeNotificadorImpl(params INotificacao[] notificacoes)
        {
            _notificacoes = notificacoes;
        }

        public INotificacao ObterNotificacao(TipoDocumento tipo)
        {
            return _notificacoes.FirstOrDefault(e => e.AplicarQuando(tipo));
        }
    }
}
