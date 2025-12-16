using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrgMode.Syntax;

namespace OrgModeTests.Syntax;

[TestClass]
public sealed class PositionTests {

  [TestMethod]
  public void Reset_moves_to_first_character() {
    var p = new Position(20, 2, 1);
    p.Reset();
    Assert.AreEqual(0, p.Index);
    Assert.AreEqual(1, p.Line);
    Assert.AreEqual(1, p.Column);
  }

  [TestMethod]
  public void Advance_the_position() {
    var p = new Position();
    Assert.AreEqual(0, p.Index);
    Assert.AreEqual(1, p.Line);
    Assert.AreEqual(1, p.Column);

    p.Advance();
    Assert.AreEqual(1, p.Index);
    Assert.AreEqual(1, p.Line);
    Assert.AreEqual(2, p.Column);
    p.Reset();

    p.Advance(5);
    Assert.AreEqual(5, p.Index);
    Assert.AreEqual(1, p.Line);
    Assert.AreEqual(6, p.Column);
  }

  [TestMethod]
  public void Advance_the_position_with_invalid_values() {
    var p = new Position();
    Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => p.Advance(-3));
    Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => p.Advance(0));
  }

  [TestMethod]
  public void EqualityAndHashCodeAreConsistent() {
    var a = new Position(5, 2, 3);
    var b = new Position(5, 2, 3);
    Assert.IsTrue(a.Equals(b));
    Assert.IsTrue(a == b);
    Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
  }
}
