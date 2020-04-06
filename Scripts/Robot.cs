using System.Collections.Generic;
using UnityEngine;

public class Robot : Kinematic
{
    public Arrive arrive;
    public Creature creature;

    void Start()
    {
        arrive = new Arrive();
        arrive.character = this;
        arrive.target = newTarget;

 
      
    }

    // Update is called once per frame
    public void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = arrive.getSteering().linear;
        base.Update();
		if (Input.GetKeyDown(KeyCode.Return))
        {
              ITask behavior = ConfigureBehavior();
			  behavior.run();
        }

    }

    public ITask ConfigureBehavior()
    {
		List<ITask> taskList = new List<ITask>();

		ITask Human = new isHuman(creature);
		ITask HumanAndDog = new isHuman(creature);
		ITask NotHuman = new isNotHuman(creature);
		ITask CheckIfDogIsPresent = new isRobotDogPresent(creature);
		ITask ShootAir = new shootAir(creature);
		ITask ShootHuman = new shootHuman(creature);
		ITask ShootCreature = new shootCreature(creature);
		ITask petDog = new petDog(creature);
		
		//not a human, shoot the creature
		taskList.Add(Human);
		taskList.Add(ShootAir);

		Sequence SpareTheHuman = new Sequence(taskList);
		taskList = new List<ITask>();

		taskList.Add(NotHuman);
		taskList.Add(ShootCreature);

		Sequence SaveTheHuman = new Sequence(taskList);
		taskList = new List<ITask>();
		
		taskList.Add(CheckIfDogIsPresent);
		taskList.Add(Human);
		taskList.Add(ShootHuman);
		taskList.Add(petDog);
		
		
		Sequence SaveTheDog = new Sequence(taskList);
		taskList = new List<ITask>();
		
		taskList.Add(SaveTheDog);
		taskList.Add(SpareTheHuman);
		taskList.Add(SaveTheHuman);
		

        Selector selector = new Selector(taskList);
        return selector;
      
    }
}