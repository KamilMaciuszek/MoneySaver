using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneySaver
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingExpensePage : ContentPage
    {
        double total;
        public AddingExpensePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            total += Convert.ToDouble(AmountEntry.Text);
            Expenses expenses = new Expenses()
            {
                Name = NameEntry.Text,
                Amount = AmountEntry.Text,
                TotalExpenses = total
            };
            // zrób tak, żeby totalExpenses się zwiększało.
            TotalAmount.Text = expenses.TotalExpenses.ToString();

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.ListOfExpenses))
            {
                connection.CreateTable<Expenses>();
                var numberOfRows = connection.Insert(expenses);


                if (numberOfRows > 0) { DisplayAlert("The expense was added", "The monthly budget left is: ", "Confirm"); }
                else
                    DisplayAlert("Something gone wrong", "Try again ", "Confirm");
            }
        }
    }
}