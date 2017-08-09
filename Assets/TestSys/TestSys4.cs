

using System;
using ecs;


public class TestSys4 : EntitySystem
{

	public TestSys4(params Type[] types) :
		base(types)
	{

	}


	protected override void ProcessEntity(Entity entity)
	{
		var tran = entity.GetComponent<MyTransform>();
		tran.position += UnityEngine.Vector3.one;
		tran.scale = UnityEngine.Vector3.one * 0.5f;
	}

}
