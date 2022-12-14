using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zh2_NTPSHY.Models;

namespace Zh2_NTPSHY
{
    public partial class Form2 : Form
    {
        StudiesContext context = new StudiesContext();
        public Form2()
        {
            InitializeComponent();
            instructorBindingSource.DataSource = context.Instructors.ToList();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, string.Empty);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Érvénytelen");
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, string.Empty);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            Regex r = new Regex("Dr\\.");

            if (!r.IsMatch(textBox2.Text)&& !string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Dr. vagy semmi");
            }
                
        }

        void Szures()
        {
            var lekerdez = from x in context.Statuses
                           select x;
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = lekerdez.ToList();
        }
        void Szures1()
        {
            var lekerdez = from x in context.Employements
                           select x;
            listBox2.DisplayMember = "Name";
            listBox2.DataSource = lekerdez.ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Szures();
            Szures1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {


                var index = ((Status)listBox1.SelectedItem).StatusId;
                var index2 = ((Employement)listBox2.SelectedItem).EmployementId;

                Instructor i = new Instructor();
                i.Name = textBox1.Text;
                i.Salutation = textBox2.Text;
                i.StatusFk = index;
                i.EmployementFk = index2;

                context.Instructors.Add(i);
                try
                {
                    context.SaveChanges();
                    instructorBindingSource.DataSource = context.Instructors.ToList();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
