using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace k_means
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            fl = new file();
            InitializeComponent();
            delColumnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            grid.Columns.Add("Объект", "Объект");
        }
        DataTable table;

        private void createTable()
        {
            table = new DataTable();

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                table.Columns.Add(grid.Columns[i].Name);
            }

            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                table.Rows.Add();
            }

            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    table.Rows[i][j] = grid.Rows[i].Cells[j].Value;
                }
            }
        }

        file fl;
        int[] counts;
        //List<DataTable> tables;
        // file
        /*
                private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
                {
                    try
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
                        if (ofd.ShowDialog() == DialogResult.Cancel) return;
                        BinaryFormatter bf = new BinaryFormatter();
                        string filename = ofd.FileName;
                        Stream str = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                        fl = (file)bf.Deserialize(str);
                        for (int i = 0; i < fl.grid.Columns.Count-1; i++)
                        {
                            grid.Columns.Add(fl.names[i], fl.names[i]);
                        }

                        grid.DataSource = fl.grid;
                    }
                    catch (Exception q)
                    {
                        MessageBox.Show(q.Message);
                    }
                }

                private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
                {
                    try
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
                        sfd.FileName = "file1.bin";
                        fl.names = new string[grid.Columns.Count - 1];
                        int y = 2;
                        for(int i = 0; i < fl.names.Length;i++)
                        {
                            fl.names[i] = grid.Columns[y++].Name;
                        }
                        fl.grid =  (DataTable)grid.DataSource;
                        if (sfd.ShowDialog() == DialogResult.Cancel) { return; }
                        BinaryFormatter bf = new BinaryFormatter();
                        string filename = sfd.FileName;
                        Stream str = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                        bf.Serialize(str, fl);
                        str.Close();
                        MessageBox.Show("Сохранено");
                    }
                    catch (Exception q)
                    {
                        MessageBox.Show(q.Message);
                    }
                }
                */
        //end file

        private void addColumnButton_Click(object sender, EventArgs e)
        {
            if (addColumnBox.Text.Trim(' ') == "") { MessageBox.Show("Введите название столбца!"); return; }
            grid.Columns.Add(addColumnBox.Text, addColumnBox.Text);
            delColumnBox.Items.Add(addColumnBox.Text);
            addColumnBox.Clear();
            addColumnBox.Focus();
        }

        private void delColumnButton_Click(object sender, EventArgs e)
        {
            if (delColumnBox.Text.Trim(' ') == "") { MessageBox.Show("Введите название столбца!"); return; }
            grid.Columns.Remove(grid.Columns[delColumnBox.Text]);
            delColumnBox.Items.Remove(delColumnBox.Text);
            delColumnBox.Text = "";
        }

        void CreateCenters(int k)
        {
            Random rnd = new Random();
            fl.centers = new List<Center>();
            for (int i = 0; i < k; i++)
            {
                fl.koordCenters = new double[grid.Columns.Count - 1];
                for(int j = 0; j < grid.Columns.Count - 1; j++)
                {
                    fl.koordCenters[j] = rnd.Next(0, Convert.ToInt32(GetMaxValueInTable()));
                }
                Center c = new Center(fl.koordCenters);
                fl.centers.Add(c);
            }
            /*double[] a = { 1, 1, 1 };
            double[] b = { 2, 1, 1 };
            fl.centers.Add(new Center(a));
            fl.centers.Add(new Center(b));*/
        }

        double GetMaxValueInTable()
        {
            double max = 0;
            for (int i = 1; i < grid.Columns.Count; i++)
            {
                for (int j = 0; j < grid.Rows.Count - 1; j++)
                {
                    if (Convert.ToDouble(grid.Rows[j].Cells[i].Value) > max) max = Convert.ToDouble(grid.Rows[j].Cells[i].Value);
                }
            }
            return max;
        }

        void GetValueToCenter(int k)
        {
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                double[] raznKoord = new double[grid.Columns.Count - 1];
                for (int k1 = 0; k1 < k; k1++)
                {
                    for (int j = 0; j < grid.Columns.Count - 1; j++)
                    {
                        raznKoord[j] = Convert.ToDouble(grid.Rows[i].Cells[j + 1].Value) - fl.centers[k1][j];
                        double tmp = 0;
                        for (int t = 0; t < raznKoord.Count(); t++)
                        {
                            tmp += Math.Pow(raznKoord[t], 2);
                        }
                        double res = Math.Sqrt(tmp);
                        fl.table.Rows[i][k1] = res;
                    }
                }
            }
        }
        DataTable CreateTable(int k)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < k; i++)
            {
                table.Columns.Add("r" + (i + 1));
            }
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                table.Rows.Add();
            }
            table.Columns.Add("S");
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                table.Rows[i][table.Columns.Count-1] = -1;
            }
            return table;
        }

        void SetClasses(int k1)
        {
            for (int i = 0; i < fl.table.Rows.Count; i++)
            {
                double min = 999999999;
                for (int j = 0; j < k1; j++)
                {
                    if (Convert.ToDouble(fl.table.Rows[i][j]) < min) min = Convert.ToDouble(fl.table.Rows[i][j]);
                }
                int ind = 0;
                for (int k = 0; k < k1; k++)
                {
                    if (Convert.ToDouble(fl.table.Rows[i][k]) == min) { ind = k; break; }
                }
                fl.table.Rows[i][fl.table.Columns.Count - 1] = ind;
            }
            tmpGrid.DataSource = fl.table;
            //fl.tmpTable = fl.table;
        }

        void GetClasses(int k)
        {
            counts = new int[k];
            int ch1 = 0;
            string str = "";
            int kl = 0;
            /*for (int j = 0; j < fl.table.Rows.Count; j++)
            {
                if (Convert.ToInt32(fl.table.Rows[j][fl.table.Columns.Count - 1]) < min) min = Convert.ToInt32(fl.table.Rows[j][fl.table.Columns.Count - 1]);
            }
            double max = 0;
            for (int j = 0; j < fl.table.Rows.Count; j++)
            {
                if (Convert.ToInt32(fl.table.Rows[j][fl.table.Columns.Count - 1]) > max) max = Convert.ToInt32(fl.table.Rows[j][fl.table.Columns.Count - 1]);
            }*/
            fl.classList = new List<int[]>();
            for (int i = 0; i < k; i++)
            {
                ch1 = 0;
                for (int c = 0; c < fl.table.Rows.Count; c++)
                {
                    if (Convert.ToInt32(fl.table.Rows[c][fl.table.Columns.Count - 1]) == i) { ch1++; }
                }
                int[] classInd = new int[ch1];
                kl = 0;
                for (int c = 0; c < fl.table.Rows.Count; c++)
                {
                    if (Convert.ToInt32(fl.table.Rows[c][fl.table.Columns.Count - 1]) == i) { classInd[kl] = c; str += " " + (classInd[kl++]) + " "; }
                }
                fl.classList.Add(classInd);
                str += "\n";
            }
            //MessageBox.Show(str);
        }

        double Error()
        {
            double err = 0;
            for (int i = 0; i < fl.table.Rows.Count; i++)
            {
                double min = 999999;
                for (int j = 0; j < fl.table.Columns.Count-1; j++)
                {
                    if (Convert.ToDouble(fl.table.Rows[i][j]) < min) min = Convert.ToDouble(fl.table.Rows[i][j]);
                }
                err += Math.Pow(min, 2);
            }
            return err;
        }

        void GetNewCenters()
        {
                       for (int i = 0; i < fl.classList.Count(); i++)
            {
                for (int r = 1; r < grid.Columns.Count; r++)
                {
                    double tmp = 0;
                    for (int j = 0; j < fl.classList[i].Count(); j++)
                    {
                        tmp += Convert.ToDouble(grid.Rows[fl.classList[i][j]].Cells[r].Value);
                    }
                    fl.centers[i][r - 1] = tmp / fl.classList[i].Count();
                }
            }
            /*string tm = "";
            foreach (Center c in fl.centers)
            {
                for (int i = 0; i < c.Count; i++)
                {
                    tm += c[i] + " ";
                }
                tm += "\n";
            }
            MessageBox.Show(tm);*/
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            try
            {


                int equalsCount = 0;
                int equalsCountTab = 0;
                Excel ex = new Excel();
                ex.CreateSheet("k-means");
                for (int k = 2; k <= Convert.ToInt32(kBox.Value); k++)
                {
                    //tables = new List<DataTable>();
                    fl.errors = new List<double>();
                    fl.table = CreateTable(k);
                    CreateCenters(k);

                    do
                    {
                        List<Center> oldCen = new List<Center>();
                        GetValueToCenter(k);

                        fl.tmpTable = CreateTable(k);
                        for (int i = 0; i < fl.table.Rows.Count; i++)
                        {
                            for (int j = 0; j < fl.table.Columns.Count; j++)
                            {
                                fl.tmpTable.Rows[i][j] = fl.table.Rows[i][j];
                            }
                        }
                        oldCen = new List<Center>();
                        foreach (Center c in fl.centers)
                        {
                            oldCen.Add(c.Clone());
                        }

                        SetClasses(k);
                        fl.errors.Add(Error());
                        GetClasses(k);
                        GetNewCenters();

                        ex.CreateCells(grid, fl.classList, "k-means", k, Error(), fl.table, fl.centers);
                        equalsCount = 0;
                        equalsCountTab = 0;

                        for (int i = 0; i < fl.tmpTable.Rows.Count; i++)
                        {

                            if (Convert.ToInt32(fl.table.Rows[i][fl.table.Columns.Count - 1]) == Convert.ToInt32(fl.tmpTable.Rows[i][fl.table.Columns.Count - 1])) equalsCountTab++;

                        }

                        for (int i = 0; i < fl.centers.Count; i++)
                        {
                            for (int j = 0; j < fl.centers[i].Count; j++)
                            {
                                if (fl.centers[i][j] == oldCen[i][j]) equalsCount++;
                            }
                        }
                    } while ((equalsCount != fl.table.Rows.Count) && (equalsCountTab != grid.Rows.Count - 1));

                }
                ex.WriteToFile("k-means");
                //MessageBox.Show("Выполнено");
            }
            catch(Exception q)
            {
                MessageBox.Show(q.Message);
            } 
        }
        Stream str;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = grid.Rows.Count - 2; i >= 0; i--)
                {
                    grid.Rows.RemoveAt(i);
                }
                for (int i = grid.Columns.Count - 1; i >= 0; i--)
                {
                    grid.Columns.RemoveAt(i);
                }

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                BinaryFormatter bf = new BinaryFormatter();
                string filename = ofd.FileName;
                str = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                table = (DataTable)bf.Deserialize(str);
               
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    grid.Columns.Add(table.Columns[i].ColumnName, table.Columns[i].ColumnName);
                }
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    grid.Rows.Add();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        grid.Rows[j].Cells[i].Value = table.Rows[j][i];
                    }
                }
            }
            catch (Exception q)
            {
                delColumnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                grid.Columns.Add("Объект", "Объект");
                MessageBox.Show(q.Message);
            }
            finally
            {
                str.Close();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                createTable();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
                sfd.FileName = "file1.bin";
                if (sfd.ShowDialog() == DialogResult.Cancel) { return; }
                BinaryFormatter bf = new BinaryFormatter();
                string filename = sfd.FileName;
                Stream str = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                bf.Serialize(str, table);
                str.Close();
                MessageBox.Show("Сохранено");
            }
            catch (Exception q)
            {
                MessageBox.Show(q.Message);
            }
        }
    }
}
