
using Parlot;
using Parlot.Fluent;
using static Parlot.Fluent.Parsers;

namespace OrgModeTests.Parser;

[TestClass]
public class ParserTests {

[TestMethod]
public void Parlot_Parser_AndAllowsWhitespaceBetweenElements() {
    var input = "age = 12";
    var parser = Terms.Identifier().And(Terms.Char('=')).And(Terms.Integer());
    var result = parser.Parse(input);

    Assert.AreEqual("age", result.Item1);
    Assert.AreEqual('=', result.Item2);
    Assert.AreEqual(12, result.Item3);
}

}
