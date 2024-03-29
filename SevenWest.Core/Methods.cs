﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SevenWest.Core
{
    
    public class Methods
    {
        public static List<Person> GetPersons()
        {
            var persons = new List<Person>();

            try
            {
                using (StreamReader r = new StreamReader("example_data.json"))
                {
                    string json = r.ReadToEnd();
                    persons = JsonConvert.DeserializeObject<List<Person>>(json);
                }
            }
            catch (JsonException exception)
            {
                // Do some meaningful logging/error reporting here. Either Log4Net or maybe a messaging framework if applicable
            }

            return persons;
        }
        
        // The JSON read in currently isn't validated. There's some semantic issues with the data too.
        // For instance:
        //  - There's duplicate ids
        //  - Invalid Gender letters

        // I considered having some validation checks against it using a jsonschema and
        // JSONObject and outputting/logging lines that didn't meet the expected format.
        // The downside to this approach would be any other data sources would have to
        // have their own data validators implemented with their own integration/mapping
        // class hence why I put some basic validation in the PersonQueries class.
        
    }

}
