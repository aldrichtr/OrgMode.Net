
namespace OrgMode.Syntax;

/// <summary>
/// The entire OrgMode buffer.
/// </summary>
public record OrgData(
  int Begin,
  int End,
  ElementList Content,
  int PostBlank
) : GreaterElement(Begin, End, Content, PostBlank);
