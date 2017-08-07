

using UnityEngine;
using ecs;


public class Example : MonoBehaviour
{
	ECSWorld world = new ECSWorld();

	void Start()
	{

	}


	void Update()
	{
		world.Update();
	}

}
