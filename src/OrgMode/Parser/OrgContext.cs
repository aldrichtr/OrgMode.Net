
using Parlot;
using Parlot.Fluent;

namespace OrgMode.Parser;

public class OrgContext(Scanner scanner, bool useNewLines = false)
  : ParseContext(scanner, useNewLines) {

}
