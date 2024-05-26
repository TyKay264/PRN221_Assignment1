using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FUNewsManagementSystem
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CategoryList category = new CategoryList();
            category.Show();
        }

        private void btnNewsArticle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnSystemAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AccountManagement accountManagement = new AccountManagement();
            accountManagement.Show();
        }
    }
}
