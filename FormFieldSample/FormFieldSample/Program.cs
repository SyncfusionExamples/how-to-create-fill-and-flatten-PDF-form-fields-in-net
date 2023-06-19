using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;

namespace FormFieldSample {
    internal class Program {
        static void Main(string[] args) {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VFhhQlVEfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Qd0FjUH5fdX1RR2ZZ  ");

            CreateForm();
            FillForm();
        }
        static void CreateForm() {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a new page to the PDF document.
            PdfPage page = document.Pages.Add();
            //Set the font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
            //Draw the text.
            page.Graphics.DrawString("Job Application", font,PdfBrushes.Black, new PointF(250,0));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            page.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));
            //Create a textbox field and add the properties.
            PdfTextBoxField textBoxField1 = new PdfTextBoxField(page, "Name");
            textBoxField1.Bounds = new RectangleF(10, 40, 200, 20);
            textBoxField1.ToolTip = "Name";
            //Add the form field to the document.
            document.Form.Fields.Add(textBoxField1);

            page.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));
            //Create a textbox field and add the properties.
            PdfTextBoxField textBoxField2 = new PdfTextBoxField(page, "Email address");
            textBoxField2.Bounds = new RectangleF(10, 100, 200, 20);
            textBoxField2.ToolTip = "Email address";
            //Add the form field to the document.
            document.Form.Fields.Add(textBoxField2);

            page.Graphics.DrawString("Phone", font, PdfBrushes.Black, new PointF(10, 140));
            //Create a textbox field and add the properties.
            PdfTextBoxField textBoxField3 = new PdfTextBoxField(page, "Phone");
            textBoxField3.Bounds = new RectangleF(10, 160, 200, 20);
            textBoxField3.ToolTip = "Phone";
            //Add the form field to the document.
            document.Form.Fields.Add(textBoxField3);

            page.Graphics.DrawString("Gender", font, PdfBrushes.Black, new PointF(10, 200));
            //Create a Radio button.
            PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "Gender");
            //Add the radio button into form.
            document.Form.Fields.Add(employeesRadioList);
            //Create radio button items.
            page.Graphics.DrawString("Male", font, PdfBrushes.Black, new PointF(40, 220));
            PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Male");
            radioButtonItem1.Bounds = new RectangleF(10, 220, 20, 20);
            page.Graphics.DrawString("Female", font, PdfBrushes.Black, new PointF(140, 220));
            PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Female");
            radioButtonItem2.Bounds = new RectangleF(110, 220, 20, 20);
            //Add the items to radio button group.
            employeesRadioList.Items.Add(radioButtonItem1);
            employeesRadioList.Items.Add(radioButtonItem2);

            //Create file stream.
            using (FileStream outputFileStream= new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
        static void FillForm() {
            //Get stream from an existing PDF document.
            FileStream docStream = new FileStream("Output.pdf", FileMode.Open, FileAccess.Read);
            //Load the existing PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
            //Load the form from the loaded document.
            PdfLoadedForm form = loadedDocument.Form;
            //Load the form field collections from the form.
            PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;
            PdfLoadedField loadedField = null;

            //Get the field using TryGetField Method.
            if (fieldCollection.TryGetField("Name", out loadedField)) {
                (loadedField as PdfLoadedTextBoxField).Text = "Simons";
            }
            if (fieldCollection.TryGetField("Email address", out loadedField)) {
                (loadedField as PdfLoadedTextBoxField).Text = "simonsbistro@outlook.com";
            }
            if (fieldCollection.TryGetField("Phone", out loadedField)) {
                (loadedField as PdfLoadedTextBoxField).Text = "31 12 34 56";
            }
            if (fieldCollection.TryGetField("Gender", out loadedField)) {
                (loadedField as PdfLoadedRadioButtonListField).SelectedIndex = 0;
            }
            //Flatten the whole form.
            form.Flatten=true;

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("FilledPDF.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream. 
                loadedDocument.Save(outputFileStream);
            }
            //Close the document.
            loadedDocument.Close(true);
        }
    }
}