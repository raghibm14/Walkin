using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class AlgorithmMotor : MonoBehaviour
{
    //wayfindstuffs
    GameObject[] allv;
    private GameObject[] stairs;
    int pi,n;
    int krun, kinrun;
    public int[,] graph;
    List<Vector3> way;
    RaycastHit hit;
    //ui stuffs:
    CameraMotor cm;
    public Dropdown from;
    public Dropdown to;
    List<string> options;
    public Text runtext;
    public InputField newspeed;
    public Text startspeed;

    //temp variables
    Vector3 direction;
    Quaternion rtemp;
    int pos1;
    private void Start()
    {
        krun = kinrun = -1;
        cm = GameObject.Find("Navigation").GetComponent<CameraMotor>();
        Invoke("LateStart", 0.4f);
    }
    void LateStart()
    {
        allv = new GameObject[1000];
        way = new List<Vector3>();
        int i = 0,j=0;
        n = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PI"))
        {
            allv[n++] = go;
        }
        pi = n;
        foreach (GameObject goi in GameObject.FindGameObjectsWithTag("HI"))
        {
            allv[n++] = goi;
        }
     
            //allv= GameObject.FindGameObjectsWithTags(new string[] { "Tank1", "Tank2", "Tank3" });
           
        //Debug.Log("Points are interests are total: "+n);
        graph = new int[n,n];
        for (i = 0; i < n; i++)
        {
            for (j = i + 1; j < n; j++)
            {
              //  if (allv[i].gameObject.layer == allv[j].gameObject.layer)
               // {
                    if (Physics.Raycast(allv[i].transform.position, allv[j].transform.position - allv[i].transform.position, out hit))
                    {
                        if (hit.collider.gameObject.name == allv[j].name)
                        {
                            graph[i,j] =graph[j,i]=(int) hit.distance;
                        }
                        else
                        {
                            graph[i, j] = graph[j, i] = 100000;
                        }
                    }
                //}
                else
                {
                    graph[i, j] = graph[j, i] = 100000;

                }

            }
        }
      
        startspeed.text = cm.walkSpeed.ToString();
        from.ClearOptions();
        to.ClearOptions();
        options = new List<string>();
        for (i = 0; i < pi; i++)
        {
            options.Add(allv[i].name);
        }
        from.AddOptions(options);
        to.AddOptions(options);
        
        stairs = GameObject.FindGameObjectsWithTag("Stairs");
        for (i = 0; i < stairs.Length; i++)
        {
            stairs[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void changestartpos()
    {
        pos1 = from.value;
        transform.position = allv[pos1].transform.position;
        transform.rotation = allv[pos1].transform.rotation;
        
    }
    public void changespeed()
    {
        if(newspeed.text!="")
        {
            cm.walkSpeed = System.Convert.ToInt32(newspeed.text);
        }
    }
    void runDjikstra(int source, int dest)
    {
        pq a = new pq(source);
        rec temp;
        int[] dist=new int[n];
        string[] path = new string[n];
        for(int i=0;i<n;i++)
        {
            dist[i] = 100000;
            path[i] = "";
        }
        dist[source] = 0;
        while (!a.isEmpty())
        {
            temp = a.top();
            a.delete();
            for(int i=0;i<n;i++)
            {
                if(dist[i]>dist[temp.v]+graph[temp.v,i])
                {
                    dist[i] = dist[temp.v] + graph[temp.v, i];
                    path[i] = path[temp.v]+temp.v.ToString()+",";
                    a.insert(new rec(i, dist[temp.v]+graph[temp.v,i]));
                }
            }
        }
      //  for (int i = 0; i < n; i++)
      //  {
        //    Debug.Log("Shortest dist to " + allv[i].gameObject.name + " is: " + dist[i]+" and path is: "+path[i]);
      //  }
       // Debug.Log("source: " + source.ToString() + " , " + dest.ToString());
        if (dist[dest] < 100000)
        {
            string[] values = path[dest].Split(',');
            for (int i = 0; i < values.Length - 1; i++)
            {
                Debug.Log(allv[Int32.Parse(values[i])].gameObject.name);
                way.Add(allv[Int32.Parse(values[i])].transform.position);
            }
            way.Add(allv[dest].transform.position);
            kinrun = values.Length;
            krun = 0;
        }
        runtext.text = "Manual Camera Navigation is off. You're walking from " + allv[from.value].name + " to " + allv[to.value].name
            +". Total distance to be covered: "+(double)dist[to.value]/30+ " metres.";

    }
    public void findway()
    {
        pos1 = from.value;
        transform.position = allv[pos1].transform.position;
        way.Clear();
        runDjikstra(from.value, to.value);
       
    }
    void Update()
    {
       if(krun>=0 && krun<kinrun)
        {
            transform.position = Vector3.MoveTowards(transform.position, way[krun], 1);
            direction = way[krun] - transform.position;
            rtemp = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation,rtemp,Time.deltaTime);
           
            if (transform.position == way[krun])
            {
                krun++;
            }
           // runtext.text=runtext.text+". You are now passing by "
            cm.canwalk = false;
        }
       else if(krun==kinrun)
        {
            runtext.text = "Manual Camera Navigation is on.";
            cm.canwalk = true;
        }
       
       
    }
    public void GoToStart()
    {
        SceneManager.LoadScene("StartUI");
    }
}
