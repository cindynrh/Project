using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    //membuat class untuk method 1
    public class Method1
    {
        private int[] cindy = new int[29];
        private int n;

        //membuat method untuk menginputkan elemen array
        public void read()
        {
            while (true)
            {
                Console.Write("Masukkan jumlah Elemen array: ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 29)
                    break;
                else
                    Console.WriteLine("\n Array dapat dimasukkan hingga 29. \n");
            }
            Console.WriteLine("\n--------------------");
            Console.WriteLine(" Masukkan elemen Array ");
            Console.WriteLine("----------------------");

            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + "> ");
                string s1 = Console.ReadLine();
                cindy[i] = Int32.Parse(s1);
            }
        }

        //membuat method untuk menampilkan method 1
        public void display()
        {
            Console.WriteLine("\n--------------------");
            Console.WriteLine(" elemen array telah disortir ");
            Console.WriteLine("----------------------");

            for (int fd = 0; fd < n; fd++)
            {
                Console.WriteLine(cindy[fd]);
            }
        }
        //membuat method untuk mensortir array yang di inputkan
        public void sort()
        {
            for (int i = 1; i < n; i++)
            {
                int temp = cindy[i];
                int fd = i - 1;
                while (fd >= 0 && cindy[fd] > temp)
                {
                    cindy[fd + 1] = cindy[fd];
                    fd--;
                }
                cindy[fd + 1] = temp;
            }
            return;
        }
    }
    //membuat class untuk method 2
    public class Method2
    {
        private int[] cindy = new int[29];
        private int[] sorted = new int[29];
        private int cmp_count, mov_count, n;
        public Method2()
        {
            //untuk menampilkan jumlah perbandingan
            cmp_count = 0;
            //untuk menampilkan jumlah perpindahan data
            mov_count = 0;
        }
        //membuat method untuk menginputkan elemen array
        public void read()
        {
            while (true)
            {
                Console.WriteLine("Masukkan jumlah elemen array: ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 29)
                    break;
                else
                    Console.WriteLine("\n Array dapat dimasukkan hingga 29. \n");
            }
            Console.WriteLine("\n---------------");
            Console.WriteLine(" Masukkan elemen array ");
            Console.WriteLine("---------------------");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                cindy[i] = Int32.Parse(s1);
            }
        }
        //membuat method untuk menukar 
        public void swap(int x, int y)
        {
            int temp;
            temp = cindy[x];
            cindy[x] = cindy[y];
            cindy[y] = temp;
        }

        //MergeSort function
        void merge(int low, int mid, int high)
        {
            int i, fd, k;
            i = low;
            fd = mid + 1;
            k = low;
            while ((i <= mid) && (fd <= high))
            {
                if (cindy[i] <= cindy[fd])
                {
                    sorted[k++] = cindy[i++];
                }
                else
                {
                    sorted[k++] = cindy[fd++];
                }
                cmp_count++;
            }
            while (i <= mid)
            {
                sorted[k++] = cindy[i++];
                mov_count++;
            }
            while (fd <= high)
            {
                sorted[k++] = cindy[fd++];
                mov_count++;
            }
            for (i = low; i <= high; i++)
            {
                cindy[i] = sorted[i];
                mov_count++;
            }
        }
        //m_sort method
        public void m_sort(int low, int high)
        {
            int mid;
            if (low >= high)
                return;
            mid = (low + high) / 2;
            m_sort(low, mid);
            m_sort(mid + 1, high);
            merge(low, mid, high);
        }
        //membuat method untuk menampilkan array yang diinputkan
        public void display()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine(" elemen array telah disortir ");
            Console.WriteLine("-------------------------");
            for (int fd = 0; fd < n; fd++)
            {
                Console.WriteLine(cindy[fd] + "\n");
            }
            Console.WriteLine("\njumlah perbandingan: " + cmp_count);
            Console.WriteLine("\njumlah perpindahan data: " + mov_count);
        }
        public int getSize() { return (n); }
    }

    class program
    {
        static void Main(string[] args)
        {
            //membuat instansi untuk kelas method 1 dan method 2
            Method1 m1 = new Method1();
            Method2 m2 = new Method2();

            //deklarasi variabel untuk ekspresi Switch
            int pilih;

            //membuat Perulangan
            Console.WriteLine(" MENU ");
            Console.WriteLine("======");
            Console.WriteLine("1. Method1");
            Console.WriteLine("2. Method2");
            Console.WriteLine("3. Selesai/keluar");
            Console.Write("Pilih (1/2/3) : ");
            pilih = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            //membuat switch
            switch (pilih)
            {
                case 1:
                    m1.read();
                    m1.sort();
                    m1.display();
                    break;
                case 2:
                    m2.read();
                    m2.m_sort(0, m2.getSize() - 1);
                    m2.display();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Pilihan Salah !");
                    Console.ReadKey();
                    break;
            }
            Console.Read();
        }
    }
}
