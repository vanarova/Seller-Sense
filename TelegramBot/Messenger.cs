using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TelegramBot
{
    public class Messenger
    {

        //public static async Task Send(string msg)
        // {
        //     string botToken = "6690932378:AAEqzJfgbgUNic4S30aSkdXdStoz8eB8574";


        //     await SendTelegramMessage(botToken, 1890586948, "some mg");  //personal
        //     await SendTelegramMessage(botToken, -889985488, "some mg");  //grp

        // }

        private static LogDepth _logLevel;


        public enum LogDepth
        {
            LogAllActions, LogDataImportsExports, LogOnlyWhenUserWants
        }

        public Messenger()
        {
            _logLevel = LogDepth.LogAllActions;
        }
        
       

        public static async Task<string> SendTelegramMessage(string botToken, long chatId, 
            string message)
        {
            //if (logDepth != _logLevel)
            //    return;
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.telegram.org/bot{botToken}/sendMessage";
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("chat_id", chatId.ToString()),
                new KeyValuePair<string, string>("text", message)
                //new KeyValuePair<string, string>("parse_mode", "markdown")
            });

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                //if (response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine("Message sent successfully!");
                //}
                //else
                //{
                //    Console.WriteLine($"Message sending failed. Response: {responseContent}");
                //}
                return responseContent;
            }
        }

        public static async Task SendTelegramImage(string botToken, long chatId, string message,
            string imagePath, string fileName)
        {
           
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.telegram.org/bot{botToken}/sendPhoto";
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(chatId.ToString()), "chat_id");
                content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(imagePath)), "photo", fileName);
                content.Add(new StringContent(message), "caption");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
               //Task< HttpResponseMessage> t = client.PostAsync(apiUrl, content);
               // t.RunSynchronously();
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Image sent successfully!");
                }
                else
                {
                    Console.WriteLine($"Image sending failed. Response: {responseContent}");
                }
            }
        }



        public static async Task SendTelegramFile(string botToken, long chatId, 
            string filePath, string fileName)
        {
           
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.telegram.org/bot{botToken}/sendDocument";
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(chatId.ToString()), "chat_id");
                content.Add(new ByteArrayContent(File.ReadAllBytes(Path.Combine(filePath,fileName))), "document", fileName);

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("File sent successfully!");
                }
                else
                {
                    Console.WriteLine($"File sending failed. Response: {responseContent}");
                }
            }
        }





    }
}