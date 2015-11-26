using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.model.cijfer
{
    class VakCijfer:Gradable
    {
        //variablen van vak en cijfer + mogelijk EC's
        private String vaknaam;
        private int ec;
        private double cijfer;

        public String VakNaam { get { return vaknaam; } }
        public int EC { get { return ec; } }
        public double Cijfer { get { return cijfer; } }

        //constructor
        public VakCijfer(String vaknaam, int ec, double cijfer) {
            this.vaknaam = vaknaam;
            this.ec = ec;
            this.cijfer = cijfer;
        }
        //checkt of het cijfer een voldoende is
        public Boolean isVoldoende()
        {
            return cijfer >= 5.5;
        }
    }
}
