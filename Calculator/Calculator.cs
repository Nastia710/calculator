using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator
{
    
    public class Calculator
    {
        public string Expression { get; set; }
        public string DisplayText { get; set; }
        public bool isNewOp { get; set; }
        public bool isError { get; set; }
        public bool isSandwichBtnClk { get; set; }

        public Calculator()
        {
            Expression = "";
            DisplayText = "0";
            isNewOp = true;
            isError = false;
        }

        public void DisplayError()
        {
            isError = false;
            Clear();
        }

        public void ResetError()
        {
            Expression = "";
            DisplayText = "Error";
            isNewOp = true;
            isError = true;
        }

        public void Clear()
        {
            Expression = "";
            DisplayText = "0";
            isNewOp = true;
        }

        public void Backspace()
        {
            if(isError)
            {
                ResetError();
                return;
            }
            if (DisplayText.Length == 1 || (DisplayText.Length == 2 && DisplayText[0] == '-'))
            {
                DisplayText = "0";
                isNewOp = true;
            }
            else
            {
                DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);
            }
        }

        public void AddNumber(string number)
        {
            if(isError)
            {
                ResetError();
            }
            if(isNewOp)
            {
                DisplayText = number;
                isNewOp = false;
            }
            else
            {
                if (DisplayText == "0" && number != ",")
                {
                    DisplayText = number;
                }
                else
                {
                    DisplayText += number;
                }
            }
        }

        public void AddDot()
        {
            if (isError)
            {
                ResetError();
            }
            if (isNewOp)
            {
                DisplayText = "0,";
                isNewOp = false;
            }
            else if(!DisplayText.Contains(","))
            {
                DisplayText += ",";
            }
        }

        public void AddOp(string op)
        {
            if (isError)
            {
                ResetError();
            }
            Expression = $"{DisplayText} {op}";
            isNewOp = true;
        }
    }
}
