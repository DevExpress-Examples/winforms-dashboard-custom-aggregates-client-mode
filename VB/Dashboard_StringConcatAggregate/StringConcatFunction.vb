Imports DevExpress.Data.Filtering
Imports DevExpress.DataProcessing.Criteria
Imports System
Imports System.Collections.Generic

Namespace Dashboard_StringConcatAggregate
	Friend Class StringConcatFunction
		Implements ICustomAggregateFunction, ICustomFunctionOperatorBrowsable

		Public ReadOnly Property Name() As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name
			Get
				Return "StringConcat"
			End Get
		End Property

		Public ReadOnly Property MinOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MinOperandCount
			Get
				Return 1
			End Get
		End Property

		Public ReadOnly Property MaxOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MaxOperandCount
			Get
				Return 1
			End Get
		End Property

		Public ReadOnly Property Description() As String Implements ICustomFunctionOperatorBrowsable.Description
			Get
				Return "Takes strings, aggregates by input value, and displays them separated by commas."
			End Get
		End Property

		Public ReadOnly Property Category() As FunctionCategory Implements ICustomFunctionOperatorBrowsable.Category
			Get
				Return DevExpress.Data.Filtering.FunctionCategory.Text
			End Get
		End Property

		Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate
			Throw New NotImplementedException()
		End Function

		Public Function IsValidOperandCount(ByVal count As Integer) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandCount
			Return count <= MaxOperandCount AndAlso count >= MinOperandCount
		End Function

		Public Function IsValidOperandType(ByVal operandIndex As Integer, ByVal operandCount As Integer, ByVal type As Type) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandType
			Return IsValidOperandCount(operandCount) AndAlso operandIndex = 0 AndAlso type Is GetType(String)
		End Function

		Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
			Return GetType(String)
		End Function

		Private Function GetAggregationContextType(inputType As Type) As Type Implements ICustomAggregateFunction.GetAggregationContextType
			Return GetType(StringConcatState)
		End Function
	End Class

	Friend Class StringConcatState
		Implements ICustomAggregateFunctionContext(Of String, String)

		Private enumeration As New List(Of String)()
		Private names As ISet(Of String) = New HashSet(Of String)()
		Public Function GetResult() As String Implements ICustomAggregateFunctionContext(Of String, String).GetResult
			Return String.Join(", ", enumeration.ToArray())
		End Function

		Public Sub Process(ByVal value As String) Implements ICustomAggregateFunctionContext(Of String, String).Process
			If names.Add(value) Then
				enumeration.Add(value)
			End If
		End Sub
	End Class
End Namespace
