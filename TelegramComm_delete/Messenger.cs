namespace TelegramComm
{
    public class Messenger
    {

       public static async Task Send(string[] args)
        {
            string botToken = "6690932378:AAEqzJfgbgUNic4S30aSkdXdStoz8eB8574";
            string chatId = "@sellersense";
            string message = "Hello, from your Telegram bot!";

            await SendTelegramMessage(botToken, chatId, message);
        }

       public static async Task SendTelegramMessage(string botToken, string chatId, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.telegram.org/bot{botToken}/sendMessage";
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("chat_id", chatId.ToString()),
                new KeyValuePair<string, string>("text", message)
            });

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully!");
                }
                else
                {
                    Console.WriteLine($"Message sending failed. Response: {responseContent}");
                }
            }
        }

    }
}