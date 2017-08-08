
using System;
using System.Collections.Generic;


namespace ecs
{

	public static class SystemTypeManager
	{
		class SystemType
		{
			public int id;

			public Type type;

			public SystemType(int id, Type type)
			{
				this.id = id;
				this.type = type;
			}
		}


		private static Dictionary<Type, SystemType> systemTypeDic = new Dictionary<Type, SystemType>();

		private static int nextTypeId = 0;


		public static int GetTypeId<T>() where T : EntitySystem
		{
			Type type = typeof(T);
			return GetTypeId(type);
		}

		public static int GetTypeId(Type type)
		{
			SystemType sysType = null;
			if (!systemTypeDic.TryGetValue(type, out sysType))
			{
				sysType = new SystemType(nextTypeId++, type);
				systemTypeDic.Add(type, sysType);
			}
			return sysType.id;
		}

	}

}