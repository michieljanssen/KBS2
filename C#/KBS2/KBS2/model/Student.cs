using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBS2.model.cijfer;

namespace KBS2.model
{
    class Student
    {
        private String naam;
        private String id;
        private List<VakCijfer> cijfers;

        public String Naam { get { return naam; } }
        public String ID { get { return id; } }
        public List<VakCijfer> Cijfers { get { return cijfers; } }

        public Student(String naam, String id, List<VakCijfer> cijfers) {
            this.naam = naam;
            this.id = id;
            this.cijfers = cijfers;
        }

        public int gehaaldeEC()
        {
            int amount = 0;
            for (int i = 0; i < cijfers.Count; i++) {
                if (cijfers[i].isVoldoende()) {
                    amount += cijfers[i].EC;
                }
            }
            return amount;
        }

        public int gemisteEC()
        {
            int amount = 0;
            for (int i = 0; i < cijfers.Count; i++)
            {
                if (!cijfers[i].isVoldoende())
                {
                    amount += cijfers[i].EC;
                }
            }
            return amount;
        }
        public int totaalEC() {
            int amount = 0;
            for (int i = 0; i < cijfers.Count; i++)
            {
                    amount += cijfers[i].EC;
            }
            return amount;
        }
    }
}
