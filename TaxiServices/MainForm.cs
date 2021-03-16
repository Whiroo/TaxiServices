﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TaxiServices.Classes;

namespace TaxiServices
{
    public partial class MainForm : Form
    {
        public AppContext Db;

        public MainForm()
        {
            InitializeComponent();
            Db = new AppContext();
            dataGridView1.DataSource = Db.Drivers.Local.ToBindingList();
            commissionGrid.DataSource = Db.Commissions.Local.ToBindingList();
            Db.Drivers.Load();
            Db.Commissions.Load();

            // Не знал, как правильно, сделал так

            #region dataGridColumnName

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Позывной";
            dataGridView1.Columns[2].HeaderText = "Модель";
            dataGridView1.Columns[3].HeaderText = "Цвет";
            dataGridView1.Columns[4].HeaderText = "Заказов";
            dataGridView1.Columns[5].HeaderText = "На линии";
            dataGridView1.Columns[6].HeaderText = "Местоположение";

            commissionGrid.Columns[0].HeaderText = "ID";
            commissionGrid.Columns[1].HeaderText = "Позывной";
            commissionGrid.Columns[2].HeaderText = "Модель";
            commissionGrid.Columns[3].HeaderText = "Сумма коммиссии";
            commissionGrid.Columns[4].HeaderText = "Оплатил";

            commissionGrid.Columns[0].Width = 160;
            commissionGrid.Columns[1].Width = 160;
            commissionGrid.Columns[2].Width = 160;
            commissionGrid.Columns[3].Width = 160;



            #endregion
        }

