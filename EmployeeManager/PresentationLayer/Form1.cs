using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using ViewModel;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            employee.Age = int.Parse(ageTextBox.Text);
            employee.Name = nameTextBox.Text;

            string[] cityData = cityComboBox.SelectedItem.ToString().Split('-').ToArray();
            employee.City = new CityViewModel(cityData[0], cityData[1]);


            employeesListBox.Items.Add($"{employee.Name}-{employee.Age}-{employee.City.Name}-{employee.City.ZipCode}");
        }

        private void addCityButton_Click(object sender, EventArgs e)
        {
            AddCity ac = new AddCity();
            ac.ShowDialog();
        }

        public void AddComboBoxItem(string item)
        {
            cityComboBox.Items.Add(item);
        }
    }
}
