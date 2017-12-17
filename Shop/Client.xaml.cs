﻿using System;
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

namespace Shop
{
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }

        string connStr = @"Data Source=EUGENEPC;Initial Catalog=StoreDB;User Id = client; Password = qwe123";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllCategories();
                cGrid.ItemsSource = null;
                cGrid.ItemsSource = Categories.categoriesList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllProducts();
                pGrid.ItemsSource = ProductsList.prodList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            pGrid.ItemsSource = null;
            pGrid.ItemsSource = ProductsList.prodList;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductsList path = pGrid.SelectedItem as ProductsList;
                DB db = new DB();
                db.openConnection(connStr);
                if (path.ammount < Convert.ToInt32(textBox.Text))
                {
                    MessageBox.Show("Отсутствует введённое количество товара");
                }
                else
                {
                    db.buySelectedProduct(path.id, Convert.ToInt32(textBox.Text));
                    MessageBox.Show("Куплено");
                }
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Categories path = cGrid.SelectedItem as Categories;
                DB db = new DB();
                db.openConnection(connStr);
                ProductsList.prodList.Clear();
                db.filtrProduct(path.id);
                pGrid.ItemsSource = null;
                pGrid.ItemsSource = ProductsList.prodList;
                MessageBox.Show("Выполнено");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow();
            mv.Show();
            this.Close();
        }
    }
}
