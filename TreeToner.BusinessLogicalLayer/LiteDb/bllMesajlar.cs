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
            MessageBox.Show(metin,"Uyarı Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        public static void error(string metin)
        {
            MessageBox.Show(metin, "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void information(string metin)
        {
            MessageBox.Show(metin, "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void question(string metin)
        {
            MessageBox.Show(metin, "Soru ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
