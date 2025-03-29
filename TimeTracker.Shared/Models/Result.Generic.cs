using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Shared.Models
{
	public class Result<T> : Result
	{
		public T? Value { get; }

		protected Result(T? value, bool isSuccess, string? error)
			: base(isSuccess, error)
		{
			Value = value;
		}

		public static Result<T> Success(T value) => new Result<T>(value, true, null);

		public static Result<T> Fail(string error) => new Result<T>(default, false, error);
	}

}
