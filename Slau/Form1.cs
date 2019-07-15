using System;
using System.Windows.Forms;


namespace Slau
{
    public partial class Form1 : Form
    {
        double[] b;      //Ответы

        double[,] matrix;//Коэффициенты

        double[] x = new double[100];

        const int n = 3; //Размерность матриц
        Gauss_Zeidel gz;
        Gauss_Djordano gj;
        public Form1()
        {
            InitializeComponent();
            InitMatrix(p);
            gz = new Gauss_Zeidel(this, matrix, b);
            gj = new Gauss_Djordano(this, matrix, b);
        }

        void Next_Click(object sender, EventArgs e)
        {
            if (p < 2) InitMatrix(p);
            else { p = 0; InitMatrix(0); }
            gz = new Gauss_Zeidel(this, matrix, b);
            gj = new Gauss_Djordano(this, matrix, b);
            label1.Text = "n: " + p.ToString();
            p++;
        }

        byte p = 0;
        void InitMatrix(byte p)
        {   //Задаём новые коэффициенты и ответы
            switch (p)
            {
                case 0:
                    {
                        b = new double[] { 11, 4, 6 };
                        matrix = new double[,] { { 5, 0, 10 }, { 1, 3, -1 }, { -30, 20 , 10 } }; break;
                    }
            
                case 1:
                    {
                        b = new double[] { -23, -13, 16 };
                        matrix = new double[,] { { 4, -7, 8 }, { 2, -4, 5 }, { -3, 11, 1 } }; break;
                    }
                
            }
            fillGrid(matrix, b);
        }

        void Gauss_Zeidel_Click(object sender, EventArgs e)
        => gz.Get();//Метод Гаусса - Зейделля
        void Gauss_Jordano_Click(object sender, EventArgs e)
        => gj.Get(); //Метод Гаусса - Жорданно

        public void fillGrid(double[,] matrix, double[] b, double[] x = null)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 1; i < n + 1; i++)
            {
                dataGridView1.Columns.Add("collum1", "x" + i.ToString());
                dataGridView1.Rows.Add("Row", "A" + i.ToString());
            }
            dataGridView1.Columns.Add("B", "B");
            for (int i = 0; i < n; i++)
            {   //Заносим значение матриц
                for (int j = 0; j < n; j++)
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];

                dataGridView1.Rows[i].Cells[n].Value = b[i];
            }
            dataGridView1.Columns.Add("X", "Xi");
            if (x == null) x = new double[n];
            for (int i = 0; i < n; i++) dataGridView1.Rows[i].Cells[4].Value = x[i];
        }
        public int GetN => n;//Возвращаем размерность матриц
    }

    class Gauss_Zeidel
    {
        Form1 mw;

        int N;                  //Размерность матрици
        double[] b;             //Ответы
        double[,] matrix;       //Коэффициенты

        public Gauss_Zeidel(Form1 mw, double[,] matrix, double[] b)
        {
            this.mw = mw /*as Form1*/;
            this.matrix = matrix;
            this.b = b;
            N = mw.GetN;
            X = new double[N];
            P = new double[N];
            a = matrix;
        }

        double[] X;
        double[] P;
        double[,] a;
        bool converge(double[] xk, double[] xkp)
        {   //Проверяем достигнута ли искомая погрешность
            double norm = 0;
            for (int i = 0; i < N; i++)
                norm += (xk[i] - xkp[i]) * (xk[i] - xkp[i]);

            return Math.Sqrt(norm) >= 0.001;
        }

        public void Get()
        {
            for (int i = 0; i < N; i++)
                X[i] = 0;
            do
            {
                for (int i = 0; i < N; i++)
                    P[i] = X[i];

                for (int i = 0; i < N; i++)
                {
                    double var = 0;
                    for (int j = 0; j < i; j++)
                        var += (matrix[i, j] * X[j]);
                    for (int j = i + 1; j < N; j++)
                        var += (matrix[i, j] * P[j]);
                    X[i] = (b[i] - var) / matrix[i, i];
                }
            }
            while (converge(X, P));
            mw.fillGrid(matrix, P, X);
        }
    }

    class Gauss_Djordano
    {
        Form1 mw;

        int N;                  //Размерность матрици
        double[] b;             //Ответы
        double[,] matrix;       //Коэффициенты

        public Gauss_Djordano(Form1 mw, double[,] matrix, double[] b)
        {
            this.mw = mw /*as Form1*/;
            this.matrix = matrix;
            this.b = b;
            N = mw.GetN;
            x = new double[N];
        }

        double[] x;

        void First_Element(double[,] matrix, double[] b)
        {
            int imax = 0, j = 0;
            double max = matrix[0, 0];
            bool izmena = false;
            for (int i = 1; i < N; i++)
            {
                if (max < matrix[i, 0])
                {
                    imax = i;
                    izmena = true;
                    max = matrix[i, 0];
                }
                if (max == matrix[i, 0])
                    while (j < N)
                    {
                        if (matrix[imax, j + 1] < matrix[i, j + 1])
                        {
                            imax = i;
                            izmena = true;
                        }
                        else break;
                        j++;
                    }
            }
            double c = 0;
            if (izmena == true)
            {
                for (int i = 0; i < N; i++)
                {
                    c = matrix[0, i];
                    matrix[0, i] = matrix[imax, i];
                    matrix[imax, i] = c;
                }
                c = b[0];
                b[0] = b[imax];
                b[imax] = c;
            }
        }

        public void Get()
        {
            First_Element(matrix, b);//Выбор ведущего элемента
            int n1 = 0;
            do
            {
                double del = matrix[n1, n1];
                for (int i = n1; i < N; i++)
                    matrix[n1, i] = matrix[n1, i] / del;

                b[n1] = b[n1] / del;
                for (int i = n1 + 1; i < N; i++)
                {
                    double mult = matrix[i, n1];
                    for (int j = n1; j < N; j++)
                        matrix[i, j] = matrix[i, j] - matrix[n1, j] * mult;

                    b[i] = b[i] - b[n1] * mult;
                }

                n1++;
            } while (n1 < N);
            int n2 = N - 1;
            do
            {
                for (int i = n2 - 1; i >= 0; i--)
                {
                    double mult = matrix[n2 - 1, n2];
                    for (int j = n2; j >= 0; j--)
                        matrix[i, j] = matrix[i, j] - matrix[n2, j] * mult;

                    b[i] = b[i] - b[n2] * mult;
                }
                n2--;
            } while (0 < n2);

            double mult1 = matrix[0, N - 1];
            for (int j = 0; j < N; j++)
                matrix[0, j] = matrix[0, j] - matrix[N - 1, j] * mult1;

            b[0] = b[0] - b[N - 1] * mult1;
            for (int j = 0; j < N; j++)
                x[j] = b[j];

            mw.fillGrid(matrix, b, x);
        }
    }
}