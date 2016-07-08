using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms.Design;

namespace _SCREEN_CAPTURE
{
    public class ColorBoxDesginer : ControlDesigner
    {
        public override SelectionRules SelectionRules {
            get {
                return base.SelectionRules & ~SelectionRules.AllSizeable;
            }
        }
    }
}
