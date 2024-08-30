using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PipeGenerator : SpawnerObjects<Pipe>
{
    public override void OnGet(Pipe pipe)
    {
        pipe.transform.position = GetRandomPosition();
        base.OnGet(pipe);
    }
}
