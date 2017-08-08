
using System.Collections.Generic;
using UnityEngine;
using ecs;


public class Example : MonoBehaviour
{
	World world = new World();


	void Start()
	{
		world.Init();

		TestInit();
	}


	void Update()
	{
		world.Update();

		TestUpdate();
	}


	private float lastTime;
	private int totalFrames = 0;
	private float fps;
	void LateUpdate()
	{
		++totalFrames;
		if (Time.realtimeSinceStartup > lastTime + 0.5f)
		{
			fps = totalFrames / (Time.realtimeSinceStartup - lastTime);
			totalFrames = 0;
			lastTime = Time.realtimeSinceStartup;
		}
	}

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

		AppendLine("fps: " + fps);
		AppendLine("entity: " + world.entityManager.GetEntityCount());
		AppendLine("entity: " + testEntityIds.Count);
		AppendLine("system: " + world.systemManager.GetSystemCount());

		int sysCount = world.systemManager.GetSystemCount();
		for (int i = 0; i < sysCount; ++i)
		{
			var sys = world.systemManager.GetSystemByIndex(i);
			AppendLine("  - " + sys.GetType() + ": " + sys.GetEntityCount());
		}

		if (GUI.Button(new Rect(sw, sh + height * (index++), 300, height), "rand add"))
			RandAdd();
		if (GUI.Button(new Rect(sw, sh + height * (index++), 300, height), "rand del"))
			RandDel();
	}


	private List<int> testEntityIds = new List<int>();
	private void TestInit()
	{
		for (int i = 0; i < 10000; ++i)
		{
			var entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<MyRender>();

			var entity2 = world.entityManager.AddEntity();
			entity2.AddComponent<MyTransform>();
			testEntityIds.Add(entity2.Id);
		}
	}

	bool add = false;
	private void TestUpdate()
	{
		if (add)
			RandAdd();
		else
			RandDel();
		add = !add;
	}

	private void RandAdd()
	{
		int count = Random.Range(10, 50);
		for (int i = 0; i < count; ++i)
		{
			if (i % 2 == 0)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<MyRender>();
			}
			else
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
			}
		}
	}

	private void RandDel()
	{
		if (testEntityIds.Count == 0)
			return;

		int count = Random.Range(10, 50);
		for (int i = 0; i < count; ++i)
		{
			int index = Random.Range(0, testEntityIds.Count-1);
			world.entityManager.RemoveEntity(testEntityIds[index]);
			testEntityIds.RemoveAt(index);
		}
	}

}
