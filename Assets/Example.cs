
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
			if (i > 5)
				break;
			var sys = world.systemManager.GetSystemByIndex(i);
			AppendLine("  - " + sys.GetType() + ": " + sys.GetEntityCount());
		}

		if (GUI.Button(new Rect(sw, sh + height * (index++), 300, height), "rand add"))
			RandAddEntity();
		if (GUI.Button(new Rect(sw, sh + height * (index++), 300, height), "rand del"))
			RandDelEntity();
	}


	private List<int> testEntityIds = new List<int>();
	private void TestInit()
	{
		for (int i = 0; i < 500; ++i)
		{
			var entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<MyRender>();

			var entity2 = world.entityManager.AddEntity();
			entity2.AddComponent<MyTransform>();
			testEntityIds.Add(entity2.Id);

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom1>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom2>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom3>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom4>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom5>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom6>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom7>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<TestCom8>();

			entity = world.entityManager.AddEntity();
			testEntityIds.Add(entity.Id);
			entity.AddComponent<MyTransform>();
			entity.AddComponent<MyRender>();
			AddAllCom(entity);
		}
	}

	bool add = false;
	private void TestUpdate()
	{
		if (add)
			RandAddEntity();
		else
			RandDelEntity();
		add = !add;
	}

	private void RandAddEntity()
	{
		int count = Random.Range(10, 50);
		for (int i = 0; i < count; ++i)
		{
			int m = i % 10;
			if (m == 0)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<MyRender>();
			}
			else if (m == 1)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom1>();
			}
			else if (m == 2)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom2>();
			}
			else if (m == 3)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom3>();
			}
			else if (m == 4)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom4>();
			}
			else if (m == 5)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom5>();
			}
			else if (m == 6)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom6>();
			}
			else if (m == 7)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom7>();
			}
			else if (m == 8)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom8>();
			}
			else if (m == 9)
			{
				var ent = world.entityManager.AddEntity();
				testEntityIds.Add(ent.Id);
				ent.AddComponent<MyTransform>();
				ent.AddComponent<TestCom9>();
				AddAllCom(ent);
			}
		}
	}

	private void RandDelEntity()
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


	private void RandDelComponent()
	{
		if (testEntityIds.Count == 0)
			return;

		int count = Random.Range(10, 50);
		for (int i = 0; i < count; ++i)
		{
			int index = Random.Range(0, testEntityIds.Count - 1);
			int entityId = testEntityIds[index];
			int m = i % 10;
			if (m == 0)
			{
				if (world.entityManager.HasComponent<TestCom1>(entityId))
					world.entityManager.RemoveComponent<TestCom1>(entityId);
			}
			else if (m == 0)
			{
				if (world.entityManager.HasComponent<TestCom2>(entityId))
					world.entityManager.RemoveComponent<TestCom2>(entityId);
			}
		}
	}


	private void AddAllCom(Entity entity)
	{
		entity.AddComponent<TestCom1>();
		entity.AddComponent<TestCom2>();
		entity.AddComponent<TestCom3>();
		entity.AddComponent<TestCom4>();
		entity.AddComponent<TestCom5>();
		entity.AddComponent<TestCom6>();
		entity.AddComponent<TestCom7>();
		entity.AddComponent<TestCom8>();
		entity.AddComponent<TestCom9>();
		entity.AddComponent<TestCom10>();
		entity.AddComponent<TestCom11>();
		entity.AddComponent<TestCom12>();
		entity.AddComponent<TestCom13>();
		entity.AddComponent<TestCom14>();
		entity.AddComponent<TestCom15>();
		entity.AddComponent<TestCom16>();
		entity.AddComponent<TestCom17>();
		entity.AddComponent<TestCom18>();
		entity.AddComponent<TestCom19>();
		entity.AddComponent<TestCom20>();
		entity.AddComponent<TestCom21>();
		entity.AddComponent<TestCom22>();
		entity.AddComponent<TestCom23>();
		entity.AddComponent<TestCom24>();
		entity.AddComponent<TestCom25>();
		entity.AddComponent<TestCom26>();
		entity.AddComponent<TestCom27>();
		entity.AddComponent<TestCom28>();
		entity.AddComponent<TestCom29>();
		entity.AddComponent<TestCom30>();
		entity.AddComponent<TestCom31>();
		entity.AddComponent<TestCom32>();
		entity.AddComponent<TestCom33>();
		entity.AddComponent<TestCom34>();
		entity.AddComponent<TestCom35>();
		entity.AddComponent<TestCom36>();
		entity.AddComponent<TestCom37>();
		entity.AddComponent<TestCom38>();
		entity.AddComponent<TestCom39>();
		entity.AddComponent<TestCom40>();
		entity.AddComponent<TestCom41>();
		entity.AddComponent<TestCom42>();
		entity.AddComponent<TestCom43>();
		entity.AddComponent<TestCom44>();
		entity.AddComponent<TestCom45>();
		entity.AddComponent<TestCom46>();
		entity.AddComponent<TestCom47>();
		entity.AddComponent<TestCom48>();
		entity.AddComponent<TestCom49>();
		entity.AddComponent<TestCom50>();
		entity.AddComponent<TestCom51>();
		entity.AddComponent<TestCom52>();
		entity.AddComponent<TestCom53>();
		entity.AddComponent<TestCom54>();
		entity.AddComponent<TestCom55>();
		entity.AddComponent<TestCom56>();
		entity.AddComponent<TestCom57>();
		entity.AddComponent<TestCom58>();
		entity.AddComponent<TestCom59>();
		entity.AddComponent<TestCom60>();
		entity.AddComponent<TestCom61>();
		entity.AddComponent<TestCom62>();
		entity.AddComponent<TestCom63>();
		entity.AddComponent<TestCom64>();
		entity.AddComponent<TestCom65>();

	}

}
