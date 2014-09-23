namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos
{
    using Entidades;

    public class ProcessadorDeNfce : ProcessadorDeDocumentoBase<Nfce>
    {
        public ProcessadorDeNfce()
            : base(TipoDocumento.NFCe)
        {
        }

        public override void Processar(string conteudo)
        {
            Validar(conteudo);
            Armazenar(Nfce.ObterNfce(conteudo));
            Notificar(conteudo);
        }
    }
}