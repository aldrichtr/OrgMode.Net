
namespace OrgMode.Syntax;

public record Span(Position Start, Position End) {
  public long Length => End.Index - Start.Index;

  public bool IsEmpty => Length == 0;

  public override string ToString() => $"[{Start.Index}, {End.Index})";
}
