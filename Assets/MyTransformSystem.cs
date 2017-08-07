

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
		UnityEngine.Debug.Log("MyRenderSystem");
	}

}
