
using System;
using System.Collections;


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
			OnUpdate();
		}


		public abstract void OnUpdate();


		public void OnAddComponent(Entity entity, Component component)
		{
			BitSet bits = entityManager.GetEntityComponentBitSet(entity.Id);
			if (bits.Contains(componentBits))
			{
				entityArray[entity.Id] = entity;
			}
		}


		public void OnRemoveComponent(Entity entity, Component component)
		{
			BitSet bits = entityManager.GetEntityComponentBitSet(entity.Id);
			if (bits.Contains(componentBits))
			{
				entityArray[entity.Id] = null;
			}
		}

	}

}