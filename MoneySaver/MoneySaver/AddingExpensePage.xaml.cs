using System;
using System.Collections.Generic;
using System.Globalization;
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
        public AddingExpensePage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("AmountAfterAdding")) { TotalAmount.Text = Application.Current.Properties["AmountAfterAdding"].ToString(); }
        }
        private void AddingTotalExpenses()
        {
            Application.Current.Properties["AmountBefore"] = Convert.ToDouble(TotalAmount.Text);
            Application.Current.Properties["AmountAfterAdding"] = Convert.ToDouble(AmountEntry.Text) + Convert.ToDouble(Application.Current.Properties["AmountBefore"]);
            TotalAmount.Text = Application.Current.Properties["AmountAfterAdding"].ToString();
            Application.Current.SavePropertiesAsync();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            AddingTotalExpenses();


            Expenses expenses = new Expenses()
            {
                Name = NameEntry.Text,
                Amount = AmountEntry.Text,
            };
            

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.ListOfExpenses))
            {
                connection.CreateTable<Expenses>();
                var numberOfRows = connection.Insert(expenses);


                if (numberOfRows > 0) { DisplayAlert("The expense was added", "The monthly budget left is: ", "Confirm"); }
                else
                    DisplayAlert("Something gone wrong", "Try again ", "Confirm");
            }
            AmountEntry.Text = string.Empty;
            NameEntry.Text = string.Empty;
        }
    }
}