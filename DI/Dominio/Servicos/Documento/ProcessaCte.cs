namespace DI.Dominio.Servicos.Documento
{
    using Entidades;
    using Infra;
    using Repositorios;

    public class ProcessaCte : IProcessaDocumento
    {
        private readonly ValidaXmlCte _validacao;
        private readonly IRepositorioBase<Cte> _ctes;
        private readonly INotificacao _notificacao;

        public ProcessaCte(IRepositorioBase<Cte> ctes, ValidaXmlCte validacao, INotificacao notificacao)
        {
            _validacao = validacao;
            _ctes = ctes;
            _notificacao = notificacao;
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = conteudo
                };

            _ctes.Armazenar(cte);
            _notificacao.Enviar("Cte enviado! " + conteudo);
        }

        public bool EhAplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}