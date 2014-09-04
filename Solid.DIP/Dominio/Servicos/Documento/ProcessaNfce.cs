namespace Solid.DIP.Dominio.Servicos.Documento
{
    using Entidades;
    using Infra;
    using Repositorios;

    public class ProcessaNfce : ProcessaDocumento
    {
        private readonly ValidaXmlNfce _validacao;
        private readonly Nfces _nfces;
        private readonly Notificacao _notificacao;

        public ProcessaNfce()
        {
            _validacao = new ValidaXmlNfce();
            _nfces = new Nfces();
            _notificacao = new Email();
        }

        public override void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = conteudo
                };

            _nfces.ArmazenarNfce(nfce);
            _notificacao.Enviar("Nfce enviada! " + conteudo);
        }
    }
}