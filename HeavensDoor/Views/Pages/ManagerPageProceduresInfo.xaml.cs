using HeavensDoor.Helper;
using HeavensDoor.UserService;
using HeavensDoorClass;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace HeavensDoor.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPageMaterialInfo.xaml
    /// </summary>
    public partial class ManagerPageMaterialInfo : Page, INotifyPropertyChanged
    {
        private DateTime dateTimeStart;
        private DateTime dateTimeEnd;
        private long dateTimeStartChart;
        public double costProcedures;
        public int countProcedures;

        public ObservableCollection<Procedure> Procedures { get; set; }
        public ObservableCollection<GraphicClassMaterial> GraphicClassMaterials { get; set; }

        public DateTime DateTimeStart { get => dateTimeStart; set { dateTimeStart = value; OnPropertyChange(); } }
        public DateTime DateTimeEnd { get => dateTimeEnd; set { dateTimeEnd = value; OnPropertyChange();  } }
        public long DateTimeStartChart { get => dateTimeStartChart; set { dateTimeStartChart = value; OnPropertyChange(); } }
        public double CostProcedures { get => costProcedures; set { costProcedures = value; OnPropertyChange(); } }
        public int CountProcedures { get => countProcedures; set { countProcedures = value; OnPropertyChange(); } }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public Func<double, string> XFormatter { get; set; }

        public ObservableCollection<Session> Sessions { get; set; }
        Random random=new Random();
        public int Counts { get; set; }


        public ManagerPageMaterialInfo()
        {
            DateTimeEnd = DateTime.Now;
            DateTimeStart = DateTimeEnd.AddMonths(-1);
            DateTimeStartChart = DateTimeStart.Ticks;
            SeriesCollection =new SeriesCollection();
            LoadProducts();
            GraphicClassMaterials = new ObservableCollection<GraphicClassMaterial>();
            LoadGraphic();
            InitializeComponent();
            DataContext = this;

            var typeMaper = Mappers.Xy<MaterialsStatistic>().X((value,index)=>value.Ticks).Y(value=>value.MaterialCount);
            Charting.For<MaterialsStatistic>(typeMaper);
            UserServices.Instance.HubConnections.On("UpdateProc", () =>
            {
                LoadProducts();
                LoadGraphic();
            });
        }

        public void LoadProducts()
        {
            var request = new RestRequest("/api/Procedure", Method.GET);
            var response = UserServices.Instance.restClient.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Procedures = new ObservableCollection<Procedure>(JsonConvert.DeserializeObject<List<Procedure>>(response.Result.Content));
            }

            var request1 = new RestRequest("/api/Session", Method.GET);
            var response1 = UserServices.Instance.restClient.ExecuteAsync(request1);
            if (response1.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Sessions = new ObservableCollection<Session>(JsonConvert.DeserializeObject<List<Session>>(response1.Result.Content).Where(p=>p.Idstatus==2));
            }
        }

        public void LoadGraphic()
        {
            
            foreach(var proc in Procedures)
            {
                ChartValues<MaterialsStatistic> materialsStatistics = new ChartValues<MaterialsStatistic>();

                for (DateTime date = DateTimeStart; date <= DateTimeEnd; date = date.AddDays(1))
                {
                    int count = 0;
                    foreach(var ses in Sessions.Where(p=>p.DateTime.Value.Date==date.Date))
                    {
                        if (ses.IdproceduresNavigation.Idprocedure == proc.Idprocedure)
                        {
                            count ++;
                            
                        }
                    }
                     materialsStatistics.Add(new MaterialsStatistic(proc.Name, count, date.Ticks));
                   
                    if (GraphicClassMaterials.FirstOrDefault(p => p.Procedure.Idprocedure == proc.Idprocedure) == null)
                    {
                        GraphicClassMaterials.Add(new GraphicClassMaterial(proc, count, proc.Price * count));
                    }
                    else
                    {
                        if (count == 0)
                        {
                            continue;
                        }
                        GraphicClassMaterials.FirstOrDefault(p => p.Procedure.Idprocedure == proc.Idprocedure).Count += count;
                        GraphicClassMaterials.FirstOrDefault(p => p.Procedure.Idprocedure == proc.Idprocedure).Cost += proc.Price;

                    }
                }
                SeriesCollection.Add(new LineSeries
                {
                     Title=proc.Name,
                      Values=materialsStatistics,

                });
            }
            XFormatter = p => new DateTime((long)p).ToString("d");
            OnPropertyChange(nameof(SeriesCollection));
        }

        #region OnPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion

        private void UpdateSchart_Click(object sender, RoutedEventArgs e)
        {
            LoadGraphic();
        }

        private void CreatePDFMaterial_Click(object sender, RoutedEventArgs e)
        {
            GenerateReceiptInvoice();
        }
        private void GenerateReceiptInvoice()
        {
            Counts = random.Next(1, 100);
            var recieptInviceNumber = $"R{Counts}";
            FileStream fs = new FileStream($"Reports/{recieptInviceNumber}.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Rectangle rec2 = new Rectangle(PageSize.A4);


            Document doc = new Document(rec2, 50, 50, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var textFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
            var tableFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
            var titleFont = new iTextSharp.text.Font(baseFont, 21, iTextSharp.text.Font.NORMAL);
            writer.SetLanguage("ru-RU");
            doc.AddAuthor($"{UserServices.Instance.Account.Fio}");
            doc.AddTitle($"Отчет по процедурам {recieptInviceNumber}");
            doc.Open();

            Paragraph paragraph;
            paragraph = new Paragraph($"Отчет по процедурам {recieptInviceNumber} от {DateTime.Now.ToShortDateString()}", titleFont);
            paragraph.Alignment = 1;
            //paragraph.ExtraParagraphSpace = 20;
            paragraph.Leading = 30;
            paragraph.SpacingAfter = 20;
            doc.Add(paragraph);

            paragraph = new Paragraph($"Составил {UserServices.Instance.Account.PostStaff} {UserServices.Instance.Account.Fio}", textFont);
            paragraph.Alignment = 3;
            paragraph.SpacingAfter = 10;
            doc.Add(paragraph);

            paragraph = new Paragraph($"От {DateTimeStart} до {DateTimeEnd}", textFont);
            paragraph.Alignment = 3;
            paragraph.SpacingAfter = 10;
            doc.Add(paragraph);

            paragraph = new Paragraph($"Принял: ___________________ ___________________", textFont);
            paragraph.Alignment = 3;
            paragraph.SpacingAfter = 0;
            doc.Add(paragraph);
            paragraph = new Paragraph($"                                    Должность и ФИО рабочего", tableFont);
            paragraph.Alignment = 3;
            paragraph.SpacingAfter = 20;
            doc.Add(paragraph);

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[4] { 20, 80, 50,50  });
            PdfPCell cell;

            cell = new PdfPCell(new Phrase("№", tableFont));
            cell.BorderWidth = 1;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Наименование процедуры", tableFont));
            cell.HorizontalAlignment = 1;
            cell.BorderWidth = 1;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Кол-во процедур", tableFont));
            cell.HorizontalAlignment = 1;
            cell.BorderWidth = 1;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Прибыль", tableFont));
            cell.HorizontalAlignment = 1;
            cell.BorderWidth = 1;
            table.AddCell(cell);

        

            int id = 1;
            
            foreach (var item in GraphicClassMaterials)
            {
                cell = new PdfPCell(new Phrase(id.ToString(), tableFont));
                cell.HorizontalAlignment = 0;
                cell.BorderWidth = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Procedure.Name, tableFont));
                cell.HorizontalAlignment = 0;
                cell.BorderWidth = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(item.Count.ToString(), tableFont));
                cell.HorizontalAlignment = 0;
                cell.BorderWidth = 1;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(Math.Round(item.Cost, 2).ToString("C"), tableFont));
                cell.HorizontalAlignment = 0;
                cell.BorderWidth = 1;
                table.AddCell(cell);            

                id++;
            }

            cell = new PdfPCell(new Phrase("Итого:", tableFont));
            cell.HorizontalAlignment = 0;
            cell.BorderWidth = 1;
            cell.Colspan = 2;
            table.AddCell(cell);

           

            cell = new PdfPCell(new Phrase(GraphicClassMaterials.Sum(p => p.Count).ToString(), tableFont));
            cell.HorizontalAlignment = 0;
            cell.BorderWidth = 1;
            table.AddCell(cell);
         

            cell = new PdfPCell(new Phrase(Math.Round(GraphicClassMaterials.Sum(p => p.Cost), 2).ToString("C"), tableFont));
            cell.HorizontalAlignment = 0;
            cell.BorderWidth = 1;
            table.AddCell(cell);            

            doc.Add(table);
            doc.Close();
            writer.Close();
            fs.Close();
        }
    }
}
