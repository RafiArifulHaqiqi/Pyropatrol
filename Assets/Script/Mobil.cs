using UnityEngine;

public class Mobil : MonoBehaviour
{
    [Header("Wheel Colliders (Fisik)")]
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider rearLeft;
    public WheelCollider rearRight;

    [Header("Wheel Visuals (Model Ban)")]
    public Transform visualFL;
    public Transform visualFR;
    public Transform visualRL;
    public Transform visualRR;

    [Header("Pengaturan Mobil")]
    public float motorForce = 1500f;
    public float breakForce = 3000f;
    public float maxSteerAngle = 30f;

    private void FixedUpdate()
    {
        // 1. MENDAPATKAN INPUT (W,A,S,D atau Panah)
        float moveInput = Input.GetAxis("Vertical");   // Maju/Mundur
        float steerInput = Input.GetAxis("Horizontal"); // Belok Kiri/Kanan
        bool isBraking = Input.GetKey(KeyCode.Space);  // Rem (Spasi)

        // 2. MENJALANKAN MESIN
        // Kita beri tenaga ke semua roda (All Wheel Drive) agar lebih kuat
        frontLeft.motorTorque = moveInput * motorForce;
        frontRight.motorTorque = moveInput * motorForce;
        rearLeft.motorTorque = moveInput * motorForce;
        rearRight.motorTorque = moveInput * motorForce;

        // 3. BELOK (Hanya roda depan)
        float steerAngle = steerInput * maxSteerAngle;
        frontLeft.steerAngle = steerAngle;
        frontRight.steerAngle = steerAngle;

        // 4. PENGEREMAN
        ApplyBrakes(isBraking);

        // 5. UPDATE POSISI BAN VISUAL
        UpdateAllWheelVisuals();
    }

    private void ApplyBrakes(bool isBraking)
    {
        float currentBrakeForce = isBraking ? breakForce : 0f;
        frontLeft.brakeTorque = currentBrakeForce;
        frontRight.brakeTorque = currentBrakeForce;
        rearLeft.brakeTorque = currentBrakeForce;
        rearRight.brakeTorque = currentBrakeForce;
    }

    private void UpdateAllWheelVisuals()
    {
        UpdateSingleWheelVisual(frontLeft, visualFL);
        UpdateSingleWheelVisual(frontRight, visualFR);
        UpdateSingleWheelVisual(rearLeft, visualRL);
        UpdateSingleWheelVisual(rearRight, visualRR);
    }

    private void UpdateSingleWheelVisual(WheelCollider collider, Transform visual)
    {
        // PENGAMAN: Jika visual tidak diisi (None) di Inspector, kode ini akan dilewati agar TIDAK ERROR
        if (visual == null) return;

        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);

        visual.position = pos;
        visual.rotation = rot;
    }
}