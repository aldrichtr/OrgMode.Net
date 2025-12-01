using System.Collections.Generic;

using Parlot;
using Parlot.Fluent;

using static Parlot.Fluent.Parsers;

public static class OrgTerm {

  private static readonly string UPPER_ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
  private static readonly string LOWER_ALPHA = "abcdefghijklmnopqrstuvwxyz";
  public class Symbol {
    public static readonly Parser<Char> Star = Terms.Char('*');
    public static readonly Parser<Char> Hash = Terms.Char('#');

    public static readonly Parser<Char> Underbar = Terms.Char('_');
    public static readonly Parser<Char> Plus = Terms.Char('+');
    public static readonly Parser<Char> Minus = Terms.Char('-');
    public static readonly Parser<Char> Colon = Terms.Char(':');
    public static readonly Parser<Char> LBracket = Terms.Char('[');
    public static readonly Parser<Char> RBracket = Terms.Char(']');
    public static readonly Parser<Char> LBrace = Terms.Char('{');
    public static readonly Parser<Char> RBrace = Terms.Char('}');
  }

  public class Whitespace {

    public static readonly Parser<Char> Space = Terms.Char(' ');
    public static readonly Parser<Char> Tab = Terms.Char('\t');
    public static readonly Parser<Char> LF = Terms.Char('\n');
    public static readonly Parser<Char> CR = Terms.Char('\r');
  }

  public static readonly Parser<char> NewLine = Terms.Text(Whitespace.CR.Optional().Then(Whitespace.LF));

  public static readonly Parser<string> HashPlus = Terms.Text("#+");
  public static readonly Parser<IReadOnlyList<TextSpan>> UpperWord = OneOrMany(Terms.AnyOf(UPPER_ALPHA));
}
