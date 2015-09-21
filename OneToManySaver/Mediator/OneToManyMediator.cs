using OneToManySaver.CustomControl;
using OneToManySaver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneToManySaver.Mediator
{
    public class OneToManyMediator : IMediator
    {
        /// <summary>
        /// Implement method to map event from a form to a method in another form
        /// </summary>
        /// <param name="parControl">Publisher form</param>
        /// <param name="childControl">Receiver form</param>
        public void MapEventControlToControl(IPublisherControl pubControl, IReceiverControl recControl)
        {
            pubControl.ActionOccursEvent += recControl.UpdateText;
        }

        /// <summary>
        /// Implement method to save location of a control when it's closing
        /// </summary>
        /// <param name="control"></param>
        public void HandleControlLocation(IControl control)
        {
            control.CustomFormClosingEvent += SaveControlLocation;
            control.CustomFormLoadEvent += LoadControlLocation;
        }

        /// <summary>
        /// Implement method to show children controls when parent control is loaded
        /// </summary>
        /// <param name="control"></param>
        public void ShowChildrenControlsOnLoad(IControl control)
        {
            control.CustomFormLoadEvent += ShowChildrenControls;
        }

        /// <summary>
        /// Private method to save location of a control using FormPositionHelper.SaveLocation
        /// </summary>
        /// <param name="control"></param>
        private void SaveControlLocation(IControl control)
        {
            if (control is Form)
            {
                FormPositionHelper.SaveLocation((Form)control);
                if (control.ChildrenControls != null)
                {
                    foreach (var child in control.ChildrenControls)
                    {
                        if (child is Form)
                            FormPositionHelper.SaveLocation((Form)child);
                    }
                }
            }
        }

        /// <summary>
        /// Private method to set location of a control using FormPositionHelper.SetLocation
        /// </summary>
        /// <param name="control"></param>
        private void LoadControlLocation(IControl control)
        {
            if (control is Form)
                FormPositionHelper.SetLocation((Form)control);
        }

        /// <summary>
        /// Private method to show children controls when parent is loaded
        /// </summary>
        /// <param name="control"></param>
        private void ShowChildrenControls(IControl control)
        {
            foreach (var child in control.ChildrenControls)
            {
                if (child is Form)
                    ((Form)child).Show();
            }
        }
    }
}