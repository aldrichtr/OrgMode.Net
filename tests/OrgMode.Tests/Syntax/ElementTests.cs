using Microsoft.VisualStudio.TestTools.UnitTesting;

using OrgMode.Syntax;

namespace OrgMode.Tests.Syntax;

[TestClass]
public class ElementTests {
  private TestElement element = null!;

  [TestInitialize]
  public void Setup() {
    element = new TestElement();
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void SetData_NullKey_Throws() {
    element.SetData(null!, "value");
  }

  [TestMethod]
  public void SetData_StoresAndRetrievesValue() {
    element.SetData("key", "value");
    Assert.IsTrue(element.ContainsData("key"));
    Assert.AreEqual("value", element.GetData("key"));
  }

  [TestMethod]
  public void RemoveData_RemovesKey() {
    element.SetData("key", "value");
    var removed = element.RemoveData("key");
    Assert.IsTrue(removed);
    Assert.IsFalse(element.ContainsData("key"));
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void AddContent_Null_Throws() {
    element.AddContent(null!);
  }

  [TestMethod]
  public void AddContent_AppendsItem() {
    element.AddContent("hello");
    Assert.AreEqual(1, element.ContentCount);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void InsertContent_NegativeIndex_Throws() {
    element.InsertContent(-1, "oops");
  }

  [TestMethod]
  public void InsertContent_ValidIndex_InsertsItem() {
    element.AddContent("first");
    element.InsertContent(0, "inserted");
    Assert.AreEqual(2, element.ContentCount);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void RemoveContentAt_InvalidIndex_Throws() {
    element.RemoveContentAt(0);
  }
}
