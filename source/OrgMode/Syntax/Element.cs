
using System.Collections;

namespace OrgMode.Syntax;
/// <summary>
/// Represents a syntax element in an Org mode document.
/// Contains a Type, a collection of Properties, and a Content collection
/// </summary>
public abstract class Element : IElement {

  /// <summary>
  /// Holds the properties associated with the element
  /// </summary>
  private readonly Dictionary<object, object> _data = [];

/// <summary>
/// Holds the Content (Either other Elements or Text)
/// </summary>
  private readonly List<object> _content = [];

// SECTION Property methods

  public void SetData(object key, object value) {
    ArgumentNullException.ThrowIfNull(key, "No key was provided");
    _data[key] = value;
  }

  public bool ContainsData(object key) {
    ArgumentNullException.ThrowIfNull(key, "No key was provided");
    return _data.ContainsKey(key);
  }

  public object? GetData(object key) {
    ArgumentNullException.ThrowIfNull(key, "No key was provided");
    _data.TryGetValue(key, out var value);
    return value;
  }

  public bool RemoveData(object key) {
    return _data.Remove(key);
  }
// !SECTION

  // SECTION Content methods

  public virtual void AddContent(object content) {
    ArgumentNullException.ThrowIfNull(content, "No content was provided");
    _content.Add(content);
  }

  public virtual void InsertContent(int index, object content) {
    ArgumentNullException.ThrowIfNull(content, "No content was provided");
    ArgumentOutOfRangeException.ThrowIfNegative(index, "Index must be zero or more");
    _content.Insert(index, content);
  }

  public virtual void RemoveContent(object? content) {
    // ! The ArrayList.Remove method allows nulls
    _content.Remove(content);
  }

  public virtual void RemoveContentAt(int index) {
    ArgumentOutOfRangeException.ThrowIfNegative(index, "Index must be zero or more");
    ArgumentOutOfRangeException.ThrowIfGreaterThan(index, _content.Count, $"Index {index} is out of range");
    _content.RemoveAt(index);
  }


  public bool HasContent => _content.Count > 0;
  public int ContentCount => _content.Count;


  // !SECTION

}
