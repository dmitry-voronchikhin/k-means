using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    public class Center
    {
        double[] koordinates;
        public Center(double[] koord)
        {
            koordinates = koord;
        }

        public double this[int i]
        {
            get
            {
               return koordinates[i];
            }
            set
            {
                koordinates[i] = value;
            }
        }

        public int Count
        {
            get
            {
                return koordinates.Count();
            }
        }

        public Center Clone()
        {
            return new Center(koordinates);
        }
    }
}
