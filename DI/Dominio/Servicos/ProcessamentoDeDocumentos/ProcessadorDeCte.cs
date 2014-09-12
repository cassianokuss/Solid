namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos
{
    using Entidades;

    public class ProcessadorDeCte : ProcessadorDeDocumentoBase<Cte>
    {
        public ProcessadorDeCte()
            : base(TipoDocumento.CTe)
        {
        }

        public override void Processar(string conteudo)
        {
            Validar(conteudo);
            Armazenar(Cte.ObterCte(conteudo));
            Notificar(conteudo);
        }
    }
}