
namespace OrgMode.Syntax;

/// <summary>
/// Objects are inline markup within elements.
/// Examples: bold, italic, links, timestamps
/// </summary>
public abstract record OrgObject(
  int Begin,
  int End,
  string Content,
  int PostBlank
) : OrgElement(Begin, End, PostBlank);
