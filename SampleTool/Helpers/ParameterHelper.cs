using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;

namespace SampleTool.Helper
{
	public class ParameterHelper : IParameterHelper
	{
		private readonly Document _doc;

		public ParameterHelper(Document doc)
		{
			_doc = doc;
		}

		public string GetParameterValueAsString(string parameterName)
		{
			Parameter theParam = GetParameterFromProjectInfo(parameterName);
			if (null == theParam)
			{
				return null;
			}

			// Reads data in the parameter
			return theParam.AsString();
		}

		public bool HasParameter(string parameterName)
		{
			Parameter theParam = GetParameterFromProjectInfo(parameterName);
			if (null == theParam)
			{
				return false;
			}

			return true;
		}

		public bool SetParameterValue(string parameterName, string value)
		{
			if (!HasParameter(parameterName)) { return false; }

			Parameter theParam = GetParameterFromProjectInfo(parameterName);

			Transaction transaction = new Transaction(_doc, "updating parameter " + parameterName);
			if (transaction.Start() == TransactionStatus.Started)
			{
				try
				{
					theParam.Set(value);
					transaction.Commit();
					return true;
				}
				catch (Exception ex)
				{
					transaction.RollBack();
				}
			}
			return false;

		}

		/// <summary>
		/// Gets the revit parameter from project info
        /// If more than one parameter has the same name, returns the 'first' one
		/// </summary>
		/// <param name="parameterName">name of the parameter</param>
		/// <returns>parameter or null if not found</returns>
		private Parameter GetParameterFromProjectInfo(string parameterName)
		{
			Element pInfo = _doc.ProjectInformation;
			if (null == pInfo)
			{
				return null;
			}

            List<Parameter> paramList = pInfo.GetParameters(parameterName).ToList<Parameter>();
            return (0 < paramList.Count) ? paramList[0] : null;

		}       
    }
}
