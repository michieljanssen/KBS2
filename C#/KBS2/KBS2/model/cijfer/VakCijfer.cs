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
        public Boolean ECsBehaald()
        {
            Boolean behaald = true;
            ToetsCijfer[] cijfers = this.besteToetsen().ToArray();
            for (int i = 0; i < cijfers.Length; i++)
            {
                if (!cijfers[i].ECsBehaald())
                    behaald = false;
            }
            return behaald;
        }

        public List<ToetsCijfer> besteToetsen()
        {
            List<ToetsCijfer> list = new List<ToetsCijfer>();
            for (int i = 0; i < cijfers.Count; i++)
            {
                if (list.Count > 0) //IF list contains grades
                {
                    Boolean hasToets = false; //THEN hastToets = false
                    for (int b = 0; b < list.Count; b++)
                    {
                        if (list[b].toetsName.Equals(cijfers[i].toetsName))//loop to find the highest grade from that toetstype
                        {
                            hasToets = true;
                            if (list[b].Cijfer < cijfers[i].Cijfer)
                            {
                                list[b] = cijfers[i];
                            }
                        }

                    }
                    if (!hasToets)
                    {
                        list.Add(cijfers[i]);
                    }
                }
                else { //IF list is empty add first grade
                    list.Add(cijfers[i]);
                }
            }
            return list;
        }

        //berekent het gemiddelde
        public double gemiddelde()
        {
            List<ToetsCijfer> cijfers = this.besteToetsen();
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
