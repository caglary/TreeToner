using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeToner.BusinessLogicalLayer.LiteDb
{
    public static class bllMesajlar
    {

        public static void warning(string metin)
        {
            MessageBox.Show(metin,"Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }



    }
}
