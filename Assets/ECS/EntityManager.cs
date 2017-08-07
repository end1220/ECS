
using System;
using System.Collections;


namespace ecs
{
	using ComponentArray = MutableArray<Component>;

	public class EntityManager
	{
		private MutableArray<Entity> entityArray = new MutableArray<Entity>();  // index is entity id

		private MutableArray<BitArray> entityComponentBitsArray = new MutableArray<BitArray>();

		private MutableArray<ComponentArray> entityComponentsArray = new MutableArray<ComponentArray>(); // index is entity id

		private MutableArray<ComponentArray> typeConponnetsArray = new MutableArray<ComponentArray>();   // index is component type index

		private int nextEntityId = 0;

		private EntitySystemManager systemManager;


		public EntityManager(EntitySystemManager mgr)
		{
			systemManager = mgr;
		}


		public Entity AddEntity()
		{
			Entity ent = new Entity(nextEntityId++, this);
			entityArray.Add(ent);
			BitArray bits = new BitArray(256, false);
			entityComponentBitsArray.Add(bits);
			return ent;
		}


		public void RemoveEntity(int entityId)
		{
			Entity ent = FindEntity(entityId);
			if (ent != null)
			{
				entityArray[ent.Id] = null;
				entityComponentBitsArray[ent.Id] = null;
				RemoveAllComponents(ent.Id);
			}
		}


		public Entity FindEntity(int id)
		{
			Entity ent = null;
			ent = entityArray[id];
			return ent;
		}


		public T AddComponent<T>(int entityId) where T :  Component, new()
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return null;

			T component = new T();
			AddComponent(entityId, component);
			return component;
		}


		public void AddComponent(int entityId, Component component)
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return;

			int comTypeId = ComponentTypeManager.GetTypeId(component.GetType());

			ComponentArray entComArray = entityComponentsArray[entityId];
			Component com = entComArray[comTypeId];
			if (com == null)
			{
				com = component;
				entComArray[comTypeId] = com;
				ComponentArray typeComArray = typeConponnetsArray[comTypeId];
				typeComArray.Add(com);

				BitArray bits = entityComponentBitsArray[entityId];
				bits[comTypeId] = true;

				systemManager.OnAddComponent(ent, com);
			}
		}


		public void RemoveComponent<T>(int entityId) where T : Component, new()
		{
			RemoveComponent(entityId, typeof(T));
		}


		public void RemoveComponent(int entityId, Type type)
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return;

			int comTypeId = ComponentTypeManager.GetTypeId(type);

			ComponentArray entComArray = entityComponentsArray[entityId];
			Component com = entComArray[comTypeId];
			if (com != null)
			{
				entComArray[comTypeId] = null;
				ComponentArray typeComArray = typeConponnetsArray[comTypeId];
				typeComArray.Remove(com);

				systemManager.OnRemoveComponent(ent, com);

				BitArray bits = entityComponentBitsArray[entityId];
				bits[comTypeId] = false;
			}
		}


		public void RemoveAllComponents(int entityId)
		{
			ComponentArray entComArray = entityComponentsArray[entityId];
			for (int i = 0; i < entComArray.GetCapacity(); ++i)
			{
				Component com = entComArray[i];
				if (com != null)
					RemoveComponent(entityId, com.GetType());
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

			ComponentArray entComArray = entityComponentsArray[entityId];
			Component com = entComArray[comTypeId];

			return com;
		}


		public bool HasComponent<T>(int entityId)
		{
			int comTypeId = ComponentTypeManager.GetTypeId(typeof(T));
			BitArray bits = entityComponentBitsArray[entityId];
			bool has = bits[comTypeId];
			return has;
		}


		public bool HasComponent(int entityId, Type type)
		{
			int comTypeId = ComponentTypeManager.GetTypeId(type);
			BitArray bits = entityComponentBitsArray[entityId];
			bool has = bits[comTypeId];
			return has;
		}


		public BitArray GetEntityComponentBitArray(int entityId)
		{
			return entityComponentBitsArray[entityId];
		}


		public int GetEntityCount()
		{
			return entityArray.Count;
		}

	}

}