using Godot;
using System;

public class Rafinery : Building
{
	/*
	....
	*/

	protected float oil;
	protected float fuel;
	private float capacity;
	public static float rate = 5.0f

	private Timer timer;

	public Rafinery() : base (100)
	{
		this.oil = 100;
		this.fuel = 0;
		this.capacity = 3000;
		
	}

	///...
	public void AddOil(float amount)
	{
		oil += amount;
		if (oil > capacity)
		{
			oil = capacity;
		}
	}


	public override void _EnterTree()
	{
		isPlaced = true;
		timer = GetNode<Timer>("Timer");
	}


	/* Equivalent a la fonction _Process
		delta => timer.WaitTime
	*/
	public void _on_Timer_timeout()
	{
		if (isPlaced && oil >= rate)
		{
			fuel += 1;
			oil-= 5;
		}
	}

	public void Remove_Fuel(float amount)
	{
		fuel -= amount;
		if (fuel < 0)
		{
			fuel = 0;
		}
	}
}
