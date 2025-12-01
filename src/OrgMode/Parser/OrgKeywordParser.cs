using Parlot.Fluent;
using static Parlot.Fluent.Parsers;

using OrgMode.Syntax;
using Parlot;

namespace OrgMode.Parser;

/// <summary>
/// Parser for Org-mode keywords like #+TITLE, #+AUTHOR, etc.
/// </summary>
public class OrgKeywordParser : IOrgParser {
  /// <inheritdoc />
  public string Name => "Keyword";

  /// <inheritdoc />
  public Parser<IElement> Build() {
    return OrgTerm.HashPlus
      .Then(OrgTerm.UpperWord)
      .Then(OrgTerm.Symbol.Colon)
      .And(OrgTerm.Whitespace)
      .Select(result => {
          var name = result[1].ToString();
          var value = result[3].ToString().Trim();
          return new OrgKeyword(name, value);
        });
  }
}
