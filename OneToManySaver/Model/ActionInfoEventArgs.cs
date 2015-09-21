using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToManySaver.Model
{
    public class ActionInfoEventArgs
    {
        public readonly string ControlName;
        public readonly string ActionName;
        public readonly string ActionDescription;

        public ActionInfoEventArgs(string controlName, string actionName, string actionDesc)
        {
            this.ControlName = controlName;
            this.ActionName = actionName;
            this.ActionDescription = actionDesc;
        }
    }
}