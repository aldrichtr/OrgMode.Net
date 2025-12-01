using Parlot;
using Parlot.Fluent;
using static Parlot.Fluent.Parsers;

using OrgMode.Syntax;

namespace OrgMode.Parser;

/// <summary>
/// Entry point for parsing Org-mode documents. Wraps the builder and exposes a simple API.
/// </summary>
public class OrgParser {
  private readonly Parser<List<IElement>> _pipeline;

  /// <summary>
  /// Constructs an OrgParser using the provided builder and parser keys.
  /// </summary>
  /// <param name="builder">The parser builder to use.</param>
  /// <param name="keys">The parser keys to include in the pipeline.</param>
  public OrgParser(OrgParserBuilder builder, params string[] keys) {
    _pipeline = builder.Build(keys);
  }

  /// <summary>
  /// Parses the input string into a list of Org-mode elements.
  /// </summary>
  /// <param name="input">The Org-mode document text.</param>
  /// <returns>A list of parsed elements.</returns>
  public List<IElement> Parse(string input) {
    var context = new ParseContext(input);
    var result = _pipeline.Parse(context);
    return result.Success ? result.Value : new List<IElement>();
  }
}
