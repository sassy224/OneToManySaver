using OneToManySaver.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneToManySaver.Mediator
{
    public interface IMediator
    {
        /// <summary>
        /// Interface method to map event from a control to a method in another control
        /// </summary>
        /// <param name="parControl">Publisher form</param>
        /// <param name="childControl">Receiver form</param>
        void MapEventControlToControl(IPublisherControl pubControl, IReceiverControl recControl);

        /// <summary>
        /// Interface method to handle location of a control
        /// </summary>
        /// <param name="control"></param>
        void HandleControlLocation(IControl control);

        /// <summary>
        /// Interface method to show children controls when parent control is loaded
        /// </summary>
        /// <param name="control"></param>
        void ShowChildrenControlsOnLoad(IControl control);
    }
}