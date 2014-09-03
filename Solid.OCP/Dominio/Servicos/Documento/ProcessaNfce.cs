namespace Solid.OCP.Dominio.Servicos.Documento
{
    using Entidades;
    using Infra;
    using Repositorios;

    public class ProcessaNfce : ProcessaDocumento
    {
        private readonly ValidaXmlNfce _validacao;
        private readonly Nfces _Nfces;
        private readonly Email _email;

        public ProcessaNfce()
        {
            _validacao = new ValidaXmlNfce();
            _Nfces = new Nfces();
            _email = new Email();
        }

        public override void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = conteudo
                };

            _Nfces.ArmazenarNfce(nfce);
            _email.EnviarEmail("Nfce enviada! " + conteudo);
        }
    }
}