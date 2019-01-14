using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialSystem.Models;
using FinancialSystem.Utilities;
using FinancialSystem.TestClass;

namespace FinancialSystem.test {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void TestMethod1() {
			TestCreateUser tc = new TestCreateUser();
			tc.createUser();
		}
		
	}
}
