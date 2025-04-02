using AssistHub.Backend.Entities;

namespace AssistHub.Backend.Repositories;

public class GuidBasedRepositoryBase<T> : IGuidBasedRepository<T> where T : GuidBasedEntity
{
    private List<T> Entities { get; set; } = [];

    public T Add(T entity)
    {
        Entities.Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        var isUpdated = false;
        for (var i = 0; i < Entities.Count; i++)
        {
            if (Entities[i].Id != entity.Id) continue;
            Entities[i] = entity;
            isUpdated = true;
        }

        if (!isUpdated)
        {
            Add(entity);
        }

        return entity;
    }

    public void Delete(T entity)
    {
        for (var i = 0; i < Entities.Count; i++)
        {
            if (Entities[i].Id != entity.Id) continue;
            Entities.RemoveAt(i);
            return;
        }

        throw new Exception("Entity not found");
    }

    public void DeleteById(Guid id)
    {
        Entities.RemoveAll(x => x.Id == id);
    }

    public T Get(Guid id)
    {
        var firstOrDefault = Entities.FirstOrDefault(e => e.Id == id);
        if (firstOrDefault == null) throw new Exception("Entity not found");
        return firstOrDefault;
    }
}