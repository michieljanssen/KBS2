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
        public String Naam { get { return leerlingnaam; } }
        public String ID { get { return leerlingid; } }

        public ToetsCijfer(String leerlingid, String leerlingnaam, double cijfer) {
            this.leerlingid = leerlingid;
            this.leerlingnaam = leerlingnaam;
            this.cijfer = cijfer;
        }

        public Boolean isVoldoende() {
            return cijfer >= 5.5;
        }
    }
}
