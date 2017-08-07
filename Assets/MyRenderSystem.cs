

using System;
using ecs;


public class MyRenderSystem : EntitySystem
{

	public MyRenderSystem(EntityManager entityManager, params Type[] types) :
		base(entityManager, types)
	{

	}


	public override void OnUpdate()
	{
		if (EntityArray.Count > 0)
			UnityEngine.Debug.Log("MyRenderSystem");
	}

}
