using Godot;
using System;

public class GameOver : Label
{
    private Timer timer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        timer = GetNode<Timer>("../Timer");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(timer.time >= 29.9999)
            Text = "BABYSAT FOR 30 SECONDS\nPress Space to Advance to the Next Level";
        if(Globals.gameOver)
        {
            Show();
            if(Input.IsActionJustPressed("ui_restart"))
            {
                Globals.gameOver = false;
                GetTree().ReloadCurrentScene();
            }
        }
    }
}
