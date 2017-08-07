

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
		UnityEngine.Debug.Log("MyRenderSystem");
	}

}
