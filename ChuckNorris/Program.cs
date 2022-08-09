using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace ChuckNorris

{

    class Program2
    {
    static void Main(string[] args)
        {
            using(HttpClient? source = new HttpClient())//Send HTTP requests and receive HTTP responses
                {   
                    Uri? endpoint = new Uri("http://api.icndb.com/jokes/random?firstName=Ringo&lastName=Starr"); //Source url changes Chuck Norris to Ringo Starr

                    HttpResponseMessage? result = source.GetAsync(endpoint).Result; //HTTP response messasge and status
            
                    string? json = result.Content.ReadAsStringAsync().Result; //Convert result to JSON   
                
                    Console.WriteLine(json); //Output the JSON
                }
        }//EoM
    }//EoC

}//EoN

