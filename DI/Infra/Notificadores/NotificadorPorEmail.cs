namespace DI.Infra.Notificadores
{
    using System;
    using Dominio.Entidades;

    public class NotificadorPorEmail : Notificador
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando email: " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe || tipo == TipoDocumento.NFCe;
        }
    }
}