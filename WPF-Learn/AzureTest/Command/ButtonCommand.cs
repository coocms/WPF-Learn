using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace AzureTest.Command
{
    internal class ButtonCommand : ICommand
    {
        Action<string> _action;
        public ButtonCommand(Action<string> action)
        {
            _action = action;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            string key = "30ba7fe54d40410587054a77b83d7b67";
            string endpoint = "https://api.cognitive.microsofttranslator.com/";
            string location = "koreacentral";
            // Input and output languages are defined as parameters.
            string route = "/translate?api-version=3.0&from=zh-Hans&to=en";
            string textToTranslate = parameter.ToString();
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                // location required if you're using a multi-service or regional (not global) resource.
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                dynamic res = JsonConvert.DeserializeObject(result);
                result = res[0].translations[0].text;
                _action(result);
            }
        }
    }
}
