using UnityEngine;

public class Butterface : Hittable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hit()
    {
        ScoreController.instance.AddPoints(5);
    }
}
