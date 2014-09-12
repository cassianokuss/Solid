namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Notificadores
{
    using Servicos;

    public interface Notificador : EstrategiaPorTipoDeDocumento
    {
        void Enviar(string conteudo);
    }
}