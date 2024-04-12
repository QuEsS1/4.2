using System;
using static test.Form1;

namespace test
{
    public partial class Form1 : Form
    {
        public List<NOTE> Notes;
        public struct NOTE
        {
            public string FamilyName;
            public string Name;
            public string PhoneNumber;
            public DateTime BirthDate;
            public NOTE(string familyName, string name, string phoneNumber, DateTime birthDate)
            {
                FamilyName = familyName;
                Name = name;
                PhoneNumber = phoneNumber;
                BirthDate = birthDate;
            }   
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str;
            using (StreamReader s = new StreamReader("1.txt"))
            {
                str = s.ReadToEnd();
            }
            richTextBox1.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random(); ;
            string[] n = { "���������", "�������", "������", "�����", "�����", "�����", "�����", "��������", "�������", "�������", "������", "�������", "��������", "��������", "��������", "�������", "����", "��������", "������", "�������", "�������", "����", "����", "�����", "����", "������", "����������", "������", "������", "������", "������", "�������", "����", "�����", "����", "�����", "������", "������", "���������", "������", "�������", "�����", "����", "�������" };
            string[] f = { "������", "������", "�������", "�������", "��������", "��������", "�����", "�������", "�������", "������", "�������", "�������", "������", "�������", "��������", "������", "������", "�������", "�������", "����������", "��������", "��������", "���������", "�����", "�������", "�������", "��������", "�����", "�������", "��������", "�������", "�������", "�������", "������", "�����", "�������" };
            List<NOTE> notes = new List<NOTE>();
            for (int i = 0; i < 10; i++)
            {
                string PhoneNumber;
                int ran = random.Next(0, 2);
                if (ran == 0)
                {
                    textBox1.Text = "������� ����� � ���� ����";
                    PhoneNumber = textBox2.Text.ToString();
                }
                else
                {
                    PhoneNumber = "����� �� ������";
                }
                DateTime birthDate = new DateTime(random.Next(1950, 2010), random.Next(1, 13), random.Next(1, 29));
                NOTE note = new NOTE(n[random.Next(n.Length)], f[random.Next(f.Length)], PhoneNumber, birthDate);
                notes.Add(note);
            }
            Notes = notes;
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += Notes[i].Name.ToString() + " " + Notes[i].FamilyName.ToString() + " " + Notes[i].PhoneNumber.ToString() + " " + Notes[i].BirthDate.ToString("dd.MM.yyyy") + '\n';
            }
            using (StreamWriter writer = new StreamWriter("1.txt"))
            {
                writer.WriteLine(str);
            }
            textBox1.Text = "��������� ������ �������";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            File.Delete("1.txt");
            File.Delete("2.txt");
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            textBox1.Text = "���� ������";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader r = new StreamReader("1.txt"))
            {
                string s=r.ReadToEnd();
                using (StreamWriter writer=new StreamWriter("2.txt"))
                {
                    writer.Write(s);
                }
            }
            textBox1.Text = "���� ��������";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<NOTE> notes = Notes;
            for (int i = 0; i < notes.Count - 1; i++)
            {
                for (int j = 0; j < notes.Count - i - 1; j++)
                {
                    if (notes[j].BirthDate > notes[j + 1].BirthDate)
                    {
                        NOTE temp = notes[j];
                        notes[j] = notes[j + 1];
                        notes[j + 1] = temp;
                    }
                }
            }
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += Notes[i].Name.ToString() + " " + Notes[i].FamilyName.ToString() + " " + Notes[i].PhoneNumber.ToString() + " " + Notes[i].BirthDate.ToString("dd.MM.yyyy") + '\n';
            }
            using (StreamWriter writer = new StreamWriter("2.txt"))
            {
                writer.WriteLine(str);
            }
            richTextBox2.Text = str;
        }
    }
}
