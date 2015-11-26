using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBS2.model.cijfer;

namespace KBS2.model
{
    public class Student
    {
        //variablenen student
        private String naam;
        private String id;
        //lijst van cijfers
        private List<VakCijfer> cijfers;

        public String Naam { get { return naam; } }
        public String ID { get { return id; } }
        public List<VakCijfer> Cijfers { get { return cijfers; } }

        //constructor
        public Student(String naam, String id, List<VakCijfer> cijfers) {
            this.naam = naam;
            this.id = id;
            this.cijfers = cijfers;
        }
        //geeft het totaal gehaalde ec's terug
        public int gehaaldeEC()
        {
            //maakt variabele aan
            int amount = 0;
            //gaat door alle cijfers heen
            for (int i = 0; i < cijfers.Count; i++) {
                //checked of het cijfer voldoende is
                if (cijfers[i].isVoldoende()) {
                    //voegt ecs toe
                    amount += cijfers[i].EC;
                }
            }
            //geeft variabele terug
            return amount;
        }
        //geeft het totaal gemiste ec's terug
        public int gemisteEC()
        {
            //maakt variabele aan
            int amount = 0;
            //gaat door alle cijfers heen
            for (int i = 0; i < cijfers.Count; i++)
            {
                //checked of het onvoldoende is
                if (!cijfers[i].isVoldoende())
                {
                    //voegt ec's toe
                    amount += cijfers[i].EC;
                }
            }
            //geeft totaal terug
            return amount;
        }
        //geeft het totaal mogelijke ec's
        public int totaalEC() {
            //maakt variable aan
            int amount = 0;
            //gaat door alle cijfers heen
            for (int i = 0; i < cijfers.Count; i++)
            {
                //voegt ecs toe
                    amount += cijfers[i].EC;
            }
            //geeft totaal terug
            return amount;
        }
    }
}
