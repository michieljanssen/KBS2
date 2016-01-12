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
        //verkrijgt een lijst van unique toetsen met de hoogste cijfers
        public List<ToetsCijfer> besteToetsen()
        {
            List<ToetsCijfer> list = new List<ToetsCijfer>();
            for (int i = 0; i < cijfers.Count; i++)
            {
                if (list.Count > 0) //checked of de lijst iets bevat
                {
                    Boolean hasToets = false; //variable die bij houdt of de huidige toets er al inzit
                    for (int b = 0; b < list.Count; b++)
                    {
                        if (list[b].toetsName.Equals(cijfers[i].toetsName))//checked of de toets er in zit
                        {
                            hasToets = true;
                            //vervangt de toets als de huidige toets zijn cijfer hoger is
                            if (list[b].Cijfer < cijfers[i].Cijfer)
                            {
                                list[b] = cijfers[i];
                            }
                        }

                    }
                    //als de toets er niet inzit voeg hem toe
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
