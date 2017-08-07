

namespace ecs
{

	public class ECSWorld
	{
		public EntityManager entityManager { get; private set; }

		public EntitySystemManager systemManager { get; private set; }


		public void Init()
		{
			systemManager = new EntitySystemManager();
			entityManager = new EntityManager(systemManager);
			systemManager.Init(entityManager);
		}


		public void Update()
		{
			systemManager.Update();
		}


		public void Destroy()
		{

		}


	}

}