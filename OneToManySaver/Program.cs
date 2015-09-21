using OneToManySaver.CustomControl;
using OneToManySaver.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneToManySaver
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Form1());

            //Init forms
            ParentFrm parentFrm = new ParentFrm();
            ChildFrm childFrm1 = new ChildFrm();
            childFrm1.Name = "Child Form 1";
            ChildFrm childFrm2 = new ChildFrm();
            childFrm2.Name = "Child Form 2";
            List<IControl> childrenControls = new List<IControl>() { childFrm1, childFrm2 };
            parentFrm.ChildrenControls = childrenControls;

            //Init mediator
            IMediator mediator = new OneToManyMediator();
            mediator.MapEventControlToControl(parentFrm, childFrm1);
            mediator.MapEventControlToControl(parentFrm, childFrm2);
            mediator.ShowChildrenControlsOnLoad(parentFrm);
            mediator.HandleControlLocation(parentFrm);
            mediator.HandleControlLocation(childFrm1);
            mediator.HandleControlLocation(childFrm2);

            //Show form
            parentFrm.ShowDialog();
        }
    }
}