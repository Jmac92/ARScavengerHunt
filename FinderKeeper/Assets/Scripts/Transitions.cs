using Mapbox.Utils;
using UnityEngine;

public static class Transitions {
    public static string finalScore { get; set; }

    public static Vector2d[] locations { get; set; }

    public static Vector2d playerPosition { get; set; }

    public static Quaternion playerRotation { get; set; }

    public static bool rotationSetting { get; set; }

    public static bool cameraSetting { get; set; }

    public static bool isOverviewActive { get; set; }
}
