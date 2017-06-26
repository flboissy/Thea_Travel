using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Data
{
    public class JournéeViewModel
    {
        public int Index { get; set; }
        public IJournée Model { get; set; }

        public JournéeViewModel(int i, IJournée m)
        {
            Index = i;
            Model = m;
        }
    }
}
