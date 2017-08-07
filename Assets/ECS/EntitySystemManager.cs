
using System;
using System.Collections.Generic;


namespace ecs
{

	public class EntitySystemManager
	{

		private List<EntitySystem> systemList;


		public void Init(EntityManager entityManager)
		{
			systemList = new List<EntitySystem>()
			{
				new MyTransformSystem(entityManager, typeof(MyTransform)),
				new MyRenderSystem(entityManager, typeof(MyTransform), typeof(MyRender)),
			};
		}


		public void Update()
		{
			foreach (EntitySystem sys in systemList)
			{
				sys.Update();
			}
		}


		public void OnAddComponent(Entity entity, Component component)
		{
			foreach (EntitySystem sys in systemList)
			{
				sys.OnAddComponent(entity, component);
			}
		}


		public void OnRemoveComponent(Entity entity, Component component)
		{
			foreach (EntitySystem sys in systemList)
			{
				sys.OnRemoveComponent(entity, component);
			}
		}

		public int GetSystemCount()
		{
			return systemList.Count;
		}

		public EntitySystem GetSystemByIndex(int index)
		{
			return systemList[index];
		}

	}

}