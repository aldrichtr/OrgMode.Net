
using System.Collections.Generic;

namespace OrgMode.Syntax;

public sealed class ElementList {

  public IReadOnlyList<Element> Elements { get; }

  public ElementList(IReadOnlyList<Element> elements) {
    Elements = elements;
  }
}
