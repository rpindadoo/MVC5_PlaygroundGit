using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;
using Sample.DataAccess.Entities;

namespace Sample.Web.Controllers.Helpers{
    public interface IChartHelper{
        ChartData GetMovieRatesPerMonth(IQueryable<MovieRate> movies);
        MemoryStream GetPieChart(ChartData chartData);
    }

    public class ChartHelper : IChartHelper{
        public MemoryStream GetPieChart(ChartData chartData){
            var chart = new Chart{Height = 200, Width = 300};

            chart.ChartAreas.Add(new ChartArea());
            chart.Series.Add(new Series("Data"));

            for (var x = 0; x < chartData.Values.Count(); x++){
                var ptIdx = chart.Series["Data"].Points.AddXY(
                    chartData.PropNames[x],
                    chartData.Values[x]);
                var pt = chart.Series["Data"].Points[ptIdx];
                pt.LegendText = "#VALX (#VALY)";
            }

            chart.Series["Data"].IsValueShownAsLabel = true;
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";

            chart.Legends.Add(new Legend("Months"));
            chart.Legends["Months"].Docking = Docking.Bottom;
            chart.Legends["Months"].Alignment = StringAlignment.Center;

            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return returnStream;
        }

        public ChartData GetMovieRatesPerMonth(IQueryable<MovieRate> movieRates){
            var chartData = new ChartData();

            foreach (var date in movieRates.GroupBy(x => x.Date.Month))
            {
                chartData.Values.Add(movieRates.Count(x => x.Date.Month == date.Key));
                chartData.PropNames.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Key));
            }

            return chartData;
        }
    }
}