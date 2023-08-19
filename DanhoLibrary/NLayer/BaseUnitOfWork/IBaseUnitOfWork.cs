using System.Threading.Tasks;

namespace DanhoLibrary.NLayer.BaseUnitOfWork;

internal interface IBaseUnitOfWork
{
    /// <summary>
    /// Save changes to database
    /// </summary>
    /// <returns>Rows affected</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Save changes to database
    /// </summary>
    /// <returns>Rows affected</returns>
    int SaveChanges();
}
