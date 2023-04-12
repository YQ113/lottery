using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Threading;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace a108223012lottery
{
    public partial class Form1 : Form
    {
        PictureBox[] pb = new PictureBox[50];
        //Image ball = Image.FromFile(Application.StartupPath + "\\Resources/ball.png");

        Random rnd = new Random();
        int[] x = new int[50];
        int[] y = new int[50];
        int[] p = new int[6];
        int[] a = new int[6];
        int count = 0;
        int[] record;
        bool o = false;
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i < 50; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Width = 37;
                pb[i].Height = 37;
                //pb[i].BackColor = Color.Black;
                pb[i].Visible = true;
                pb[i].BorderStyle = BorderStyle.None;
                pb[i].Top = 354;
                //pb[i].Top = 0;
                //pb[i].Left = 115;
                //pb[i].Left = 190;
                pb[i].Left = rnd.Next(0, 310);
                pb[i].BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                pb[i].BackgroundImageLayout = ImageLayout.Stretch;
                pb[i].Name = i.ToString();
                panel1.Controls.Add(pb[i]);
                pb[i].Enabled = false;

                x[i] = rnd.Next(0, 2);
                y[i] = rnd.Next(0, 2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'lurtorDataSet.record' 資料表。您可以視需要進行移動或移除。
            this.recordTableAdapter.Fill(this.lurtorDataSet.record);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < 50; i++)
            {
                switch (x[i] % 2)
                {
                    case 0:
                        if (pb[i].Left < panel1.Width - pb[i].Width)
                        {
                            pb[i].Left = pb[i].Left + 10;
                        }
                        else
                        {
                            x[i] = x[i] + 1;
                        }
                        break;
                    case 1:
                        if (pb[i].Left > 0)
                        {
                            pb[i].Left = pb[i].Left - 10;
                        }
                        else
                        {
                            x[i] = x[i] - 1;
                        }
                        break;
                }
                switch (y[i] % 2)
                {
                    case 0:
                        if (pb[i].Top < panel1.Height - pb[i].Height)
                        {
                            pb[i].Top = pb[i].Top + 10;

                        }
                        else
                        {
                            y[i] = y[i] + 1;
                        }
                        break;
                    case 1:
                        if (pb[i].Top > 0)
                        {
                            pb[i].Top = pb[i].Top - 10;
                            if (pb[i].Top <= 0 && pb[i].Left > 115 && pb[i].Left < 190)
                            {
                                if (o == true)
                                {

                                    if (count == 0)
                                    {
                                        pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                                        pictureBox1.Enabled = false;
                                        timer2.Enabled = true;
                                        p[count] = i;
                                    }
                                    else if (count == 1)
                                    {
                                        pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                                        pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                                        pictureBox2.Enabled = false;
                                        timer3.Enabled = true;
                                        p[count] = i;
                                    }
                                    else if (count == 2)
                                    {
                                        pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                                        pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
                                        pictureBox3.Enabled = false;
                                        timer4.Enabled = true;
                                        p[count] = i;
                                    }
                                    else if (count == 3)
                                    {
                                        pictureBox4.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                                        pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
                                        pictureBox4.Enabled = false;
                                        timer5.Enabled = true;
                                        p[count] = i;
                                    }
                                    else if (count == 4)
                                    {
                                        pictureBox5.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                                        pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
                                        pictureBox5.Enabled = false;
                                        timer6.Enabled = true;
                                        p[count] = i;
                                    }
                                    else if (count == 5)
                                    {
                                        pictureBox6.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                                        pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
                                        pictureBox6.Enabled = false;
                                        timer7.Enabled = true;
                                        p[count] = i;
                                    }
                                    else
                                    {
                                        textBox1.Text = p[0].ToString();
                                        textBox2.Text = p[1].ToString();
                                        textBox3.Text = p[2].ToString();
                                        textBox4.Text = p[3].ToString();
                                        textBox5.Text = p[4].ToString();
                                        textBox6.Text = p[5].ToString();
                                        timer1.Enabled = false;
                                        for (int j = 1; j < 50; j++)
                                        {
                                            pb[j].Visible = true;
                                            pb[j].Top = 354;
                                            pb[j].Left = rnd.Next(0, 310);
                                            pb[j].Enabled = false;
                                            x[i] = rnd.Next(0, 2);
                                            y[i] = rnd.Next(0, 2);
                                        }
                                        button2.Enabled = true;
                                        insert_to_access();
                                        DataGridView_show();
                                    }
                                    count++;
                                }
                            }
                        }
                        else
                        {
                            y[i] = y[i] - 1;
                        }
                        break;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Top > 600)
            {
                pictureBox1.Top -= 4;

            }
            else
            {
                pictureBox1.Left += 10;
                if (pictureBox1.Left >= 150)
                {
                    timer2.Enabled = false;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox2.Top > 600)
            {
                pictureBox2.Top -= 4;

            }
            else
            {
                pictureBox2.Left += 10;
                if (pictureBox2.Left >= 455)
                {
                    timer3.Enabled = false;
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Top > 600)
            {
                pictureBox3.Top -= 4;

            }
            else
            {
                pictureBox3.Left += 10;
                if (pictureBox3.Left >= 400)
                {
                    timer4.Enabled = false;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            if (pictureBox4.Top > 600)
            {
                pictureBox4.Top -= 4;

            }
            else
            {
                pictureBox4.Left += 10;
                if (pictureBox4.Left >= 350)
                {
                    timer5.Enabled = false;
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {

            if (pictureBox5.Top > 600)
            {
                pictureBox5.Top -= 4;

            }
            else
            {
                pictureBox5.Left += 10;
                if (pictureBox5.Left >= 300)
                {
                    timer6.Enabled = false;
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (pictureBox6.Top > 600)
            {
                pictureBox6.Top -= 4;

            }
            else
            {
                pictureBox6.Left += 10;
                if (pictureBox6.Left >= 250)
                {
                    timer7.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 50; i++)
            {
                pb[i].Top = rnd.Next(0, 310);
                pb[i].Left = rnd.Next(0, 354);
            }
            timer1.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {                 
            button3.Enabled = false;
            button4.Enabled = true;
            o = true;

            //var sameArr = a.Intersect(p).ToArray();
            //if (sameArr != null)
            //    label4.Text = "本期中獎號碼為" + sameArr;
            //else label4.Text = "本期沒有中獎";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;

            pictureBox1.BackgroundImage = null;
            pictureBox1.Top = 175;
            pictureBox1.Left = 600;
            pictureBox2.BackgroundImage = null;
            pictureBox2.Top = 175;
            pictureBox2.Left = 550;
            pictureBox3.BackgroundImage = null;
            pictureBox3.Top = 175;
            pictureBox3.Left = 500;
            pictureBox4.BackgroundImage = null;
            pictureBox4.Top = 175;
            pictureBox4.Left = 450;
            pictureBox5.BackgroundImage = null;
            pictureBox5.Top = 175;
            pictureBox5.Left = 400;
            pictureBox6.BackgroundImage = null;
            pictureBox6.Top = 175;
            pictureBox6.Left = 350;

            count = 0;
            o = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            for (int i = 0; i < 6; i++)
            {
                a[i] = -1;
                p[i] = -1;
            }

            for (int i = 1; i < 50; i++)
            {
                //pb[i].BackColor = Color.Black;
                pb[i].Visible = true;
                pb[i].BorderStyle = BorderStyle.None;
                pb[i].Top = 354;
                //pb[i].Top = 0;
                //pb[i].Left = 115;
                //pb[i].Left = 190;
                pb[i].Left = rnd.Next(0, 310);
                pb[i].BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources/ball" + i.ToString() + ".png");
                pb[i].BackgroundImageLayout = ImageLayout.Stretch;
                pb[i].Name = i.ToString();
                panel1.Controls.Add(pb[i]);
                pb[i].Enabled = false;

                x[i] = rnd.Next(0, 2);
                y[i] = rnd.Next(0, 2);
            }
        }

        private void DataGridView_show()
        {
            //第一步：設定連線字串
            String strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=lurtor.accdb";

            //第二步：建立資料庫連線物件

            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = strConnectionString;

            //第三步：開啟資料庫連線
            cn.Open();

            //第四步：取得資料並填入 DataSet
            OleDbDataAdapter oleda = new OleDbDataAdapter("SELECT * FROM record", cn);
            DataSet ds = new DataSet("ds_dragon_ball");
            oleda.Fill(ds, "ds_dragon_ball");

            //第五步：設定 DataSource

            //*方法一****************************************
            //DataGridView1.DataSource = ds.Tables[0];

            //bindingSource1.DataSource = ds.Tables[0];
            //DataGridView1.DataSource = bindingSource1;
            //*方法一****************************************

            //*方法二****************************************
            DataGridView1.DataSource = ds;
            DataGridView1.DataMember = ("ds_dragon_ball");
            //*方法二****************************************

            //第六步：關閉資料庫連線
            cn.Close();
        }

        private void insert_to_access()
        {
            //第一步：設定連線字串
            String strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=lurtor.accdb";

            //第二步：建立資料庫連線物件
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = strConnectionString;

            //第三步：開啟資料庫連線
            cn.Open();

            //SQL
            String SqlStr = "";
            SqlStr = " insert into record( ball_1, ball_2, ball_3, ball_4, ball_5, ball_sp )values( ";
            //SqlStr &= "'" & Date.Now.ToShortDateString & "' ,"
            for (int z = 0; z < 5; z++)
            {
                SqlStr += "'" + p[z] + "',";
            }
            SqlStr += "'" + p[5] + "' )";

            //建立Command物件
            OleDbCommand command_ = new OleDbCommand(SqlStr, cn);
            //執行SQL語法
            command_.ExecuteNonQuery();

            //關閉資料庫連線
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridView_show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
