namespace TaxiServices
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addDriverBtn = new System.Windows.Forms.Button();
            this.createOflineBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.onlineCityBtn = new System.Windows.Forms.Button();
            this.addOnlineBtn = new System.Windows.Forms.Button();
            this.delDriverBtn = new System.Windows.Forms.Button();
            this.addOrderBtn = new System.Windows.Forms.Button();
            this.queDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.orderToCityBtn = new System.Windows.Forms.Button();
            this.delOrderBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.offFromCityBtn = new System.Windows.Forms.Button();
            this.pauseDriverBtn = new System.Windows.Forms.Button();
            this.toPassBtn = new System.Windows.Forms.Button();
            this.cityQueGried = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.paidCheckBtn = new System.Windows.Forms.Button();
            this.saveComListWeekBtn = new System.Windows.Forms.Button();
            this.commissionGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.allOrdersPerWeekBtn = new System.Windows.Forms.Button();
            this.allSumTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.diffCommTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ordersPerWeekTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sumCommissionBtn = new System.Windows.Forms.Button();
            this.commisionTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.countOrdersTxTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numberDriverTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.setCmsBox = new System.Windows.Forms.TextBox();
            this.saveSetCms = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.devPassBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queDataGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityQueGried)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commissionGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(743, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // addDriverBtn
            // 
            this.addDriverBtn.Location = new System.Drawing.Point(6, 175);
            this.addDriverBtn.Name = "addDriverBtn";
            this.addDriverBtn.Size = new System.Drawing.Size(181, 23);
            this.addDriverBtn.TabIndex = 5;
            this.addDriverBtn.Text = "Добавить водителя";
            this.addDriverBtn.UseVisualStyleBackColor = true;
            this.addDriverBtn.Click += new System.EventHandler(this.addDriverBtn_Click);
            // 
            // createOflineBtn
            // 
            this.createOflineBtn.Location = new System.Drawing.Point(567, 175);
            this.createOflineBtn.Name = "createOflineBtn";
            this.createOflineBtn.Size = new System.Drawing.Size(182, 23);
            this.createOflineBtn.TabIndex = 6;
            this.createOflineBtn.Text = "Снять с линии";
            this.createOflineBtn.UseVisualStyleBackColor = true;
            this.createOflineBtn.Click += new System.EventHandler(this.createOflineBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.onlineCityBtn);
            this.groupBox1.Controls.Add(this.addOnlineBtn);
            this.groupBox1.Controls.Add(this.delDriverBtn);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.addDriverBtn);
            this.groupBox1.Location = new System.Drawing.Point(7, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 211);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Таксисты:";
            // 
            // onlineCityBtn
            // 
            this.onlineCityBtn.Location = new System.Drawing.Point(380, 175);
            this.onlineCityBtn.Name = "onlineCityBtn";
            this.onlineCityBtn.Size = new System.Drawing.Size(181, 23);
            this.onlineCityBtn.TabIndex = 11;
            this.onlineCityBtn.Text = "На линию в городе";
            this.onlineCityBtn.UseVisualStyleBackColor = true;
            this.onlineCityBtn.Click += new System.EventHandler(this.onlineCityBtn_Click);
            // 
            // addOnlineBtn
            // 
            this.addOnlineBtn.Location = new System.Drawing.Point(193, 175);
            this.addOnlineBtn.Name = "addOnlineBtn";
            this.addOnlineBtn.Size = new System.Drawing.Size(181, 23);
            this.addOnlineBtn.TabIndex = 10;
            this.addOnlineBtn.Text = "Поставить на линию";
            this.addOnlineBtn.UseVisualStyleBackColor = true;
            this.addOnlineBtn.Click += new System.EventHandler(this.addOnlineBtn_Click);
            // 
            // delDriverBtn
            // 
            this.delDriverBtn.Location = new System.Drawing.Point(567, 175);
            this.delDriverBtn.Name = "delDriverBtn";
            this.delDriverBtn.Size = new System.Drawing.Size(182, 23);
            this.delDriverBtn.TabIndex = 9;
            this.delDriverBtn.Text = "Удалить водителя";
            this.delDriverBtn.UseVisualStyleBackColor = true;
            this.delDriverBtn.Click += new System.EventHandler(this.delDriverBtn_Click);
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.Location = new System.Drawing.Point(6, 175);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(181, 23);
            this.addOrderBtn.TabIndex = 8;
            this.addOrderBtn.Text = "Добавить заказ";
            this.addOrderBtn.UseVisualStyleBackColor = true;
            this.addOrderBtn.Click += new System.EventHandler(this.addOrderBtn_Click);
            // 
            // queDataGrid
            // 
            this.queDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queDataGrid.Location = new System.Drawing.Point(6, 19);
            this.queDataGrid.Name = "queDataGrid";
            this.queDataGrid.ReadOnly = true;
            this.queDataGrid.Size = new System.Drawing.Size(743, 150);
            this.queDataGrid.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.orderToCityBtn);
            this.groupBox4.Controls.Add(this.delOrderBtn);
            this.groupBox4.Controls.Add(this.queDataGrid);
            this.groupBox4.Controls.Add(this.addOrderBtn);
            this.groupBox4.Controls.Add(this.createOflineBtn);
            this.groupBox4.Location = new System.Drawing.Point(7, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(760, 211);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Очередь на поселке:";
            // 
            // orderToCityBtn
            // 
            this.orderToCityBtn.Location = new System.Drawing.Point(193, 175);
            this.orderToCityBtn.Name = "orderToCityBtn";
            this.orderToCityBtn.Size = new System.Drawing.Size(181, 23);
            this.orderToCityBtn.TabIndex = 12;
            this.orderToCityBtn.Text = "Заказ в город";
            this.orderToCityBtn.UseVisualStyleBackColor = true;
            this.orderToCityBtn.Click += new System.EventHandler(this.orderToCityBtn_Click);
            // 
            // delOrderBtn
            // 
            this.delOrderBtn.Location = new System.Drawing.Point(380, 175);
            this.delOrderBtn.Name = "delOrderBtn";
            this.delOrderBtn.Size = new System.Drawing.Size(181, 23);
            this.delOrderBtn.TabIndex = 11;
            this.delOrderBtn.Text = "Удалить заказ";
            this.delOrderBtn.UseVisualStyleBackColor = true;
            this.delOrderBtn.Click += new System.EventHandler(this.delOrderBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 483);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Поселок";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Город";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.offFromCityBtn);
            this.groupBox5.Controls.Add(this.pauseDriverBtn);
            this.groupBox5.Controls.Add(this.toPassBtn);
            this.groupBox5.Controls.Add(this.cityQueGried);
            this.groupBox5.Location = new System.Drawing.Point(7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(760, 211);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Очередь в городе:";
            // 
            // offFromCityBtn
            // 
            this.offFromCityBtn.Location = new System.Drawing.Point(508, 175);
            this.offFromCityBtn.Name = "offFromCityBtn";
            this.offFromCityBtn.Size = new System.Drawing.Size(241, 23);
            this.offFromCityBtn.TabIndex = 1;
            this.offFromCityBtn.Text = "Снять с линии";
            this.offFromCityBtn.UseVisualStyleBackColor = true;
            this.offFromCityBtn.Click += new System.EventHandler(this.offFromCityBtn_Click);
            // 
            // pauseDriverBtn
            // 
            this.pauseDriverBtn.Location = new System.Drawing.Point(257, 175);
            this.pauseDriverBtn.Name = "pauseDriverBtn";
            this.pauseDriverBtn.Size = new System.Drawing.Size(245, 23);
            this.pauseDriverBtn.TabIndex = 2;
            this.pauseDriverBtn.Text = "Перерыв в городе";
            this.pauseDriverBtn.UseVisualStyleBackColor = true;
            // 
            // toPassBtn
            // 
            this.toPassBtn.Location = new System.Drawing.Point(6, 175);
            this.toPassBtn.Name = "toPassBtn";
            this.toPassBtn.Size = new System.Drawing.Size(245, 23);
            this.toPassBtn.TabIndex = 1;
            this.toPassBtn.Text = "В очередь на поселке";
            this.toPassBtn.UseVisualStyleBackColor = true;
            this.toPassBtn.Click += new System.EventHandler(this.toPassBtn_Click);
            // 
            // cityQueGried
            // 
            this.cityQueGried.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cityQueGried.Location = new System.Drawing.Point(6, 19);
            this.cityQueGried.Name = "cityQueGried";
            this.cityQueGried.ReadOnly = true;
            this.cityQueGried.Size = new System.Drawing.Size(743, 150);
            this.cityQueGried.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(779, 457);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Комиссия";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.paidCheckBtn);
            this.groupBox6.Controls.Add(this.saveComListWeekBtn);
            this.groupBox6.Controls.Add(this.commissionGrid);
            this.groupBox6.Location = new System.Drawing.Point(7, 132);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(758, 316);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Общий лист комиссии:";
            // 
            // paidCheckBtn
            // 
            this.paidCheckBtn.Location = new System.Drawing.Point(190, 283);
            this.paidCheckBtn.Name = "paidCheckBtn";
            this.paidCheckBtn.Size = new System.Drawing.Size(158, 23);
            this.paidCheckBtn.TabIndex = 2;
            this.paidCheckBtn.Text = "Подтвердить оплату";
            this.paidCheckBtn.UseVisualStyleBackColor = true;
            this.paidCheckBtn.Click += new System.EventHandler(this.paidCheckBtn_Click);
            // 
            // saveComListWeekBtn
            // 
            this.saveComListWeekBtn.Location = new System.Drawing.Point(9, 283);
            this.saveComListWeekBtn.Name = "saveComListWeekBtn";
            this.saveComListWeekBtn.Size = new System.Drawing.Size(175, 23);
            this.saveComListWeekBtn.TabIndex = 1;
            this.saveComListWeekBtn.Text = "Сохранить коммиссию";
            this.saveComListWeekBtn.UseVisualStyleBackColor = true;
            this.saveComListWeekBtn.Click += new System.EventHandler(this.resetWeekBtn_Click);
            // 
            // commissionGrid
            // 
            this.commissionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commissionGrid.Location = new System.Drawing.Point(9, 19);
            this.commissionGrid.Name = "commissionGrid";
            this.commissionGrid.ReadOnly = true;
            this.commissionGrid.Size = new System.Drawing.Size(743, 258);
            this.commissionGrid.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.allOrdersPerWeekBtn);
            this.groupBox3.Controls.Add(this.allSumTxtBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.diffCommTxtBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ordersPerWeekTxtBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(253, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 123);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Статистика за неделю:";
            // 
            // allOrdersPerWeekBtn
            // 
            this.allOrdersPerWeekBtn.Location = new System.Drawing.Point(12, 89);
            this.allOrdersPerWeekBtn.Name = "allOrdersPerWeekBtn";
            this.allOrdersPerWeekBtn.Size = new System.Drawing.Size(75, 23);
            this.allOrdersPerWeekBtn.TabIndex = 10;
            this.allOrdersPerWeekBtn.Text = "Посчитать";
            this.allOrdersPerWeekBtn.UseVisualStyleBackColor = true;
            this.allOrdersPerWeekBtn.Click += new System.EventHandler(this.allOrdersPerWeekBtn_Click);
            // 
            // allSumTxtBox
            // 
            this.allSumTxtBox.Location = new System.Drawing.Point(194, 70);
            this.allSumTxtBox.Name = "allSumTxtBox";
            this.allSumTxtBox.ReadOnly = true;
            this.allSumTxtBox.Size = new System.Drawing.Size(100, 20);
            this.allSumTxtBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Разница с предыдущей неделей:";
            // 
            // diffCommTxtBox
            // 
            this.diffCommTxtBox.Location = new System.Drawing.Point(194, 45);
            this.diffCommTxtBox.Name = "diffCommTxtBox";
            this.diffCommTxtBox.ReadOnly = true;
            this.diffCommTxtBox.Size = new System.Drawing.Size(100, 20);
            this.diffCommTxtBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Общая сумма комиссии:";
            // 
            // ordersPerWeekTxtBox
            // 
            this.ordersPerWeekTxtBox.Location = new System.Drawing.Point(194, 17);
            this.ordersPerWeekTxtBox.Name = "ordersPerWeekTxtBox";
            this.ordersPerWeekTxtBox.ReadOnly = true;
            this.ordersPerWeekTxtBox.Size = new System.Drawing.Size(100, 20);
            this.ordersPerWeekTxtBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Количество заказов за неделю:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sumCommissionBtn);
            this.groupBox2.Controls.Add(this.commisionTxtBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.countOrdersTxTBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numberDriverTxtBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 123);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Комиссия:";
            // 
            // sumCommissionBtn
            // 
            this.sumCommissionBtn.Location = new System.Drawing.Point(9, 89);
            this.sumCommissionBtn.Name = "sumCommissionBtn";
            this.sumCommissionBtn.Size = new System.Drawing.Size(75, 23);
            this.sumCommissionBtn.TabIndex = 9;
            this.sumCommissionBtn.Text = "Посчитать";
            this.sumCommissionBtn.UseVisualStyleBackColor = true;
            this.sumCommissionBtn.Click += new System.EventHandler(this.sumCommissionBtn_Click_1);
            // 
            // commisionTxtBox
            // 
            this.commisionTxtBox.Location = new System.Drawing.Point(126, 70);
            this.commisionTxtBox.Name = "commisionTxtBox";
            this.commisionTxtBox.ReadOnly = true;
            this.commisionTxtBox.Size = new System.Drawing.Size(100, 20);
            this.commisionTxtBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Сумма комисии:";
            // 
            // countOrdersTxTBox
            // 
            this.countOrdersTxTBox.Location = new System.Drawing.Point(126, 43);
            this.countOrdersTxTBox.Name = "countOrdersTxTBox";
            this.countOrdersTxTBox.Size = new System.Drawing.Size(100, 20);
            this.countOrdersTxTBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Модель машины:";
            // 
            // numberDriverTxtBox
            // 
            this.numberDriverTxtBox.Location = new System.Drawing.Point(126, 17);
            this.numberDriverTxtBox.Name = "numberDriverTxtBox";
            this.numberDriverTxtBox.Size = new System.Drawing.Size(100, 20);
            this.numberDriverTxtBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Номер водителя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(779, 457);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Настройки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.saveSetCms);
            this.groupBox7.Controls.Add(this.setCmsBox);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(7, 14);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(233, 87);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Настройки комиссии:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Комиссия за заказ:";
            // 
            // setCmsBox
            // 
            this.setCmsBox.Location = new System.Drawing.Point(121, 22);
            this.setCmsBox.Name = "setCmsBox";
            this.setCmsBox.Size = new System.Drawing.Size(100, 20);
            this.setCmsBox.TabIndex = 1;
            // 
            // saveSetCms
            // 
            this.saveSetCms.Location = new System.Drawing.Point(9, 58);
            this.saveSetCms.Name = "saveSetCms";
            this.saveSetCms.Size = new System.Drawing.Size(212, 23);
            this.saveSetCms.TabIndex = 2;
            this.saveSetCms.Text = "Сохранить";
            this.saveSetCms.UseVisualStyleBackColor = true;
            this.saveSetCms.Click += new System.EventHandler(this.saveSetCms_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.devPassBox);
            this.groupBox8.Location = new System.Drawing.Point(7, 107);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(233, 341);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Настройки разработчика:";
            // 
            // devPassBox
            // 
            this.devPassBox.Location = new System.Drawing.Point(121, 19);
            this.devPassBox.Name = "devPassBox";
            this.devPassBox.Size = new System.Drawing.Size(100, 20);
            this.devPassBox.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Пароль:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 483);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queDataGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cityQueGried)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commissionGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addDriverBtn;
        private System.Windows.Forms.Button createOflineBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addOrderBtn;
        private System.Windows.Forms.Button delDriverBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button delOrderBtn;
        private System.Windows.Forms.Button addOnlineBtn;
        public System.Windows.Forms.DataGridView queDataGrid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button sumCommissionBtn;
        private System.Windows.Forms.TextBox commisionTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox countOrdersTxTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numberDriverTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button allOrdersPerWeekBtn;
        private System.Windows.Forms.TextBox allSumTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox diffCommTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ordersPerWeekTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button offFromCityBtn;
        private System.Windows.Forms.Button pauseDriverBtn;
        private System.Windows.Forms.Button toPassBtn;
        private System.Windows.Forms.DataGridView cityQueGried;
        private System.Windows.Forms.Button orderToCityBtn;
        private System.Windows.Forms.Button onlineCityBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView commissionGrid;
        private System.Windows.Forms.Button paidCheckBtn;
        private System.Windows.Forms.Button saveComListWeekBtn;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox devPassBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button saveSetCms;
        private System.Windows.Forms.TextBox setCmsBox;
        private System.Windows.Forms.Label label8;
    }
}

