using System;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OrgMode.Syntax;

namespace OrgModeTests.Syntax;

[TestClass]
public class ElementTests {
  private Element element = null!;

  [TestInitialize]
  public void Setup() {
    element = new Element();
  }

  [TestMethod]
  public void SetData_NullKey_Throws() {
    Assert.ThrowsExactly<ArgumentNullException>(
      () => element.SetData(null!, "value")
    );
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
  public void AddContent_Null_Throws() {
    Assert.ThrowsExactly<ArgumentNullException>(
      () => element.AddContent(null!)
    );
  }

  [TestMethod]
  public void AddContent_AppendsItem() {
    element.AddContent("hello");
    Assert.AreEqual(1, element.ContentCount);
  }

  [TestMethod]
  public void InsertContent_NegativeIndex_Throws() {
    Assert.ThrowsExactly<ArgumentOutOfRangeException>(
      () => element.InsertContent(-1, "oops")
    );
  }

  [TestMethod]
  public void InsertContent_ValidIndex_InsertsItem() {
    element.AddContent("first");
    element.InsertContent(0, "inserted");
    Assert.AreEqual(2, element.ContentCount);
  }

  [TestMethod]
  public void RemoveContentAt_InvalidIndex_Throws() {
    Assert.ThrowsExactly<ArgumentOutOfRangeException>(
      () => element.RemoveContentAt(0)
    );
  }
}
