//using Java.Sql;

using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration;
//using static Android.Preferences.PreferenceActivity;

namespace Contador.ViewModel
{
    public partial class ViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public ViewModel()
        {
            CopyPasteTitle = "❐";
            ParentesisTitle = "[ ]";
        }

        private const string Value = ")";

        #endregion

        [ObservableProperty] string _currentCalculation;
        [ObservableProperty] double _fontSize;
        [ObservableProperty] int _countClear = 0;
        [ObservableProperty] bool _countCopy = false;
        [ObservableProperty] string _copyNumb = "";
        [ObservableProperty] int _copyNumbTwo = 0;
        [ObservableProperty] string _copyPasteTitle;
        [ObservableProperty] string _copyTitle = "";
        [ObservableProperty] string _parentesisTitle;
        [ObservableProperty] string _operationsHistory;
        [ObservableProperty] ObservableCollection<string> _operations =
        [
            "0"
        ];
        [ObservableProperty] string _currentCalculationMoney = "0";
        [ObservableProperty] int _currentCalculationTwo = 0;
        [ObservableProperty] bool _isEnable = false;
        [ObservableProperty] bool _isEnableClearContador = false;
        [ObservableProperty] bool _isEnableCopyContador = false;
        [ObservableProperty] bool _isEnableCero = false;
        [ObservableProperty] bool _isEnableNum = true;
        [ObservableProperty] bool _isEnableClear = false;
        [ObservableProperty] bool _isEnableCopy = false;
        [ObservableProperty] bool _isEnableDecimalPoint = true;
        [ObservableProperty] bool _isEnableParentheses = true;
        [ObservableProperty] bool _isEnableCalculus = false;
        [ObservableProperty] bool _isBalanced = true;
        [ObservableProperty] string _textColorClear = "Grey";
        [ObservableProperty] string _textColorCopy = "Grey";
        [ObservableProperty] string _current1 = "0";
        [ObservableProperty] string _current5 = "0";
        [ObservableProperty] string _current10 = "0";
        [ObservableProperty] string _current20 = "0";
        [ObservableProperty] string _current50 = "0";
        [ObservableProperty] string _current100 = "0";
        [ObservableProperty] string _current200 = "0";
        [ObservableProperty] string _current500 = "0";
        [ObservableProperty] string _current1000 = "0";
        [ObservableProperty] string _currentPaste = "0";
        [ObservableProperty] int _moneyChange = 0;
        [ObservableProperty] string _changeMoney = "0";
        [ObservableProperty] string _cantMoney = "0";

        //[RelayCommand]
        //async Task Navigation(string url)
        //{
        //    await
        //    Shell.Current.GoToAsync("///" + url);
        //}

