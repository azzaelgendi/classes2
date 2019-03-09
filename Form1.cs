using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * ***************************************************************************
 * 
 * Revision History 
 * written by Azza Elgendy
 * March 26,2018
 * Purpose classes ,composition 
 * 
 * ***************************************************************************/
namespace classes2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Box myBox;
        public class Point
        {
            private int x;
            private int y;
            private int z;

            public int X
            {
                set { x = value; }
                get { return x; }
            }

            public int Y
            {
                set { y = value; }
                get { return y; }
            }
            public int Z
            {
                set { z = value; }
                get { return z; }
            }
        }
        public class line
        {
            private Point ptn1;
            private Point ptn2;
            public Point Ptn1
            {
                set { ptn1 = value; }
                get { return ptn1; }
            }
            public Point Ptn2
            {
                set { ptn2 = value; }
                get { return ptn2; }
            }
            public int CalculateLine()
            {
                if ((Ptn1.X - Ptn2.X) != 0)
                {
                    return Math.Abs(Ptn1.X - Ptn2.X);
                }
                else if ((Ptn1.Y - Ptn2.Y) != 0)
                {
                    return Math.Abs(Ptn1.Y - Ptn2.Y);
                }
                else
                {
                    return Math.Abs(Ptn1.Z - Ptn2.Z);
                }
            }
        }
        public class Box //line
        {
            private line ln1;
            private line ln2;
            private line ln3;

            public line Ln1
            {
                set { ln1 = value; }
                get { return ln1; }
            }
            public line Ln2
            {
                set { ln2 = value; }
                get { return ln2; }
            }
            public line Ln3
            {
                set { ln3 = value; }
                get { return ln3; }
            }
            public string CalculateLenght()
            {
                string data = "";
                int width = Ln1.CalculateLine();
                int height = Ln2.CalculateLine();
                int lenght = Ln3.CalculateLine();
                data = "Lenght = " + lenght.ToString() + " cm\n"
                    + "Width = " + width.ToString() + " cm\n"
                    + "height = " + lenght.ToString() + " cm\n";
                return data;
            }

            public int CalculateArea()
            {

                int area = ((Ln1.CalculateLine() * Ln2.CalculateLine() * 2)
                    + (Ln2.CalculateLine() * Ln3.CalculateLine() * 2)
                    + (Ln1.CalculateLine() * Ln3.CalculateLine() * 2));
                return area;
            }
            public int CalculateVolume()
            {
                int width = Ln1.CalculateLine();
                int height = Ln2.CalculateLine();
                int lenght = Ln3.CalculateLine();
                int volume = (Ln1.CalculateLine()
                    * Ln2.CalculateLine()
                    * Ln3.CalculateLine());
                return volume;
            }
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //show the hidden objects
            pictureBoxToHide.Hide();
            pictureBox1.Show();
            groupBox1.Show();
            groupBox2.Show();
            groupBox3.Show();
            groupBoxline1.Show();
            //call the main class
            myBox = new Box();
            //load the data in to lines and point
            myBox.Ln1 = new line();
            myBox.Ln1.Ptn1 = new Point();
            myBox.Ln1.Ptn2 = new Point();

            myBox.Ln2 = new line();
            myBox.Ln2.Ptn1 = new Point();
            myBox.Ln2.Ptn2 = new Point();

            myBox.Ln3 = new line();
            myBox.Ln3.Ptn1 = new Point();
            myBox.Ln3.Ptn2 = new Point();
            // load the X,Y,Z to the points
            //line 1
            myBox.Ln1.Ptn1.X = Convert.ToInt32(textBoxX.Text);
            myBox.Ln1.Ptn1.Y = Convert.ToInt32(textBoxY.Text);
            myBox.Ln1.Ptn1.Z = Convert.ToInt32(textBoxZ.Text);
            myBox.Ln1.Ptn2.X = Convert.ToInt32(textBoxXLine1.Text);
            myBox.Ln1.Ptn2.Y = Convert.ToInt32(textBoxYLine1.Text);
            myBox.Ln1.Ptn2.Z = Convert.ToInt32(textBoxZLine1.Text);
            //line 2
            myBox.Ln2.Ptn1.X = Convert.ToInt32(textBoxX.Text);
            myBox.Ln2.Ptn1.Y = Convert.ToInt32(textBoxY.Text);
            myBox.Ln2.Ptn1.Z = Convert.ToInt32(textBoxZ.Text);
            myBox.Ln2.Ptn2.X = Convert.ToInt32(textBoxXLine2.Text);
            myBox.Ln2.Ptn2.Y = Convert.ToInt32(textBoxYLine2.Text);
            myBox.Ln2.Ptn2.Z = Convert.ToInt32(textBoxZLine2.Text);
            //line 3
            myBox.Ln3.Ptn1.X = Convert.ToInt32(textBoxX.Text);
            myBox.Ln3.Ptn1.Y = Convert.ToInt32(textBoxY.Text);
            myBox.Ln3.Ptn1.Z = Convert.ToInt32(textBoxZ.Text);
            myBox.Ln3.Ptn2.X = Convert.ToInt32(textBoxXLine3.Text);
            myBox.Ln3.Ptn2.Y = Convert.ToInt32(textBoxYLine3.Text);
            myBox.Ln3.Ptn2.Z = Convert.ToInt32(textBoxZLine3.Text);
            //Dispaly the result
            richTextBoxDisplay.Text = myBox.CalculateLenght();
            richTextBoxDisplay.Text += "The Box Area : "
                + myBox.CalculateArea().ToString() + "cm2\n";
            richTextBoxDisplay.Text += "The Box Volume : "
                + myBox.CalculateVolume().ToString() + "cm3\n";
            textBoxPoint1.Text = (("( " + myBox.Ln1.Ptn1.X
                + ", "
                + myBox.Ln1.Ptn1.Y
                + ", "
                + myBox.Ln1.Ptn1.Z
                + " )").ToString());
            textBoxPoint2Line1.Text = (("( " + myBox.Ln1.Ptn2.X
                + ", "
                + myBox.Ln1.Ptn2.Y
                + ", "
                + myBox.Ln1.Ptn2.Z
                + " )").ToString());
            textBoxPoint2Line2.Text = (("( " + myBox.Ln2.Ptn2.X
                + ", "
                + myBox.Ln2.Ptn2.Y
                + ", "
                + myBox.Ln2.Ptn2.Z
                + " )").ToString());
            textBoxPoint2Line3.Text = (("( " + myBox.Ln3.Ptn2.X
                + ", "
                + myBox.Ln3.Ptn2.Y
                + ", "
                + myBox.Ln3.Ptn2.Z + " )").ToString());
        }
        //hide objects on form load
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBoxline1.Hide();
        }
    }
}
