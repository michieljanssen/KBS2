﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.model.cijfer
{
    public class VakCijfer:Gradable
    {
        //variablen van vak en cijfer + mogelijk EC's
        private String vaknaam;
        private int ec;
        private List<ToetsCijfer> cijfers;

        public String VakNaam { get { return vaknaam; } }
        public int EC { get { return ec; } }
        public List<ToetsCijfer> Cijfer { get { return cijfers; } }

        //constructor
        public VakCijfer(String vaknaam, int ec, List<ToetsCijfer> cijfers) {
            this.vaknaam = vaknaam;
            this.ec = ec;
            this.cijfers = cijfers;
        }
        //checkt of het cijfer een voldoende is
        public Boolean isVoldoende()
        {
            return gemiddelde() >= 5.5;
        }


        //berekent het gemiddelde
        public double gemiddelde()
        {
            //checkt of er cijfers zijn
            if (cijfers.Count > 0)
            {
                //maakt een totaal variable toe
                double sum = 0.0;

                //gaat door alle cijfers heen
                for (int i = 0; i < cijfers.Count; i++)
                {
                    //voegt het cijfer aan de variable toe
                    sum += cijfers[i].Cijfer;
                }

                //maakt nieuwe variable aan die het totaal deelt door het aantal cijfers
                double gemiddelde = sum / cijfers.Count;
                //geeft het gemiddelde terug

                return Math.Round(gemiddelde, 1);
            }
            else {
                //anders als er geen cijfers zijn: geef 0.0 terug
                return 0.0;
            }
        }
    }
}
