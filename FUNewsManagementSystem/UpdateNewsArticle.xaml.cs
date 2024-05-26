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
    /// Interaction logic for UpdateNewsArticle.xaml
    /// </summary>
    public partial class UpdateNewsArticle : Window
    {
        private readonly INewsArticlesService iNewsArticleService;
        private readonly ICategoryService iCategoryService;
        private NewsArticle _newsArticle;
        public UpdateNewsArticle(NewsArticle newsArticle)
        {
            InitializeComponent();
            _newsArticle = newsArticle;
            iNewsArticleService = new NewsArticleService();
            iCategoryService = new CategoryService();
            LoadNewsArticle();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadNewsArticle()
        {
            if (_newsArticle != null)
            {
                txtNewsTitle.Text = _newsArticle.NewsTitle;
                txtCreatedDate.SelectedDate = _newsArticle.CreatedDate;
                txtNewsContent.Text = _newsArticle.NewsContent;
                cboCategoryId.SelectedValue = _newsArticle.CategoryId;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadNewsArticle();
            LoadCategoryList(); 
        }

        public void LoadCategoryList()
        {
            try
            {
                var categoryList = iCategoryService.GetCategories();
                cboCategoryId.ItemsSource = categoryList;
                cboCategoryId.DisplayMemberPath = "CategoryId";
                cboCategoryId.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}
