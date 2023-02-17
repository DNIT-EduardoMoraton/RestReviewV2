using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReviewV2.Mensajes.Difusion
{
    class AutorNavValueChangedMessage : ValueChangedMessage<bool>
    {
        public AutorNavValueChangedMessage(bool changed) : base(changed) { }
    }
}
