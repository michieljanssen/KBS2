using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBS2.cijfer;

namespace KBS2.cijfer
{
    class Toets
    {
        private String naam;
        private String type;
        private List<ToetsCijfer> cijfers;

        public String Type { get { return type; } }
        public String Naam { get { return naam; } }
        public List<ToetsCijfer> Cijfers { get { return cijfers; } }

        public Toets(String naam, String type, String datum,List<ToetsCijfer> cijfers)
        {
            this.naam = naam;
            this.type = type;
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
            if (cijfers.Count != 0)
            {
                return (voldoendes() * 100) / (cijfers.Count);
            }
            else {
                return 0;
            }
        }

    }
}
