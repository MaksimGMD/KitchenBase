using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using KitchenBase.Classes;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using excel = Microsoft.Office.Interop.Excel;

namespace KitchenBase.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductRecords.xaml
    /// </summary>
    public partial class ProductRecords : System.Windows.Window
    {
        DataProcedure DataProcedure = new DataProcedure();
        private string QR = "";
        public ProductRecords()
        {
            InitializeComponent();
        }

        //DataProcedure procedure = new DataProcedure();

        private void cbTypeProductFill()
        {
            DBConnection connection = new DBConnection();
            connection.TypeProductFill();
            cbTypeProduct.ItemsSource = connection.dtTypeProduct.DefaultView;
            cbTypeProduct.SelectedValuePath = "ID_TypeProduct";
            cbTypeProduct.DisplayMemberPath = "Название типа продукта";
        }

        private void dgFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrYchetProductovNaSklade = qr;
            connection.YchetProductovNaSkladeFill();
            dgYchetProductovNaSklade.ItemsSource = connection.dtYchetProductovNaSklade.DefaultView;
            dgYchetProductovNaSklade.Columns[0].Visibility = Visibility.Collapsed;
            dgYchetProductovNaSklade.Columns[5].Visibility = Visibility.Collapsed;

        }

        private void dgYchetProductovNaSklade_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("NameProduct"):
                    e.Column.Header = "НаименованиеПродукта";
                    break;
                case ("TypeProduct"):
                    e.Column.Header = "НазваниеТипаПродукта";
                    break;
                case ("VesProducta"):
                    e.Column.Header = "ВесПродукта";
                    break;
                case ("KolichestvoNaSklade"):
                    e.Column.Header = "КоличествоНаСкладе";
                    break;
                case ("SrokGodnosti"):
                    e.Column.Header = "СрокГодности";
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrYchetProductovNaSklade;
            dgFill(QR);
            cbTypeProductFill();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgYchetProductovNaSklade.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tbSearch.Text)
                {
                    dgYchetProductovNaSklade.SelectedItem = dataRow;
                }
            }
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            string newQR = QR + "where [NameProduct] like '%" + tbSearch.Text + "%' or [VesProducta] like '%" + tbSearch.Text + "%' or [KolichestvoNaSklade] like '%" + tbSearch.Text + "%' " +
            " or [SrokGodnosti] like '%" + tbSearch.Text + "%' or [TypeProduct] like '%" + tbSearch.Text + "%'";
            dgFill(newQR);
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            dgFill(QR);
        }

       public void Message()
        {
            MessageBox.Show("Поле не может быть пустым!! " +
             "\n Заполните все поля и попробуйте снова!", "KitchenBase",
             MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameProduct.Text == "")
            {
                case (true):
                    Message();
                    tbNameProduct.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameProduct.Background = Brushes.White;
                    switch (tbWeightProduct.Text == "")
                    {
                        case (true):
                            Message();
                            tbWeightProduct.Background = Brushes.Red;
                            break;
                        case (false):
                            tbWeightProduct.Background = Brushes.White;
                            switch (tbQuantityStock.Text == "")
                            {
                                case (true):
                                    Message();
                                    tbQuantityStock.Background = Brushes.Red;
                                    break;
                                case (false):
                                    tbQuantityStock.Background = Brushes.White;
                                    switch (tbShelfLife.Text == "")
                                    {
                                        case (true):
                                            Message();
                                            tbShelfLife.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            tbShelfLife.Background = Brushes.White;
                                            switch (cbTypeProduct.SelectedIndex == -1)
                                            {
                                                case (true):
                                                    Message();
                                                    cbTypeProduct.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    cbTypeProduct.Background = Brushes.White;
                                                    DataProcedure.spYchetProductovNaSklade_insert(tbNameProduct.Text.ToString(), tbWeightProduct.Text.ToString(), tbQuantityStock.Text.ToString(), tbShelfLife.Text.ToString(), 
                                                        Convert.ToInt32(cbTypeProduct.SelectedValue.ToString()));
                                                    dgFill(QR);
                                                    cbTypeProductFill();
                                                    tbNameProduct.Text = "";
                                                    tbWeightProduct.Text = "";
                                                    tbQuantityStock.Text = "";
                                                    tbShelfLife.Text = "";
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (tbNameProduct.Text == "")
            {
                case (true):
                    Message();
                    tbNameProduct.Background = Brushes.Red;
                    break;
                case (false):
                    tbNameProduct.Background = Brushes.White;
                    switch (tbWeightProduct.Text == "")
                    {
                        case (true):
                            Message();
                            tbWeightProduct.Background = Brushes.Red;
                            break;
                        case (false):
                            tbWeightProduct.Background = Brushes.White;
                            switch (tbQuantityStock.Text == "")
                            {
                                case (true):
                                    Message();
                                    tbQuantityStock.Background = Brushes.Red;
                                    break;
                                case (false):
                                    tbQuantityStock.Background = Brushes.White;
                                    switch (tbShelfLife.Text == "")
                                    {
                                        case (true):
                                            Message();
                                            tbShelfLife.Background = Brushes.Red;
                                            break;
                                        case (false):
                                            tbShelfLife.Background = Brushes.White;
                                            switch (cbTypeProduct.SelectedIndex == -1)
                                            {
                                                case (true):
                                                    Message();
                                                    cbTypeProduct.Background = Brushes.Red;
                                                    break;
                                                case (false):
                                                    cbTypeProduct.Background = Brushes.White;
                                                    DataRowView ID = (DataRowView)dgYchetProductovNaSklade.SelectedItems[0];
                                                    DataProcedure.spYchetProductovNaSklade_update(Convert.ToInt32(ID["ID_Producta"]), tbNameProduct.Text.ToString(), tbWeightProduct.Text.ToString(), tbQuantityStock.Text.ToString(), tbShelfLife.Text.ToString(),
                                                        Convert.ToInt32(cbTypeProduct.SelectedValue.ToString()));
                                                    dgFill(QR);
                                                    cbTypeProductFill();
                                                    tbNameProduct.Text = "";
                                                    tbWeightProduct.Text = "";
                                                    tbQuantityStock.Text = "";
                                                    tbShelfLife.Text = "";
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgYchetProductovNaSklade.SelectedItems[0];
            switch (MessageBox.Show("Хотите удалить запись?", "Удаление!", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                case MessageBoxResult.OK:
                    DataProcedure.spYchetProductovNaSklade_delete(Convert.ToInt32(ID["ID_Producta"]));
                    dgFill(QR);
                    cbTypeProductFill();
                    tbNameProduct.Text = "";
                    tbWeightProduct.Text = "";
                    tbQuantityStock.Text = "";
                    tbShelfLife.Text = "";
                    break;
            }
        }

        private void btCreatingBillLading_Click(object sender, RoutedEventArgs e)
        {
            /* Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "YchetProductov";

            for (int i = 1; i < dgYchetProductovNaSklade.Columns.Count + 1; i++)
            {
                worksheet.Cells[i, 1] = dgYchetProductovNaSklade.Columns[i - 1].Header;
            }

            for (int i = 0; i < dgYchetProductovNaSklade.Items.Count; i++)
            {
                for (int j = 0; j < dgYchetProductovNaSklade.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgYchetProductovNaSklade.Items[i].Columns[j].Value.Tostring();
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "output";
            saveFileDialog.DefaultExt = ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            } */

            /* Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
             Microsoft.Office.Interop.Excel._Workbook wb;
             Microsoft.Office.Interop.Excel._Worksheet ws;
             XlReferenceStyle RefStyle = Excel.ReferenceStyle;
             wb = (Microsoft.Office.Interop.Excel._Workbook)Excel.Workbooks.Add(1);
             ws = (Microsoft.Office.Interop.Excel._Worksheet)wb.ActiveSheet;
             for (int j = 0; j < dgYchetProductovNaSklade.Columns.Count; ++j)
             {
                 (ws.Cells[1, j + 1] as Range).Value2 = dgYchetProductovNaSklade.Columns[j].Header;
                 for (int i = 0; i < dgYchetProductovNaSklade.Items.Count; ++i)
                 {
                     object Val = dgYchetProductovNaSklade.Items[i].Cells.[j].Value;
                     if (Val != null)
                         (ws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                 }
             }
             Excel.Visible = true;
             ws.Columns.EntireColumn.AutoFit();
             Excel.ReferenceStyle = RefStyle;
             ReleaseExcel(Excel as Object);

             private void ReleaseExcel(object excel)
             {
                 // Уничтожение объекта Excel.
                 Marshal.ReleaseComObject(excel);
                 // Вызываем сборщик мусора для немедленной очистки памяти
                 GC.GetTotalMemory(true);
             } */

            /*
            string extension = "xlsx";

            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog()
            {
                DefaultExt = extension,
                Filter = String.Format("{1} files (.{0})|.{0}|All files (.)|.", extension, "Excel"),
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == true)
            {
                using (Stream stream = dialog.OpenFile())
                {
                    gridViewExport.ExportToXlsx(stream,
                        new GridViewDocumentExportOptions()
                        {
                            ShowColumnFooters = true,
                            ShowColumnHeaders = true,
                            ShowGroupFooters = true
                        });
                }
            } 
            ExportToExcel(); */

            //dgYchetProductovNaSklade.ExportToExcel();

            /*
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dgYchetProductovNaSklade.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = dgYchetProductovNaSklade.Columns[j].Header;
            }
            for (int i = 0; i < dgYchetProductovNaSklade.Columns.Count; i++)
            {
                for (int j = 0; j < dgYchetProductovNaSklade.Items.Count; j++)
                {
                    TextBlock b = dgYchetProductovNaSklade.Columns[i].GetCellContent(dgYchetProductovNaSklade.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                } 
            } */

            //Создание процесса Excel
            //excel.Application application_ex
            //    = new excel.Application();
            ////Создание книги
            //excel.Workbook workbook
            //    = application_ex.Workbooks.Add();
            ////Создание страницы
            //excel.Worksheet worksheet
            //    = (excel.Worksheet)workbook.ActiveSheet;
            //try
            //{
            //    switch (type)
            //    {
            //        case Document_Type.Report:
            //            //Название страницы
            //            worksheet.Name = "Отчёт";
            //            for (int row = 0; row < table.Rows.Count; row++)
            //                for (int col = 0; col < table.Columns.Count; col++)
            //                {
            //                    //ЗАнесение данных в ячейку
            //                    worksheet.Cells[row + 1][col + 1]
            //                        = table.Rows[row][col].ToString();
            //                }
            //            //Указание диапазона работы с ячеёками листа
            //            excel.Range border
            //                //Начало диапазона
            //                = worksheet.Range[worksheet.Cells[1, 1],
            //                //Динамический конец диапазона в зависимости от
            //                //выдодимых данных
            //                worksheet.Cells[table.Rows.Count + 1]
            //                [table.Columns.Count + 1]];
            //            //Стиль линий границ ячеек
            //            border.Borders.LineStyle = excel.XlLineStyle.xlContinuous;
            //            //Выравнивание во высоте
            //            border.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
            //            //Выравнивание по ширине
            //            border.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
            //            //Внесение даты создания документа
            //            worksheet.Cells[table.Rows.Count + 3][2]
            //                = string.Format("Дата создания {0}",
            //                DateTime.Now.ToString());
            //            //Объединение ячеек
            //            worksheet.Range[worksheet.Cells[table.Rows.Count + 3, 2],
            //                worksheet.Cells[table.Rows.Count + 2,
            //                table.Columns.Count + 2]].Merge();
            //            break;
            //        case Document_Type.Statistic:
            //            worksheet.Name = "Статистический отчёт";
            //            for (int row = 0; row < table.Rows.Count; row++)
            //                for (int col = 0; col < table.Columns.Count; col++)
            //                {
            //                    worksheet.Cells[row + 1][col + 1]
            //                        = table.Rows[row][col].ToString();
            //                }
            //            excel.Range border1
            //                = worksheet.Range[worksheet.Cells[1, 1],
            //                worksheet.Cells[table.Rows.Count + 1]
            //                [table.Columns.Count + 1]];
            //            border1.Borders.LineStyle
            //                = excel.XlLineStyle.xlContinuous;
            //            border1.VerticalAlignment
            //                = excel.XlHAlign.xlHAlignCenter;
            //            border1.HorizontalAlignment
            //                = excel.XlHAlign.xlHAlignCenter;
            //            worksheet.Cells[table.Rows.Count + 3][2]
            //                = string.Format("Дата создания {0}",
            //                DateTime.Now.ToString());
            //            worksheet.Range[worksheet.Cells[table.Rows.Count + 3, 2],
            //                worksheet.Cells[table.Rows.Count + 2,
            //                table.Columns.Count + 2]].Merge();
            //            //Класс области графиков
            //            excel.ChartObjects chartObjects
            //                = (excel.ChartObjects)worksheet.ChartObjects(
            //                    Type.Missing);
            //            //Область размещения графиков: отступы слева сверху,
            //            //размер ширина и высота
            //            excel.ChartObject chartObject
            //                = chartObjects.Add(300, 50, 250, 250);
            //            //Объявление области графика
            //            excel.Chart chart = chartObject.Chart;
            //            //Объявление колекции построений графиков
            //            excel.SeriesCollection seriesCollection
            //                = (excel.SeriesCollection)chart.SeriesCollection(
            //                    Type.Missing);
            //            //Объявление посторения графика
            //            excel.Series series = seriesCollection.NewSeries();
            //            //Тип графика
            //            chart.ChartType = excel.XlChartType.xl3DColumn;
            //            //Диапазон значений по оси X
            //            series.XValues =
            //                worksheet.get_Range("B2", "B" + table.Rows.Count + 1);
            //            //Диапазон значений по оси Y
            //            series.Values =
            //                worksheet.get_Range("C2", "C" + table.Rows.Count + 1);
            //            break;
            //     catch
            //{

            //}
            //finally
            //{
            //    //Сохранение книги
            //    workbook.SaveAs(string.Format("{0}\\{1}", Environment.CurrentDirectory, name), application_ex.DefaultSaveFormat);
            //    //Закрытие книги
            //    workbook.Close();
            //    //Завершение процесса
            //    application_ex.Quit();
            //}
            

            /* dgYchetProductovNaSklade.SelectAllCells();
            dgYchetProductovNaSklade.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dgYchetProductovNaSklade);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dgYchetProductovNaSklade.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\test2.xlsx");
            file.WriteLine(result.Replace(',', ' '));
            file.Close(); */

        }


    }        
}
