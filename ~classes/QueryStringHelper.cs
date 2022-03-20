using Ans.Net6.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Ans.Net6.Web
{

	public class QueryStringHelper
	{

		public Dictionary<string, StringValues> RequestParams { get; private set; }
		public Dictionary<string, StringValues> InputParams { get; private set; }


		public QueryStringHelper(
			IQueryCollection query,
			params string[] ignoreParams)
		{
			ignoreParams = ignoreParams
				.Concat(new string[] { "descending" })
				.ToArray();
			this.RequestParams = new Dictionary<string, StringValues>();
			this.InputParams = new Dictionary<string, StringValues>();
			foreach (var key1 in query.Keys)
			{
				this.RequestParams.Add(key1, query[key1]);
				if (Array.IndexOf(ignoreParams, key1) == -1)
					InputParams.Add(key1, query[key1]);
			}
		}


		public bool TestHas(
			string key)
		{
			return RequestParams.ContainsKey(key);
		}


		public bool Test(
			string key,
			string value)
		{
			if (TestHas(key))
				return RequestParams[key].ToString().Equals(value);
			return false;
		}


		public int? GetInt(
			string key)
		{
			if (TestHas(key))
				return RequestParams[key].ToString().ToInt();
			return null;
		}


		public int GetInt(
			string key,
			int defaultValue)
		{
			if (TestHas(key))
				return RequestParams[key].ToString().ToInt(defaultValue);
			return defaultValue;
		}


		public string GetQueryString(
			string key,
			int value,
			int nullValue)
		{
			if (value != nullValue)
				return $"?{key}={value}";
			return string.Empty;
		}


		public string GetQueryString(
			string queryString)
		{
			var d1 = QueryHelpers.ParseQuery(queryString);
			var d2 = InputParams.Concat(d1)
				.GroupBy(x => x.Key)
				.ToDictionary(x => x.Key, x => x.Last().Value);
			return QueryHelpers.AddQueryString("?", d2);
		}


		public void Delete(
			string key)
		{
			InputParams.Remove(key);
		}

	}

}
