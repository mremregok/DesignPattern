﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.AdapterPattern.Example2.ObjectAdapterPattern
{
    internal interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }
}
