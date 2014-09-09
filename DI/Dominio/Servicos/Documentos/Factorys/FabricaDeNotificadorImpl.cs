namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Infra.Notificaoes;
    using Entidades;

    public class FabricaDeNotificadorImpl : FabricaDeNotificador
    {
        private readonly Notificacao[] _notificacoes;

        public FabricaDeNotificadorImpl(params Notificacao[] notificacoes)
        {
            _notificacoes = notificacoes;
        }

        public Notificacao ObterNotificacao(TipoDocumento tipo)
        {
            return _notificacoes.FirstOrDefault(e => e.AplicarQuando(tipo));
        }
    }
}
