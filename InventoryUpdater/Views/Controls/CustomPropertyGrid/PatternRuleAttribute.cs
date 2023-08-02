using System.Text.RegularExpressions;

namespace CustomControls.Rule
{
	/// <summary>
	/// Validate the input data against a Regular Expression
	/// </summary>
	public class PatternRuleAttribute : RuleBaseAttribute
	{
		#region Data Members

		private readonly string _pattern;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pattern"></param>
		public PatternRuleAttribute( string pattern )
		{
			this._pattern = pattern;
		}

		#endregion

		#region Methods - Public

		/// <summary>
		/// Validate the input data
		/// </summary>
		/// <param name="dataObject"></param>
		/// <returns></returns>
		public override bool IsValid( object dataObject )
		{
			this.ErrorMessage = string.Empty;

			if ( dataObject is string )
			{
				string data = (string)dataObject;
				if ( Regex.IsMatch( data, this._pattern ) )
				{
					return ( true );
				}
			}

			this.ErrorMessage = string.Format(
				"Incorrect value entered: {0}, Please check field description for correct allowed format",
				dataObject );

			return ( false );
		}

		#endregion
	}
}

