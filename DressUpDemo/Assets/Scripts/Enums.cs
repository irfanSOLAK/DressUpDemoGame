using UnityEngine;

public enum Button_Type
{
    [InspectorName("Cloth Button")]
    CLOTH_BUTTON,

    [InspectorName("Tab Button")]
    TAB_BUTTON,
}

public enum Cloth_Type
{
    [InspectorName("Unknown Cloth")]
    UNKNOWN,

    [InspectorName("Top Cloth")]
    TOP,

    [InspectorName("Bottom Cloth")]
    BOTTOM,

    [InspectorName("FullBody Cloth")]
    FULLBODY,
}

public enum Game_Events
{
    EquipClothEvent,
};