namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos
{
    public interface ProcessadorDeDocumento : EstrategiaPorTipoDeDocumento
    {
        void Processar(string conteudo);
    }
}
