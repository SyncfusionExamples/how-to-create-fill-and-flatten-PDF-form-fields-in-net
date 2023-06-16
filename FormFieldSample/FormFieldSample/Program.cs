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
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
            page.Graphics.DrawString("Job Application", font,PdfBrushes.Black, new PointF(250,0));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            page.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));
            PdfTextBoxField textBoxField1 = new PdfTextBoxField(page, "Name");
            textBoxField1.Bounds = new RectangleF(10, 40, 200, 20);
            textBoxField1.ToolTip = "Name";
            document.Form.Fields.Add(textBoxField1);

            page.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));
            PdfTextBoxField textBoxField2 = new PdfTextBoxField(page, "Email address");
            textBoxField2.Bounds = new RectangleF(10, 100, 200, 20);
            textBoxField2.ToolTip = "Email address";
            document.Form.Fields.Add(textBoxField2);

            page.Graphics.DrawString("Phone", font, PdfBrushes.Black, new PointF(10, 140));
            PdfTextBoxField textBoxField3 = new PdfTextBoxField(page, "Phone");
            textBoxField3.Bounds = new RectangleF(10, 160, 200, 20);
            textBoxField3.ToolTip = "Phone";
            document.Form.Fields.Add(textBoxField3);

            page.Graphics.DrawString("Gender", font, PdfBrushes.Black, new PointF(10, 200));
            PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "Gender");
            document.Form.Fields.Add(employeesRadioList);
            page.Graphics.DrawString("Male", font, PdfBrushes.Black, new PointF(40, 220));
            PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Male");
            radioButtonItem1.Bounds = new RectangleF(10, 220, 20, 20);
            page.Graphics.DrawString("Female", font, PdfBrushes.Black, new PointF(140, 220));
            PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Female");
            radioButtonItem2.Bounds = new RectangleF(110, 220, 20, 20);
            employeesRadioList.Items.Add(radioButtonItem1);
            employeesRadioList.Items.Add(radioButtonItem2);

            using (FileStream outputFileStream= new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                document.Save(outputFileStream);
            }
            document.Close(true);
        }
        static void FillForm() {
            FileStream docStream = new FileStream("Output.pdf", FileMode.Open, FileAccess.Read);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
            PdfLoadedForm form = loadedDocument.Form;
            PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;
            PdfLoadedField loadedField = null;

            if(fieldCollection.TryGetField("Name", out loadedField)) {
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
            form.Flatten=true;

            using (FileStream outputFileStream = new FileStream("FilledPDF.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                loadedDocument.Save(outputFileStream);
            }
            loadedDocument.Close(true);
        }
    }
}