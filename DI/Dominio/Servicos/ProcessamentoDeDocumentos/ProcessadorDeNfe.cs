namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos
{
    using Entidades;
    using Fabricas;
    using Notificadores;
    using Repositorios;
    using Validadores;

    public class ProcessadorDeNfe : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validador;
        private readonly Repositorio<Nfe> _nfes;
        private readonly Notificador _notificador;
        public string Teste { get; set; }

        public ProcessadorDeNfe(Repositorio<Nfe> nfes, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validador = validaXmlFactory.ObterValidador(TipoDocumento.NFe);
            _nfes = nfes;
            _notificador = notificacaoFactory.ObterNotificador(TipoDocumento.NFe);
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