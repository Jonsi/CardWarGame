using System.Collections;
using UnityEngine;

public class MVCController<TView,TModel> : MonoBehaviour,IController<TModel>
    where TView : IView<TModel>
{
    [SerializeField] protected TView View;
    protected TModel Data;

    public virtual void Set(TModel data)
    {
        Data = data;
        View.Set(data);
    }
}