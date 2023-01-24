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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
namespace Послений_пример
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Students
        {
            public string name1 { get; set; }
            public string fam1 { get; set; }
            public string ot1 { get; set; }
            public string mat1 { get; set; }
            public string phis1 { get; set; }
            public string info1 { get; set; }
        }

        List<Students> st = new List<Students>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click_1(object sender, RoutedEventArgs e)
        {

            if (Name.Text.Length == 0 || Fam.Text.Length == 0 || Ot.Text.Length == 0
                || Mat.Text.Length == 0 || Phis.Text.Length == 0 || Info.Text.Length == 0) res.Text = "Пустая строка";
            else if (Mat.Text.Length > 1 || Phis.Text.Length > 1 || Info.Text.Length > 1
                || Char.Parse(Mat.Text) < '2' || Char.Parse(Mat.Text) > '5'
                || Char.Parse(Phis.Text) < '2' || Char.Parse(Phis.Text) > '5'
                || Char.Parse(Info.Text) < '2' || Char.Parse(Info.Text) > '5') res.Text = "Не корректное написание оценки";
            else if (Name.Text.Length > 50 || Fam.Text.Length > 50 || Ot.Text.Length > 50) res.Text = "Более 50 символов";
            else
            {
                Students s = new Students();

                s.name1 = Name.Text;
                s.fam1 = Fam.Text;
                s.ot1 = Ot.Text;
                s.mat1 = Mat.Text;
                s.phis1 = Phis.Text;
                s.info1 = Info.Text;

                st.Add(s);
                l.Items.Add(s);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string FileName = "";
            string FileText = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "|*.txt";
            foreach (Students s in st)
                FileText += $"{s.name1 + ", " + s.fam1 + ", " + s.ot1 + ", " + s.mat1 + ", " + s.phis1 + ", " + s.info1}\n";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = dialog.FileName;
                File.WriteAllText(FileName, FileText);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            bool FileCheck = true;
            string FileText = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileText = File.ReadAllText(dialog.FileName);
                }
                catch
                {
                    FileCheck = false;
                }
            }
            else FileCheck = false;
            if (FileCheck)
            {
                st.Clear();
                l.Items.Clear();
                int badString = -1;
                foreach (string str in FileText.Split('\n'))
                {
                    if (st.Count < 100)
                    {
                        string[] field = str.Split();
                        if (field.Length == 6)
                        {
                            Students s = new Students();

                            s.name1 = field[0];
                            s.fam1 = field[1];
                            s.ot1 = field[2];
                            s.mat1 = field[3];
                            s.phis1 = field[4];
                            s.info1 = field[5];

                            st.Add(s);
                            l.Items.Add(s);
                        }
                        else badString++;
                    }
                    else badString++;
                }
                if (badString > 0) System.Windows.MessageBox.Show("Не произведена записаь. \nНе записано: " + badString.ToString()
                     + "\nЗаписано: " + st.Count.ToString());
            }
            else System.Windows.MessageBox.Show("Поврежден файл");
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            l.Items.Remove(l.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Math2 = 0;
            int Phis2 = 0;
            int Info2 = 0;

            int Math3 = 0;
            int Phis3 = 0;
            int Info3 = 0;

            int Math4 = 0;
            int Phis4 = 0;
            int Info4 = 0;

            int Math5 = 0;
            int Phis5 = 0;
            int Info5 = 0;

            foreach (Students s in st)
            {
                if(s.mat1 == "2") Math2++;
                if(s.phis1 == "2") Phis2++;
                if (s.info1 == "2") Info2++;
                int result2 = Math2 + Phis2 + Info2;

                if (s.mat1 == "3") Math3++;
                if (s.phis1 == "3") Phis3++;
                if (s.info1 == "3") Info3++;
                int result3 = Math3 + Phis3 + Info3;

                if (s.mat1 == "4") Math4++;
                if (s.phis1 == "4") Phis4++;
                if (s.info1 == "4") Info4++;
                int result4 = Math4 + Phis4 + Info4;

                if (s.mat1 == "5") Math5++;
                if (s.phis1 == "5") Phis5++;
                if (s.info1 == "5") Info5++;
                int result5 = Math5 + Phis5 + Info5;

                res.Text = "2: " + result2 + "\n3: " + result3 + "\n4: " + result4 + "\n5: " + result5;
            }
        }
    }
}
