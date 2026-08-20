using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    public static Transform[] CreationSpawnPoints;

    public CreationModel[] creation;
    //  public GameObject O;

    public static Action<int,string> create;

    private bool c_t = false;
    private int number = 0;

    private string base64 = "";
   
    private int spawnNumberSize;
    private int spawnNumber = -1;

    private GameObject creature;

    // private int cnt = 2;

    private Creation butterfly_creation_function;

    private void Awake()
    {
        create = (i,j) => {
            number = i;
            base64 = j;
            c_t = true;
        };

    }

    void Start(){
        CreationSpawnPoints = CreationPoints.creationpoints;
        spawnNumberSize = CreationPoints.pointsSize;
    }

    void Update(){
        if(c_t){
            returnNumber();
            switch(number){
                case 0:
                    creature  = (GameObject)Instantiate(creation[0].creation,CreationSpawnPoints[spawnNumber].position,Quaternion.identity);
                    butterfly_creation_function = creature.GetComponent<Creation>();
                    butterfly_creation_function.MyWayPoints(spawnNumber);


                    try{
                        // base64 받아와서 byte 변환
                        byte[]  imageBytes = Convert.FromBase64String(base64);
                        // texture2d 생성
                        Texture2D tex = new Texture2D(1, 1);
                        tex.LoadImage( imageBytes );

                        //그 하위에 다른 오브젝트있을시 그 이전 오브젝트 삭제
                        // if(CreationSpawnPoints[spawnNumber].transform.childCount !=0)
                        // {
                        //     Destroy(CreationSpawnPoints[spawnNumber].transform.GetChild(0).gameObject);
                        // }


                        //포인트의 자식으로 들어가게 생성- true를 사용하면 자식 개체가 현재 월드 위치를 유지함. false를 사용하면 부모에 상대적인 위치가 지정됨
                        // creature.transform.SetParent(CreationSpawnPoints[spawnNumber].transform,false);

                        Material material1 = new Material(Shader.Find("Shader Graphs/CreationSurface"));
                        material1.SetTexture("_Texture2D",tex);
                        creature.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().material = material1;

                        
                        //이미지 파일 생성
                        // System.IO.File.WriteAllBytes("Assets/Imge/"+"img"+cnt+".png",imageBytes);
                        // cnt ++;

                    }catch(Exception ex){
                        Debug.Log(ex);
                    }

                    
                    c_t= false;
                break;
                case 1:
                    // creature  = (GameObject)Instantiate(creation[1].creation, StringrayspawnPoint[randomInt].position, StringrayspawnPoint[randomInt].rotation);
                    // stringray_creation_funtion = creature.GetComponent<Creation_Stringray>();
                    // stringray_creation_funtion.MyWayPoints(randomInt);
                    
                    c_t= false;
                break;
                case 2:
                    // creature  = (GameObject)Instantiate(creation[2].creation, SquidspawnPoint[randomInt].position, SquidspawnPoint[randomInt].rotation);
                    // squid_creation_funtion = creature.GetComponent<Creation_Squid>();
                    // squid_creation_funtion.MyWayPoints(randomInt);
                    
                    c_t= false;
                break;
                case 3:
                    // creature  = (GameObject)Instantiate(creation[3].creation, TunaspawnPoint[randomInt].position, TunaspawnPoint[randomInt].rotation);
                    // tuna_creation_funtion = creature.GetComponent<Creation_Tuna>();
                    // tuna_creation_funtion.MyWayPoints(randomInt);
                    
                    c_t= false;
                break;
                default:
                    Debug.Log("생성되지 않는 크리쳐");
                break;
            }
        }
    }

    public void returnNumber()
    {
        if(spawnNumber < 0 || spawnNumber < spawnNumberSize-1)
        {
            spawnNumber ++;
        }else
        {
            spawnNumber = 0;
        }

        Debug.Log(spawnNumber);
    }


}