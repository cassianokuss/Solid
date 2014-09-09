namespace DI.Dominio.Servicos.Documentos
{
    using Factorys;
    using Validacoes;
    using Infra.Notificaoes;
    using Entidades;
    using Repositorios;

    public class ProcessadorDeNfce : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validacao;
        private readonly Repositorio<Nfce> _nfces;
        private readonly Notificador _notificacao;

        public ProcessadorDeNfce(Repositorio<Nfce> nfces, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.NFCe);
            _nfces = nfces;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.NFCe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = conteudo
                };

            _nfces.Armazenar(nfce);
            _notificacao.Enviar("Nfce enviada! " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFCe;
        }
    }
}