using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.IO;

namespace Ans.Net6.Web
{

	public static partial class _e
	{

		//public static ViewEngineResult GetViewEngineResult(
		//	this Controller controller,
		//	string viewName,
		//	string masterName = null)
		//{
		//	return Engines.FindView(
		//		controller.ControllerContext, viewName, masterName);
		//}


		//public static bool ViewExists(
		//	this ViewEngineResult viewEngine)
		//{
		//	return (viewEngine.View != null);
		//}


		//public static string RazorViewToString(
		//	this Controller controller,
		//	string viewName,
		//	object model)
		//{
		//	controller.ViewData.Model = model;
		//	using (var writer = new StringWriter())
		//	{
		//		var v1 = ViewEngines.Engines.FindPartialView(
		//			controller.ControllerContext, viewName);
		//		var c1 = new ViewContext(
		//			controller.ControllerContext, v1.View,
		//			controller.ViewData, controller.TempData, writer);
		//		v1.View.Render(c1, writer);
		//		v1.ViewEngine.ReleaseView(controller.ControllerContext, v1.View);
		//		return writer.GetStringBuilder().ToString();
		//	}
		//}


		//public static void SendMailFromView(
		//	this Controller controller,
		//	string viewName,
		//	object model,
		//	string subject,
		//	string to,
		//	string bcc = null)
		//{
		//	string body = controller.RazorViewToString(viewName, model);
		//	MailAddressCollection bccMails = null;
		//	if (bcc == null)
		//		bccMails.Add(LibConfig.SendMail_Bcc);
		//	else
		//		foreach (var item in bcc.SplitItems())
		//			bccMails.Add(item);
		//	SuppMailer.SendMail(
		//		subject, body, new MailAddress(to), bccMails);
		//}

	}

}
