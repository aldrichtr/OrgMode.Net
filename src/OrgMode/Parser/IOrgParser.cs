using Parlot.Fluent;
using OrgMode.Syntax;

namespace OrgMode.Parser;

/// <summary>
/// Interface for modular Org-mode parsers.
/// </summary>
public interface IOrgParser {
  /// <summary>
  /// The name used to register this parser.
  /// </summary>
  string Name { get; }

  /// <summary>
  /// Builds the parser instance.
  /// </summary>
  /// <returns>A parser that produces an Org-mode element.</returns>
  Parser<IElement> Build();
}
