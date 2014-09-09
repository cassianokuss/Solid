﻿namespace DI.Infra.Notificaoes
{
    using System;
    using Dominio.Entidades;

    public class Sms : Notificacao
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