using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Mensajes.Difusion
{
    class AnyadirArticuloValueChangedMessage : ValueChangedMessage<bool>
    {
        public AnyadirArticuloValueChangedMessage(bool changed) : base(changed) { }

    }
}
