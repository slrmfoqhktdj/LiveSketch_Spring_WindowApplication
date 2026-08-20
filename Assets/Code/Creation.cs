using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creation : MonoBehaviour
{
     public float speed = 3f;

    // public float turnspeed = 1f;

    // public float startcurve = 1f;
    // public float endcurve = 3f;
    // public float target_distance = 0.2f;


    // private float m_timerMax = 10f;
    // private float m_timerCurrent = 0;

    [Header("Unity Stuff")]
    private Transform target;
    private Transform startpoint;
    private int wavepointIndex = 0;
    private bool runstart = true;



    private Vector3 dir;

    private Transform[] points;

    // [Range(0,1)]
    // private float curveangle = 0.02f;

    public void MyWayPoints(int num)
    {
        startpoint = CreationPoints.creationpoints[num];
        GetWaypoints(startpoint);
        target = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(runstart){

            // if(m_timerCurrent>m_timerMax)
            // {
            //     return;
            // }

            // m_timerCurrent += Time.deltaTime * speed;

            dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime , Space.World);
            

            //베니어 곡선1
            // Vector3 c_point_01 = transform.position+(startcurve*transform.right);
            // Vector3 c_point_02 = target.position+(endcurve*target.right);
            // transform.position = new Vector3(
            //     CubicBezierCurve(transform.position.x,c_point_01.x,c_point_02.x,target.position.x),
            //     CubicBezierCurve(transform.position.y,c_point_01.y,c_point_02.y,target.position.y),
            //     CubicBezierCurve(transform.position.z,c_point_01.z,c_point_02.z,target.position.z)
            // );
            
            
            //목표까지 감속이동
            // transform.position = Vector3.Lerp(transform.position,target.position,curveangle);
            //목표까지 위로 호를 그리면서 감속이동
            // transform.position = Vector3.Slerp(transform.position,target.position,curveangle);
            // 목표를 향해 부드러운 회전
            // transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime);

            //베니어 곡선2
            // transform.position = GetBezierPosition(speed);

            transform.rotation = Quaternion.LookRotation(dir,dir);


   
        }

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        // if(Vector3.Distance(transform.position, target.position) <= target_distance)
        {           
            
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= points.Length -1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = points[wavepointIndex];

        // transform.Rotate(Vector3.up * Time.deltaTime * 2);
    }

    void EndPath()
    {
        Destroy(gameObject);
        //  Destroy(gameObject,5f); 5초후 사라지게
    }

    void GetWaypoints(Transform startpoint)
    {
        
        points = new Transform[startpoint.childCount];
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = startpoint.GetChild(i);
        }
        
    }

    /// <summary>
    /// 3차 베지어 곡선.
    /// </summary>
    /// <param name="a">시작 위치</param>
    /// <param name="b">시작 위치에서 얼마나 꺾일 지 정하는 위치</param>
    /// <param name="c">도착 위치에서 얼마나 꺾일 지 정하는 위치</param>
    /// <param name="d">도착 위치</param>
    /// <returns></returns>
    // private float CubicBezierCurve(float a, float b, float c, float d)
    // {
    //     // (0~1)의 값에 따라 베지어 곡선 값을 구하기 때문에, 비율에 따른 시간을 구했다.
    //     float t = m_timerCurrent / m_timerMax; // (현재 경과 시간 / 최대 시간)
    //     // float t = 0.01f; // (현재 경과 시간 / 최대 시간)


    //     // 방정식.
    //     /*
    //     return Mathf.Pow((1 - t), 3) * a
    //         + Mathf.Pow((1 - t), 2) * 3 * t * b
    //         + Mathf.Pow(t, 2) * 3 * (1 - t) * c
    //         + Mathf.Pow(t, 3) * d;
    //     */

    //     // 이해한대로 편하게 쓰면.
    //     float ab = Mathf.Lerp(a, b, t);
    //     float bc = Mathf.Lerp(b, c, t);
    //     float cd = Mathf.Lerp(c, d, t);

    //     float abbc = Mathf.Lerp(ab, bc, t);
    //     float bccd = Mathf.Lerp(bc, cd, t);

    //     return Mathf.Lerp(abbc, bccd, t);
    // }


    // Vector3 GetBezierPosition(float t)
    // {
    //     Vector3 p0 = transform.position;
    //     Vector3 p1 = p0+(transform.right*startcurve);
    //     Vector3 p3 = target.position;
    //     Vector3 p2 = p3-(-target.right*endcurve);
    
    // // here is where the magic happens!
    // return Mathf.Pow(1f-t,3f)*p0+3f*Mathf.Pow(1f-t,2f)*t*p1+3f*(1f-t)*Mathf.Pow(t,2f)*p2+Mathf.Pow(t,3f)*p3;
    // }
}
