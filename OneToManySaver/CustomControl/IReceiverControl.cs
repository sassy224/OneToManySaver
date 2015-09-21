using OneToManySaver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToManySaver.CustomControl
{
    public interface IReceiverControl : IControl
    {
        void UpdateText(ActionInfoEventArgs actionInfoArgs);
    }
}