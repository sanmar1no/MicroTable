
namespace MicroTable
{
    partial class MicroTable
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TEST = new System.Windows.Forms.Button();
            this.LoadTXTtoDB = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.labelRoom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRatio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRoom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBuilding = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNameClient = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.dtpRecords = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.NamesTables = new System.Windows.Forms.Label();
            this.btnWriteRecord = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(770, 199);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(544, 274);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.TEST);
            this.panel1.Controls.Add(this.LoadTXTtoDB);
            this.panel1.Controls.Add(this.btnRead);
            this.panel1.Controls.Add(this.btnWrite);
            this.panel1.Controls.Add(this.labelRoom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbRatio);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbRoom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbBuilding);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbNameClient);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(770, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 172);
            this.panel1.TabIndex = 1;
            // 
            // TEST
            // 
            this.TEST.Location = new System.Drawing.Point(451, 123);
            this.TEST.Name = "TEST";
            this.TEST.Size = new System.Drawing.Size(75, 23);
            this.TEST.TabIndex = 16;
            this.TEST.Text = "TEST";
            this.TEST.UseVisualStyleBackColor = true;
            this.TEST.Click += new System.EventHandler(this.TEST_Click);
            // 
            // LoadTXTtoDB
            // 
            this.LoadTXTtoDB.Location = new System.Drawing.Point(451, 94);
            this.LoadTXTtoDB.Name = "LoadTXTtoDB";
            this.LoadTXTtoDB.Size = new System.Drawing.Size(75, 23);
            this.LoadTXTtoDB.TabIndex = 15;
            this.LoadTXTtoDB.Text = "LoadTXT";
            this.LoadTXTtoDB.UseVisualStyleBackColor = true;
            this.LoadTXTtoDB.Click += new System.EventHandler(this.LoadTXTtoDB_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(451, 48);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 14;
            this.btnRead.Text = "button2";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(451, 19);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 13;
            this.btnWrite.Text = "button1";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(17, 129);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(94, 17);
            this.labelRoom.TabIndex = 12;
            this.labelRoom.Text = "Помещение: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Коэффициент";
            // 
            // tbRatio
            // 
            this.tbRatio.Location = new System.Drawing.Point(332, 72);
            this.tbRatio.Name = "tbRatio";
            this.tbRatio.Size = new System.Drawing.Size(100, 22);
            this.tbRatio.TabIndex = 8;
            this.tbRatio.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "N счетчика";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(115, 72);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 22);
            this.tbNumber.TabIndex = 6;
            this.tbNumber.Text = "654987";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Помещение";
            // 
            // tbRoom
            // 
            this.tbRoom.Location = new System.Drawing.Point(332, 44);
            this.tbRoom.Name = "tbRoom";
            this.tbRoom.Size = new System.Drawing.Size(100, 22);
            this.tbRoom.TabIndex = 4;
            this.tbRoom.Text = "21";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Корпус";
            // 
            // tbBuilding
            // 
            this.tbBuilding.Location = new System.Drawing.Point(115, 44);
            this.tbBuilding.Name = "tbBuilding";
            this.tbBuilding.Size = new System.Drawing.Size(100, 22);
            this.tbBuilding.TabIndex = 2;
            this.tbBuilding.Text = "23";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Арендатор";
            // 
            // tbNameClient
            // 
            this.tbNameClient.Location = new System.Drawing.Point(115, 16);
            this.tbNameClient.Name = "tbNameClient";
            this.tbNameClient.Size = new System.Drawing.Size(100, 22);
            this.tbNameClient.TabIndex = 0;
            this.tbNameClient.Text = "ООО \"Ты\"";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(318, 70);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(100, 22);
            this.tbValue.TabIndex = 11;
            this.tbValue.Text = "65";
            this.tbValue.Visible = false;
            // 
            // dtpRecords
            // 
            this.dtpRecords.Location = new System.Drawing.Point(443, 70);
            this.dtpRecords.Name = "dtpRecords";
            this.dtpRecords.Size = new System.Drawing.Size(169, 22);
            this.dtpRecords.TabIndex = 10;
            this.dtpRecords.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(297, 404);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 31);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(297, 22);
            this.tbSearch.TabIndex = 12;
            this.tbSearch.Text = "Поиск";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Арендаторы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Помещения";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(240, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Счетчики";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(315, 103);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(297, 364);
            this.listBox2.TabIndex = 19;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // NamesTables
            // 
            this.NamesTables.AutoSize = true;
            this.NamesTables.Location = new System.Drawing.Point(315, 34);
            this.NamesTables.Name = "NamesTables";
            this.NamesTables.Size = new System.Drawing.Size(86, 17);
            this.NamesTables.TabIndex = 20;
            this.NamesTables.Text = "Помещения";
            // 
            // btnWriteRecord
            // 
            this.btnWriteRecord.Location = new System.Drawing.Point(641, 72);
            this.btnWriteRecord.Name = "btnWriteRecord";
            this.btnWriteRecord.Size = new System.Drawing.Size(92, 23);
            this.btnWriteRecord.TabIndex = 21;
            this.btnWriteRecord.Text = "Записать";
            this.btnWriteRecord.UseVisualStyleBackColor = true;
            this.btnWriteRecord.Click += new System.EventHandler(this.btnWriteRecord_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(641, 115);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MicroTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 479);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnWriteRecord);
            this.Controls.Add(this.NamesTables);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpRecords);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "MicroTable";
            this.Text = "MicroTable";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBuilding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNameClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRatio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.DateTimePicker dtpRecords;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button LoadTXTtoDB;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label NamesTables;
        private System.Windows.Forms.Button btnWriteRecord;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button TEST;
    }
}

