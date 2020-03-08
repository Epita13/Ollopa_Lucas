using System;
using System.Threading;
using Godot;
using Timer = Godot.Timer;

public class Rafinery : Building
{
	/*
	....
	*/

	protected float oil;
	protected float fuel;
	private float capacity;
	public static float rate = 5.0f;

	private Timer timer;

	public Rafinery() : base (100)
	{
		this.oil = oil;
		this.fuel = fuel;
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
		var T = timer.WaitTime;
		if (isPlaced && oil >= rate)
		{
			fuel += 1 * T;
			oil -= 5 * T;
		}

		if (isPlaced && oil < rate)
		{
			fuel += oil / rate;
			oil = 0;
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
