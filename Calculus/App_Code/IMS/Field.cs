using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public  class Field
    {
       
        public Field(String value, Boolean isError)
        {
            this.value = value;
            this.isEroor = isEroor;
        }

        public Field()
        {
            // TODO: Complete member initialization
        }

      

        public String value { get; set; }
        public Boolean isEroor { get; set; }
        public String key { get; set; }
    }

