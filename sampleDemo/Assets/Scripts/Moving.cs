
using HarmonyLib;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Moving : UdonSharpBehaviour
{
    [SerializeField] private Transform toBeMoved;
    private int indexPos = 0;
    private int tLen = 0;
    private Transform parentObj;
    private Transform[] childTransforms;
    void Start()
    {
        tLen = GetComponent<Transform>().childCount;
        parentObj = GetComponent<Transform>();
        childTransforms = new Transform[tLen];

        for (int i = 0; i < tLen; i++)
        {
            childTransforms[i]=parentObj.GetChild(i);
        }
    }
    // Update is called once per frame  
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space)) && (indexPos < tLen))
        {
            toBeMoved.transform.position = parentObj.GetChild(indexPos).transform.position;
            Debug.Log(toBeMoved.transform.position);
            indexPos += 1;
        }
    }
}
