using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBS2.cijfer;

namespace KBS2.views
{
    class Toets
    {
        private String type;
        private String datum;
        private int ec;
        private List<ToetsCijfer> cijfers;

        public Toets(String type, String datum, int ec, List<ToetsCijfer> cijfers)
        {
            this.type = type;
            this.datum = datum;
            this.ec = ec;
            this.cijfers = cijfers;
        }

        public double gemiddelde()
        {
            return 0.0;
        }

        public int voldoendes()
        {
            return 0;
        }

        public int onvoldoendes()
        {
            return 0;
        }

        public int percentageVold() {
            return 0;
        }

    }
}
