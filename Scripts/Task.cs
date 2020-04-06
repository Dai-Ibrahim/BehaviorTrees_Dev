using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITask 
{
	 bool run();
}
public class  Selector : ITask
{
	List<ITask> children;
	public Selector(List<ITask> taskList)
    {
        children = taskList;
    }
	public bool run()
	{
		foreach (ITask c in children)
		{
			if(c.run())
			{
				return true;
			}
		}
		return false;

		
	}
	
}
public class  Sequence : ITask
{
	List<ITask> children;
	public Sequence(List<ITask> taskList)
    {
        children = taskList;
    }
	public bool run()
	{
		foreach (ITask c in children)
		{
			if(c.run()==false)
			{
				return false;
			}
		}
		return true;

		
	}
	
}

public class isHuman: ITask
{
	Creature creature;
	public isHuman(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("Checking For Human: " + creature.isHuman);
		return creature.isHuman;
	}
}
public class isNotHuman : ITask
{
	Creature creature;
	public isNotHuman(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("Checking For non-human: " + !creature.isHuman);
		return !creature.isHuman;
	}
}

public class isRobotDogPresent : ITask
{
	Creature creature;
	public isRobotDogPresent(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("Checking For Robot Dog: " + creature.isDogPresent);
		return creature.isDogPresent;
	}
}

public class shootAir: ITask
{
	Creature creature;
	public shootAir(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("Shooting Air");
		return creature.isHuman;
	}
}

public class shootHuman : ITask
{
	Creature creature;
	public shootHuman(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("Shooting Human");
		return creature.isDogPresent;
	}
}
public class shootCreature: ITask
{
	Creature creature;
	public shootCreature(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("Shooting at Creature");
		return !creature.isHuman;
	}
}
public class petDog: ITask
{
	Creature creature;
	public petDog(Creature refCreature)
	{
		creature = refCreature;
	}
	public bool run()
	{
		Debug.Log("petting Dog");
		return creature.isDogPresent;
	}
}

