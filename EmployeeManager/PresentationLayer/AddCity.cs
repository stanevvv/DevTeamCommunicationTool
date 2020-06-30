using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel;

namespace PresentationLayer
{
    public partial class AddCity : Form
    {
        public AddCity()
        {
            InitializeComponent();
        }

        private void addCityButton_Click(object sender, EventArgs e)
        {
            CityViewModel city = new CityViewModel(nameTextBox.Text, zipCodeTextBox.Text);

            Form1 f1 = (Form1) Application.OpenForms["Form1"];
            f1.AddComboBoxItem($"{city.Name}-{city.ZipCode}");

            Hide();
        }


    }
}
