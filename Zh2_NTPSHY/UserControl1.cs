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
    public partial class UserControl1 : UserControl
    {
        StudiesContext context = new StudiesContext();
        public UserControl1()
        {
            InitializeComponent();
            timeBindingSource.DataSource = context.Times.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Szures();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Szures2();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabla();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabla();
        }


        void Szures()
        {
            var lekeredez = from x in context.Rooms
                            where x.Name.StartsWith(textBox1.Text)
                            select x;
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = lekeredez.ToList();
        }
        void Szures2()
        {
            var lekeredez = from x in context.Courses
                            where x.Name.StartsWith(textBox2.Text)
                            select new ListB
                            {
                                CourseSk = x.CourseSk,
                                CourseName = x.Name
                            };
            listBox2.DisplayMember = "CourseName";
            listBBindingSource.DataSource = lekeredez.ToList();
        }

        void Tabla()
        {
            if (listBox2.SelectedItem == null) return;
            
            var index = ((Room)listBox1.SelectedItem).RoomSk;
            var index2 = ((ListB)listBox2.SelectedItem).CourseSk;

            var lekerdez = from x in context.Lessons
                           where x.CourseFk == index2 && x.RoomFk == index
                           select new Dtg
                           {
                               TimeFk = x.TimeFkNavigation.TimeId,
                               CourseName = x.CourseFkNavigation.Name,
                               RoomName = x.RoomFkNavigation.Name
                           };

            dtgBindingSource1.DataSource = lekerdez.ToList();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Szures();
            Szures2();
            Tabla();
        }
    }

    public class Dtg
    {
        public byte TimeFk { get; set; }
        public string CourseName { get; set; }
        public string RoomName { get; set; }
    }
    public class ListB
    {
        public int CourseSk { get; set; }

        public string CourseName { get; set; }
    }
}
