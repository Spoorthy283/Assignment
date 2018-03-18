using StoreItem_NutidAB.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StoreItem_NutidAB.Client
{
    class StoreItemClient
    {        
        //Make GET Request to server, and return List of StoreItem 
        public List<StoreItem> GetData(ref String Url, ref HttpStatusCode statusCode) 
        {
            List<StoreItem> storeItems = new List<StoreItem>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = HttpMethod.Get.ToString();
                String responseStr = String.Empty;
            
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;                
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseStr = reader.ReadToEnd();
                    storeItems = JsonConvert.DeserializeObject<List<StoreItem>>(responseStr);
                    reader.Close();
                    dataStream.Close();                   
                }
                response.Close();
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
           
            return storeItems;
        }

        //Serialize List of StoreItem and get json String and make POST request        
        public void UpdateData(ref String Url, List<StoreItem> storeItems, ref HttpStatusCode statusCode) 
        {
            try
            {
                String postJsonData = JsonConvert.SerializeObject(storeItems);
                Console.WriteLine("Json  " + postJsonData);
                UpdateData(ref Url, ref postJsonData, ref statusCode);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception(e.Message);                
            }
        }

        //Make POST request 
        public void UpdateData(ref String Url, ref String postJsonData, ref HttpStatusCode statusCode)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = HttpMethod.Post.ToString();
            
                if (postJsonData != string.Empty)
                {
                    Stream dataStream = request.GetRequestStream();
                    request.ContentType = "application/Json";
                    byte[] byteArray = Encoding.UTF8.GetBytes(postJsonData);
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    statusCode = response.StatusCode;                   
                }
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }            
        }

    }
}
