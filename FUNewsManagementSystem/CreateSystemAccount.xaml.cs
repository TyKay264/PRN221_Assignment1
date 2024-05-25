using BusinessObjects;
using Services;
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
    /// Interaction logic for CreateSystemAccount.xaml
    /// </summary>
    public partial class CreateSystemAccount : Window
    {
        private readonly ISystemAccountService iSystemAccountService;
        public CreateSystemAccount()
        {
            InitializeComponent();
            iSystemAccountService = new SystemAccountService();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SystemAccount systemAccount = new SystemAccount();

            try
            {
                systemAccount.AccountName = txtAccountName.Text;
                systemAccount.AccountEmail = txtAccountEmail.Text;
                if (cboAccountRole.SelectedItem != null)
                {
                    systemAccount.AccountRole = Int32.Parse(cboAccountRole.SelectedValue.ToString());
                }
                systemAccount.AccountPassword = txtAccountPassword.Password;
                iSystemAccountService.SaveSystemAccount(systemAccount);
                this.Close();
                AccountManagement accountManagement = new AccountManagement();
                accountManagement.Show();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AccountManagement accountManagement = new AccountManagement();
            accountManagement.Show();
        }

        /*private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            NewsArticle newsArticle = new NewsArticle();
            try
            {
                newsArticle.NewsTitle = txtNewsTitle.Text;
                newsArticle.CreatedDate = txtCreatedDate.SelectedDate ?? DateTime.Now;
                newsArticle.NewsContent = txtNewsContent.Text;
                newsArticle.ModifiedDate = txtModifiedDate.SelectedDate ?? DateTime.Now;
                newsArticle.NewsStatus = true;
                newsArticle.CreatedById = Login.UserId;

                if (cboCategoryId.SelectedItem != null)
                {
                    newsArticle.CategoryId = ((Category)cboCategoryId.SelectedItem).CategoryId;
                }

                iNewsArticlesService.SaveNewsArticle(newsArticle);
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
        }*/

        public void LoadAcountRole()
        {
                var accountRoles = new List<dynamic>();
                    accountRoles.Add(new { AccountRoleId = 1, AccountRoleName = "Staff" });
                    accountRoles.Add(new { AccountRoleId = 2, AccountRoleName = "Lecture" });
                cboAccountRole.ItemsSource = accountRoles;
                cboAccountRole.DisplayMemberPath = "AccountRoleName";
                cboAccountRole.SelectedValuePath = "AccountRoleId";
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAcountRole();
        }
    }
}
