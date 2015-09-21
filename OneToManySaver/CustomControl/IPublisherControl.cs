using OneToManySaver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToManySaver.CustomControl
{
    public delegate void ActionHandler(ActionInfoEventArgs actionInfoArgs);

    public interface IPublisherControl : IControl
    {
        //Event that only IPublisherControl publishes
        event ActionHandler ActionOccursEvent;
    }
}