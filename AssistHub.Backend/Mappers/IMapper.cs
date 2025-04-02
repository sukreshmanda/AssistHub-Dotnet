using AssistHub.Backend.Entities;

namespace AssistHub.Backend.Mappers;

public interface IMapper<in T, out TV> where T : GuidBasedEntity
{
    public TV Map(T source);
}