Imports System
Imports System.Windows.Forms
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports System.Globalization

Namespace Dashboard_StringConcatAggregate
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			BonusSkins.Register()
			SkinManager.EnableFormSkins()
			UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful")
			CriteriaOperator.RegisterCustomFunction(New StringConcatFunction())
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace
