namespace DI.Dominio.Servicos.Documentos
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
            Armazenar(new Cte(conteudo));
            Notificar(conteudo);
        }
    }
}