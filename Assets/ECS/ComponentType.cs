
using System;
using System.Collections.Generic;


namespace ecs
{

	public class ComponentType
	{
		public int index;

		public Type type;

		public ComponentType(int id, Type type)
		{
			this.index = id;
			this.type = type;
		}
	}


	public static class ComponentTypeManager
	{
		//private static List<ComponentType> componentTypes = new List<ComponentType>();

		private static Dictionary<Type, ComponentType> componentTypeDic = new Dictionary<Type, ComponentType>();

		private static int nextIndex = 0;


		public static int GetComponentIndex(Component component)
		{
			ComponentType comType = null;
			Type type = component.GetType();
			if (!componentTypeDic.TryGetValue(type, out comType))
			{
				comType = new ComponentType(nextIndex++, type);
				componentTypeDic.Add(type, comType);
			}
			return comType.index;
		}
	}

}