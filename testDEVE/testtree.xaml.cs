using System;
using System.Collections.Generic;
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
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for testtree.xaml
    /// </summary>
    public partial class testtree : Window
    {
        dtbbdsDataContext dc = new dtbbdsDataContext();
        public testtree()
        {
            InitializeComponent();
            
        }
    }
}
