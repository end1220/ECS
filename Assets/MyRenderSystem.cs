

using System;
using ecs;


public class MyRenderSystem : EntitySystem
{

	public MyRenderSystem(params Type[] types) :
		base(types)
	{

	}


	protected override void ProcessEntity(Entity entity)
	{
		var tran = entity.GetComponent<MyTransform>();
		var render = entity.GetComponent<MyRender>();
		Draw(render, tran);
	}


	private void Draw(MyRender render, MyTransform transform)
	{
		transform.position -= UnityEngine.Vector3.one;
	}

}
