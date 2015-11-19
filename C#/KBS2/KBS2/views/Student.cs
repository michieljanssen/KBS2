using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBS2.cijfer;

namespace KBS2.views
{
    class Student
    {
        private String naam;
        private String id;
        private List<VakCijfer> cijfers;

        public Student(String naam, String id, List<VakCijfer> cijfers) {
            this.naam = naam;
            this.id = id;
            this.cijfers = cijfers;
        }

    }
}
