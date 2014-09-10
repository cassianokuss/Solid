namespace DI.Dominio.Servicos.Documentos
{
    using Entidades;
    using Repositorios;
    using Fabricas;
    using Validadores;
    using Infra.Notificadores;

    public class ProcessadorDeNfce : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validador;
        private readonly Repositorio<Nfce> _nfces;
        private readonly Notificador _notificador;

        public ProcessadorDeNfce(Repositorio<Nfce> nfces, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validador = validaXmlFactory.ObterValidador(TipoDocumento.NFCe);
            _nfces = nfces;
            _notificador = notificacaoFactory.ObterNotificador(TipoDocumento.NFCe);
        }

        public void Processar(string conteudo)
        {
            _validador.Validar(conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = conteudo
                };

            _nfces.Armazenar(nfce);
            _notificador.Enviar("Nfce enviada! " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFCe;
        }
    }
}