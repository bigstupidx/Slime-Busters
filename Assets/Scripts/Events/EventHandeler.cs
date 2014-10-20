public class EventHandeler
{
    public delegate void HitSlime();
    public static event HitSlime OnHitSlime;

    public static void CallOnHitSlime()
    {
        if (OnHitSlime != null)
        {
            OnHitSlime();
        }
    }
}