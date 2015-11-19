using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.cijfer
{
    class ToetsCijfer: Gradable
    {
        private String leerlingid;
        private String leerlingnaam;
        private double cijfer;

        public double Cijfer { get { return cijfer; } }

        public ToetsCijfer(String leerlingid, String leerlingnaam, double cijfer) {
            this.leerlingid = leerlingid;
            this.leerlingnaam = leerlingnaam;
            this.cijfer = cijfer;
        }

        public Boolean isVoldoende() {
            return false;
        }
    }
}
