using System.Runtime.InteropServices;

public static class WebGLPluginJS
{
    [DllImport("__Internal")]
    public static extern void SendPointsToPage(int number);

    [DllImport("__Internal")]
    public static extern void SendTimeToPage(int time);

    [DllImport("__Internal")]
    public static extern void SendCoinsNumberToPage(int coins);

    [DllImport("__Internal")]
    public static extern void SendLevelToPage(int level);
}