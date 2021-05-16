using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public GameObject camera;

    [Range(1,10)]
    public int NumberOfObjectsMin;
    [Range(2, 20)]
    public int NumberOfObjectsMax;
    
    public GameObject[] StageElements;
    public GameObject[] RandomObjects;
    public Material RandMat;
    [Range(1,10)]
    public float SpawnAreaX = 3f;
    [Range(1, 10)]
    public float SpawnAreaY = 3f;

    private float Dist;

    private int NumOfObj;

    List<Vector2> newPosList = new List<Vector2>();
    List<GameObject> gameList = new List<GameObject>();

    void Start()
    {
        NumOfObj = Random.Range(NumberOfObjectsMin, NumberOfObjectsMax);
        gameList.Clear();
    }

    void Update()
    {
        DestroyAll();
        RandomizeStage();
        NewPositions();
        SpawnObjects(NumOfObj);
        camera.transform.localRotation = Quaternion.Euler(30, Random.Range(-30f,30f), 0);
    }

    void DestroyAll()
    {
        for (int i = 0; i < gameList.Count; i++)
        {
            Destroy(gameList[i]);
        }
        gameList.Clear();
        //foreach (Transform child in this.transform)
        //{
        //    Destroy(child.gameObject);
        //}
    }
    void NewPositions()
    {
        NumOfObj = Random.Range(NumberOfObjectsMin, NumberOfObjectsMax);
        Dist = Mathf.Sqrt((SpawnAreaX * SpawnAreaY) / NumOfObj);
        newPosList = PoissonDiscSampling.GeneratePoints(Dist, new Vector2(SpawnAreaX, SpawnAreaY));
    }

    void SpawnObjects(int n_obj)
    {
        DestroyAll();
        for (int i = 0; i < n_obj   ; i++)
        {
            Vector3 newPos = new Vector3(newPosList[i].x - SpawnAreaX/2, 0, newPosList[i].y - SpawnAreaY/2);
            GameObject newobj = Instantiate(RandomObjects[Random.Range(0, RandomObjects.Length)], newPos, Quaternion.Euler(0, 0, 0), this.transform);
            //newobj.GetComponent<Renderer>().material = RandMat;
            newobj.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.HSVToRGB(Random.Range(0f, 1f), 0.8f, 0.8f));
            newobj.transform.Translate(new Vector3(0, (newobj.transform.position.y - newobj.GetComponent<MeshFilter>().mesh.bounds.min.y), 0));
            Debug.Log("i");

            gameList.Add(newobj);
        }
    }
    void RandomizeStage()
    {
        for (int i = 0; i < StageElements.Length; i++)
        {
            StageElements[i].GetComponent<Renderer>().material.SetColor("_BaseColor", Color.HSVToRGB(Random.Range(0f, 1f), 0.8f, 0.8f));
        }
    }   
}
