namespace Solid.DI2
{
    using System;
    using System.Linq.Expressions;
    using Dominio.Entidades;
    using Dominio.Servicos.Processadores;
    using Dominio.Servicos.Validadores;
    using SimpleInjector;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            var fab2 = new FabricaImpl<ProcessadorDeDocumento, TipoDeDocumento>(container);
            fab2.Register<ProcessadorDeDocumentoNfe>(new TipoDeDocumento { Tipo = Tipo.NFe });
            fab2.Register<ProcessadorDeDocumentoCte>(new TipoDeDocumento { Tipo = Tipo.CTe });

            container.RegisterSingle<Fabrica<ProcessadorDeDocumento, TipoDeDocumento>>(fab2);

            var fab = container.GetInstance<Fabrica<ProcessadorDeDocumento, TipoDeDocumento>>();

            var xxx = fab.CriarProcessadorDeDocumento(new TipoDeDocumento { Tipo = Tipo.NFe, Versao = 1 });
        }
    }

    public interface Fabrica<TInter, TTipo>
    {
        TInter CriarProcessadorDeDocumento(TTipo tipo);
    }

    public class FabricaImpl<TInter, TTipo> : Fabrica<TInter, TTipo>
        where TInter : class
        where TTipo : IComparador<TTipo>
    {
        private readonly Dictionary<TTipo, InstanceProducer> _processadoresDeDocumento = new Dictionary<TTipo, InstanceProducer>();
        private readonly Container _container;

        public FabricaImpl(Container container)
        {
            _container = container;
        }

        public TInter CriarProcessadorDeDocumento(TTipo tipo)
        {
            var key = _processadoresDeDocumento.Keys.FirstOrDefault(o => tipo.Igual(o));
            return (TInter)_processadoresDeDocumento[key].GetInstance();
        }

        public void Register<T1>(TTipo tipo, Lifestyle lifestyle = null) where T1 : class, TInter
        {
            lifestyle = lifestyle ?? Lifestyle.Transient;

            var registration = lifestyle.CreateRegistration<TInter, T1>(_container);

            var producer = new InstanceProducer(typeof(Fabrica<TInter, TTipo>), registration);

            _processadoresDeDocumento.Add(tipo, producer);
        }
    }
}
