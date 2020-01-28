using Godot;
using System;

public class Rafinery : Building.cs
{

protected int oil;
protected int fuel;
protected int OilInMachine;
private int capacity;


public Rafinery ()
{
	this.oil = 0;
	this.fuel = 0;
	this.capacity = 5000;
	this.OilInMachine = 0;
}

public void AddOil (int oil)
{
	if (oil <= capacity)
	{
		if (oil + OilInMachine <= capacity)
		{
			OilInMachine += oil;
		}
		OilInMachine = capacity
		oil -= capacity;
	}
}


public override void _Process (float delta)
{
	if (OilInMachine >= 10)
	{
		fuel += 2;
		OilInMachine -= 10;
	}
}

public void IsPlaced()
{
	 return IsPlaced.Place(location);
}








    public override void _Ready()
    {

    }








}
