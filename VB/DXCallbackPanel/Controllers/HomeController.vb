Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DXCallbackPanel.Models

Namespace DXCallbackPanel.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			ViewData("Employees") = NorthwindDataProvider.GetEmployeesList()
			Dim employeeID As Integer = NorthwindDataProvider.GetFirstEmployeeID()
			Return View("Index", NorthwindDataProvider.GetEmployee(employeeID))
		End Function
		Public Function CallbackPanelPartial() As ActionResult
			Dim employeeID As Integer = If((Not String.IsNullOrEmpty(Request.Params("EmployeeID"))), Integer.Parse(Request.Params("EmployeeID")), NorthwindDataProvider.GetFirstEmployeeID())
			Return PartialView("CallbackPanelPartial", NorthwindDataProvider.GetEmployee(employeeID))
		End Function
	End Class
End Namespace
