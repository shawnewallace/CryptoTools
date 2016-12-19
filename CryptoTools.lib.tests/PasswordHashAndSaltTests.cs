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
    private const string PASSWORD = "wsr$7n9";

    private string _result;

    [SetUp]
    public void SetupEachTest()
    {
      _result = PasswordHashCreator.Create(PASSWORD);
    }

    [Test]
    public void ThePasswordIsEncrypted()
    {
      Assert.AreNotEqual(PASSWORD, _result);
    }

    [Test]
    public void ItWillValidateACorrectPassword()
    {
      Assert.IsTrue(HashedPasswordValidator.Validate(PASSWORD, _result));
    }

    [Test]
    public void ItWillRejectAnIncorrectPassword()
    {
      Assert.IsFalse(HashedPasswordValidator.Validate("wsr-7n9", _result));
    }

    [Test]
    public void TheIterationsAndSaltAreIncluded()
    {
      var numColumns = _result.Count(r => r == ':');
      Assert.AreEqual(2, numColumns);
    }
  }
}
