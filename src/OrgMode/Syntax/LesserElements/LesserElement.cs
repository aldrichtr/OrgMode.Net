
namespace OrgMode.Syntax;


/// <summary>
/// A LesserElement is an OrgElement that does not contain other elements
/// </summary>
/// <inheritdoc cref="OrgElement"/>
/// <param name="Content">This is the textual content of the Element</param>
public abstract record LesserElement(
  int Begin,
  int End,
  string Content,
  int PostBlank
) : OrgElement(Begin, End, PostBlank);
