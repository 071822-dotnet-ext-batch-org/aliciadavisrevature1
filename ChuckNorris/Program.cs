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

                    Console.WriteLine(); //Create a line space

                    Uri? endpoint2 = new Uri("http://api.icndb.com/jokes/random?exclude=[explicit]"); //Source url changes category of jokes retrieved to nerdy ones

                    HttpResponseMessage? result2 = source.GetAsync(endpoint2).Result; //HTTP response messasge and status
            
                    string? json2 = result2.Content.ReadAsStringAsync().Result; //Convert result to JSON   
                
                    Console.WriteLine(json2); //Output the JSON
                }
        }//EoM
    }//EoC

}//EoN

