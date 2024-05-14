using CommunityToolkit.Maui.Behaviors;
using System.Globalization;

namespace Contador.Views;

public partial class Contador : ContentPage
{
    public Contador()
    {
        InitializeComponent();
        BindingContext = App.ViewModel;

        //((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).CopyNumb != "0")
        {
            ((ViewModel.ViewModel)BindingContext).CurrentPaste = ((ViewModel.ViewModel)BindingContext).CopyNumb.ToString(CultureInfo.InvariantCulture);
            if (((ViewModel.ViewModel)BindingContext).CurrentPaste == "")
            {
                ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
            }
        }
    }
    class NumericValidationBehaviorPage : ContentPage
    {
        public NumericValidationBehaviorPage()
        {
            var entry = new Entry
            {
                Keyboard = Keyboard.Numeric

            };

            var validStyle = new Style(typeof(Entry));
            validStyle.Setters.Add(new Setter
            {
                Property = Entry.TextColorProperty,
                Value = Colors.Green
            });

            var invalidStyle = new Style(typeof(Entry));
            invalidStyle.Setters.Add(new Setter
            {
                Property = Entry.TextColorProperty,
                Value = Colors.Red
            });

            var numericValidationBehavior = new NumericValidationBehavior
            {
                InvalidStyle = invalidStyle,
                ValidStyle = validStyle,
                Flags = ValidationFlags.ValidateOnValueChanged,
                MinimumValue = 0,
                MaximumDecimalPlaces = 0
            };

            entry.Behaviors.Add(numericValidationBehavior);

            Content = entry;
        }
    }

    public void Current1_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current1 == "0")
            ((ViewModel.ViewModel)BindingContext).Current1 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent1.Focus();
    }
    private void Current5_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current5 == "0")
            ((ViewModel.ViewModel)BindingContext).Current5 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent5.Focus();

    }
    private void Current10_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current10 == "0")
            ((ViewModel.ViewModel)BindingContext).Current10 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent10.Focus();

    }
    private void Current20_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current20 == "0")
            ((ViewModel.ViewModel)BindingContext).Current20 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent20.Focus();

    }
    private void Current50_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current50 == "0")
            ((ViewModel.ViewModel)BindingContext).Current50 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent50.Focus();

    }
    private void Current100_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current100 == "0")
            ((ViewModel.ViewModel)BindingContext).Current100 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent100.Focus();
    }
    private void Current200_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current200 == "0")
            ((ViewModel.ViewModel)BindingContext).Current200 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent200.Focus();
    }
    private void Current500_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current500 == "0")
            ((ViewModel.ViewModel)BindingContext).Current500 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent500.Focus();
    }
    private void Current1000_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).Current1000 == "0")
            ((ViewModel.ViewModel)BindingContext).Current1000 = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyCurrent1000.Focus();
    }
    //private void CurrentPaste_OnFocused(object sender, FocusEventArgs e)
    //{
    //    if (((ViewModel.ViewModel)BindingContext).CurrentPaste == "0")
    //        ((ViewModel.ViewModel)BindingContext).CurrentPaste = string.Empty;

    //    if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current1 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current5 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current10 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current20 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current50 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current100 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current200 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current500 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
    //    if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";
    //    if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
    //        ((ViewModel.ViewModel)BindingContext).CantMoney = "0";
    //}
    private void ChangeMoney_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == "0")
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).CantMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).CantMoney = "0";

        MyChangeMoney.Focus();
    }
    private void CantMoney_OnFocused(object sender, FocusEventArgs e)
    {
        if (((ViewModel.ViewModel)BindingContext).CantMoney == "0")
            ((ViewModel.ViewModel)BindingContext).CantMoney = string.Empty;

        if (((ViewModel.ViewModel)BindingContext).Current1 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current5 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current5 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current10 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current10 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current20 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current20 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current50 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current50 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current100 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current100 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current200 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current200 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current500 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current500 = "0";
        if (((ViewModel.ViewModel)BindingContext).Current1000 == string.Empty)
            ((ViewModel.ViewModel)BindingContext).Current1000 = "0";
        //if (((ViewModel.ViewModel)BindingContext).CurrentPaste == string.Empty)
        //    ((ViewModel.ViewModel)BindingContext).CurrentPaste = "0";
        if (((ViewModel.ViewModel)BindingContext).ChangeMoney == string.Empty)
            ((ViewModel.ViewModel)BindingContext).ChangeMoney = "0";

        MyCantMoney.Focus();
    }
}