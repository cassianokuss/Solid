namespace Solid.DIP.Dominio.Servicos.Documento
{
    using Entidades;
    using Infra;
    using Repositorios;

    public class ProcessaCte : ProcessaDocumento
    {
        private readonly ValidaXmlCte _validacao;
        private readonly Ctes _ctes;
        private readonly Notificacao _notificacao;

        public ProcessaCte()
        {
            _validacao = new ValidaXmlCte();
            _ctes = new Ctes();
            _notificacao = new Email();
        }

        public override void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = conteudo
                };

            _ctes.ArmazenarCte(cte);
            _notificacao.Enviar("Cte enviado! " + conteudo);
        }
    }
}