using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting;

namespace Calculator
{
    public class ALU
    {
        public int Calculate(List<object> components)
        {
            int leftOperand = 0;
            for (int i = 0; i < components.Count; i++)
            {
                if (i == components.Count)
                {
                    return (int) components[i];
                }

                if (components[i] is Operator)
                {
                    var slicedEquation = components.GetRange(i+1, components.Count - 1);
                    var rightOperand = Calculate((List<object>)slicedEquation);
                    var op = (Operator) components[i];

                    return op.Calculate(leftOperand, rightOperand);
                }

                if (components[i] is int)
                {
                    leftOperand = (int) components[i];
                }
            }

            return 1;
        }
    }
}