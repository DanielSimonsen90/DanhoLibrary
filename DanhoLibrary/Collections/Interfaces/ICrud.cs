namespace ConsoleThing
{
    public interface ICrud<Collection, Item>
    {
        /// <summary>
        /// Creates a new item to collection
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>Collection with the new item</returns>
        Collection Create(Item item);
        /// <summary>
        /// Read an <typeparamref name="Item"/> matching the <paramref name="id"/>
        /// </summary>
        /// <param name="id">Identifier to differentiate the <typeparamref name="Item"/>s</param>
        /// <returns>The <typeparamref name="Item"/> matching the <paramref name="id"/></returns>
        Item Read(string id);
        /// <summary>
        /// Update an <typeparamref name="Item"/> matching <paramref name="id"/> with <paramref name="updatedItem"/>
        /// </summary>
        /// <param name="id">Identifier to differentiate the <typeparamref name="Item"/>s</param>
        /// <param name="updatedItem">The updated item</param>
        /// <returns>The updated item</returns>
        Item Update(string id, Item updatedItem);
        /// <summary>
        /// Delete the <paramref name="item"/> from <typeparamref name="Collection"/>
        /// </summary>
        /// <param name="item">The <typeparamref name="Item"/> to delete</param>
        /// <returns>The <typeparamref name="Collection"/> without <paramref name="item"/></returns>
        Collection Delete(Item item);
        /// <summary>
        /// Delete the <typeparamref name="Item"/> matching the <paramref name="id"/> from <typeparamref name="Collection"/>
        /// </summary>
        /// <param name="id">Identifier to differentiate the <typeparamref name="Item"/>s</param>
        /// <returns>The <typeparamref name="Collection"/> without <paramref name="item"/></returns>
        Collection Delete(string id);
    }
}