using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using De.TorstenMandelkow.MetroChart;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HIMS.Report
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //TestPageViewModel ob = new TestPageViewModel();
           // qwe.ItemsSource = ob.Errors;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Count", typeof(Int32));
            DataRow dr = dt.NewRow();
            //dr[0][0] ="Vivek";
            //dr[0][1] =10;
            dt.Rows.Add("VIVEK", 10);
            dt.Rows.Add("Dharm", 2);
            var test = new ObservableCollection<TestClass>();
            //foreach(var row in dt.Rows)
            //{
            //    var obj = new TestClass()
            //    {
            //        Number = (int)row.ItemArray[0],
            //        Category = (string)row.ItemArray[1]

            //    };
            //}
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                var obj = new TestClass() { Number = (int)dt.Rows[i].ItemArray[1], Category = (string)dt.Rows[i].ItemArray[0] };
                test.Add(obj);
            }
            qwe.ItemsSource = test;
            //mychart.ItemsSource = dt.DefaultView;

            //(De.TorstenMandelkow.MetroChart.PieChart.mcChart.Series[0].ItemsSource) =dt.DefaultView;
            //pie.Series[0].ItemsSource = dt.DefaultView;
            //Errors = new ObservableCollection<TestClass>();
            //Series = new ObservableCollection<SeriesData>();
            //Errors.Add(new TestClass() { Category = "Globalization", Number = 75 });
            //Errors.Add(new TestClass() { Category = "Features", Number = 2 });
            //Errors.Add(new TestClass() { Category = "ContentTypes", Number = 12 });
            //Errors.Add(new TestClass() { Category = "Correctness", Number = 83 });
            //Errors.Add(new TestClass() { Category = "Naming", Number = 80 });
            //Errors.Add(new TestClass() { Category = "Best Practices", Number = 29 });
            //Series.Add(new SeriesData() { SeriesDisplayName = "Errors", Items = Errors });

            //mycharts.DisplayMember = "Name";
            ////mychart.DisplayMemberPath = "Name ";
            //mycharts.ValueMember = "Count";
            //    ((De.TorstenMandelkow.MetroChart.ChartSeries)pie.Series[0]).ItemsSource =
            //new KeyValuePair<string, int>[]{
            //newKeyValuePair<string,int>("Project Manager", 12),
            //newKeyValuePair<string,int>("CEO", 25),
            //newKeyValuePair<string,int>("Software Engg.", 5),
            //newKeyValuePair<string,int>("Team Leader", 6),
            //newKeyValuePair<string,int>("Project Leader", 10),
            //newKeyValuePair<string,int>("Developer", 4) };
            //}
            //public abc
            //{

            //}
            //pie.Series.Add();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            //obj.Show();
        }
        //public System.Collections.ObjectModel.ObservableCollection<TestClass> Errors
        //{
        //    get;
        //    set;
        //}
        //public ObservableCollection<SeriesData> Series
        //{
        //    get;
        //    set;
        //}
    }
    //public class SeriesData
    //{
    //    public string SeriesDisplayName { get; set; }

    //    public string SeriesDescription { get; set; }

    //    public ObservableCollection<TestClass> Items { get; set; }
    //}
    //public class TestClass : INotifyPropertyChanged
    //{
    //    public string Category { get; set; }

    //    private float _number = 0;
    //    public float Number
    //    {
    //        get
    //        {
    //            return _number;
    //        }
    //        set
    //        {
    //            _number = value;
    //            if (PropertyChanged != null)
    //            {
    //                this.PropertyChanged(this, new PropertyChangedEventArgs("Number"));
    //            }
    //        }

    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //}

    //public class CountryCollection :Collection<Country> // Extending from System.Collections.ObjectModel.Collection class
    //{
    //    public CountryCollection() // Constructor to add Country objects to the CountryCollection
    //    {
    //        Add(new Country("China", 1336718015));
    //        Add(new Country("India", 1189172906));
    //        Add(new Country("United States", 313232044));
    //        Add(new Country("Indonesia", 245613043));
    //        Add(new Country("Brazil", 203429773));
    //    }
    //}
    //public class Country
    //{
    //    public Country(string Name, long Population)    // Constructor
    //    {
    //        this.Name = Name;
    //        this.Population = Population;
    //    }
    //    public string Name                // Name Property
    //    {
    //        get;
    //        set;
    //    }
    //    public long Population                // Population Property
    //    {
    //        get;
    //        set;
    //    }
    //}
    //public class TestPageViewModel
    //{
    //    public ObservableCollection<TestClass> Errors { get; private set; }

    //    public TestPageViewModel()
    //    {
    //        Errors = new ObservableCollection<TestClass>();
    //        Errors.Add(new TestClass() { Category = "Globalization", Number = 75 });
    //        Errors.Add(new TestClass() { Category = "Features", Number = 2 });
    //        Errors.Add(new TestClass() { Category = "ContentTypes", Number = 12 });
    //        Errors.Add(new TestClass() { Category = "Correctness", Number = 83 });
    //        Errors.Add(new TestClass() { Category = "Best Practices", Number = 29 });
    //    }

    //    private object selectedItem = null;
    //    public object SelectedItem
    //    {
    //        get
    //        {
    //            return selectedItem;
    //        }
    //        set
    //        {
    //            // selected item has changed
    //            selectedItem = value;
    //        }
    //    }
    //}

    // class which represent a data point in the chart
    public class TestClass
    {
        public string Category { get; set; }

        public int Number { get; set; }
    }
}
