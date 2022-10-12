using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public List<Unit> units = new List<Unit>();

    public Goal goal { get; set; }
    public int teamId { get; set; }


    public void CreateTeam()
    {

        var gm = GameManager.instance;
        for (int i = 0; i < gm.teamSize; i++)
        {

            var g = Instantiate(gm.prefabs.unit, transform.position, Quaternion.identity);
            var u = g.GetComponent<Unit>();
            u.transform.position = Random.insideUnitCircle * gm.dimensions.y * 0.5f;
            u.team = this;

        }
    }
    private void Start()
    {
        CreateTeam();

    }



}
