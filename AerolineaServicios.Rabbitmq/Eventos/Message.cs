using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaServicios.Rabbitmq.Eventos
{
    public abstract class Message :IRequest<bool>
    {
        public string MessageType { get; set; } 
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
