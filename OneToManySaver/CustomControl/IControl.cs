using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneToManySaver.CustomControl
{
    public delegate void CustomFormClosingHandler(IControl control);
    public delegate void CustomFormLoadHandler(IControl control);

    public interface IControl
    {
        //Events that all IControl control publishes
        event CustomFormClosingHandler CustomFormClosingEvent;
        event CustomFormLoadHandler CustomFormLoadEvent;

        //Property
        List<IControl> ChildrenControls { get; set; }
    }
}