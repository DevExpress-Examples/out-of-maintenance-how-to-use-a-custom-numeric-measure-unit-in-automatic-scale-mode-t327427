Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace AggregationSample
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#ConfigureChart"
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            chart.Series.Add(GenerateSeries(10000))

            Dim diagram As XYDiagram = TryCast(chart.Diagram, XYDiagram)
            If diagram Is Nothing Then
                Return
            End If

            diagram.AxisX.NumericScaleOptions.AggregateFunction = AggregateFunction.Average
            diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Automatic
            diagram.AxisX.NumericScaleOptions.AutomaticMeasureUnitsCalculator = New CustomNumericMeasureUnitCalculator()

            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
        End Sub
        #End Region ' #ConfigureChart

        Private Function GenerateSeries(ByVal pointCount As Integer) As Series
            Dim series As Series = New Series With {.Name = "Random data", .View = New SideBySideBarSeriesView()}
            Dim generator As New Random()
            For i As Integer = 0 To pointCount - 1
                series.Points.Add(New SeriesPoint(CDbl(i), generator.NextDouble()))
            Next i
            Return series
        End Function
    End Class

    #Region "#InterfaceImpl"
    Friend Class CustomNumericMeasureUnitCalculator
        Implements INumericMeasureUnitsCalculator

        Public Function CalculateMeasureUnit(
                ByVal series As IEnumerable(Of Series),
                ByVal axisLength As Double,
                ByVal pixelsPerUnit As Integer,
                ByVal visualMin As Double,
                ByVal visualMax As Double,
                ByVal wholeMin As Double,
                ByVal wholeMax As Double) As Double Implements INumericMeasureUnitsCalculator.CalculateMeasureUnit
            Dim visualRange As Double = visualMax - visualMin
            Return Math.Ceiling(visualRange / 20)
        End Function
    End Class
    #End Region ' #InterfaceImpl
End Namespace
