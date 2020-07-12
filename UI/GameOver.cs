using Godot;
using System;

public class GameOver : Label
{
    private Timer timer;
    private LevelHandler levelHandler;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        timer = GetNode<Timer>("../Timer");
        levelHandler = GetNode<LevelHandler>("/root/LevelHandler");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Globals.gameOver)
        {
            if(timer.time >= 29.9999)
            {
                Text = "BABYSAT FOR 30 SECONDS\nPress Space to Advance to the Next Level";
                if(Input.IsActionJustPressed("ui_select"))
                {
                    levelHandler.ChangeLevel(levelHandler.curLevel + 1);
                }
            }
            Show();
            if(Input.IsActionJustPressed("ui_restart"))
            {
                Globals.gameOver = false;
                GetTree().ReloadCurrentScene();
            }
        }
    }
}
