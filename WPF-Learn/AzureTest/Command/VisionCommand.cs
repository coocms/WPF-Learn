using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows;

namespace AzureTest.Command
{
    internal class VisionCommand : ICommand
    {
        //InkCanvas _inkCanvas;
        public VisionCommand(InkCanvas inkCanvas)
        {
            //_inkCanvas = inkCanvas;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            

            string subscriptionKey = "025515d379ce475fa68770e33aa637b9";
            string endpoint = "https://cooc-vision.cognitiveservices.azure.com/";
            string file = @"F:\github\test.png";
            CreateBitmapFromVisual(parameter as Visual, file);
            
            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);

            await ReadFileUrl(client, File.OpenRead(file));

        }
        ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }
        public async Task ReadFileUrl(ComputerVisionClient client, Stream st)
        {


            // Read text from URL

            //ReadHeaders textHeaders = await client.ReadAsync(urlFile);

            ReadInStreamHeaders header = await client.ReadInStreamAsync(st);

            // After the request, get the operation location (operation ID)
            //string operationLocation = textHeaders.OperationLocation;
            string operationLocation = header.OperationLocation;

            Thread.Sleep(2000);

            // <snippet_extract_response>
            // Retrieve the URI where the recognized text will be stored from the Operation-Location header.
            // We only need the ID and not the full URL
            const int numberOfCharsInOperationId = 36;
            string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

            // Extract the text
            ReadOperationResult results;
            Console.WriteLine($"Reading text from local file ...");
            Console.WriteLine();
            do
            {
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while ((results.Status == OperationStatusCodes.Running ||
                results.Status == OperationStatusCodes.NotStarted));
            // </snippet_extract_response>

            // <snippet_extract_display>
            // Display the found text.
            Console.WriteLine();
            var textUrlFileResults = results.AnalyzeResult.ReadResults;
            foreach (ReadResult page in textUrlFileResults)
            {
                foreach (Line line in page.Lines)
                {
                    Console.WriteLine(line.Text);
                }
            }
            Console.WriteLine();
        }
        

        public void CreateBitmapFromVisual(Visual target, string fileName)
        {
            if (target == null || string.IsNullOrEmpty(fileName)) return;
            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
            RenderTargetBitmap renderTarget = new RenderTargetBitmap((Int32) bounds.Width,
                (Int32) bounds.Height, 96, 96, PixelFormats.Pbgra32);
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext context = visual.RenderOpen())
            {
                VisualBrush visualBrush = new VisualBrush(target);
                context.DrawRectangle(visualBrush, null, new Rect(new System.Windows.Point(), bounds.Size));
            }
            renderTarget.Render(visual);
            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            using (Stream stm = File.Create(fileName))
            {
                bitmapEncoder.Save(stm);
            }

        }
    }

}


