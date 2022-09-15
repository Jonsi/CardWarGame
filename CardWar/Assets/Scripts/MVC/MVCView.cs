using UnityEngine;

public class MVCView<TModel> : MonoBehaviour, IView<TModel>
{
    protected TModel Data;

    public virtual void Set(TModel data)
    {
        Data = data;
    }
}
