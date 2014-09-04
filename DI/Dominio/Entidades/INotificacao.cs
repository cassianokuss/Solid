namespace DI.Dominio.Entidades
{
    public interface INotificacao
    {
        void Enviar(string conteudo);
        bool EnviarQuando(TipoDocumento tipo);
    }
}