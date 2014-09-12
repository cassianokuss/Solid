namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Notificadores
{
    using System;
    using Entidades;

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