        [RelayCommand]
        void Clear()
        {
            if (CountCopy)
            {
                CountCopy = false;
            } else
            {
                CopyNumb = "";
                CopyPasteTitle = "❐";
                CopyTitle = "";
                CountClear -= 2;
            }

            OperationsHistory = "";

            Operations =
            [
                "0"
            ];
            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
            //CurrentCalculation = 0;
            CurrentCalculation = "";
            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.CurrentCalculation));
            //CopyPasteTitle = "❐";
            ParentesisTitle = "[ ]";

            CurrentPaste = "0";

            CountClear ++;

            IsEnableNum = true;
            IsEnableDecimalPoint = true;
            IsEnableParentheses = true;
            IsEnableCalculus = false;
            IsEnableAction();
        }

        [RelayCommand]
        void OperationAction(string operation)
        {
            var pos = Operations.Count;

            if (!System.Text.RegularExpressions.Regex.IsMatch(Operations[pos - 1], @"^\d+(\.\d+)?$"))
            {
                if (!Operations[pos - 1].EndsWith(Value))
                {
                    return;
                }
            }

            if (Operations[pos - 1] is "+" or "–" or "÷" or "×")
                Operations[pos - 1] = operation;

            else if (Operations[pos - 1].EndsWith("."))
            {
                return;
            }

            else if (Operations[0] == "0")
            {
                return;
            }

            else
                Operations.Add(operation);
            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));

            IsEnableNum = true;
            IsEnableDecimalPoint = true;
            IsEnableParentheses = true;
            IsEnableCalculus = false;
            IsEnableAction();
        }

        [RelayCommand]
        void SelectNumber(int number)
        {
            if (Enumerable.LastOrDefault<string>(Operations) is "+" or "–" or "÷" or "×")
                Operations.Add("0");

            var pos = Operations.Count;

            if (Operations[pos - 1].Contains(")"))
            {
                return;
            }

            if (Operations[pos - 1].Length == 12)
            {
                IsEnableNum = false;
                IsEnableCero = false;
                return;
            }

            if (CurrentCalculation is not null && CurrentCalculation.Length >= 15)
            {
                //IsEnable = false;
                IsEnableNum = false;
                IsEnableCero = false;
                return;
            }

            if (number == 0 && Operations[0] is "0") return;
            if (number != 0 && Operations[pos - 1] is "0") Operations[pos - 1] = string.Empty;

            if (Operations[pos - 1].Contains("."))
            {
                var posPoint = Operations[pos - 1].IndexOf(".", StringComparison.Ordinal);
                if (Operations[pos - 1].Length - posPoint > 2)
                {
                    IsEnableNum = false;
                    return;
                }
            }

            if (Operations[pos - 1].Contains('('))
            {
                Operations.Add("");
                pos ++;
            }

            Operations[pos - 1] += number;

            if (Operations[pos - 1] is "00")
            {
                Operations[pos - 1] = "0.";
            }

            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));

            ExecuteCalculus();

            IsEnableAction();

            if (!Operations.Contains("("))
            {
                IsEnableParentheses = false;
            }
        }

        [RelayCommand]
        void ExecuteCalculus()
        {
            //CurrentCalculation = 0;
            CurrentCalculation = "";

            var operationTemp = new List<string>();
            foreach (var item in Operations)
                operationTemp.Add(item);

            if (Enumerable.LastOrDefault<string>(Operations) is "+" or "–")
                operationTemp.Add("0");
            if (Enumerable.LastOrDefault<string>(Operations) is "×" or "÷")
                operationTemp.Add("1");

            try
            {
                //CurrentCalculation = ExecuteCalculus(operationTemp);

                if (ExecuteCalculus(operationTemp) == 0 && !(Operations.Contains("+") || Operations.Contains("–") || Operations.Contains("×") || Operations.Contains("÷")))
                {
                    CurrentCalculation = "";
                    return;
                }
                
                CurrentCalculation = " = " + ExecuteCalculus(operationTemp).ToString(CultureInfo.InvariantCulture);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //CurrentCalculation = 0;
                CurrentCalculation = "";
            }
        }
        private decimal ExecuteCalculus(List<string> operationTemp)
        {
            var cantIniPar = operationTemp.Count(d=> d == "(");
            var cantFinPar = operationTemp.Count(d=> d == ")");
            if (cantIniPar != cantFinPar)
            {
                while (cantFinPar < cantIniPar)
                {
                    operationTemp.Add(")");
                    cantFinPar = operationTemp.Count(d => d == ")");
                }
            }

            var posIniPar = operationTemp.IndexOf("(");
            var posFinPar = operationTemp.IndexOf(")");

            while (posIniPar != -1 && posFinPar != -1)
            {
                List<string> listParentesis = new List<string>();
                for (int i = posIniPar + 1; i < posFinPar; i++)
                {
                    listParentesis.Add(operationTemp[i]);
                }

                var resultParent = ExecuteCalculus(listParentesis);

                List<string> tempoper = new List<string>();
                for (int i = 0; i < operationTemp.Count; i++)
                {
                    if (i < posIniPar || i > posFinPar)
                    {
                        tempoper.Add(operationTemp[i]);
                    }
                }

                tempoper.Insert(posIniPar, resultParent.ToString(CultureInfo.InvariantCulture));
                operationTemp = tempoper;
                posIniPar = operationTemp.IndexOf("(");
                posFinPar = operationTemp.IndexOf(")");
                if (operationTemp.Count == 1) return decimal.Parse(operationTemp[0], CultureInfo.InvariantCulture);
            }
            if (operationTemp.Count < 3) return 0;
            
            var firstNumber = decimal.Parse(operationTemp[0], CultureInfo.InvariantCulture);
            var operatorTemp = operationTemp[1];
            var secondNumber = decimal.Parse(operationTemp[2], CultureInfo.InvariantCulture);

            decimal result = 0;
            switch (operatorTemp)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "–":
                    result = firstNumber - secondNumber;
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    result = firstNumber / (decimal)secondNumber;
                    break;
            }

            if (operationTemp.Count == 3) return result;

            var temp = new List<string>
            {
                result.ToString(CultureInfo.InvariantCulture)
            };

            for (int i = 3; i < operationTemp.Count; i++)
            {
                temp.Add(operationTemp[i]);
            }

            return ExecuteCalculus(temp);
        }

        [RelayCommand]
        void BackSpace()
        {
            var pos = Operations.Count;

            if (Operations[pos - 1].Contains("(") && pos<2)
            {
                Operations[0] = "0";
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                ParentesisTitle = "[ ]";
                return;
            }

            if (Operations[pos - 1].EndsWith("("))
            {
                Operations.RemoveAt(pos - 1);
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                ParentesisTitle = "[ ]";
                return;
            }

            if (Operations[pos - 1].EndsWith(")"))
            {
                Operations.RemoveAt(pos - 1);
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                ParentesisTitle = "[]";
                return;
            }

            if (Enumerable.LastOrDefault<string>(Operations) is "+" or "–" or "×" or "÷" or "(" or ")")
                Operations.RemoveAt(pos - 1);
            else
            {
                if (Enumerable.LastOrDefault<string>(Operations) is not "0")
                {
                    Operations[pos - 1] = Operations[pos - 1].Substring(0, Operations[pos - 1].Length - 1);

                    if (Operations[pos - 1] is "")
                    {
                        Operations[pos - 1] = "0";
                    }
                }
                else
                {
                    if (Operations.Count > 1)
                    {
                        Operations.RemoveAt(pos - 1);
                    }
                }
            }

            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
            ExecuteCalculus();

            IsEnableAction();
        }

        [RelayCommand]
        void DecimalPoint(string value)
        {
            var pos = Operations.Count;
            if (Enumerable.LastOrDefault<string>(Operations) is "")
            {
                return;
            }
            if (Enumerable.LastOrDefault<string>(Operations) is ")")
            {
                return;
            }
            if (Operations[pos - 1].Contains("."))
            {
                return;
            }
            if (Operations[pos - 1].EndsWith("÷"))
            {
                Operations.Add("0.");
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                IsEnableDecimalPoint = false;
                return;
            }
            if (Operations[pos - 1].EndsWith("×"))
            {
                Operations.Add("0.");
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                IsEnableDecimalPoint = false;
                return;
            }
            if (Operations[pos - 1].EndsWith("–"))
            {
                Operations.Add("0.");
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                IsEnableDecimalPoint = false;
                return;
            }
            if (Operations[pos - 1].EndsWith("+"))
            {
                Operations.Add("0.");
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                IsEnableDecimalPoint = false;
                return;
            }

            Operations[pos - 1] += value;
            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));

            IsEnableDecimalPoint = false;
            IsEnableCero = true;
        }

        [RelayCommand]
        void Calculus()
        {
            //if (CurrentCalculation is not 0)
            if (CurrentCalculation is null) return;

            if (IsBalanced is false) return;

            var pos = Operations.Count;
            if (Operations[pos - 1].EndsWith("÷"))
            {
                return;
            }
            if (Operations[pos - 1].EndsWith("×"))
            {
                return;
            }
            if (Operations[pos - 1].EndsWith("–"))
            {
                return;
            }
            if (Operations[pos - 1].EndsWith("+"))
            {
                return;
            }

            if (Operations[pos - 1].EndsWith("."))
            {
                return;
            }

            if (CurrentCalculation is not "")
            {
                var temp = CurrentCalculation.Remove(0, 3);
                var result = "";
                foreach (var item in Operations)
                {
                    //if (!string.IsNullOrEmpty(result)) result += " ";
                    result += " " + item;
                }
                OperationsHistory = result + CurrentCalculation;

                Operations.Clear();

                Operations.Add(temp);
                //Operations.Add(CurrentCalculation.ToString());
                //CurrentCalculation = 0;
                CurrentCalculation = "";
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));

                IsEnableCopy = false;
                IsEnableCalculus = false;
                IsEnableParentheses = false;
            }
        }

        [RelayCommand]
        void CopyPaste()
        {
            //if (CurrentCalculation is null) return;

                var pos = Operations.Count;

                if (CurrentCalculation is not "" && CopyPasteTitle != "❏")
                {
                    CurrentPaste = _currentCalculation.Remove(0, 3);
                    OnPropertyChanged(nameof(ViewModel.CurrentPaste));

                    if (CurrentPaste == "0")
                    {
                        CopyNumb = "";
                        return;
                    }

                    CopyNumb = CurrentPaste;
                    CopyPasteTitle = "❏";
                    CopyTitle = "❐";
                    CountCopy = true;
                    IsEnableAction();

                    return;
                }

                if (CopyPasteTitle == "❏")
                {
                    if (Enumerable.LastOrDefault<string>(Operations) is "+" or "–" or "×" or "÷")
                    {
                        Operations.Add(CopyNumb.ToString(CultureInfo.InvariantCulture));
                        OnPropertyChanged(nameof(ViewModel.Operations));
                        ExecuteCalculus();
                        CopyPasteTitle = "❐";
                        CopyNumb = "";
                    }
                    if (Enumerable.LastOrDefault<string>(Operations) is "0")
                    {
                        Operations.RemoveAt(pos - 1);
                        Operations.Add(CopyNumb.ToString(CultureInfo.InvariantCulture));
                        OnPropertyChanged(nameof(ViewModel.Operations));
                        ExecuteCalculus();
                        CopyPasteTitle = "❐";
                        CopyNumb = "";
                    }
                }
        }

        [RelayCommand]
        void CopyPasteTwo()
        {
            if (CurrentCalculationTwo is 0) return;

            //TO DO Navigation("Calculadora");

            CopyNumbTwo = CurrentCalculationTwo;

            Clear();

            Operations =
            [
                $"{CurrentCalculationTwo}"
            ];

            IsEnableClear = true;
            IsEnable = true;
            IsEnableCero = true;
            IsEnableParentheses = false;
            IsEnableCalculus = false;

            //IsEnableCopyContador = false;
        }

        bool ParenthesesBalance()
        {
            var contador = 0;

            foreach (string c in Operations)
            {
                if (c == "(")
                    contador++;
                else if (c == ")")
                    contador--;

                if (contador < 0)
                    return false; // Paréntesis desbalanceados
            }

            return true;
        }

        [RelayCommand]
        void Parentheses()
        {
            IsEnableDecimalPoint = false;
            IsEnableParentheses = false;

            var pos = Operations.Count;

            if (Operations[0] is "0")
            {
                Operations[0] = "(";
                //Operations.Add("");
                OnPropertyChanged(nameof(Contador.ViewModel.ViewModel.Operations));
                ParentesisTitle = "[]";
                IsBalanced = false;
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Operations[pos - 1], @"^\d+(\.\d+)?$"))
            {
                if (Operations[pos - 1] is "" or "(" or ")")
                {
                    return;
                }

                if (Operations[pos - 1] is not "+" or "–" or "÷" or "×")
                {
                    if (ParentesisTitle == "[ ]")
                    {
                        Operations.Add("(");
                        OnPropertyChanged(nameof(ViewModel.Operations));
                        ParentesisTitle = "[]";
                        IsBalanced = false;
                    }
                    return;
                }

                if (ParentesisTitle == "[]")
                {
                    return;
                }
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(Operations[pos - 1], @"^\d+(\.\d+)?$"))
            {
                if (ParentesisTitle == "[ ]")
                {
                    return;
                }
                if (Operations[pos - 2] is "(")
                {
                    return;
                }
            }

            if (ParentesisTitle == "][")
            {
                return;
            }

            if (Operations[pos - 1].EndsWith("÷"))
            {
                Operations.Add("(");
                OnPropertyChanged(nameof(ViewModel.Operations));
                ParentesisTitle = "[]";
                IsBalanced = false;
                return;
            }
            if (Operations[pos - 1].EndsWith("×"))
            {
                Operations.Add("(");
                OnPropertyChanged(nameof(ViewModel.Operations));
                ParentesisTitle = "[]";
                IsBalanced = false;
                return;
            }
            if (Operations[pos - 1].EndsWith("–"))
            {
                Operations.Add("(");
                OnPropertyChanged(nameof(ViewModel.Operations));
                ParentesisTitle = "[]";
                IsBalanced = false;
                return;
            }
            if (Operations[pos - 1].EndsWith("+"))
            {
                Operations.Add("(");
                OnPropertyChanged(nameof(ViewModel.Operations));
                ParentesisTitle = "[]";
                IsBalanced = false;
                return;
            }

            if (ParentesisTitle == "[]")
            {
                Operations.Add(")");
                OnPropertyChanged(nameof(ViewModel.Operations));
                ExecuteCalculus();
                //ParentesisTitle = "[ ]";
            }

            //if (Operations.Contains(")"))
            //{
            //    ParentesisTitle = "][";
            //    IsBalanced = true;
            //    return;
            //}

            IsEnableAction();
        }

        [RelayCommand]
        //void CurrentCopy()
        //{
        //}
        
        partial void OnCurrent1Changed(string value)
        {
            if (Current1 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current1 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current1 != "0")
            {
                Current1 = Current1.Substring(0, Current1.Length - 1);
            }
        }
        partial void OnCurrent5Changed(string value)
        {
            if (Current5 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current5 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current5 != "0")
            {
                Current5 = Current5.Substring(0, Current5.Length - 1);
            }
        }
        partial void OnCurrent10Changed(string value)
        {
            if (Current10 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current10 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current10 != "0")
            {
                Current10 = Current10.Substring(0, Current10.Length - 1);
            }
        }
        partial void OnCurrent20Changed(string value)
        {
            if (Current20 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current20 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current20 != "0")
            {
                Current20 = Current20.Substring(0, Current20.Length - 1);
            }
        }
        partial void OnCurrent50Changed(string value)
        {
            if (Current50 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current50 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current50 != "0")
            {
                Current50 = Current50.Substring(0, Current50.Length - 1);
            }
        }
        partial void OnCurrent100Changed(string value)
        {
            if (Current100 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current100 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current100 != "0")
            {
                Current100 = Current100.Substring(0, Current100.Length - 1);
            }
        }
        partial void OnCurrent200Changed(string value)
        {
            if (Current200 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current200 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current200 != "0")
            {
                Current200 = Current200.Substring(0, Current200.Length - 1);
            }
        }
        partial void OnCurrent500Changed(string value)
        {
            if (Current500 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current500 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current500 != "0")
            {
                Current500 = Current500.Substring(0, Current500.Length - 1);
            }
        }
        partial void OnCurrent1000Changed(string value)
        {
            if (Current1000 == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (Current1000 == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (Current1000 != "0")
            {
                Current1000 = Current1000.Substring(0, Current1000.Length - 1);
            }
        }
        partial void OnCurrentPasteChanged(string value)
        {
            if (CurrentPaste == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (CurrentPaste == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (CurrentPaste != "0")
            {
                CurrentPaste = CurrentPaste.Substring(0, CurrentPaste.Length - 1);
            }
        }
        partial void OnChangeMoneyChanged(string value)
        {
            if (ChangeMoney == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (ChangeMoney == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (ChangeMoney != "0")
            {
                ChangeMoney = ChangeMoney.Substring(0, ChangeMoney.Length - 1);
            }
        }
        partial void OnCantMoneyChanged(string value)
        {
            if (CantMoney == "")
            {
                Recalcular();
                return;
            }

            int number;
            if (int.TryParse(value, out number))
            {
                if (CantMoney == "0")
                {
                    return;
                }
                Recalcular();
            }
            else if (CantMoney != "0")
            {
                CantMoney = CantMoney.Substring(0, CantMoney.Length - 1);
            }
        }

        public static double RedondearACincoCentimos(double numero)
        {
            return Math.Round(numero * 20) / 20;
        }

        private void RecalcularMoney()
        {
            var int_CantMoney = 0;
            if (CantMoney != "")
            {
                int_CantMoney = int.Parse(CantMoney);
            }

            var float_CurrentCalculationTwo = (float)CurrentCalculationTwo;
            if (MoneyChange == 0)
            {
                CurrentCalculationMoney = CantMoney;
            }
            else
            {
                //var temp3 = float.Parse(CurrentCalculationMoney);
                var calculus = int_CantMoney + (float_CurrentCalculationTwo / MoneyChange);
                var calculusRound = (float)RedondearACincoCentimos(calculus);
                CurrentCalculationMoney = $"{calculusRound:F2}";
            }

            IsEnableContadorAction();
        }
        private void Recalcular()
        {
            int number;

            if (Current1 == "")
            {
                return;
            }

            //CurrentCalculationTwo = int.Parse(Current1);
            //CurrentCalculationTwo += int.Parse(Current5) * 5;
            //CurrentCalculationTwo += int.Parse(Current10) * 10;
            //CurrentCalculationTwo += int.Parse(Current20) * 20;
            //CurrentCalculationTwo += int.Parse(Current50) * 50;
            //CurrentCalculationTwo += int.Parse(Current100) * 100;
            //CurrentCalculationTwo += int.Parse(Current200) * 200;
            //CurrentCalculationTwo += int.Parse(Current500) * 500;
            //CurrentCalculationTwo += int.Parse(Current1000) * 1000;
            //CurrentCalculationTwo += int.Parse(CurrentPaste);
            //CurrentCalculationTwo += int.Parse(Current500) * 500;

            if (int.TryParse(Current1, out number))
            {
                var current1 = int.Parse(Current1);
                CurrentCalculationTwo = current1;
                RecalcularMoney();
            }

            if (int.TryParse(Current5, out number))
            {
                var current5 = int.Parse(Current5);
                CurrentCalculationTwo += current5 * 5;
                RecalcularMoney();
            }

            if (int.TryParse(Current10, out number))
            {
                var current10 = int.Parse(Current10);
                CurrentCalculationTwo += current10 * 10;
                RecalcularMoney();
            }

            if (int.TryParse(Current20, out number))
            {
                var current20 = int.Parse(Current20);
                CurrentCalculationTwo += current20 * 20;
                RecalcularMoney();
            }

            if (int.TryParse(Current50, out number))
            {
                var current50 = int.Parse(Current50);
                CurrentCalculationTwo += current50 * 50;
                RecalcularMoney();
            }

            if (int.TryParse(Current100, out number))
            {
                var current100 = int.Parse(Current100);
                CurrentCalculationTwo += current100 * 100;
                RecalcularMoney();
            }

            if (int.TryParse(Current200, out number))
            {
                var current200 = int.Parse(Current200);
                CurrentCalculationTwo += current200 * 200;
                RecalcularMoney();
            }

            if (int.TryParse(Current500, out number))
            {
                var current500 = int.Parse(Current500);
                CurrentCalculationTwo += current500 * 500;
                RecalcularMoney();
            }

            if (int.TryParse(Current1000, out number))
            {
                var current1000 = int.Parse(Current1000);
                CurrentCalculationTwo += current1000 * 1000;
                RecalcularMoney();
            }

            if (int.TryParse(CurrentPaste, out number))
            {
                var currentPaste = int.Parse(CurrentPaste);
                CurrentCalculationTwo += currentPaste;
                RecalcularMoney();
            }

            if (int.TryParse(ChangeMoney, out number))
            {
                MoneyChange = int.Parse(ChangeMoney);
            }

            if (int.TryParse(CantMoney, out number))
            {
                var cantMoney = int.Parse(CantMoney);
                cantMoney = cantMoney * MoneyChange;
                RecalcularMoney();
                CurrentCalculationTwo += cantMoney;
            }

            OnPropertyChanged(nameof(Contador.ViewModel.ViewModel._currentCalculationTwo));

        }

        [RelayCommand]
        void ClearTwo()
        {
            CurrentCalculationMoney = "0";
            CurrentCalculationTwo = 0;
            Current1 = "0";
            Current5 = "0";
            Current10 = "0";
            Current20 = "0";
            Current50 = "0";
            Current100 = "0";
            Current200 = "0";
            Current500 = "0";
            Current1000 = "0";
            CurrentPaste = "0";
            ChangeMoney = "0";
            CantMoney = "0";

            IsEnableClearContador = false;
            IsEnableCopyContador = false;
            TextColorClear = "Grey";
            TextColorCopy = "Grey";
        }

        [RelayCommand]
        void IsEnableAction()
        {
            IsEnable = true;
            IsEnableClear = true;
            IsEnableCero = true;

            var negative = false;
            if (CurrentCalculation is not null) 
            {
                if (CurrentCalculation is not "" && CopyPasteTitle != "❏")
                {
                    if (CurrentCalculation.Contains("-"))
                    {
                        negative = true;
                        IsEnableCopy = false;
                    }

                    if (CurrentCalculation is not " = 0" && negative == false)
                    {
                        IsEnableCopy = true;
                    };
                }
            }
            if (CopyPasteTitle == "❏")
            {
                IsEnableCopy = false;
            }

            var pos = Operations.Count;

            if (Operations[0] is "0")
            {
                IsEnable = false;
                IsEnableClear = false;
                IsEnableCero = false;
                IsEnableCopy = false;
            }

            if (CopyNumb != "")
            {
                IsEnableClear = true;
            }

            IsEnableDecimalPoint = true;
            if (Operations[pos - 1].Contains("."))
            {
                IsEnableDecimalPoint = false;
                IsEnableCero = true;
            }
            if (Operations[pos - 1].EndsWith(".0"))
            {
                IsEnableDecimalPoint = false;
                IsEnableCero = false;
            }
            if (Operations[pos - 1].Contains("."))
            {
                var posPoint = Operations[pos - 1].IndexOf(".", StringComparison.Ordinal);
                if (Operations[pos - 1].Length - posPoint > 2)
                {
                    IsEnableCero = false;
                    IsEnableNum = false;
                }
            }
            if (Enumerable.LastOrDefault<string>(Operations) is ")")
            {
                IsEnableDecimalPoint = false;
            }

            IsEnableParentheses = true;
            if (System.Text.RegularExpressions.Regex.IsMatch(Operations[pos - 1], @"^\d+(\.\d+)?$"))
            {
                //if (ParentesisTitle == "[ ]")
                //{
                //    IsEnableParentheses = false;
                //}
                if (pos > 1 && Operations[pos - 2] is "(")
                {
                    IsEnableParentheses = false;
                }
            }
            if (Operations.Contains(")"))
            {
                ParentesisTitle = "][";
                IsBalanced = true;
                IsEnableParentheses = false;
            }
            if (ParentesisTitle == "[]")
            {
                if (Operations[pos - 1].EndsWith("÷"))
                {
                    IsEnableParentheses = false;
                }
                if (Operations[pos - 1].EndsWith("×"))
                {
                    IsEnableParentheses = false;
                }
                if (Operations[pos - 1].EndsWith("–"))
                {
                    IsEnableParentheses = false;
                }
                if (Operations[pos - 1].EndsWith("+"))
                {
                    IsEnableParentheses = false;
                }

            }

            if (CurrentCalculation != "")
            {
                IsEnableCalculus = true;
            }
        }

        void IsEnableContadorAction()
        {
            if (CurrentCalculationTwo != 0)
            {
                IsEnableClearContador = true;
                TextColorClear = "White";
                IsEnableCopyContador = true;
                TextColorCopy = "White";
            }
            if (CurrentCalculationMoney != "0")
            {
                IsEnableClearContador = true;
                TextColorClear = "White";
            }
        }
    }
}