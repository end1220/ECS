
using System;
using System.Collections.Generic;


namespace ecs
{
	using ComponentList = List<Component>;

	public class EntityManager
	{
		private Dictionary<int, Entity> entities = new Dictionary<int, Entity>();

		private Dictionary<int, ComponentList> entityComponents = new Dictionary<int, ComponentList>();

		private Dictionary<Type, ComponentList> typeConponnets = new Dictionary<Type, ComponentList>();

		private List<EntitySystem> systems = new List<EntitySystem>();

		private int nextEntityId = 0;


		public Entity AddEntity()
		{
			Entity ent = new Entity();
			ent.Id = nextEntityId++;
			entities.Add(ent.Id, ent);
			return ent;
		}


		public Entity FindEntity(int id)
		{
			Entity ent = null;
			entities.TryGetValue(id, out ent);
			return ent;
		}


		public T AddComponent<T>(int entityId) where T :  Component, new()
		{
			Entity ent = FindEntity(entityId);
			if (ent == null)
				return null;

			T com = new T();

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