using AssistHub.Backend.Entities;

namespace AssistHub.Backend.Repositories;

public interface IGuidBasedRepository<T> where T : GuidBasedEntity
{
    T Add(T entity);
    T Update(T entity);
    void Delete(T entity);
    T Get(Guid id);
}