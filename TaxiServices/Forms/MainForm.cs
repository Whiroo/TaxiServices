using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TaxiServices.Classes;
using TaxiServices.Engines;
using TaxiServices.Settings;

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
            Config.IsFirstStart = false;
            if (File.Exists(Environment.CurrentDirectory + "\\settings.xml\\"))
                ConfigEngine.LoadSettingAsync();
            else
                ConfigEngine.SaveSettingsAsync();


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

        // Первая вкладка, сделал для удобства самому себе
        #region FirstTab
        private void addDriverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new CreateDriverFrm();
                var result = frm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                var driver = new Driver
                {
                    Number = int.Parse(frm.idTxtBox.Text),
                    Model = frm.modelTxtBox.Text,
                    Color = frm.colorTxtBox.Text,
                    Orders = int.Parse(frm.ordersTxtBox.Text),
                    Online = frm.comboBox1.SelectedItem.ToString(),
                    Location = "Посёлок"
                };
                //Дефолт значение
                Db.Drivers.Add(driver);
                Db.SaveChangesAsync();
                AddDriverToCommissionList(driver);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private void addOnlineBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var index = dataGridView1.SelectedRows[0].Index;
                    var converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out var id);
                    if (converted == false)
                        MessageBox.Show("Не удалось добавить заказ");
                    var driver = Db.Drivers.Find(id);
                    if (driver != null && driver.Online != "Да")
                    {
                        driver.Online = "Да";
                        Engine.AddDriverToQueue(driver, false);
                    }
                    queDataGrid.DataSource = Engine.Refresh(false);

                    Db.SaveChangesAsync();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
        private void onlineCityBtn_Click(object sender, EventArgs e)
        {
            try
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
                    Db.SaveChangesAsync();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
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
                    var cmsDriver = Db.Commissions.Find(id);
                    Db.Commissions.Remove(cmsDriver);


                    Db.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (queDataGrid.SelectedRows.Count > 0)
                {
                    var index = queDataGrid.SelectedRows[0].Index;
                    var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                    int.TryParse(queDataGrid[4, index].Value.ToString(), out _);
                    if (converted == false)
                        MessageBox.Show("Не удалось добавить заказ");
                    var driver = Db.Drivers.Find(id);
                    var drivercom = Db.Commissions.Find(id);
                    var driverstat = new StatisticsData();
                    driverstat.DriverModel = driver?.Model;
                    driverstat.DriverNumber = driver.Number;
                    driverstat.OrdersTime = Engine.WhatsTime(false);

                    // Проверка на дубликаты в датагриде
                    if (driver != null && queDataGrid.SelectedRows[0].Index == 0)
                    {
                        //MessageBox.Show(queDataGrid.SelectedRows[0].Index.ToString());//queDataGrid[0, index].ToString());
                        driver.Orders += 1;
                        Engine.DeleteDriverFromQueue(driver, false); //Костыль
                        Engine.AddDriverToQueue(driver, false);
                        drivercom.PerWeek = Engine.CalcCommission(driver.Orders);
                        Db.SaveChangesAsync();
                        queDataGrid.DataSource = Engine.Refresh(false);
                        dataGridView1.Refresh();
                        Engine.WriteToFileWithTimeAsync(driverstat);

                    }
                    else
                    {
                        driver.Orders += 1;
                        Engine.DeleteDriverFromQueue(driver, false, true);
                        //Engine.DeleteDriverFromQueue(driver, false);
                        queDataGrid.DataSource = Engine.Refresh(false);//Костыль
                        Engine.AddDriverToQueue(driver, false);
                        drivercom.PerWeek = Engine.CalcCommission(driver.Orders);
                        Db.SaveChangesAsync();
                        queDataGrid.DataSource = Engine.Refresh(false);
                        dataGridView1.Refresh();
                        Engine.WriteToFileWithTimeAsync(driverstat);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        private void orderToCityBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (queDataGrid.SelectedRows.Count > 0)
                {
                    var index = queDataGrid.SelectedRows[0].Index;
                    var converted = int.TryParse(queDataGrid[0, index].Value.ToString(), out var id);
                    int.TryParse(queDataGrid[4, index].Value.ToString(), out _);
                    if (converted == false)
                        MessageBox.Show("Не удалось добавить заказ");
                    //MessageBox.Show(id + order.ToString());
                    var driver = Db.Drivers.Find(id);
                    if (driver != null)
                    {
                        driver.Orders += 1;
                        driver.Location = "Город";
                        Engine.DeleteDriverFromQueue(driver, false); //Костыль
                        Engine.AddDriverToQueue(driver, true);
                    }

                    Db.SaveChangesAsync();
                    queDataGrid.DataSource = Engine.Refresh(false);
                    cityQueGried.DataSource = Engine.Refresh(true);
                    dataGridView1.Refresh();
                    queDataGrid.Refresh();
                    cityQueGried.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
                throw;
            }
        }

        private void delOrderBtn_Click(object sender, EventArgs e)
        {
            try
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
                    Db.SaveChangesAsync();
                    MessageBox.Show("Заказ удален");
                    dataGridView1.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        private void createOflineBtn_Click(object sender, EventArgs e)
        {
            try
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
                    Db.SaveChangesAsync();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }
        #endregion

        #region SecondTab

        private void toPassBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cityQueGried.SelectedRows.Count > 0)
                {
                    var index = cityQueGried.SelectedRows[0].Index;
                    var converted = int.TryParse(cityQueGried[0, index].Value.ToString(), out var id);
                    int.TryParse(cityQueGried[4, index].Value.ToString(), out var order);
                    if (converted == false)
                        MessageBox.Show("Не удалось добавить заказ");
                    //MessageBox.Show(id + order.ToString());
                    var driver = Db.Drivers.Find(id);
                    if (driver != null)
                    {
                        driver.Orders += 1;
                        driver.Location = "Поселок";
                        Engine.DeleteDriverFromQueue(driver, true); //Костыль
                        Engine.AddDriverToQueue(driver, false);
                    }

                    Db.SaveChangesAsync();
                    queDataGrid.DataSource = Engine.Refresh(false);
                    cityQueGried.DataSource = Engine.Refresh(true);
                    dataGridView1.Refresh();
                    queDataGrid.Refresh();
                    cityQueGried.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        private void offFromCityBtn_Click(object sender, EventArgs e)
        {
            try
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
                    Db.SaveChangesAsync();
                    dataGridView1.Refresh();
                    cityQueGried.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        #endregion

        #region ThirdTab

        private void delFromCmsGridBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (commissionGrid.SelectedRows.Count > 0)
                {
                    var index = 0;
                    var converted = int.TryParse(commissionGrid[0, index].Value.ToString(), out var id);
                    if (converted == false)
                        MessageBox.Show("Не удалось выбрать водителя");
                    var cmsDriver = Db.Commissions.Find(id);
                    Db.Commissions.Remove(cmsDriver);
                    commissionGrid.Refresh();
                    Db.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        private void sumCommissionBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                var numberDrivers = numberDriverTxtBox.Text;
                var driverNum = int.Parse(numberDrivers);
                var driverModel = commisionTxtBox.Text;
                var driver = Db.Drivers.First(p => p.Number == driverNum && p.Model == driverModel);
                countOrdersTxTBox.Text = driver.Orders.ToString();
                var sum = Engine.CalcCommission(driver.Orders).ToString();
                commisionTxtBox.Text = sum;
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        private void allOrdersPerWeekBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = Engine.CalcAllOrderPerWeek(Db.Drivers.ToList());
                ordersPerWeekTxtBox.Text = temp[0].ToString();
                allSumTxtBox.Text = temp[1].ToString();
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        // Сохранение старых данных о комиссии.
        // Сохранял в JSON формате, для того, что бы было удобно отправить файл на сервер или через Телеграм
        private void resetWeekBtn_Click(object sender, EventArgs e)
        {
            var cmsList = Db.Commissions.Local.ToList();
            Engine.SaveOldDataAsync(cmsList);
        }

        private void paidCheckBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (commissionGrid.SelectedRows.Count > 0)
                {
                    var index = commissionGrid.SelectedRows[0].Index;
                    var converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out var id);
                    if (converted == false)
                        MessageBox.Show("Не удалось поставить на линию");
                    var driver = Db.Drivers.Find(id);
                    var cms = Db.Commissions.Find(id);
                    driver.Orders = 0;
                    cms.PerWeek = 0;
                    cms.Paid = "Да";
                    Db.SaveChangesAsync();
                    commissionGrid.Refresh();
                }
            }
            catch (Exception exception)
            {
                Logger.Write(exception);
            }
        }

        #endregion

        #region FourTab

        private void saveSetCms_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(setCmsBox.Text))
            {
                Config.Commission = int.Parse(setCmsBox.Text);
            }
        }

        private void saveSettngsBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(serverAdrrTextBox.Text))
            {
                if (Config.UseTelegram == true)
                    Config.TelegramBotToken = serverAdrrTextBox.Text;
                else
                    Config.ServerURL = serverAdrrTextBox.Text;
            }

            Config.UserId = Engine.GetIDUser();
            ConfigEngine.SaveSettingsAsync();

        }

        private void devOpenButton_Click(object sender, EventArgs e)
        {
            if (devPassBox.Text == Config.DevPassword)
            {
                settingsGroupBox.Visible = true;
                userIdTextBox.Text = Engine.GetIDUser();
            }
            else
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var labelControls = settingsGroupBox.Controls.Find("serverLabel", false);
            var s = selectUploadBox.SelectedIndex;
            if (s == 1)
            {
                labelControls[0].Text = "Токен Бота:";
                Config.UseTelegram = true;
                Config.UseServer = false;
            }
            else
            {
                labelControls[0].Text = "Адрес сервера:";
                Config.UseServer = true;
                Config.UseTelegram = false;
            }
        }


        #endregion

        private void AddDriverToCommissionList(Driver driver)
        {
            var cms = new Commission
            {
                DriverNumber = driver.Number,
                DriverModel = driver.Model,
                PerWeek = 0,
                Paid = "Нет"
            };
            Db.Commissions.Add(cms);
            Db.SaveChangesAsync();
        }




        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var driver in Db.Drivers)
            {
                driver.Online = "Нет";
            }

            Db.SaveChangesAsync();




        }

        private void resetAllCmsButton_Click(object sender, EventArgs e)
        {
            Engine.ResetCommissionsAsync(Db.Drivers.ToList());

        }








    }
}