using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weddeberekening_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void colculatButton_Click(object sender, RoutedEventArgs e)
        {
            double gross;
            double uurloon;
            double tax;
            double net;
            short aantaluren;
            //Belastingen
            double tax50 = 0.05 ;
            double tax40 = 0.04;
            double tax30 = 0.03;
            double tax20 = 0.02;
            double notax = 0.0;
            //Variabelen
            string name = personeelTextBox.Text;
            uurloon= float.Parse(uurloonTextBox.Text);
            aantaluren = short.Parse(aantalurenTextBox.Text);
            //Belastingen berkenen
            gross = uurloon * aantaluren;
            if (gross > 50000)
            {
                tax= gross * tax50;
            }
            else if (gross > 25000)
            {
                tax = gross * tax40;
            }
            else if (gross > 15000)
            {
                tax = gross * tax30;
            }
            else if (gross > 10000)
            {
                tax = gross * tax20;
            }
            else
            {
                tax = gross * notax;
            }
            //resultaat
            net = gross + tax;
            resultTextBox.Text = $"LOONFICHE VAN {name}\r\n\r\n" +
                $"Aantal gewerkte uren: {aantaluren}\r\n\r\n" +
                $"Uurloon: {uurloon:c}\r\n" +
                $"Bruto salaris: {gross:c}\r\n" +
                $"Belasting: {tax:c}\r\n" +
                $"Netto salaris: {net:c}\r\n";
            }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            personeelTextBox.Text = "";
            uurloonTextBox.Text = "0";
            aantalurenTextBox.Text = "0";
            resultTextBox.Text = "";
            personeelTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}