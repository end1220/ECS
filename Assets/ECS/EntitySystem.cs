
using System;


namespace ecs
{

	public abstract class EntitySystem
	{
		private BitSet componentBits = new BitSet();

		private MutableArray<Entity> entityArray = new MutableArray<Entity>();

		public MutableArray<Entity> EntityArray { get { return entityArray; } }

		private EntityManager entityManager;


		public EntitySystem(EntityManager entityManager, params Type[] types)
		{
			this.entityManager = entityManager;

			for (int i = 0; i < types.Length; ++i)
			{
				int comTypeId = ComponentTypeManager.GetTypeId(types[i]);
				componentBits[comTypeId] = true;
			}
		}


		public void Update()
		{
			for (int i = 0; i < entityArray.Count; ++i)
				ProcessEntity(entityArray[i]);
		}


		public abstract void ProcessEntity(Entity entity);


		public void OnAddComponent(Entity entity, Component component)
		{
			BitSet bits = entityManager.GetEntityComponentBitSet(entity.Id);
			if (bits.Contains(componentBits))
			{
				int sysTypeId = SystemTypeManager.GetTypeId(GetType());
				if (!entity.SystemBits[sysTypeId])
				{
					entity.SystemBits[sysTypeId] = true;
					entityArray.Add(entity);
				}
			}
		}


		public void OnRemoveComponent(Entity entity, Component component)
		{
			BitSet bits = entityManager.GetEntityComponentBitSet(entity.Id);
			if (bits.Contains(componentBits))
			{
				int comTypeId = ComponentTypeManager.GetTypeId(component.GetType());
				if (componentBits[comTypeId])
					entityArray.Remove(entity);
			}
		}


		public void OnRemoveEntity(Entity entity)
		{
			BitSet bits = entityManager.GetEntityComponentBitSet(entity.Id);
			if (bits.Contains(componentBits))
			{
				entityArray.Remove(entity);
			}
		}


		public int GetEntityCount()
		{
			return entityArray.Count;
		}

	}

}