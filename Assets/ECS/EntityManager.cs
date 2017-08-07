
using System;
using System.Collections.Generic;


namespace ecs
{
	using ComponentArray = MutableArray<Component>;

	public class EntityManager
	{
		private MutableArray<Entity> entities = new MutableArray<Entity>();	// index is entity id

		private MutableArray<ComponentArray> entityComponents = new MutableArray<ComponentArray>(); // index is entity id

		private MutableArray<ComponentArray> typeConponnets = new MutableArray<ComponentArray>();   // index is component type index

		private List<EntitySystem> systems = new List<EntitySystem>();

		private int nextEntityId = 0;


		public Entity AddEntity()
		{
			Entity ent = new Entity(this);
			ent.Id = nextEntityId++;
			entities.Set(ent.Id, ent);
			return ent;
		}


		public void RemoveEntity(int entityId)
		{
			Entity ent = FindEntity(entityId);
			if (ent != null)
			{
				entities.RemoveAt(ent.Id);
				RemoveAllComponents(ent.Id);
			}
		}


		public Entity FindEntity(int id)
		{
			Entity ent = null;
			ent = entities.Get(id);
			return ent;
		}


		public T AddComponent<T>(int entityId) where T :  Component, new()
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return null;

			int comTypeId = ComponentTypeManager.GetTypeId<T>();

			ComponentArray entComArray = entityComponents.Get(entityId);
			Component com = entComArray.Get(comTypeId);
			if (com == null)
			{
				com = new T();
				entComArray.Set(comTypeId, com);
				ComponentArray typeComArray = typeConponnets.Get(comTypeId);
				typeComArray.Add(com);
			}

			return com as T;
		}


		public void RemoveComponent<T>(int entityId) where T : Component, new()
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return;

			int comTypeId = ComponentTypeManager.GetTypeId<T>();

			ComponentArray entComArray = entityComponents.Get(entityId);
			Component com = entComArray.Get(comTypeId);
			if (com != null)
			{
				entComArray.RemoveAt(comTypeId);
				ComponentArray typeComArray = typeConponnets.Get(comTypeId);
				typeComArray.Remove(com);
			}
		}


		public void RemoveAllComponents(int entityId)
		{
			ComponentArray entComArray = entityComponents.Get(entityId);
			for (int i = 0; i < entComArray.GetCapacity(); ++i)
			{
				Component com = entComArray.Get(i);
				if (com != null)
				{
					int comTypeId = ComponentTypeManager.GetTypeId(com.GetType());
					ComponentArray typeComArray = typeConponnets.Get(comTypeId);
					typeComArray.Remove(com);
				}
			}
		}


		public T GetComponent<T>(int entityId) where T : Component, new()
		{
			return GetComponent(entityId, typeof(T)) as T;
		}


		public Component GetComponent(int entityId, Type type)
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return null;

			int comTypeId = ComponentTypeManager.GetTypeId(type);

			ComponentArray entComArray = entityComponents.Get(entityId);
			Component com = entComArray.Get(comTypeId);

			return com;
		}


		public void Update()
		{
			foreach (var sys in systems)
			{
				sys.Update();
			}
		}


	}

}