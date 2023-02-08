using System;
using System.Text;
using System.Web;
using System.Net;
using System.IO;


public class Program
{
    public static void Main()
    {
        string apiToken = "your token"; //Your api_token At Lifetimesms.com
        string apiSecret = "your secert?"; //Your api_secret  At Lifetimesms.com
        string toNumber = "number"; //Your cell phone number with country code
        string Masking = "mask"; //Your Company Brand Name 
        string MessageText = "SMS Sent using .Net Testing";

        string jsonResponse = SendSMSPOST(apiToken, apiSecret, toNumber, Masking, MessageText);
        Console.WriteLine(jsonResponse);
    }
    public static string SendSMSPOST(string apiToken, string apiSecret, string toNumber, string Masking, string MessageText)
    {

        String api = "https://lifetimesms.com/json";
        String parameters = "api_token=" + apiToken + "&api_secret=" + apiSecret + "&to=" + toNumber + "&from=" + Masking + "&message=" + MessageText;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
        httpWebRequest.Accept = "application/json";
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        httpWebRequest.Method = "POST";
        using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
        {

            parameters = "api_token=" + apiToken + "&api_secret=" + apiSecret + "&to=" + toNumber + "&from=" + Masking + "&message=" + MessageText;


            streamWriter.Write(parameters);
            streamWriter.Flush();
            streamWriter.Close();
        }


        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            return result.ToString();

        }


        return null;
    }

}