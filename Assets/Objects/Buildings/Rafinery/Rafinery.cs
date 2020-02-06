using Godot;
using System;

public class Rafinery : Building
{
	/*
	....
	*/

	protected int oil;
	protected int fuel;
	private int capacity;

	private Timer timer;

	public Rafinery() : base (100)
	{
		this.oil = 0;
		this.fuel = 0;
		this.capacity = 3000;
		
	}

	///...
	public void AddOil(int amount)
	{
		oil += amount;
		if (oil > capacity)
		{
			oil = capacity;
		}
	}


	public override void _EnterTree()
	{
		timer = GetNode<Timer>("Timer");
	}


	/* Equivalent a la fonction _Process
		delta => timer.WaitTime
	*/
	public void _on_Timer_timeout()
	{
		if (isPlaced && oil >= 10)
		{
			fuel += 2;
			oil-= 10;
		}
	}

	public void Remove_Fuel(int amount)
	{
		fuel -= amount;
		if (fuel < 0)
		{
			fuel = 0;
		}
	}
}
