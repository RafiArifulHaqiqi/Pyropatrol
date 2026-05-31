using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Tarik mobil Police ke sini
    public float distance = 6.0f;   // Jarak kamera dari mobil
    public float height = 3.0f;     // Ketinggian kamera
    public float rotationSpeed = 5f; // Kecepatan putar kamera (mouse)

    private float currentRotationAngle;
    private float currentHeight;
    private float mouseX;

    void LateUpdate()
    {
        if (!target) return;

        // 1. MENDAPATKAN INPUT MOUSE (Klik Kanan ditahan untuk putar view)
        // Jika ingin putar tanpa klik kanan, hapus bagian "Input.GetMouseButton(1)"
        if (Input.GetMouseButton(1)) 
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        }

        // 2. MENGHITUNG POSISI
        // Mengikuti rotasi mobil ditambah rotasi mouse
        float wantedRotationAngle = target.eulerAngles.y + mouseX;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Membuat gerakan kamera halus (Smooth)
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 3f * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, 3f * Time.deltaTime);

        // Mengubah rotasi menjadi posisi
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        Vector3 pos = target.position;
        pos -= currentRotation * Vector3.forward * distance;
        pos.y = currentHeight;

        // 3. TERAPKAN KE KAMERA
        transform.position = pos;
        transform.LookAt(target.position + Vector3.up * 1.5f); // Kamera selalu menghadap mobil
    }
}