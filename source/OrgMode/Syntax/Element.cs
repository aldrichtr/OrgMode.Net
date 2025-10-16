
namespace OrgMode.Syntax;
/// <summary>
/// Represents a syntax element in an Org mode document.
/// </summary>
public abstract class Element : IElement {

  /// <summary>
  /// Holds arbitrary data associated with this element.
  /// </summary>
  private readonly Dictionary<object, object> _data = [];

  public void SetData(object key, object value) {
    _data[key] = value;
  }

  public bool ContainsData(object key) {
    return _data.ContainsKey(key);
  }

  public object? GetData(object key) {
    _data.TryGetValue(key, out var value);
    return value;
  }

  public bool RemoveData(object key) {
    return _data.Remove(key);
  }
}
