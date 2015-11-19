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
            double sum = 0.0;
            for (int i = 0; i < cijfers.Count; i++)
            {
                sum += cijfers[i].Cijfer;
            }
            double gemiddelde = sum / cijfers.Count;
            return gemiddelde;
        }

        public int voldoendes()
        {
            int amount = 0;
            for (int i = 0; i < cijfers.Count; i++)
            {
                if (cijfers[i].isVoldoende()) {
                    amount++;
                }
            }
            return amount;
        }

        public int onvoldoendes()
        {
            int amount = 0;
            for (int i = 0; i < cijfers.Count; i++)
            {
                if (!cijfers[i].isVoldoende())
                {
                    amount++;
                }
            }
            return amount;
        }

        public int percentageVold()
        {
            return (voldoendes() * 100) / (cijfers.Count );
        }

    }
}
