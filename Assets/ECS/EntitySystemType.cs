
using System;
using System.Collections.Generic;


namespace ecs
{

	public static class EntitySystemTypeManager
	{
		class EntitySystemType
		{
			public int id;

			public Type type;

			public EntitySystemType(int id, Type type)
			{
				this.id = id;
				this.type = type;
			}
		}


		private static Dictionary<Type, EntitySystemType> systemTypeDic = new Dictionary<Type, EntitySystemType>();

		private static int nextTypeId = 0;


		public static int GetTypeId<T>() where T : EntitySystem
		{
			Type type = typeof(T);
			return GetTypeId(type);
		}

		public static int GetTypeId(Type type)
		{
			EntitySystemType sysType = null;
			if (!systemTypeDic.TryGetValue(type, out sysType))
			{
				sysType = new EntitySystemType(nextTypeId++, type);
				systemTypeDic.Add(type, sysType);
			}
			return sysType.id;
		}

	}

}