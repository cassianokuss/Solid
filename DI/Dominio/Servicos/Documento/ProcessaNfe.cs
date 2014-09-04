namespace DI.Dominio.Servicos.Documento
{
    using Entidades;
    using Factory;
    using Repositorios;

    public class ProcessaNfe : IProcessaDocumento
    {
        private readonly IValidaXml _validacao;
        private readonly IRepositorioBase<Nfe> _nfes;
        private readonly INotificacao _notificacao;

        public ProcessaNfe(IRepositorioBase<Nfe> nfes, IValidaXmlFactory validaXmlFactory, INotificacaoFactory notificacaoFactory)
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

        public bool ProcessarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe;
        }
    }
}