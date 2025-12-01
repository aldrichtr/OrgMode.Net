using Parlot.Fluent;
using static Parlot.Fluent.Parsers;
using OrgMode.Syntax;

using ElementParser = Parlot.Fluent.Parser<OrgMode.Syntax.IElement>;
using Pipeline = System.Collections.Generic.List<Parlot.Fluent.Parser<OrgMode.Syntax.IElement>>;
using ParserRegistry = System.Collections.Generic.Dictionary<string, Parlot.Fluent.Parser<OrgMode.Syntax.IElement>>;

namespace OrgMode.Parser;

/// <summary>
/// Builder class for composing Org-mode parsers into a pipeline.
/// </summary>
public class OrgParserBuilder {
  private readonly ParserRegistry _registry = new();

  /// <summary>
  /// Registers a parser with the given key.
  /// </summary>
  /// <param name="key">The parser name.</param>
  /// <param name="parser">The parser instance.</param>
  public OrgParserBuilder Register(string key, ElementParser parser) {
    _registry[key] = parser;
    return this;
  }

  /// <summary>
  /// Builds a pipeline from the registered parsers matching the given keys.
  /// </summary>
  /// <param name="keys">The parser keys to include.</param>
  /// <returns>A composed parser that parses a list of elements.</returns>
  public Pipeline Build(params string[] keys) {
    var selectedParsers = keys
        .Where(_registry.ContainsKey)
        .Select(k => _registry[k])
        .ToArray();

    return ZeroOrMany<Pipeline>(selectedParsers);
  }
}
