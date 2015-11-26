using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBS2.model.cijfer;

namespace KBS2.model
{
    class Toets
    {
        //toets variabele
        private String naam;
        private String type;
        //lijst van cijfers
        private List<ToetsCijfer> cijfers;

        public String Type { get { return type; } }
        public String Naam { get { return naam; } }
        public List<ToetsCijfer> Cijfers { get { return cijfers; } }
        
        //constructor
        public Toets(String naam, String type,List<ToetsCijfer> cijfers)
        {
            this.naam = naam;
            this.type = type;
            this.cijfers = cijfers;
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
                return gemiddelde;
            }
            else {
                //anders als er geen cijfers zijn: geef 0.0 terug
                return 0.0;
            }
        }
        
        //geeft het aantal voldoendes terug
        public int voldoendes()
        {
            //maakt variabele aan voor aantal voldoendes
            int amount = 0;
            
            //gaat door alle cijfers heen
            for (int i = 0; i < cijfers.Count; i++)
            {
                //checked of cijfer voldoende is
                if (cijfers[i].isVoldoende()) {
                    //voegt cijfer toe
                    amount++;
                }
            }
            
            //geeft totaal terug
            return amount;
        }
        
        //geeft aantal onvoldoendes terug
        public int onvoldoendes()
        {
            //maakt variabele aan voor aantal onvoldoendes
            int amount = 0;
            
            //gaat door alle cijfers heen
            for (int i = 0; i < cijfers.Count; i++)
            {
                //checked aantal onvoldoendes
                if (!cijfers[i].isVoldoende())
                {
                    //voegt cijfer toe
                    amount++;
                }
            }
            
            //geeft totaal terug
            return amount;
        }
        
        //berekent het percentage voldoendes terug
        public int percentageVold()
        {
            //checked of het aantal cijfers groter is dan 0
            if (cijfers.Count > 0)
            {
                //geeft het percentage terug
                return (voldoendes() * 100) / (cijfers.Count);
            }
            else {
                //anders geef 0 terug
                return 0;
            }
        }

    }
}
