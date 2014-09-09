namespace DI.Dominio.Servicos.Documentos
{
    public interface ProcessadorDeDocumento : EstrategiaPorTipoDeDocumento
    {
        void Processar(string conteudo);
    }
}
