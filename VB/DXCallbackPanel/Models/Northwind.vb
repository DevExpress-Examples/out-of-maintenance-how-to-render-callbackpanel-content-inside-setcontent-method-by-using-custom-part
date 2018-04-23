Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections

Namespace DXCallbackPanel.Models
	Public NotInheritable Class NorthwindDataProvider
		Private Shared db_Renamed As NorthwindDataContext

		Private Sub New()
		End Sub
		Public Shared ReadOnly Property DB() As NorthwindDataContext
			Get
				If db_Renamed Is Nothing Then
					db_Renamed = New NorthwindDataContext()
				End If
				Return db_Renamed
			End Get
		End Property
		Public Shared Function GetEmployeesList() As IEnumerable
			Return _
				From employee In DB.Employees _
				Select New With {Key .ID = employee.EmployeeID, Key .Name = employee.LastName & " " & employee.FirstName}
		End Function
		Public Shared Function GetFirstEmployeeID() As Integer
			Return ( _
					From employee In DB.Employees _
					Select employee.EmployeeID).First()
		End Function
		Public Shared Function GetEmployees() As IEnumerable
			Return _
				From employee In DB.Employees _
				Select employee
		End Function
		Public Shared Function GetEmployee(ByVal employeeId As Integer) As Employee
			Return ( _
					From employee In DB.Employees _
					Where employeeId = employee.EmployeeID _
					Select employee).Single()
		End Function
	End Class
End Namespace