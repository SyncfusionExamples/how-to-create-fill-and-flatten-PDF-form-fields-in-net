# How to Create, Fill, and Flatten PDF Form Fields in .NET using the Syncfusion&reg; PDF Library

## Introduction
A quick start .NET console project that shows how to create, fill, and flatten PDF form fields using the Syncfusion&reg; PDF Library.

## System requirement
**Framework and SDKs**
* .NET SDK (version 5.0 or later)

**IDEs**
*  Visual Studio 2019/ Visual Studio 2022

## Code snippet for Create, Fill, and Flatten PDF Form Fields
We will create a new .NET console application, add the Syncfusion&reg; PDF library package, and write the code

```csharp
static void CreateForm() 
{
    //Create a new PDF document.
    PdfDocument document = new PdfDocument();
    //Add a new page to the PDF document.
    PdfPage page = document.Pages.Add();
    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
    //Draw the text.
    page.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0));

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
    page.Graphics.DrawString("Male", font, PdfBrushes.Black, new PointF(40, 220));
    //Create radio button items.
    PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Male");
    radioButtonItem1.Bounds = new RectangleF(10, 220, 20, 20);
    page.Graphics.DrawString("Female", font, PdfBrushes.Black, new PointF(140, 220));
    PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Female");
    radioButtonItem2.Bounds = new RectangleF(110, 220, 20, 20);
    //Add the items to radio button group.
    employeesRadioList.Items.Add(radioButtonItem1);
    employeesRadioList.Items.Add(radioButtonItem2);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) 
    {       
        //Save the PDF document to file stream. 
        document.Save(outputFileStream);
    }
    //Close the document.
    document.Close(true);
}

static void FillForm() 
{
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
    form.Flatten = true;
    
    //Create file stream.
    using (FileStream outputFileStream = new FileStream("FilledPDF.pdf", FileMode.Create, FileAccess.ReadWrite)) {
        //Save the PDF document to file stream. 
        loadedDocument.Save(outputFileStream);
    }
    //Close the document.
    loadedDocument.Close(true);
}
```

**Output Image**

**CreateFormPDF**
<img src="FormFieldSample/FormFieldSample/Output_images/CreateFormPDF.png" alt="Output_Image" width="100%" Height="Auto"/>

**FilledPDF**
<img src="FormFieldSample/FormFieldSample/Output_images/FilledPDF.png" alt="output_image" width="100%" Height="Auto"/>

## How to run the examples
* Download this project to a location in your disk. 
* Open the solution file using Visual Studio. 
* Rebuild the solution to install the required NuGet package. 
* Run the application.

## Resources
*   **Product page:** [Syncfusion&reg; PDF Framework](https://www.syncfusion.com/document-processing/pdf-framework/net)
*   **Documentation page:** [Syncfusion&reg; .NET PDF library](https://help.syncfusion.com/file-formats/pdf/overview)
*   **Online demo:** [Syncfusion&reg; .NET PDF library - Online demos](https://ej2.syncfusion.com/aspnetcore/PDF/CompressExistingPDF#/bootstrap5)
*   **Blog:** [Syncfusion&reg; .NET PDF library - Blog](https://www.syncfusion.com/blogs/category/pdf)
*   **Knowledge Base:** [Syncfusion&reg; .NET PDF library - Knowledge Base](https://www.syncfusion.com/kb/windowsforms/pdf)
*   **EBooks:** [Syncfusion&reg; .NET PDF library - EBooks](https://www.syncfusion.com/succinctly-free-ebooks)
*   **FAQ:** [Syncfusion&reg; .NET PDF library - FAQ](https://www.syncfusion.com/faq/)

## Support and feedback
*   For any other queries, reach our [Syncfusion&reg; support team](https://www.syncfusion.com/support/directtrac/incidents/newincident?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples) or post the queries through the [community forums](https://www.syncfusion.com/forums?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples).
*   Request new feature through [Syncfusion&reg; feedback portal](https://www.syncfusion.com/feedback?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples).

## License
This is a commercial product and requires a paid license for possession or use. Syncfusion’s licensed software, including this component, is subject to the terms and conditions of [Syncfusion's EULA](https://www.syncfusion.com/eula/es/?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples). You can purchase a licnense [here](https://www.syncfusion.com/sales/products?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples) or start a free 30-day trial [here](https://www.syncfusion.com/account/manage-trials/start-trials?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples).

## About Syncfusion
Founded in 2001 and headquartered in Research Triangle Park, N.C., Syncfusion&reg; has more than 26,000+ customers and more than 1 million users, including large financial institutions, Fortune 500 companies, and global IT consultancies.

Today, we provide 1600+ components and frameworks for web ([Blazor](https://www.syncfusion.com/blazor-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [ASP.NET Core](https://www.syncfusion.com/aspnet-core-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [ASP.NET MVC](https://www.syncfusion.com/aspnet-mvc-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [ASP.NET WebForms](https://www.syncfusion.com/jquery/aspnet-webforms-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [JavaScript](https://www.syncfusion.com/javascript-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Angular](https://www.syncfusion.com/angular-ui-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [React](https://www.syncfusion.com/react-ui-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Vue](https://www.syncfusion.com/vue-ui-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), and [Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples)), mobile ([Xamarin](https://www.syncfusion.com/xamarin-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [UWP](https://www.syncfusion.com/uwp-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), and [JavaScript](https://www.syncfusion.com/javascript-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples)), and desktop development ([WinForms](https://www.syncfusion.com/winforms-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [WPF](https://www.syncfusion.com/wpf-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [WinUI(Preview)](https://www.syncfusion.com/winui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples) and [UWP](https://www.syncfusion.com/uwp-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples)). We provide ready-to-deploy enterprise software for dashboards, reports, data integration, and big data processing. Many customers have saved millions in licensing fees by deploying our software.