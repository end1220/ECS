﻿

using System;
using ecs;


public class TestSys8 : EntitySystem
{

	public TestSys8(EntityManager entityManager, params Type[] types) :
		base(entityManager, types)
	{

	}


	public override void ProcessEntity(Entity entity)
	{
		var tran = entity.GetComponent<MyTransform>();
		tran.position += UnityEngine.Vector3.one;
		tran.scale = UnityEngine.Vector3.one * 0.5f;
	}

}