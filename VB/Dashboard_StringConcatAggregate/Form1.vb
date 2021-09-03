Imports DevExpress.XtraBars.Ribbon

Namespace Dashboard_StringConcatAggregate
	Partial Public Class Form1
		Inherits RibbonForm

		Public Sub New()
			InitializeComponent()
			dashboardDesigner1.CreateRibbon()
			dashboardDesigner1.LoadDashboard("..\..\Data\StringConcatAggregate.xml")
		End Sub
	End Class
End Namespace
