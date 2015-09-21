using OneToManySaver.CustomControl;
using OneToManySaver.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneToManySaver
{
    public partial class ParentFrm : Form, IPublisherControl
    {
        public ParentFrm()
        {
            InitializeComponent();
        }

        public event ActionHandler ActionOccursEvent;

        public event CustomFormClosingHandler CustomFormClosingEvent;

        public event CustomFormLoadHandler CustomFormLoadEvent;

        public List<IControl> ChildrenControls { get; set; }

        private void ParentFrm_Load(object sender, EventArgs e)
        {
            if (CustomFormLoadEvent != null)
                CustomFormLoadEvent(this);
        }

        private void ParentFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CustomFormClosingEvent != null)
                CustomFormClosingEvent(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ActionOccursEvent != null)
            {
                string controlName = ((Control)sender).Name;
                string actionName = "Button Click";
                string actionDescription = "Button on parent form clicked";
                ActionOccursEvent(new Model.ActionInfoEventArgs(controlName, actionName, actionDescription));
            }
        }
    }
}