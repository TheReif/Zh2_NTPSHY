using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zh2_NTPSHY.Models;
using Day = Zh2_NTPSHY.Models.Day;

namespace Zh2_NTPSHY
{
    
    public partial class Form3 : Form
    {
        StudiesContext context = new StudiesContext();
        public Form3()
        {
            InitializeComponent();
            lessonBindingSource.DataSource = context.Lessons.ToList();

        }
        void Szures()
        {
            var lekerdez = from x in context.Instructors
                           select x;
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = lekerdez.ToList();
        }
        void Szures1()
        {
            var lekerdez = from x in context.Courses
                           select x;
            listBox2.DisplayMember = "Name";
            listBox2.DataSource = lekerdez.ToList();
        }
        void Szures2()
        {
            var lekerdez = from x in context.Times
                           select x;
            listBox3.DisplayMember = "Name";
            listBox3.DataSource = lekerdez.ToList();
        }
        void Szures3()
        {
            var lekerdez = from x in context.Rooms
                           select x;
            listBox4.DisplayMember = "Name";
            listBox4.DataSource = lekerdez.ToList();
        }
        void Szures4()
        {
            var lekerdez = from x in context.Days
                           select x;
            listBox5.DisplayMember = "Name";
            listBox5.DataSource = lekerdez.ToList();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Szures();
            Szures1();
            Szures2();
            Szures3();
            Szures4();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = ((Instructor)listBox1.SelectedItem).InstructorSk;
            var index1 = ((Course)listBox2.SelectedItem).CourseSk;
            var index2 = ((Time)listBox3.SelectedItem).TimeId;
            var index3 = ((Room)listBox4.SelectedItem).RoomSk;
            var index4 = ((Day)listBox5.SelectedItem).DayId;


            Lesson l = new Lesson();
            l.InstructorFk = index;
            l.CourseFk = index1;
            l.TimeFk = index2;
            l.RoomFk = index3;
            l.DayFk = index4;

            context.Lessons.Add(l);
            try
            {
                context.SaveChanges();
                lessonBindingSource.DataSource = context.Lessons.ToList();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
