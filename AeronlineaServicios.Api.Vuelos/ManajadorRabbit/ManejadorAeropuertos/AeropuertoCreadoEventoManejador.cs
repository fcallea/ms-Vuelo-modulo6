using AerolineaServicios.Rabbitmq.BusRabbit;
using AerolineaServicios.Rabbitmq.EventoQueue;
using AeronlineaServicios.Api.Vuelos.Modelo.Aeropuerto;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.ManajadorRabbit.ManejadorAeropuertos
{
   public class AeropuertoCreadoEventoManejador : IEventoManejador<AeropuertoCreadoQueue>
    {
        private readonly ContextoVuelo _contexto;

        public AeropuertoCreadoEventoManejador(ContextoVuelo contexto)
        {
            _contexto = contexto;
        }

        public Task Handle(AeropuertoCreadoQueue @evento)
        {
            //var aeropuerto = new Aeropuerto
            //{
            //    IdAeropuerto = evento.IdAeropuerto,
            //    NombreAeropuerto = evento.NombreAeropuerto,
            //    OACI = evento.OACI,
            //    IATA = evento.IATA
            //};
            //_contexto.Aeropuerto.Add(aeropuerto);
            //var valor = _contexto.SaveChanges();

            var url = "https://localhost:44320/api/Vuelo/GuardarAeropuerto";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 300000;
            var json = JsonConvert.SerializeObject(evento);

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            // Invocación del servicio y respuesta con las facturas generadas
            var response = request.GetResponse();


            return Task.CompletedTask;
        }
    }
}
