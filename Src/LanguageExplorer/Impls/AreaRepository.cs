// Copyright (c) 2015 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SIL.FieldWorks.Common.FwUtils;

namespace LanguageExplorer.Impls
{
#if RANDYTODO
	// TODO: Upgrade to .Net 4.5 and use MEF 2.0 instead of reflection. (Ok, MEF will use Reflection, but that is fine.)
	// TODO: MEF will need to create the AreaRepository, and thus the areas, on a per window scope.
	// TODO: MEF in .Net 4 can't do scoping beyond singleton or per call.
#endif
	/// <summary>
	/// Repository for IArea implementations.
	/// </summary>
	internal sealed class AreaRepository : IAreaRepository
	{
		private const string DefaultAreaMachineName = "lexicon";
		private readonly Dictionary<string, IArea> m_areas = new Dictionary<string, IArea>();

		/// <summary>
		/// Constructor.
		/// </summary>
		internal AreaRepository(IToolRepository toolRepository)
		{
			var parmTypes = new Type[1];
			parmTypes[0] = typeof(IToolRepository);
			var parms = new object[1];
			parms[0] = toolRepository;

			// Use Reflection (for now) to get all implementations of IArea.
			var langExAssembly = Assembly.GetExecutingAssembly();
			var areaTypes = (langExAssembly.GetTypes().Where(typeof(IArea).IsAssignableFrom)).ToList();
			foreach (var areaType in areaTypes)
			{
				var constInfo = areaType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, parmTypes, null);
				if (constInfo == null)
				{
					continue; // It does need at least one public or non-public constructor that takes the IToolRepository parameter.
				}
				var currentArea = (IArea)constInfo.Invoke(BindingFlags.NonPublic, null, parms, null);
				m_areas.Add(currentArea.MachineName, currentArea);
			}
		}

#region Implementation of IAreaRepository

		/// <summary>
		/// Get the most recently persisted area, or the default area if
		/// the persisted one is no longer available.
		/// </summary>
		/// <returns>The last persisted area or the default area.</returns>
		public IArea GetPersistedOrDefaultArea()
		{
			// The persisted area could be obsolete or simply not present,
			// so we'll use "lexicon", if the stored one cannot be found.
			// The "lexicon" area must be available, even if there are no other areas.
			return GetArea(PropertyTable.GetValue("InitialArea", SettingsGroup.LocalSettings, DefaultAreaMachineName));
		}

		/// <summary>
		/// Get the IArea that has the machine friendly "Name" for <paramref name="machineName"/>.
		/// </summary>
		/// <param name="machineName"></param>
		/// <returns>The IArea for the given Name, or null if not in the system.</returns>
		public IArea GetArea(string machineName)
		{
			IArea retval;
			m_areas.TryGetValue(machineName, out retval);
			return retval; // May be null.
		}

		/// <summary>
		/// Return all areas in this order (if installed):
		/// Lexicon - required
		/// Text and Words
		/// Grammar
		/// Notebook
		/// Lists
		/// User defined areas (unspecified order, but after the fully supported areas)
		/// </summary>
		/// <returns></returns>
		public IList<IArea> AllAreasInOrder()
		{
			var knownAreas = new List<string>
			{
				"lexicon",
				"textAndWords",
				"grammar",
				"notebook",
				"lists"
			};
			var retval = new List<IArea>(m_areas.Count);
			if (m_areas.ContainsKey(knownAreas[0]))
				retval.Add(m_areas[knownAreas[0]]);
			if (m_areas.ContainsKey(knownAreas[1]))
				retval.Add(m_areas[knownAreas[1]]);
			if (m_areas.ContainsKey(knownAreas[2]))
				retval.Add(m_areas[knownAreas[2]]);
			if (m_areas.ContainsKey(knownAreas[3]))
				retval.Add(m_areas[knownAreas[3]]);
			if (m_areas.ContainsKey(knownAreas[4]))
				retval.Add(m_areas[knownAreas[4]]);

			// Add user-defined areas in unspecified order, but after the fully supported areas.
			retval.AddRange(m_areas.Values.Where(userDefinedArea => !knownAreas.Contains(userDefinedArea.MachineName)));


			return retval;
		}

#endregion

#region Implementation of IPropertyTableProvider

		/// <summary>
		/// Placement in the IPropertyTableProvider interface lets FwApp call IPropertyTable.DoStuff.
		/// </summary>
		public IPropertyTable PropertyTable { get; private set; }

#endregion

#region Implementation of IPublisherProvider

		/// <summary>
		/// Get the IPublisher.
		/// </summary>
		public IPublisher Publisher { get; private set; }

#endregion

#region Implementation of ISubscriberProvider

		/// <summary>
		/// Get the ISubscriber.
		/// </summary>
		public ISubscriber Subscriber { get; private set; }

#endregion

#region Implementation of IFlexComponent

		/// <summary>
		/// Initialize a FLEx component with the basic interfaces.
		/// </summary>
		/// <param name="flexComponentParameters">Parameter object that contains the required three interfaces.</param>
		public void InitializeFlexComponent(FlexComponentParameters flexComponentParameters)
		{
			FlexComponentCheckingService.CheckInitializationValues(flexComponentParameters, new FlexComponentParameters(PropertyTable, Publisher, Subscriber));

			PropertyTable = flexComponentParameters.PropertyTable;
			Publisher = flexComponentParameters.Publisher;
			Subscriber = flexComponentParameters.Subscriber;

			foreach (var area in m_areas.Values)
			{
				area.InitializeFlexComponent(new FlexComponentParameters(PropertyTable, Publisher, Subscriber));
			}
		}

#endregion
	}
}