using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SeleniumFramwork
{
    public class Jasondataread
    {
        public Root Jasonfiledata()
        {
            using (StreamReader r = new StreamReader("C:/Users/Ashrith/source/repos/SeleniumFramwork/SeleniumFramwork/sample.json"))
            {
                string jsonData = r.ReadToEnd();
                string json = JsonConvert.SerializeObject("PartyDetails");
                Root fileData = JsonConvert.DeserializeObject<Root>(jsonData);
                return fileData;


            }



        }


         public class PartyDetails
         {
           public string TypeOfParty { get; set; }
           public string Language { get; set; }
         }

        public class Personaldetails
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
           public string Gender { get; set; }
        }

         public class Root
        {
            public List<PartyDetails> PartyDetails { get; set; }
            public List<Personaldetails> Personaldetails { get; set; }
            public List<Propertydetails> Propertydetails { get; set; }

    }
        public class Propertydetails
        {
            public string Land { get; set; }
            public string House { get; set; }
            
        }


    }
}

