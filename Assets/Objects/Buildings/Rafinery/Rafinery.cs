using System;
using System.Threading;
using Godot;
using Timer = Godot.Timer;

public class Rafinery : Building
{
	/*
	....
	*/

	private float fuel;
	private float oil;
	private float capacity;
	private static float rate = 5.0f;


	private Timer timer;

	public Rafinery() : base (100)
	{
		this.oil = 0;
		this.fuel = 0;
		this.capacity = 3000;
	}

	
	public void AddOil(float amount, Liquid.Type type)
	{
		if (type == Liquid.Type.Oil)
		{
			oil += amount;
			if (oil > capacity)
			{
				oil = capacity;
			}
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
		float T = timer.WaitTime;
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

	// retire du fuel de la machine
	public void Remove_Fuel(float amount)
	{
		fuel -= amount;
		if (fuel < 0)
		{
			fuel = 0;
		}
	}
}
