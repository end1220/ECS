
using System;
using System.Collections.Generic;


namespace ecs
{

	public class SystemManager
	{
		private List<EntitySystem> systemList;


		public void Init(EntityManager entityManager, List<EntitySystem> systemList)
		{
			this.systemList = systemList;
			foreach (var sys in systemList)
			{
				sys.Init(entityManager);
			}
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