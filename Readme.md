

# Dashboard for WinForms - How to aggregate data by string concatenation

This example shows how to aggregate your data by string concatenation.

## Files to look at
<!-- default file list -->
* [Form1.cs](./CS/Dashboard_StringConcatAggregate/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_StringConcatAggregate/Form1.vb))
* [StringConcatFunction.cs](./CS/Dashboard_StringConcatAggregate/StringConcatFunction.cs) (VB: [StringConcatFunction.vb](./VB/Dashboard_StringConcatAggregate/StringConcatFunction.vb))
<!-- default file list end -->

## Overview

In this example, the [Grid](https://docs.devexpress.com/Dashboard/15150/winforms-dashboard/winforms-designer/create-dashboards-in-the-winforms-designer/dashboard-item-settings/grid) dashboard item displays _СontactName_ values concatenated by country. 


The following expressions aggregates data by string concatenation for _СontactName_ values:

| Calculated Field | Expression |
| --- | --- |
| Contact names by countries | ``` StringConcat([ContactName]) ``` |

Call the [CriteriaOperator.RegisterCustomFunction](https://docs.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.CriteriaOperator.RegisterCustomFunction(DevExpress.Data.Filtering.ICustomFunctionOperator)) method to register a custom function in your project. The following code snippet shows how to register the numeric group interval's function: 

[Program.cs](./CS/Dashboard_StringConcatAggregatel/Program.cs):
```csharp
using System;
using System.Windows.Forms
using DevExpress.Data.Filtering;

namespace Dashboard_StringConcatAggregate {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
        // ...
            CriteriaOperator.RegisterCustomFunction(new StringConcatFunction());
            Application.Run(new Form1());  
        }
    }
}
```
[Program.vb](./VB/Dashboard_StringConcatAggregate/Program.vb):
```vb
Imports System.Windows.Forms using DevExpress.Data.Filtering

Namespace Dashboard_StringConcatAggregate
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
		' ...
			CriteriaOperator.RegisterCustomFunction(New StringConcatFunction())
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace

```

## Documentation

- [Expression Constants, Operators, and Functions](https://docs.devexpress.com/Dashboard/400122/common-features/advanced-analytics/expression-constants-operators-and-functions)
- [Grouping](https://docs.devexpress.com/Dashboard/116535/common-features/data-shaping/grouping)
- [ICustomFunctionOperatorBrowsable](https://docs.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable)
- [ICustomFunctionOperatorFormattable](https://docs.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.ICustomFunctionOperatorFormattable)

## More Examples

- [Dashboard for WinForms - How to Calculate the Numeric Group Interval](https://github.com/DevExpress-Examples/winforms-dashboard-numeric-group-intervals)
- [Dashboard for WinForms - How to Calculate Fiscal Functions from Date-Time Data Fields](https://github.com/DevExpress-Examples/How-to-calculate-fiscal-functions-for-date-time-data-fields)
