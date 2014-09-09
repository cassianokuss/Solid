namespace DI.Dominio.Servicos.Documentos
{
    using Factorys;
    using Validacoes;
    using Infra.Notificaoes;
    using Entidades;
    using Repositorios;

    public class ProcessadorDeNfe : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validador;
        private readonly Repositorio<Nfe> _nfes;
        private readonly Notificador _notificador;

        public ProcessadorDeNfe(Repositorio<Nfe> nfes, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validador = validaXmlFactory.ObterValidador(TipoDocumento.NFe);
            _nfes = nfes;
            _notificador = notificacaoFactory.ObterNotificacao(TipoDocumento.NFe);
        }

        public void Processar(string conteudo)
        {
            _validador.Validar(conteudo);
            var nfe = new Nfe()
                {
                    PropriedadesDaNFe = conteudo
                };

            _nfes.Armazenar(nfe);
            _notificador.Enviar("NFe enviada! " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe;
        }
    }
}