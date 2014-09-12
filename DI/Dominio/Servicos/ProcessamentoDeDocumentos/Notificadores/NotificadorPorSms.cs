namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Notificadores
{
    using System;
    using Entidades;

    public class NotificadorPorSms : Notificador
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando SMS: " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}