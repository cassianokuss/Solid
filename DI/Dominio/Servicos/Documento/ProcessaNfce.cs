﻿namespace DI.Dominio.Servicos.Documento
{
    using Entidades;
    using Infra;
    using Repositorios;

    public class ProcessaNfce : IProcessaDocumento
    {
        private readonly ValidaXmlNfce _validacao;
        private readonly IRepositorioBase<Nfce> _nfces;
        private readonly INotificacao _notificacao;

        public ProcessaNfce(IRepositorioBase<Nfce> nfces, ValidaXmlNfce validacao, INotificacao notificacao)
        {
            _validacao = validacao;
            _nfces = nfces;
            _notificacao = notificacao;
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = conteudo
                };

            _nfces.Armazenar(nfce);
            _notificacao.Enviar("Nfce enviada! " + conteudo);
        }

        public bool EhAplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFCe;
        }
    }
}