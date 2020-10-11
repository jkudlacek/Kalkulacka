using System;
using Xamarin.Forms;
using Z.Expressions;

namespace Kalkulacka
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();  
        }
        
        public string Evaluate(string input)
        {
            string result;
            try
            {
                double a = Eval.Execute<int>(input);
                result = a.ToString();      
            } catch
            {
                result = "SUS";
            }
            return result;
        }

        void onButtonClicked(object sender, EventArgs e)
        {
            string content = (sender as Button).Text.ToString();
            switch (content)
            {
                case "C":
                    resultLabel.Text = "";
                    break;

                case "⌫":
                    string s = resultLabel.Text;
                    if (s.Contains("="))
                    {
                        resultLabel.Text = "";
                    } else
                    {
                        resultLabel.Text=s.Substring(0, s.Length - 1);
                    }
                    break;

                case "=":
                    resultLabel.Text = "=" + Evaluate(resultLabel.Text);
                    break;

                default:

                    if (resultLabel.Text.Contains("="))
                    {
                        resultLabel.Text = "";
                    }
                    resultLabel.Text += content;

                    break;

            }
        }
    }
}
