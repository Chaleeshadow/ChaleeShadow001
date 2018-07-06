using ProjectR.ECS.Net;
using Svelto.ECS;

namespace ProjectR.ECS.Player
{

	public class PlayerEntityDescriptor : GenericEntityDescriptor<PlayerEntityView,
		PlayerInputDataStruct, PlayerInfoDataStruct>
	{}
}
