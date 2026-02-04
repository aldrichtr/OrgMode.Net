
namespace OrgMode.Syntax;


/// <summary>
/// A GreaterElement is an OrgElement that can contain other OrgElements.
/// </summary>
/// <inheritdoc cref="OrgElement"/>
/// <param name="Content"></param>
public abstract record GreaterElement(
  int Begin,
  int End,
  ElementList Content,
  int PostBlank
) : OrgElement(Begin, End, PostBlank);
