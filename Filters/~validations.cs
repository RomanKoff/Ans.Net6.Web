using Ans.Net6.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

/// <summary>
/// StringValidationAttribute
/// IntValidationAttribute
/// LongValidationAttribute
/// DoubleValidationAttribute
/// FloatValidationAttribute
/// DecimalValidationAttribute
/// DateTimeValidationAttribute
/// </summary>
namespace Ans.Net6.Web.Filters
{

	public class StringValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public int MinLength { get; set; }
		public int MaxLength { get; set; }
		public string RegexPattern { get; set; }
		public string Compare { get; set; }

		public StringValidationAttribute()
		{
			this.MinLength = 0;
			this.MaxLength = 0;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			string v1 = Convert.ToString(value);
			if (IsRequired && string.IsNullOrWhiteSpace(v1))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if (!string.IsNullOrEmpty(Compare))
			{
				var p1 = validationContext.ObjectType.GetProperty(Compare);
				var attribute = p1.GetCustomAttributes(typeof(StringValidationAttribute), false)[0] as StringValidationAttribute;
				if (attribute.IsValid(p1.GetValue(validationContext.ObjectInstance, null), validationContext) == ValidationResult.Success)
				{
					string v2 = Convert.ToString(p1.GetValue(validationContext.ObjectInstance, null));
					if (!(v1 == v2))
						return new ValidationResult(
							_ResValidation.Text_ValueAndConfirmDoNotMatch);
				}
			}
			if ((MinLength > 0) && (v1.Length < MinLength))
				return new ValidationResult(
					string.Format(_ResValidation.Template_LengthLessMin, MinLength));
			if ((MaxLength > 0) && (v1.Length > MaxLength))
				return new ValidationResult(
					string.Format(_ResValidation.Template_LengthExceededMax, MaxLength));
			if (!string.IsNullOrEmpty(RegexPattern)
				&& !Regex.IsMatch(v1, RegexPattern))
				return new ValidationResult(
					_ResValidation.Text_ValueDoesNotFit);
			return ValidationResult.Success;
		}
	}



	public class IntValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public int? NullValue { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }

		public IntValidationAttribute()
		{
			this.NullValue = null;
			this.Min = int.MinValue;
			this.Max = int.MaxValue;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			int v1 = Convert.ToString(value).ToInt(0);
			if (IsRequired && (v1 == NullValue))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if (v1 < Min)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberLessMin, Min));
			if (v1 > Max)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberExceededMax, Max));
			return ValidationResult.Success;
		}
	}



	public class LongValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public long? NullValue { get; set; }
		public long Min { get; set; }
		public long Max { get; set; }

		public LongValidationAttribute()
		{
			this.NullValue = null;
			this.Min = long.MinValue;
			this.Max = long.MaxValue;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			long v1 = Convert.ToString(value).ToLong(0);
			if (IsRequired && (v1 == NullValue))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if (v1 < Min)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberLessMin, Min));
			if (v1 > Max)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberExceededMax, Max));
			return ValidationResult.Success;
		}
	}



	public class DoubleValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public double? NullValue { get; set; }
		public double Min { get; set; }
		public double Max { get; set; }

		public DoubleValidationAttribute()
		{
			this.NullValue = null;
			this.Min = double.MinValue;
			this.Max = double.MaxValue;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			double v1 = Convert.ToString(value).ToDouble(0);
			if (IsRequired && (v1 == NullValue))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if (v1 < Min)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberLessMin, Min));
			if (v1 > Max)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberExceededMax, Max));
			return ValidationResult.Success;
		}
	}



	public class FloatValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public float? NullValue { get; set; }
		public float Min { get; set; }
		public float Max { get; set; }

		public FloatValidationAttribute()
		{
			this.NullValue = null;
			this.Min = float.MinValue;
			this.Max = float.MaxValue;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			float v1 = Convert.ToString(value).ToFloat(0);
			if (IsRequired && (v1 == NullValue))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if (v1 < Min)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberLessMin, Min));
			if (v1 > Max)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberExceededMax, Max));
			return ValidationResult.Success;
		}
	}



	public class DecimalValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public decimal? NullValue { get; set; }
		public decimal Min { get; set; }
		public decimal Max { get; set; }

		public DecimalValidationAttribute()
		{
			this.NullValue = null;
			this.Min = decimal.MinValue;
			this.Max = decimal.MaxValue;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			decimal v1 = Convert.ToString(value).ToDecimal(0);
			if (IsRequired && (v1 == NullValue))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if (v1 < Min)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberLessMin, Min));
			if (v1 > Max)
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberExceededMax, Max));
			return ValidationResult.Success;
		}
	}



	public class DateTimeValidationAttribute
		: ValidationAttribute
	{
		public bool IsRequired { get; set; }
		public DateTime? NullValue { get; set; }
		public DateTime? Min { get; set; }
		public DateTime? Max { get; set; }

		public DateTimeValidationAttribute()
		{
			this.NullValue = null;
			this.Min = DateTime.MinValue;
			this.Max = DateTime.MaxValue;
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			DateTime? v1 = Convert.ToString(value).ToDateTime();
			if (IsRequired && (v1 == NullValue))
				return new ValidationResult(
					_ResValidation.Text_ValueIsRequired);
			if ((Min != null) && (v1 < Min))
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberLessMin, Min));
			if ((Max != null) && (v1 > Max))
				return new ValidationResult(
					string.Format(_ResValidation.Template_NumberExceededMax, Max));
			return ValidationResult.Success;
		}
	}

}
