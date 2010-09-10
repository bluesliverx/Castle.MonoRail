// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.MonoRail.Views.AspView.Tests.RenderingTests
{
	using NUnit.Framework;

	[TestFixture]
	public class RenderMailMessageTests : IntegrationViewTestFixture
	{
		[Test, Ignore("Engine context locator cannot find stub context")]
		public void RenderMailMessage_NoLayout_Works() {
			string templateName = "/subviews/view1";
			var writer = new System.IO.StringWriter();
			viewEngine.Process(templateName, null, writer, new System.Collections.Generic.Dictionary<string, object>());
		}

		[Test, Ignore("Engine context locator cannot find stub context")]
		public void RenderMailMessage_WithLayout_Works() {
			var templateName = "/subviews/view1";
			var layoutName = "regular";
			var writer = new System.IO.StringWriter();
			viewEngine.Process(templateName, layoutName, writer, new System.Collections.Generic.Dictionary<string, object>());
		}
	}
}
