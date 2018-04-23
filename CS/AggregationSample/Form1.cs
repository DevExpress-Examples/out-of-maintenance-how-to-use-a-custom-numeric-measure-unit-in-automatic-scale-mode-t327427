using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AggregationSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        #region #ConfigureChart
        private void Form1_Load(object sender, EventArgs e) {
            chart.Series.Add(GenerateSeries(10000));

            XYDiagram diagram = chart.Diagram as XYDiagram;
            if (diagram == null) return;

            diagram.AxisX.NumericScaleOptions.AggregateFunction = AggregateFunction.Average;
            diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Automatic;
            diagram.AxisX.NumericScaleOptions.AutomaticMeasureUnitsCalculator = new CustomNumericMeasureUnitCalculator();

            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;
        }
        #endregion #ConfigureChart

        Series GenerateSeries(int pointCount) {
            Series series = new Series {
                Name = "Random data",
                View = new SideBySideBarSeriesView()
            };
            Random generator = new Random();
            for (int i = 0; i < pointCount; ++i) {
                series.Points.Add(new SeriesPoint((double)i, generator.NextDouble()));
            }
            return series;
        }
    }

    #region #InterfaceImpl
    class CustomNumericMeasureUnitCalculator : INumericMeasureUnitsCalculator {
        public double CalculateMeasureUnit(
                IEnumerable<Series> series, 
                double axisLength, 
                int pixelsPerUnit, 
                double visualMin, 
                double visualMax, 
                double wholeMin, 
                double wholeMax) {
            double visualRange = visualMax - visualMin;
            return Math.Ceiling(visualRange / 20);
        }
    }
    #endregion #InterfaceImpl
}
