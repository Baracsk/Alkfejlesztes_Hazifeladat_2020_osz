using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes.ViewModel
{
    class ParameterTextVM
    {
        private Queue<string> positionTextList;

        public ParameterTextVM(string defaultText)
        {
            positionTextList = new Queue<string>();
            positionTextList.Enqueue(defaultText);
        }

        public string WritePosition(string X, string Y)
        {
            string OutPutText = "";

            UpdatePositionTextList("x: " + X + " y: " + Y);

            foreach (string element in positionTextList)
            {
                OutPutText += element + '\n';
            }

            return OutPutText;
        }

        private void UpdatePositionTextList(string newText)
        {
            if (positionTextList.Count() >= 10)
            {
                positionTextList.Dequeue();
            }

            positionTextList.Enqueue(newText);
        }

    }
}