using UnityEngine;

[System.Serializable] public class InputProvider {
    public enum Mode {
        Manual, AI
    }
    
    public enum Direction {
        Left, Rigth, None
    }
    
    AI ai = new AI();

    public Mode mode = Mode.Manual;
    public Direction GetHorizontalInput(Rigidbody2D rocket) {
        if (mode == Mode.Manual)
            return GetManualHorizontalInput();

        else if (rocket.velocity.y > 3) 
            return ai.WhereShouldIFly();
        else return ai.WhereShouldIFlyDown();
            
    }

    static Direction GetManualHorizontalInput() {
        if (Input.GetAxisRaw("Horizontal") > 0)
            return Direction.Rigth;
        if (Input.GetAxisRaw("Horizontal") < 0)
            return Direction.Left;
        return Direction.None;
    }
}