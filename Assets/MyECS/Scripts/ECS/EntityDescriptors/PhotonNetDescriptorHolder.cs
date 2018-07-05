using System.Collections;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace ProjectR.ECS.Net
{
	public class PhotonNetEntityDescriptor : GenericEntityDescriptor<NetEntityView,NetworkDataStruct>
	{

	}
	[DisallowMultipleComponent]
	public class PhotonNetDescriptorHolder : GenericEntityDescriptorHolder<PhotonNetEntityDescriptor>
	{
		
	}
}