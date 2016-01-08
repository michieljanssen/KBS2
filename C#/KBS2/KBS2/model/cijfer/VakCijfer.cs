using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.model.cijfer
{
    public class VakCijfer : Gradable
    {
        //variablen van vak en cijfer + mogelijk EC's
        private String vaknaam;
        private int ec;
        private List<ToetsCijfer> cijfers;

        public String VakNaam { get { return vaknaam; } }
        public int EC { get { return ec; } }
        public List<ToetsCijfer> Cijfers { get { return cijfers; } }

        //constructor
        public VakCijfer(String vaknaam, int ec, List<ToetsCijfer> cijfers)
        {
            this.vaknaam = vaknaam;
            this.ec = ec;
            this.cijfers = cijfers;
        }
        //checkt of het cijfer een voldoende is
        public Boolean isVoldoende()
        {
            Boolean behaald = true;
            ToetsCijfer[] cijfers = this.besteToetsen().ToArray();
            for (int i = 0; i < cijfers.Length; i++)
            {
                if (!cijfers[i].isVoldoende())
                    behaald = false;
            }
            return behaald;
        }

        public List<ToetsCijfer> besteToetsen()
        {
            List<ToetsCijfer> lijst = new List<ToetsCijfer>();
            for (int i = 0; i < cijfers.Count; i++) {
                if (lijst.Count > 0)
                {
                    Boolean heefttoets = false;
                    for (int b = 0; b < lijst.Count; b++) {
                        if (lijst[b].ToetsNaam.Equals(cijfers[i].ToetsNaam))
                        {
                            heefttoets = true;
                            if (lijst[b].Cijfer < cijfers[i].Cijfer)
                            {
                                lijst[b] = cijfers[i];
                            }
                        }
                      
                    }
                    if (!heefttoets) {
                        lijst.Add(cijfers[i]);
                    }
                }
                else {
                    lijst.Add(cijfers[i]);
                }
            }
            return lijst;
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
            else
            {
                //anders als er geen cijfers zijn: geef 0.0 terug
                return 0.0;
            }
        }
    }
}
