using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CellPhone
{
    public class Phone
    {
        public Phone()
        {
			Model model = new Model();
			View view = new View(model);
			Controller controller = new Controller(model, view);
        }
    }
}
