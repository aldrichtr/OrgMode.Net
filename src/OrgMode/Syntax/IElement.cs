
namespace OrgMode.Syntax;

public interface IElement {
  /// <summary>
  /// Stores a Property as a key/value pair for the Element.
  /// </summary>
  /// <param name="key">The key.</param>
  /// <param name="value">The value.</param>
  /// <exception cref="System.ArgumentNullException">if key is null</exception>
  void SetData(object key, object value);

  /// <summary>
  /// Determines whether this instance contains the specified Property
  /// </summary>
  /// <param name="key">The key.</param>
  /// <returns><c>true</c> if a data with the key is stored</returns>
  /// <exception cref="System.ArgumentNullException">if key is null</exception>
  bool ContainsData(object key);

  /// <summary>
  /// Gets the associated data for the specified Property.
  /// </summary>
  /// <param name="key">The key.</param>
  /// <returns>The associated data or null if none</returns>
  /// <exception cref="System.ArgumentNullException">if key is null</exception>
  object? GetData(object key);

  /// <summary>
  /// Removes the associated data for the specified key.
  /// </summary>
  /// <param name="key">The key.</param>
  /// <returns><c>true</c> if the data was removed; <c>false</c> otherwise</returns>
  /// <exception cref="System.ArgumentNullException"></exception>
  bool RemoveData(object key);



  // SECTION Content methods

  /// <summary>
  /// Add content to this Element
  /// </summary>
  /// <exception cref="System.ArgumentNullException"></element>
  /// <param name="content"></param>
  void AddContent(object content);

  /// <summary>
  /// Add content to this Element at the specified index
  /// </summary>
  /// <param name="index">The zero-based index to insert the object at</param>
  /// <param name="content">The content to insert</param>
  /// <exception cref="System.ArgumentOutOfRangeException"></element>
  void InsertContent(int index, object content);

  /// <summary>
  /// Remove content from this Element.
  /// </summary>
  /// <param name="content">The object to be removed</param>
  void RemoveContent(object? content);

  /// <summary>
  /// Remove content from this Element at the specified index
  /// </summary>
  /// <param name="content">The object to be removed</param>
  /// <param name="index">The zero-based index to remove the object at</param>
  void RemoveContentAt(int index);
  // !SECTION


}
