﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerAppModelLib
{
    public class Company
    {
        public void EmployeeClientVisit(IClientInteraction clientInteraction)
        {
            clientInteraction.GetPayment();
        }
    }
}
