﻿// Copyright (c) 2015 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using NUnit.Framework;
using SIL.CoreImpl.Text;
using SIL.FieldWorks.Common.FwUtils;
using SIL.FieldWorks.FDO;
using SIL.FieldWorks.FDO.Application;
using SIL.FieldWorks.FDO.FDOTests;

namespace SIL.FieldWorks.Common.Framework.DetailControls
{
	/// <summary>
	/// Tests (so far minimal) of PhoneEnvReferenceView
	/// </summary>
	[TestFixture]
	public class PhoneEnvReferenceViewTests : MemoryOnlyBackendProviderRestoredForEachTestTestBase
	{
		/// <summary>
		/// There's a lot more we could verify about the end results of this test, as well as more we could
		/// test about EnvsBeingRequestedForThisEntry. This test was intended to cover a particular bug fix.
		/// </summary>
		[Test]
		public void EnvsBeingRequestedForThisEntry_HandlesItemFollowingEmptyString()
		{
			var sda = new PhoneEnvReferenceView.PhoneEnvReferenceSda(Cache.DomainDataByFlid as ISilDataAccessManaged);
			var entry = Cache.ServiceLocator.GetInstance<ILexEntryFactory>().Create();
			var form = Cache.ServiceLocator.GetInstance<IMoStemAllomorphFactory>().Create();
			entry.LexemeFormOA = form;
			var root = form.Hvo;
			var hvos = new [] {-5000, -5001, -5002};
			sda.CacheVecProp(root, PhoneEnvReferenceView.kMainObjEnvironments, hvos, hvos.Length);
			sda.SetString(hvos[1], PhoneEnvReferenceView.kEnvStringRep, TsStringUtils.MakeString("abc", 6));
			IPublisher publisher;
			ISubscriber subscriber;
			PubSubSystemFactory.CreatePubSubSystem(out publisher, out subscriber);
			using (var propertyTable = PropertyTableFactory.CreatePropertyTable(publisher))
			using (var view = new PhoneEnvReferenceView())
			{
				view.InitializeFlexComponent(new FlexComponentParameters(propertyTable, publisher, subscriber));
				view.SetSda(sda);
				view.SetRoot(form);
				view.SetCache(Cache);
				var results = view.EnvsBeingRequestedForThisEntry();
				Assert.That(results, Has.Count.EqualTo(1));
			}
		}
	}
}
