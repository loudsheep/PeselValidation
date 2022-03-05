using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PeselValidation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string pesel = inputPESEL.Text;
            bool check = CheckPESEL(pesel);
            string message = "PESEL ";
            message += check ? "" : "nie ";
            message += "jest poprawny";

            DisplayAlert("", message, "Anuluj");
        }

        private static int[] weigths = new int[] {1, 3, 7, 9};
        private static bool CheckPESEL(string pesel)
        {
            if (pesel.Length != 11) 
            {
                return false; 
            }

            int sum = 0;
            for(int i=0; i<pesel.Length - 1; i++)
            {
                if(Char.IsDigit(pesel[i]))
                {
                    int n = pesel[i] - '0';
                    sum += n * weigths[i % weigths.Length];
                }
                else
                {
                    return false;
                }
            }
            if (!Char.IsDigit(pesel[10])) 
            {
                return false; 
            }

            sum = sum % 10;
            sum = 10 - sum;
            sum = sum == 10 ? 0 : sum;

            int last = pesel[10] - '0';

            if (last != sum) return false;

            return true;
        }
    }
}
