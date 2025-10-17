
namespace OrgMode.Syntax;

/// <summary>
/// A unit of text with a defined start and end position, and optional text content.
/// </summary>
/// <param name="start"></param>
/// <param name="end"></param>
public record TextSpan(Position Start, Position End) : Span(Start, End) {

  // TODO: How do I keep this synchronized with the reader?
  public IReadOnlyList<string>? Text { get; init; }

  public TextSpan(Position start, Position end, IReadOnlyList<string>? text)
    : this(start, end) {
    Text = text;
  }
}
