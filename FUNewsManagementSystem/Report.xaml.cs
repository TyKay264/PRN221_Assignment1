﻿using BusinessObjects;
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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        private readonly INewsArticlesService iNewsArticleService;
        public Report()
        {
            InitializeComponent();
            iNewsArticleService = new NewsArticleService();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<NewsArticle> list = iNewsArticleService.GetReportStatistic((DateTime)txtStart.SelectedDate, (DateTime)txtEnd.SelectedDate);
            dgDate.ItemsSource = list;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminMenu menu = new AdminMenu();
            menu.Show();
        }
    }
}
