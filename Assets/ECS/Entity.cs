

namespace ecs
{

	public class Entity
	{
		public int Id;

		public EntityManager entityManager;


		public Entity(EntityManager entityManager)
		{
			this.entityManager = entityManager;
		}


		public T AddComponent<T>() where T : Component, new()
		{
			return entityManager.AddComponent<T>(Id);
		}


		public void RemoveComponent<T>() where T : Component, new()
		{
			entityManager.RemoveComponent<T>(Id);
		}


		public T GetComponent<T>() where T : Component, new()
		{
			return entityManager.GetComponent<T>(Id);
		}


		public bool HasComponent<T>()
		{
			return entityManager.GetComponent(Id, typeof(T)) != null;
		}

	}

}