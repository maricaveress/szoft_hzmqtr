using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace mintazh
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new();
        public Form1()
        {
            InitializeComponent();
            countryDataBindingSource.DataSource = countryList;
            dataGridView1.DataSource = countryDataBindingSource;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("european_countries.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var x = csv.GetRecords<CountryData>();
                foreach (var item in x)
                {
                    countryList.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //t�r�l
        {
            countryDataBindingSource.RemoveCurrent();

        }

        private void button3_Click(object sender, EventArgs e) //edit
        {
            FormCountryEdit fce = new FormCountryEdit();
            fce.CountryData = countryDataBindingSource.Current as CountryData;
            fce.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter("countries.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write records to the CSV file
                csv.WriteRecords(countryList);
            };
        }
    }
}