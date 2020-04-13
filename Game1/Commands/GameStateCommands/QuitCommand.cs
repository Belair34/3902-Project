using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class QuitCommand: ICommand
    {
        public QuitCommand()
        {
        }

        public void Execute()
        {
            Game1.getInstance().Exit();
        }
    }
}
