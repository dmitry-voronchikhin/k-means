using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace k_means
{
    [Serializable]
    class file
    {
        public DataTable table;
        public DataTable tmpTable;
        public double Err = 0;
        public List<Center> centers;
        public double[] koordCenters;
        public List<int[]> classList;
        public List<double> errors;
        //public DataTable grid;
        //public string[] names;

    }
}
