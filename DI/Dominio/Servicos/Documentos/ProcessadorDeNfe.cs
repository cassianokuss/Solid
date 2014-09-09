namespace DI.Dominio.Servicos.Documentos
{
    using Factorys;
    using Validacoes;
    using Infra.Notificaoes;
    using Entidades;
    using Repositorios;

    public class ProcessadorDeNfe : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validacao;
        private readonly Repositorio<Nfe> _nfes;
        private readonly Notificacao _notificacao;

        public ProcessadorDeNfe(Repositorio<Nfe> nfes, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.NFe);
            _nfes = nfes;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.NFe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfe = new Nfe()
                {
                    PropriedadesDaNFe = conteudo
                };

            _nfes.Armazenar(nfe);
            _notificacao.Enviar("NFe enviada! " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe;
        }
    }
}