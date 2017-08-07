

namespace ecs
{

	public class Entity
	{
		private int id;
		public int Id { get { return id; } }

		public EntityManager entityManager;


		public Entity(int id, EntityManager entityManager)
		{
			this.id = id;
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
			return entityManager.HasComponent(Id, typeof(T));
		}

	}

}