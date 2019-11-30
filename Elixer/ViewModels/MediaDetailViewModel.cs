using Elixer.Models;
using System;
using System.Text;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace Elixer.ViewModels
{
    public class MediaDetailViewModel : MyBaseViewModel
    {
        public Media media { get; set; }

        public MediaDetailViewModel(Media item = null)
        {
            Title = item?.title;
            media = item;
        }
        string text;

        public string GetTextFromPDF(string url)
        {
            try
            {
                StringBuilder ster = new StringBuilder();
                //DocumentModel document = DocumentModel.Load(url);
                PdfReader read = new PdfReader(url);
                iText.Kernel.Pdf.PdfDocument doc = new iText.Kernel.Pdf.PdfDocument(read);
                //foreach (var page in doc.GetPage(int page))
                for (int i = 0; i <= doc.GetNumberOfPages(); i++)
                {
                    var word = ster.Append(PdfTextExtractor.GetTextFromPage(doc.GetPage(i)));
                    text = word.ToString();
                }
                return text;
               
            }
            catch (Exception ex)
            {
                text = "Error reading file";
                return text;
            }
        }

        //private string GetTextFromWord(string url)
        //{
        //    StringBuilder ster = new StringBuilder();
        //    Document doc = new Document();
        //    var ter = doc.LocalName;
        //}
        //private string GetTextFromsWord(string url)
        //{
        //    // Set license key to use GemBox.Document in Free mode(20 paragraphs).
        //    //ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        //    GemBox.Pdf.PdfDocument document = GemBox.Pdf.PdfDocument.Load(url);
        //    foreach (var page in document.Pages)
        //    {
        //        text = page.Content.ToString();
        //        //return text;
        //    }
        //    return text;

        //}

        public string GetTextFromText(string url)
        {
            string text = File.ReadAllText(url);
            return text.ToString();
        }

        //void BtnPlayVideo_Clicked(object sender, EventArgs e)
        //{
        //    CrossMediaManager.Current.Play(media.file);
        //}

        //void BtnStopVideo_Clicked(object sender, EventArgs e)
        //{
        //    CrossMediaManager.Current.Stop();
        //}

        

    }
}
