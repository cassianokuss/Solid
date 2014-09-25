namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos
{
    public interface ProcessadorDeDocumento : EstrategiaPorTipoDeDocumento
    {
        string Teste { get; set; }
        void Processar(string conteudo);
    }
}
