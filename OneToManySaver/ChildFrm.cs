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
    public partial class ChildFrm : Form, IReceiverControl
    {
        public ChildFrm()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    Screen scr = Screen.PrimaryScreen;
        //    this.Left = (scr.WorkingArea.Width - this.Width) / 2;
        //    this.Top = (scr.WorkingArea.Height - this.Height) / 2;

        //    FormPositionHelper.SetLocation(this);
        //}

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    FormPositionHelper.SaveLocation(this);
        //}

        public void UpdateText(Model.ActionInfoEventArgs actionInfoArgs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Child form received event from parent form");
            sb.AppendLine("Parent control name: " + actionInfoArgs.ControlName);
            sb.AppendLine("Parent control action: " + actionInfoArgs.ActionName);
            sb.AppendLine("Description: " + actionInfoArgs.ActionDescription);
            txtContent.Text += sb.ToString();
        }

        public event CustomFormClosingHandler CustomFormClosingEvent;

        public event CustomFormLoadHandler CustomFormLoadEvent;

        public List<IControl> ChildrenControls { get; set; }

        private void ChildFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CustomFormClosingEvent != null)
                CustomFormClosingEvent(this);
        }

        private void ChildFrm_Load(object sender, EventArgs e)
        {
            if (CustomFormLoadEvent != null)
                CustomFormLoadEvent(this);
        }
    }
}