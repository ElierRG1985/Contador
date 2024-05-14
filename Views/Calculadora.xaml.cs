using Microsoft.Maui;
//using ObjCRuntime;
using System.Globalization;

namespace Contador.Views;

public partial class Calculadora : ContentPage
{
    public Calculadora()
    {
        InitializeComponent();
        BindingContext = App.ViewModel;
    }
}

class LabelAutoFontSize : Label
{
    protected override void OnSizeAllocated(double width, double height)
    {
        //call base implementation
        base.OnSizeAllocated(width, height);

        //update font size
        AutoFontSize();
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == "Text")
        {
            AutoFontSize();
        }
    }

    private void AutoFontSize()
    {
        //determine the text height for the min font size
        double lowerFontSize = 20;
        double lowerTextHeight = TextHeightForFontSize(lowerFontSize);

        //determine the text height for the max font size
        double upperFontSize = 50;
        double upperTextHeight = TextHeightForFontSize(upperFontSize);

        //start a loop which'll find the optimal font size
        while (upperFontSize - lowerFontSize > 1)
        {
            //determine current average font size and calculate corresponding text height
            double fontSize = (lowerFontSize + upperFontSize) / 2;
            double textHeight = TextHeightForFontSize(fontSize); // Correcci�n aqu�

            //if the calculated height is out of bounds, update max values, else update min values
            if (textHeight > Height)
            {
                upperFontSize = fontSize;
                upperTextHeight = textHeight;
            }
            else
            {
                lowerFontSize = fontSize;
                lowerTextHeight = textHeight;
            }
        }

        //finally set the correct font size
        FontSize = lowerFontSize;
    }
    private double TextHeightForFontSize(double fontSize)
    {
        FontSize = fontSize;
        return OnMeasure(Width, Double.PositiveInfinity).Request.Height;
    }
}

class LabelAutoFontSizeERG : Label
{
    protected override void OnSizeAllocated(double width, double height)
    {
        // Llama a la implementaci�n base
        base.OnSizeAllocated(width, height);

        // Actualiza el tama�o de fuente
        AutoFontSize();
    }
    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == "Text")
        {
            AutoFontSize();
        }
    }
    private void AutoFontSize()
    {
        // Determina la altura del texto para el tama�o de fuente m�nimo
        double lowerFontSize = 10;
        double lowerTextHeight = TextHeightForFontSize(lowerFontSize);

        // Determina la altura del texto para el tama�o de fuente m�ximo
        double upperFontSize = 35;
        double upperTextHeight = TextHeightForFontSize(upperFontSize);

        // Inicia un bucle que encontrar� el tama�o de fuente �ptimo
        while (upperFontSize - lowerFontSize > 1)
        {
            // Calcula el tama�o de fuente promedio actual y la altura de texto correspondiente
            double fontSize = (lowerFontSize + upperFontSize) / 2;
            double textHeight = TextHeightForFontSize(fontSize);

            // Si la altura calculada est� fuera de los l�mites, actualiza los valores m�ximos; de lo contrario, actualiza los valores m�nimos
            if (textHeight > Height)
            {
                upperFontSize = fontSize;
                upperTextHeight = textHeight;
            }
            else
            {
                lowerFontSize = fontSize;
                lowerTextHeight = textHeight;
            }
        }
        // Finalmente, establece el tama�o de fuente correcto
        FontSize = lowerFontSize;
    }
    private double TextHeightForFontSize(double fontSize)
    {
        FontSize = fontSize;
        return OnMeasure(Width, Double.PositiveInfinity).Request.Height;
    }
}