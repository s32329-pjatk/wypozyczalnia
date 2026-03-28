namespace wypozyczalnia;

public class Projector : Device
{
    public int Power { get; set; }
    public float RecommendedDistance { get; set; }
    
    public Projector(string name, string manufacturer, int power, float recommendedDistance) : base(name, manufacturer)
    {
        Power = power;
        this.RecommendedDistance = recommendedDistance;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Power: {Power}, distance: {RecommendedDistance} m";
    }
}
