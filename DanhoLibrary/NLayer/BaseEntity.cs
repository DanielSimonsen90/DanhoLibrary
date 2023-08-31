using System.ComponentModel.DataAnnotations;

namespace DanhoLibrary.NLayer
{
    public abstract class BaseEntity<TId>
    {
        [Key]
        /// <summary>
        /// The Id of the entity.
        /// </summary>
        public TId Id { get; set; }
    }
}
