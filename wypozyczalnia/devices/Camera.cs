namespace wypozyczalnia;

public class Camera : Device
{
    public float Zoom { get; set; }
    public bool IsDigital { get; set; }
    
    public Camera(string name, string manufacturer, float zoom, bool isDigital) : base(name, manufacturer)
    {
        Zoom = zoom;
        IsDigital = isDigital;
    }
}