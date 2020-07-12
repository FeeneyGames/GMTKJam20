using Godot;
using System;

public class Timer : Label
{
    float time = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(!Globals.gameOver)
            time += delta;
        Text ="Time: " + time.ToString("0.00");
    }
}
