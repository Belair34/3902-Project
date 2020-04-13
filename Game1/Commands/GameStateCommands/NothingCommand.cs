using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class NothingCommand : ICommand
    {
        public NothingCommand()
        {

        }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
