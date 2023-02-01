
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.Mensajes.Difusion
{
    class ArticuloNavValueChangedMesage : ValueChangedMessage<bool>
    {
        public ArticuloNavValueChangedMesage(bool changed) : base(changed) { }
    }
}
