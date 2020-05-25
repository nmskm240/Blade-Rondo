namespace BladeRondo.System
{
    using UnityEngine;

    public interface IFactory
    {
        GameObject Create(string id);
    }
}