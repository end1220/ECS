

using UnityEngine;
using ecs;


public class Example : MonoBehaviour
{
	ECSWorld world = new ECSWorld();


	void Start()
	{
		world.Init();

		// test
		for (int i = 0; i < 64; ++i)
		{
			var entity = world.entityManager.AddEntity();
			entity.AddComponent<MyTransform>();
			entity.AddComponent<MyRender>();

			var entity2 = world.entityManager.AddEntity();
			entity2.AddComponent<MyTransform>();
		}
	}


	void Update()
	{
		world.Update();
	}


	/// <summary>
	/// gui
	/// </summary>
	int index = 0;
	int sw = 10;
	int sh = 0;
	int height = 20;
	private void AppendLine(string txt)
	{
		GUI.Label(new Rect(sw, sh + height * (index++), 300, height), txt);
	}
	void OnGUI()
	{
		index = 0;
		GUI.color = Color.green;

		AppendLine("entity: " + world.entityManager.GetEntityCount());
		AppendLine("system: " + world.systemManager.GetSystemCount());

		int sysCount = world.systemManager.GetSystemCount();
		for (int i = 0; i < sysCount; ++i)
		{
			var sys = world.systemManager.GetSystemByIndex(i);
			AppendLine("  - " + sys.GetType() + ": " + sys.GetEntityCount());
		}
	}

}
