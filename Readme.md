<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128575815/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T327427)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/AggregationSample/Form1.cs) (VB: [Form1.vb](./VB/AggregationSample/Form1.vb))
<!-- default file list end -->
# How to: use a custom numeric measure unit in automatic scale mode


This example demonstrates how to specify a custom numeric measure unit in <strong>Automatic</strong> scale mode.


<h3>Description</h3>

To do this, assign an object of a class implementing the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraChartsINumericMeasureUnitsCalculatortopic">INumericMeasureUnitsCalculator</a>&nbsp;interface to the&nbsp;<a href="https://documentation.devexpress.com/#corelibraries/DevExpressXtraChartsNumericScaleOptions_AutomaticMeasureUnitsCalculatortopic">AutomaticMeasureUnitsCalculator</a>&nbsp;property of&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsAxisBase_NumericScaleOptionstopic">AxisBase.NumericScaleOptions</a>.

<br/>


