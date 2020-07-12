using Godot;
using System;

public class LevelHandler : Control
{
    public int curLevel = -1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionJustPressed("ui_cancel") ||
           (curLevel == -1 && Input.IsActionJustPressed("ui_select")))
            ChangeLevel(0);
    }

    public void ChangeLevel(int index)
    {
        curLevel = index;
        Globals.gameOver = false;
        switch(curLevel)
        {
            case -1:
                GetTree().ChangeScene("res://Levels/Title.tscn");
                break;
            case 0:
            case 6:
                GetTree().ChangeScene("res://Levels/Select.tscn");
                break;
            default:
                GetTree().ChangeScene("res://Levels/Level" + index.ToString() + ".tscn");
                break;
        }
    }
}
