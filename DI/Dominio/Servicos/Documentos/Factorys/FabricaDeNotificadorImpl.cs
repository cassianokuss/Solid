namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using System.Linq;
    using Infra.Notificaoes;
    using Entidades;

    public class FabricaDeNotificadorImpl : FabricaDeNotificador
    {
        private readonly Notificador[] _notificacoes;

        public FabricaDeNotificadorImpl(params Notificador[] notificacoes)
        {
            _notificacoes = notificacoes;
        }

        public Notificador ObterNotificacao(TipoDocumento tipo)
        {
            return _notificacoes.FirstOrDefault(e => e.AplicarQuando(tipo));
        }
    }
}
