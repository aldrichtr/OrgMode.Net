
namespace OrgMode.Syntax;

/// <summary>
/// Base type for all org-mode syntax elements.
/// See: https://orgmode.org/worg/org-syntax.html
/// <param name="Begin">The Offset of the beginning of the element.</param>
/// <param name="End">The Offset of the end of the element.</param>
/// <param name="PostBlank">The amount of whitespace characters past the element</param>
/// </summary>
public abstract record OrgElement(
  int Begin,
  int End,
  int PostBlank
);
