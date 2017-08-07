
using System;
using System.Collections.Generic;


namespace ecs
{

	public abstract class EntitySystem
	{
		private EntityManager entityManager;

		private Type[] componentTypes;

		private Dictionary<int, Entity> entities = new Dictionary<int, Entity>();


		public EntitySystem(Type[] types)
		{
			componentTypes = types;
		}


		public void Update()
		{

		}

	}

}