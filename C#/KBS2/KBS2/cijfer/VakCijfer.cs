﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.cijfer
{
    class VakCijfer:Gradable
    {
        private String vaknaam;
        private int ec;
        private double cijfer;

        public VakCijfer(String vaknaam, int ec, double cijfer) {
            this.vaknaam = vaknaam;
            this.ec = ec;
            this.cijfer = cijfer;
        }

        public Boolean isVoldoende()
        {
            return false;
        }
    }
}