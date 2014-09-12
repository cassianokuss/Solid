namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Fabricas
{
    using System.Linq;
    using Entidades;
    using Notificadores;

    public class FabricaDeNotificadorImpl : FabricaDeNotificador
    {
        private readonly Notificador[] _notificadores;

        public FabricaDeNotificadorImpl(params Notificador[] notificadores)
        {
            _notificadores = notificadores;
        }

        public Notificador ObterNotificador(TipoDocumento tipo)
        {
            return _notificadores.FirstOrDefault(e => e.AplicarQuando(tipo));
        }
    }
}