        private void delDriverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var index = 0;
                    var converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out var id);
                    if (converted == false)
                        MessageBox.Show("Не удалось выбрать водителя");
                    var driver = Db.Drivers.Find(id);
                    Db.Drivers.Remove(driver);
                    Db.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Возникла непредвиденная ошибка. Номер ошибки: 0");
                throw;
            }
        }

        private void addDriverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new CreateDriverFrm();
                var result = frm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                var driver = new Driver();
                driver.Number = int.Parse(frm.idTxtBox.Text);
                driver.Model = frm.modelTxtBox.Text;
                driver.Color = frm.colorTxtBox.Text;
                driver.Orders = int.Parse(frm.ordersTxtBox.Text);
                driver.Online = frm.comboBox1.SelectedItem.ToString();
                driver.Location = "Посёлок"; //Дефолт значение
                Db.Drivers.Add(driver);
                Db.SaveChanges();
                Test(driver);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }


        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            if (queDataGrid.SelectedRows.Count > 0)
            {
                var index = queDataGrid.SelectedRows[0].Index;
                var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                int.TryParse(queDataGrid[4, index].Value.ToString(), out _);
                if (converted == false)
                    MessageBox.Show("Не удалось добавить заказ");
                var driver = Db.Drivers.Find(id);
                var cms = new Commission();
                if (driver != null)
                {
                    driver.Orders += 1;
                    Engine.DeleteDriverFromQueue(driver, false); //Костыль
                    Engine.AddDriverToQueue(driver, false);
                }

                var drivercom = Db.Commissions.Find(id);
                drivercom.PerWeek = Engine.CalcCommission(driver.Orders);
                Db.SaveChanges();
                queDataGrid.DataSource = Engine.Refresh(false);
                dataGridView1.Refresh();
            }
        }

        private void delOrderBtn_Click(object sender, EventArgs e)
        {
            if (queDataGrid.SelectedRows.Count > 0)
            {
                var index = queDataGrid.SelectedRows[0].Index;
                var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                int.TryParse(queDataGrid[4, index].Value.ToString(), out _);
                if (converted == false)
                    MessageBox.Show("Не удалось добавить заказ");
                var driver = Db.Drivers.Find(id);
                if (driver != null) driver.Orders -= 1;
                Db.SaveChanges();
                MessageBox.Show("Заказ удален");
                dataGridView1.Refresh();
            }
        }

        private void addOnlineBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out var id);
                if (converted == false)
                    MessageBox.Show("Не удалось добавить заказ");
                var driver = Db.Drivers.Find(id);
                if (driver != null)
                {
                    driver.Online = "Да";
                    Engine.AddDriverToQueue(driver, false);
                }

                Engine.Refresh(false);
                queDataGrid.DataSource = Engine.Refresh(false);
                Db.SaveChanges();
                dataGridView1.Refresh();
            }
        }

        private void createOflineBtn_Click(object sender, EventArgs e)
        {
            if (queDataGrid.SelectedRows.Count > 0)
            {
                var index = queDataGrid.SelectedRows[0].Index;
                var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                if (converted == false)
                    MessageBox.Show("Не удалось выбрать водителя");
                var driver = Db.Drivers.Find(id);
                if (driver != null)
                {
                    driver.Online = "Нет";
                    Engine.DeleteDriverFromQueue(driver, false);
                }

                queDataGrid.DataSource = Engine.Refresh(false);
                Db.SaveChanges();
                dataGridView1.Refresh();
            }
        }

        private void sumCommissionBtn_Click_1(object sender, EventArgs e)
        {
            var numberDrivers = numberDriverTxtBox.Text;
            var temp = int.Parse(numberDrivers);
            var driver = Db.Drivers.First(p => p.Number == temp);
            countOrdersTxTBox.Text = driver.Orders.ToString();
            var sum = Engine.CalcCommission(driver.Orders).ToString();
            commisionTxtBox.Text = sum;
        }

        private void orderToCityBtn_Click(object sender, EventArgs e)
        {
            if (queDataGrid.SelectedRows.Count > 0)
            {
                var index = queDataGrid.SelectedRows[0].Index;
                var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                int.TryParse(queDataGrid[4, index].Value.ToString(), out var order);
                if (converted == false)
                    MessageBox.Show("Не удалось добавить заказ");
                MessageBox.Show(id + order.ToString());
                var driver = Db.Drivers.Find(id);
                if (driver != null)
                {
                    driver.Orders += 1;
                    driver.Location = "Город";
                    Engine.DeleteDriverFromQueue(driver, false); //Костыль
                    Engine.AddDriverToQueue(driver, true);
                }

                Db.SaveChanges();
                queDataGrid.DataSource = Engine.Refresh(false);
                cityQueGried.DataSource = Engine.Refresh(true);
                dataGridView1.Refresh();
                queDataGrid.Refresh();
                cityQueGried.Refresh();
            }
        }

        private void toPassBtn_Click(object sender, EventArgs e)
        {
            if (cityQueGried.SelectedRows.Count > 0)
            {
                var index = cityQueGried.SelectedRows[0].Index;
                var converted = int.TryParse(cityQueGried[0, index].Value.ToString(), out var id);
                int.TryParse(cityQueGried[4, index].Value.ToString(), out var order);
                if (converted == false)
                    MessageBox.Show("Не удалось добавить заказ");
                MessageBox.Show(id + order.ToString());
                var driver = Db.Drivers.Find(id);
                if (driver != null)
                {
                    driver.Orders += 1;
                    driver.Location = "Поселок";
                    Engine.DeleteDriverFromQueue(driver, true); //Костыль
                    Engine.AddDriverToQueue(driver, false);
                }

                Db.SaveChanges();
                queDataGrid.DataSource = Engine.Refresh(false);
                cityQueGried.DataSource = Engine.Refresh(true);
                dataGridView1.Refresh();
                queDataGrid.Refresh();
                cityQueGried.Refresh();
            }
        }

        private void offFromCityBtn_Click(object sender, EventArgs e)
        {
            if (cityQueGried.SelectedRows.Count > 0)
            {
                var index = cityQueGried.SelectedRows[0].Index;
                var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                if (converted == false)
                    MessageBox.Show("Не удалось выбрать водителя");
                var driver = Db.Drivers.Find(id);
                if (driver != null)
                {
                    driver.Online = "Нет";
                    driver.Location = "Город";
                    Engine.DeleteDriverFromQueue(driver, true);
                }

                cityQueGried.DataSource = Engine.Refresh(false);
                Db.SaveChanges();
                dataGridView1.Refresh();
                cityQueGried.Refresh();
            }
        }

        private void onlineCityBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out var id);
                if (converted == false)
                    MessageBox.Show("Не удалось поставить на линию");
                var driver = Db.Drivers.Find(id);
                if (driver != null)
                {
                    driver.Online = "Да";
                    driver.Location = "Город";
                    Engine.AddDriverToQueue(driver, true);
                }

                Engine.Refresh(false);
                cityQueGried.DataSource = Engine.Refresh(true);
                Db.SaveChanges();
                dataGridView1.Refresh();
            }
        }

        private void allOrdersPerWeekBtn_Click(object sender, EventArgs e)
        {
            var temp = Engine.CalcAllOrderPerWeek(Db.Drivers.ToList());
            ordersPerWeekTxtBox.Text = temp[0].ToString();
            allSumTxtBox.Text = temp[1].ToString();
        }

        private void Test(Driver driver)
        {
            Commission cms = new Commission();
            cms.DriverNumber = driver.Number;
            cms.DriverModel = driver.Model;
            cms.PerWeek = 0;
            cms.Paid = "Нет";
            Db.Commissions.Add(cms);
            Db.SaveChanges();
        }

        private void resetWeekBtn_Click(object sender, EventArgs e)
        {
            var list = new List<Commission>();
            list = Db.Commissions.Local.ToList();
            Engine.SaveOldData(list);
            

        }
    }
}