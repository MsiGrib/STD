using STD.GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace STD.GUI.Widgets
{
    public partial class indexing : UserControl
    {
        private List<string> issuedBy = new List<string>() { "УФМС..." };// learn and add
        private List<string> rate = new List<string>() { "1.0", "0.5" };
        private List<string> lowSalary = new List<string>() { "24 080", "22 400" };// learn and expand
        private List<string> highSalary = new List<string>() { "24 080 (двадцать четыре тысячи восемьдесят)",
                "22 400 (двадцать две тысячи четыреста)" };// learn and expand
        createFile createFile = new createFile();

        public indexing()
        {
            InitializeComponent();
            castomCombobox2.Items.AddRange(lowSalary.ToArray());
            castomCombobox3.Items.AddRange(rate.ToArray());
            castomCombobox1.Items.AddRange(issuedBy.ToArray());
            castomCombobox1.ClientSize = new System.Drawing.Size(700, 50);
            castomCombobox2.ClientSize = new System.Drawing.Size(150, 50);
            castomCombobox3.ClientSize = new System.Drawing.Size(130, 50);

            num1Textbox.Text = "1";
            num2Textbox.Text = "2";
            fioTextbox.Text = "qwe";
            serialTextbox.Text = "123";
            numberTextbox.Text = "123";
            dateTextbox.Text = "123123";
            addressTextbox.Text = "fdfsf";
            castomCombobox1.SelectedIndex = 0;
            castomCombobox2.SelectedIndex = 0;
            castomCombobox3.SelectedIndex = 0;
        }

        private bool checkoutValidation()
        {
            if (string.IsNullOrEmpty(num1Textbox.Text) || string.IsNullOrEmpty(num2Textbox.Text) ||
                    string.IsNullOrEmpty(fioTextbox.Text) || string.IsNullOrEmpty(serialTextbox.Text) ||
                    string.IsNullOrEmpty(numberTextbox.Text) || string.IsNullOrEmpty(dateTextbox.Text) ||
                    string.IsNullOrEmpty(addressTextbox.Text) ||
                    string.IsNullOrEmpty(castomCombobox1.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(castomCombobox2.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(castomCombobox3.SelectedItem.ToString()))
                return false;
            else
                return true;
        }

        private string getSalary(string value)
        {
            foreach (var item in lowSalary.Select((val, idx) => new { val, idx }))
                if (item.val == value)
                    return highSalary[item.idx];
            return null;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (!checkoutValidation())
            {
                MessageBox.Show("Вы ввели не все поля!", "Ошибка");
                return;
            }
            indexingInfo tmp;
            tmp.num1 = num1Textbox.Text;
            tmp.num2 = num2Textbox.Text;
            tmp.fio = fioTextbox.Text;
            tmp.serial = serialTextbox.Text;
            tmp.number = numberTextbox.Text;
            tmp.date = dateTextbox.Text;
            tmp.issuedBy = castomCombobox1.SelectedItem.ToString();
            tmp.registrAddress = addressTextbox.Text;
            tmp.salary = getSalary(castomCombobox2.SelectedItem.ToString());
            tmp.rate = castomCombobox3.SelectedItem.ToString();
            tmp.mainDate = $"<<{dateTimePicker1.Value.Day}>> {dateTimePicker1.Value.ToString("MMMM")} {dateTimePicker1.Value.Year}";
            try
            {
                Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        createBtn.Enabled = false;
                    }));
                    if (!createFile.createIndexing(tmp))
                        MessageBox.Show("Документ не был создан!", "Ошибка");
                    this.Invoke(new MethodInvoker(delegate
                    {
                        createBtn.Enabled = true;
                    }));
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось создать документ!", "Ошибка");
                throw;
            }
        }
    }
}
