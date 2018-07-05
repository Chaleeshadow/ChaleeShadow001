namespace ProjectR.ECS.Player
{
    public interface IClientFactory
    {
        void Build(ClientPlayerSpawnData spawnDataClientPlayerSpawnData);
        void Build(ClientPlayerSpawnData spawnDataClientPlayerSpawnData, int id1);
    }
}