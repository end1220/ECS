
using System;
using System.Collections.Generic;


namespace ecs
{

	public static class ComponentTypeManager
	{
		class ComponentType
		{
			public int id;

			public Type type;

			public ComponentType(int id, Type type)
			{
				this.id = id;
				this.type = type;
			}
		}


		private static Dictionary<Type, ComponentType> componentTypeDic = new Dictionary<Type, ComponentType>();

		private static int nextTypeId = 0;


		public static int GetTypeId<T>() where T : Component
		{
			Type type = typeof(T);
			return GetTypeId(type);
		}

		public static int GetTypeId(Type type)
		{
			ComponentType comType = null;
			if (!componentTypeDic.TryGetValue(type, out comType))
			{
				comType = new ComponentType(nextTypeId++, type);
				componentTypeDic.Add(type, comType);
			}
			return comType.id;
		}

	}

}