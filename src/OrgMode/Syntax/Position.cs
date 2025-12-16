
namespace OrgMode.Syntax;

/// <summary>
/// Represents a unique cursor position within a content stream.  Index is zero-based character offset into the
/// content.  Line and Column are one-based human-friendly coordinates.  This type is immutable and implement value
/// semantics.
/// </summary>
public class Position : IEquatable<Position>, IComparable<Position> {
  public long Index { get; private set; }
  public long Line { get; private set; }
  public long Column { get; private set; }


  /// <summary>
  /// Creates a new Position.
  /// </summary>
  /// <param name="index">Zero-based index long the content.</param>
  /// <param name="line">One-based line number (must be &gt;= 1).</param>
  /// <param name="column">One-based column number (must be &gt;= 1).</param>
  public Position(long index, long line, long column) {
    ArgumentOutOfRangeException.ThrowIfLessThan(index, 0, "Index must be >= 0");
    ArgumentOutOfRangeException.ThrowIfLessThan(line, 1, "Line must be >= 1");
    ArgumentOutOfRangeException.ThrowIfLessThan(column, 1, "Column must be >= 1");
    Index = index;
    Line = line;
    Column = column;
  }

  public Position()
    : this(0, 1, 1) { }

  public void Reset() {
    Index = 0;
    Line = 1;
    Column = 1;
  }

  public void Advance(int count = 1) {
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);
    Index += count;
    Column += count;
  }

  public void NewLine() {
    Column = 0;
    Index++;
    Line++;
  }

  public Position AdvanceLine(long charsAdvanced = 1) => new(Index + charsAdvanced, Line + 1, 1);

  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is Position p && Equals(p);

  /// <inheritdoc/>
  public bool Equals(Position? other) {
    if (other is null) return false;
    return Index == other.Index && Line == other.Line && Column == other.Column;
  }

  public override int GetHashCode() => HashCode.Combine(Index);

  public int CompareTo(Position? other) {
    ArgumentNullException.ThrowIfNull(other);
    return Index.CompareTo(other.Index);
  }

  // #region Operator overloads
  public static bool operator ==(Position left, Position right) {
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return left.Equals(right);
  }
  public static bool operator !=(Position left, Position right) {
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return !left.Equals(right);
  }
  public static bool operator <(Position left, Position right) {
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return left.Index < right.Index;
  }
  public static bool operator <=(Position left, Position right) {
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return left.Index <= right.Index;
  }
  public static bool operator >(Position left, Position right) {
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return left.Index > right.Index;
  }
  public static bool operator >=(Position left, Position right) {
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return left.Index >= right.Index;
  }
  // #region Operator overloads

  /// <inheritdoc/>
  public override string ToString() => $"Index={Index}, Line={Line}, Column={Column}";
}
