
using System;
using System.Collections.Generic;


namespace ecs
{

	public class SystemManager
	{

		private List<EntitySystem> systemList;


		public void Init(EntityManager entityManager)
		{
			systemList = new List<EntitySystem>()
			{
				new MyTransformSystem(entityManager, typeof(MyTransform)),
				new MyRenderSystem(entityManager, typeof(MyTransform), typeof(MyRender)),

				new TestSys1(entityManager, typeof(MyTransform)),
				new TestSys2(entityManager, typeof(MyTransform)),
				new TestSys3(entityManager, typeof(MyTransform)),
				new TestSys4(entityManager, typeof(MyTransform)),
				new TestSys5(entityManager, typeof(MyTransform)),
				new TestSys6(entityManager, typeof(MyTransform)),
				new TestSys7(entityManager, typeof(MyTransform)),
				new TestSys8(entityManager, typeof(MyTransform)),
				new TestSys9(entityManager, typeof(MyTransform)),
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


		public void OnRemoveEntity(Entity entity)
		{
			foreach (EntitySystem sys in systemList)
			{
				sys.OnRemoveEntity(entity);
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