﻿using DI.Dominio.Servicos.Documento.Validacoes;
using DI.Infra;
using DI.Infra.Notificaoes;

namespace DI.Dominio.Servicos.Documento
{
    using Entidades;
    using Factory;
    using Repositorios;

    public class ProcessaCte : IProcessaDocumento
    {
        private readonly IValidaXml _validacao;
        private readonly IRepositorioBase<Cte> _ctes;
        private readonly INotificacao _notificacao;

        public ProcessaCte(IRepositorioBase<Cte> ctes, IValidaXmlFactory validaXmlFactory, INotificacaoFactory notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.CTe);
            _ctes = ctes;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.CTe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = conteudo
                };

            _ctes.Armazenar(cte);
            _notificacao.Enviar("Cte enviado! " + conteudo);
        }

        public bool ProcessarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}