using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [System.Serializable]
    public class Prefabs
    {
        public GameObject unit;
        public GameObject ball;
        public GameObject goal;
    }

    public Color[] teamColors = new Color[] { Color.blue, Color.red };
    public int teamSize = 8;
    public Vector2 goalOffset = new Vector2(-.5f, 0);
    public Vector2 dimensions = new Vector2(60, 30);

    public Prefabs prefabs = new Prefabs();
    public static GameManager instance;



    public List<Team> teams { get; set; } = new List<Team>();
    public Ball ball { get; set; }


    private void Reset()
    {
        name = "GameManager";
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            var t = new GameObject("Team " + (i + 1)).AddComponent<Team>();
            var g = Instantiate(prefabs.goal).GetComponent<Goal>();

            t.transform.position = new Vector2(dimensions.x * 0.25f, 0);
            g.transform.position = new Vector2(dimensions.x * 0.5f, 0) + goalOffset;
            if (i == 1)
            {
                g.transform.position = -g.transform.position;
                t.transform.position = -t.transform.position;
                var glocalscale = g.transform.localScale;
                glocalscale.x = -glocalscale.x;
                g.transform.localScale = glocalscale;
            }

            this.teams.Add(t);
            t.teamId = i;
            t.goal = g;
        }
        var b = Instantiate(prefabs.ball, Vector3.zero, Quaternion.identity).GetComponent<Ball>();
        this.ball = b;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(Vector3.zero, this.dimensions);
    }
}
