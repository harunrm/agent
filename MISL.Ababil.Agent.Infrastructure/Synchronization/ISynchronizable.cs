namespace MISL.Ababil.Agent.Infrastructure.Synchronization
{
    public interface ISynchronizable
    {
        object GetData();
        object SetData(object data);
    }
}