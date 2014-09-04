namespace DI.Dominio.Servicos.Documento
{
    using Entidades;
    using Factory;
    using Repositorios;

    public class ProcessaNfce : IProcessaDocumento
    {
        private readonly IValidaXml _validacao;
        private readonly IRepositorioBase<Nfce> _nfces;
        private readonly INotificacao _notificacao;

        public ProcessaNfce(IRepositorioBase<Nfce> nfces, IValidaXmlFactory validaXmlFactory, INotificacaoFactory notificacaoFactory)
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

        public bool ProcessarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFCe;
        }
    }
}