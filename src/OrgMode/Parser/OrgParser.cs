using Parlot;
using Parlot.Fluent;
using static Parlot.Fluent.Parsers;

using OrgMode.Syntax;

namespace OrgMode.Parser;

public sealed class OrgParser {

  public static readonly Parser<ElementList> Elements;

  static OrgParser() {

    // SECTION Base Characters
    var COMMA = Terms.Char(',');
    var DOT = Terms.Char('.');

    var SEMICOLON = Terms.Char(';');
    var COLON = Terms.Char(':');

    var LPAREN = Terms.Char('(');
    var RPAREN = Terms.Char(')');
    var LBRACKET = Terms.Char('[');
    var RBRACKET = Terms.Char(']');

    var AT = Terms.Char('@');
    var STAR = Terms.Char('*');
    var HASH = Terms.Char('#');
    var UBAR = Terms.Char('_');

    var EQ = Terms.Char('=');
    var PLUS = Terms.Char('+');
    var MINUS = Terms.Char('-');
    // !SECTION

    // SECTION Markers
    var HashPlus = HASH.And(PLUS);
    // !SECTION

    // SECTION - Keywords
    var ARCHIVE = Terms.Keyword("ARCHIVE", caseInsensitive: true);
    var COMMENT = Terms.Keyword("COMMENT", caseInsensitive: true);

    var CLOCK = Terms.Keyword("CLOCK:", caseInsensitive: true);

    // SECTION - Planning
    var CLOSED = Terms.Keyword("CLOSED:", caseInsensitive: true);
    var DEADLINE = Terms.Keyword("DEADLINE:", caseInsensitive: true);
    var SCHEDULED = Terms.Keyword("SCHEDULED:", caseInsensitive: true);
    // !SECTION

    // SECTION Blocks
    var BEGIN = Literals.Text("BEGIN");
    var BLOCK_BEGIN = HashPlus.And(BEGIN);

    var DYN_BLOCK_BEGIN = BLOCK_BEGIN.And(COLON);

    var SRC = Literals.Text("SRC");
    var SRC_BLOCK_BEGIN = BLOCK_BEGIN.And(UBAR).And(SRC);
    // !SECTION

  }

  public static ElementList? Parse(string input) {
    if (TryParse(input, out var result, out var _)) {
      return result;
    }
    return null;
  }

  public static bool TryParse(string input, out ElementList? result, out ParseError? error) {
    var context = new ParseContext(new Scanner(input));
    return Elements.TryParse(context, out result, out error);
  }
}
