﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIL.Utils {
	using System;


	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// This class was auto-generated by the StronglyTypedResourceBuilder
	// class via a tool like ResGen or Visual Studio.
	// To add or remove a member, edit your .ResX file then rerun ResGen
	// with the /str option, or rebuild your VS project.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	internal class ReportingStrings {

		private static global::System.Resources.ResourceManager resourceMan;

		private static global::System.Globalization.CultureInfo resourceCulture;

		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal ReportingStrings() {
		}

		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (object.ReferenceEquals(resourceMan, null)) {
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SIL.Utils.ReportingStrings", typeof(ReportingStrings).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}

		/// <summary>
		///   Overrides the current thread's CurrentUICulture property for all
		///   resource lookups using this strongly typed resource class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Globalization.CultureInfo Culture {
			get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}

		internal static System.Drawing.Bitmap cc {
			get {
				object obj = ResourceManager.GetObject("cc", resourceCulture);
				return ((System.Drawing.Bitmap)(obj));
			}
		}

		/// <summary>
		///   Looks up a localized string similar to &amp;OK.
		/// </summary>
		internal static string ks_Ok {
			get {
				return ResourceManager.GetString("ks_Ok", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Hide Details.
		/// </summary>
		internal static string ksHideDetails {
			get {
				return ResourceManager.GetString("ksHideDetails", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Please email this to {0} with this exact subject:  {1}
		///
		///{2}.
		/// </summary>
		internal static string ksPleaseEMailThisTo0WithThisExactSubject12 {
			get {
				return ResourceManager.GetString("ksPleaseEMailThisTo0WithThisExactSubject12", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Example:
		///The Morph Type field cannot be set to Normally Hidden
		///
		///Steps to reproduce:
		///1. Go to Lexicon Edit
		///2. Turn off Show Hidden Fields
		///3. In the Morph Type field, click the blue arrow, and select Field Visibility &gt; Normally Hidden
		///
		///Expected result: the morph type field is no longer shown
		///Actual result: nothing happens..
		/// </summary>
		internal static string ksSampleProblemReport {
			get {
				return ResourceManager.GetString("ksSampleProblemReport", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to FieldWorks Error.
		/// </summary>
		internal static string kstidFieldWorksErrorCaption {
			get {
				return ResourceManager.GetString("kstidFieldWorksErrorCaption", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to This application must exit..
		/// </summary>
		internal static string kstidFieldWorksErrorExitInfo {
			get {
				return ResourceManager.GetString("kstidFieldWorksErrorExitInfo", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Please describe what you are want to accomplish as well as how you would like the program changed:.
		/// </summary>
		internal static string kstidGoalAndSuggestion {
			get {
				return ResourceManager.GetString("kstidGoalAndSuggestion", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Make a Suggestion.
		/// </summary>
		internal static string kstidMakeSuggestionCaption {
			get {
				return ResourceManager.GetString("kstidMakeSuggestionCaption", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Thank you for making a suggestion. A detailed description will help us to improve the program.
		/// </summary>
		internal static string kstidMakeSuggestionNotification {
			get {
				return ResourceManager.GetString("kstidMakeSuggestionNotification", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Please email this report to {0} with a suitable subject:
		///
		///{1}.
		/// </summary>
		internal static string kstidPleaseEmailThisTo0WithASuitableSubject {
			get {
				return ResourceManager.GetString("kstidPleaseEmailThisTo0WithASuitableSubject", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Please describe the problem and the steps necessary to make it appear:.
		/// </summary>
		internal static string kstidProblemAndSteps {
			get {
				return ResourceManager.GetString("kstidProblemAndSteps", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Report a Problem.
		/// </summary>
		internal static string kstidReportProblemCaption {
			get {
				return ResourceManager.GetString("kstidReportProblemCaption", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Thank you for reporting a problem. A detailed description will help us to improve the program..
		/// </summary>
		internal static string kstidReportProblemNotification {
			get {
				return ResourceManager.GetString("kstidReportProblemNotification", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Example:
		///Please make interlinear suggestions pay attention to context
		///
		///Goal:
		///I want to be able to interlinearize texts faster without having to make choices that I think the program should be able to guess if it considered surrounding words.
		///
		///Suggestion: Add a field to Word Analyses view in which a regular expression can be specified. If the pattern matches the context in which the word appears, that analysis will be chosen as a suggestion.The pattern should include a special marker for where the word [rest of string was truncated]&quot;;.
		/// </summary>
		internal static string kstidSampleSuggestion {
			get {
				return ResourceManager.GetString("kstidSampleSuggestion", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to FLEx was not able to send your message automatically. Please try copying it to the clipboard and sending it yourself..
		/// </summary>
		internal static string kstidSendFailed {
			get {
				return ResourceManager.GetString("kstidSendFailed", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Send Message Failed.
		/// </summary>
		internal static string kstidSendFailedCaption {
			get {
				return ResourceManager.GetString("kstidSendFailedCaption", resourceCulture);
			}
		}
	}
}
