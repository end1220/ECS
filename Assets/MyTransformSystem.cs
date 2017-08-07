

using System;
using ecs;


public class MyTransformSystem : EntitySystem
{

	public MyTransformSystem(EntityManager entityManager, params Type[] types) :
		base(entityManager, types)
	{

	}


	public override void OnUpdate()
	{
		if (EntityArray.Count > 0)
			UnityEngine.Debug.Log("MyRenderSystem");
	}

}
