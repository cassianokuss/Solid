namespace Solid.DIP.Infra
{
    using System;
    using Dominio.Entidades;

    public class Email : Notificacao
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando email: " + conteudo);
        }
    }
}