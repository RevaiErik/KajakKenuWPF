using System.IO;
using System.Text;
using System.Windows;
using KajakKenuWPF;

namespace KajakKenuWPF
{
    public partial class MainWindow : Window
    {
        List<Kolcsonzes> kolcsonzesek = [];
        public MainWindow()
        {
            InitializeComponent();
            Kolcsonzesek_Listbox = null;

            using (StreamReader be = new(path: @"..\..\..\src\kolcsonzes.txt", encoding: Encoding.UTF8))
            {
                _ = be.ReadLine();
                while (!be.EndOfStream)
                {
                    Kolcsonzes kolcsonzes = new(be.ReadLine());
                    kolcsonzesek.Add(kolcsonzes);
                }
            }
 
            Kolcsonzesek_Grid.ItemsSource = kolcsonzesek;

            for (int i = 0; i < 24; i++) Ora.Items.Add(i);
            for (int i = 0; i < 60; i++) Perc.Items.Add(i);

        }

       
        private void OsszesKolcsonzes_Click(object sender, RoutedEventArgs e)
        {
            foreach (Kolcsonzes kolcsonzes in kolcsonzesek)
            {
                Kolcsonzesek_Listbox.Items.Add(kolcsonzes.ToString());
            }
        }




        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            KeresesEredmeny.Items.Clear();
          
            string ido = $"{Ora.Text}:{Perc.Text}";
            var eredmeny = kolcsonzesek.FindAll(k => k.VizenVan(ido)).ToList();
            foreach (var item in eredmeny) KeresesEredmeny.Items.Add(item);
            
        }
    }
}