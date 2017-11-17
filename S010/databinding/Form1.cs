using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Linq.Expressions;

// REF: https://www.cnblogs.com/Xavierr/archive/2011/12/12/2284891.html

namespace databinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _myData = new MyData();
            textBox1.DataBindings.Add("Text", _myData, "TheValue", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", _myData, "TheValue", false, DataSourceUpdateMode.Never);
        }

        MyData _myData;
    }

    public class MyData : INotifyPropertyChanged
    {
        private string _theValue = string.Empty;

        public string TheValue
        {
            get { return _theValue; }
            set
            {
                if (string.IsNullOrEmpty(value) && value == _theValue)
                    return;

                _theValue = value;
                NotifyPropertyChanged(() => TheValue);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            if (PropertyChanged == null)
                return;

            var memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }

       

    }

}
