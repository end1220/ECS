
using System;
using System.Collections;


namespace ecs
{

	public abstract class EntitySystem
	{
		private BitArray componentBits = new BitArray(256, false);

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
			BitArray bits = entityManager.GetEntityComponentBitArray(entity.Id);
			if (bits == componentBits)
			{
				entityArray[entity.Id] = entity;
			}
		}


		public void OnRemoveComponent(Entity entity, Component component)
		{
			BitArray bits = entityManager.GetEntityComponentBitArray(entity.Id);
			if (bits == componentBits)
			{
				entityArray[entity.Id] = null;
			}
		}

	}

}