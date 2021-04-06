using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            NetworkEngine.UploadStatisticFileAsync("01.04.2021");
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
                Db.SaveChanges();
                AddDriverToCommissionList(driver);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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
                if (driver != null && driver.Online != "Да")
                {
                    driver.Online = "Да";
                    Engine.AddDriverToQueue(driver, false);
                }
                queDataGrid.DataSource = Engine.Refresh(false);

                Db.SaveChanges();
                dataGridView1.Refresh();
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
            catch (Exception)
            {
                MessageBox.Show("Возникла непредвиденная ошибка");
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
                var drivercom = Db.Commissions.Find(id);

                if (driver != null && queDataGrid.SelectedRows[0].Index == 0)
                {
                    //MessageBox.Show(queDataGrid.SelectedRows[0].Index.ToString());//queDataGrid[0, index].ToString());
                    driver.Orders += 1;
                    Engine.DeleteDriverFromQueue(driver, false); //Костыль
                    Engine.AddDriverToQueue(driver, false);
                    drivercom.PerWeek = Engine.CalcCommission(driver.Orders);
                    Db.SaveChanges();
                    queDataGrid.DataSource = Engine.Refresh(false);
                    dataGridView1.Refresh();
                }
                else if(driver != null)
                {
                    driver.Orders += 1;
                    Engine.DeleteDriverFromQueue(driver, false, true);
                    //Engine.DeleteDriverFromQueue(driver, false);
                    queDataGrid.DataSource = Engine.Refresh(false);//Костыль
                    Engine.AddDriverToQueue(driver, false);
                    drivercom.PerWeek = Engine.CalcCommission(driver.Orders);
                    Db.SaveChanges();
                    queDataGrid.DataSource = Engine.Refresh(false);
                    dataGridView1.Refresh();
                }
                

                //var drivercom = Db.Commissions.Find(id);
                
                
            }
        }

        private void orderToCityBtn_Click(object sender, EventArgs e)
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

                Db.SaveChanges();
                queDataGrid.DataSource = Engine.Refresh(false);
                cityQueGried.DataSource = Engine.Refresh(true);
                dataGridView1.Refresh();
                queDataGrid.Refresh();
                cityQueGried.Refresh();
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
        #endregion

        #region SecondTab

        private void toPassBtn_Click(object sender, EventArgs e)
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

        #endregion

        #region ThirdTab

        private void sumCommissionBtn_Click_1(object sender, EventArgs e)
        {
            var numberDrivers = numberDriverTxtBox.Text;
            var driverNum = int.Parse(numberDrivers);
            var driverModel = commisionTxtBox.Text;
            var driver = Db.Drivers.First(p => p.Number == driverNum && p.Model == driverModel);
            countOrdersTxTBox.Text = driver.Orders.ToString();
            var sum = Engine.CalcCommission(driver.Orders).ToString();
            commisionTxtBox.Text = sum;
        }

        private void allOrdersPerWeekBtn_Click(object sender, EventArgs e)
        {
            var temp = Engine.CalcAllOrderPerWeek(Db.Drivers.ToList());
            ordersPerWeekTxtBox.Text = temp[0].ToString();
            allSumTxtBox.Text = temp[1].ToString();
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

        #endregion

        #region FourTab

        private void saveSetCms_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(setCmsBox.Text))
            {
                Config.Commission = int.Parse(setCmsBox.Text);
            }
        }


        #endregion

        private void AddDriverToCommissionList(Driver driver)
        {
            var cms = new Commission
            {
                DriverNumber = driver.Number, DriverModel = driver.Model, PerWeek = 0, Paid = "Нет"
            };
            Db.Commissions.Add(cms);
            Db.SaveChangesAsync();
        }

        
        private  void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var driver in Db.Drivers)
            {
                    driver.Online = "Нет";
            }

            Db.SaveChanges();
           

            

        }

        private void resetAllCmsButton_Click(object sender, EventArgs e)
        {
            Engine.ResetCommissionsAsync(Db.Drivers.ToList());
            
        }

        
    }
}