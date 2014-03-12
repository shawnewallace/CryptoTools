using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CryptoTools.lib.tests
{
  [TestFixture]
  public class PasswordHashAndSaltTests
  {
    [Test]
    public void ThePasswordIsEncrypted()
    {
      var result = PasswordHashCreator.Create("password");
      Assert.AreNotEqual("password", result);
    }

    [Test]
    public void TheIterationsAndSaltAreIncluded()
    {
      var result = PasswordHashCreator.Create("shawn");
      var numColumns = result.Count(r => r == ':');
      Assert.AreEqual(2, numColumns);
    }
  }
}
