using Godot;
using System;

public class GameOver : Label
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
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
