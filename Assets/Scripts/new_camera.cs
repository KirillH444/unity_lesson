using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_camera : MonoBehaviour
{
   public LayerMask maskObsticle;
   public Transform target;
   public Vector3 offset;
   public float sensitivity = 2; // чувствительность мыши
   public float limit = 80; // ограничение вращения по оси Y
   public float zoom = 0.25f; // чувствительность при увеличении колесиком мыши
   public float zoomMax = 7; // макс. увеличение приближения камеры
   public float zoomMin = 3; // мин. увеличение приближения камеры
   private float X, Y;


    void Start() // функция, которая срабатывает при запуске скрипта единожды
    {
     limit = Mathf.Abs(limit); // 
     if (limit > 90) limit = 90; // ограничение на поворот камеры в 90 градусов
     offset = new Vector3(offset.x, offset.y, -Mathf.Abs(limit) / 1.5f); // перемещение камерф к игроку
     transform.position = target.position - offset; // перемещение камерф к игроку
     Cursor.visible = false; // блокировка курсора мыши
    }

    
    void Update() // функция, которая срабатывает раз в секунду
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom; // движение колеса мыши
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom; // движение колеса мыши
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin)); // движение колеса мыши

        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        Y += Input.GetAxis("Mouse Y") * sensitivity;
        Y = Mathf.Clamp(Y, -limit, limit);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset + target. position; // смана позиции камеры

        RaycastHit raycastHit;
        if (Physics.Raycast(target.position, transform.position - target.position, out raycastHit, Vector3.Distance(transform.position, target.position), maskObsticle)) // проверка на посторнонние объекты между обЪектом и камерой

        transform.position = raycastHit.point + new Vector3(0, 0.1f, 0);
        transform.LookAt(target);
    }
}
