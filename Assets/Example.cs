

using UnityEngine;
using ecs;


public class Example : MonoBehaviour
{
	ECSWorld world = new ECSWorld();

	void Start()
	{
		world.Init();

		// test
		var entity = world.entityManager.AddEntity();
		entity.AddComponent<MyTransform>();
		entity.AddComponent<MyRender>();

		var entity2 = world.entityManager.AddEntity();
		entity2.AddComponent<MyTransform>();
	}


	void Update()
	{
		world.Update();
	}


	/// <summary>
	/// gui
	/// </summary>
	int index = 0;
	int sw = 30;
	int sh = 30;
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
	}

}
