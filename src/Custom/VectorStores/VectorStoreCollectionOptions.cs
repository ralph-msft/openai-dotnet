using System.Diagnostics.CodeAnalysis;

namespace OpenAI.VectorStores;

/// <summary>
/// Represents addition options available when requesting a collection of <see cref="VectorStore"/> instances.
/// </summary>
[Experimental("OPENAI001")]
public class VectorStoreCollectionOptions
{
    /// <summary>
    /// Creates a new instance of <see cref="VectorStoreCollectionOptions"/>.
    /// </summary>
    public VectorStoreCollectionOptions() { }

    /// <summary>
    /// The <c>order</c> that results should appear in the list according to
    /// their <c>created_at</c> timestamp.
    /// </summary>
    public ListOrder? Order { get; set; }

    /// <summary>
    /// The number of values to return in a page result.
    /// </summary>
    public int? PageSize { get; set; }

    /// <summary>
    /// The id of the item preceeding the first item in the collection.
    /// </summary>
    public string AfterId { get; set; }

    /// <summary>
    /// The id of the item following the last item in the collection.
    /// </summary>
    public string BeforeId { get; set; }
}
