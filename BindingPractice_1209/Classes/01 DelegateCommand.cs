using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotDiagnosticApp
{
    class DelegateCommand : ICommand
    {
        private SimpleEventHandler handler;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();

        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public void Execute(object obj)
        {
            this.handler();
        }
        public bool CanExecute(object obj)
        {
            return true;
        }
    }
}
