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
    public partial class Employe : Window
    {
        public Employe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            prodGrid.ItemsSource = null;
            prodGrid.ItemsSource = ProductsList.prodList;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.getAllProducts();
            prodGrid.ItemsSource = ProductsList.prodList;
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.getAllCategories();
            catGrid.ItemsSource = null;
            catGrid.ItemsSource = Categories.categoriesList;
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            catGrid.ItemsSource = null;
            catGrid.ItemsSource = Categories.categoriesList;
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.addNewProduct(textBox6.Text, Convert.ToDouble(textBox7.Text), Convert.ToInt32(textBox8.Text),
                Convert.ToInt32(textBox9.Text), textBox10.Text, Convert.ToInt32(textBox11.Text));
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            pcGrid.ItemsSource = null;
            pcGrid.ItemsSource = Producers.producerList;
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.getAllProducers();
            pcGrid.ItemsSource = null;
            pcGrid.ItemsSource = Producers.producerList;
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            ProductsList path = prodGrid.SelectedItem as ProductsList;
            db.startDelivery(path.id, path.price, Convert.ToInt32(textBox.Text), textBox1.Text, Convert.ToInt32(textBox2.Text) );
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }
    }
}
