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

namespace Zh2_NTPSHY
{
    public partial class UserControl3 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl3()
        {
            InitializeComponent();
            lessonBindingSource.DataSource = context.Lessons.ToList();
        }


        void Szures()
        {
            var lekerdez = from x in context.Lessons
                           select x;
            listBox1.DisplayMember = "LessonSk";
            listBox1.DataSource = lekerdez.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var index = ((Lesson)listBox1.SelectedItem).LessonSk;

            var törlendő = from x in context.Lessons
                           where x.LessonSk == index
                           select x;

            context.Lessons.Remove(törlendő.FirstOrDefault());
            try
            {
                context.SaveChanges();
                lessonBindingSource.DataSource = context.Lessons.ToList();
                Szures();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            Szures();
        }
    }
}
