﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.model.cijfer
{
    public class ToetsCijfer: Gradable
    {
        //data variabelen van de toets
        private String leerlingid;
        private String leerlingnaam;
        private String toetsnaam;
        private double cijfer;
        private String datum;

        public double Cijfer { get { return cijfer; } }
        public String Datum { get { return datum; } }
        public String Naam { get { return leerlingnaam; } }
        public String ID { get { return leerlingid; } }
        public String toetsName { get { return toetsnaam; } }
        
        //constructor
        public ToetsCijfer(String leerlingid, String leerlingnaam, String toetsnaam, double cijfer, String datum) {
            this.toetsnaam = toetsnaam;
            this.datum = datum;
            this.leerlingid = leerlingid;
            this.leerlingnaam = leerlingnaam;
            this.cijfer = cijfer;
        }
        
        //check voor voldoende
        public Boolean ECsBehaald() {
            return cijfer >= 5.5;
        }
    }
}
