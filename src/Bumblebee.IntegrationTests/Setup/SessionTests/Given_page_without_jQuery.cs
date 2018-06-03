﻿using Bumblebee.IntegrationTests.Shared;
using Bumblebee.IntegrationTests.Shared.Hosting;
using Bumblebee.IntegrationTests.Shared.Pages;
using Bumblebee.JQuery;
using Bumblebee.Setup;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Setup.SessionTests
{
	[TestFixture(typeof(HeadlessChrome))]
	public class Given_page_without_jQuery<T> : HostTestFixture
		where T : IDriverEnvironment, new()
	{
		[OneTimeSetUp]
		public void TestFixtureSetUp()
		{
			Threaded<Session>
				.With<T>()
				.NavigateTo<CheckboxPage>(GetUrl("Checkbox.html"));
		}

		[OneTimeTearDown]
		public void TestFixtureTearDown()
		{
			Threaded<Session>
				.End();
		}

		[Test]
		public void HasJQuery()
		{
			Threaded<Session>
				.CurrentBlock<PageWithJQuery>()
				.Session.HasJQuery()
				.Should().BeFalse();
		}
	}
}
