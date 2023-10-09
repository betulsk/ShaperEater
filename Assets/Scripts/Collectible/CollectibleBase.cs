
using UnityEngine;

public class CollectibleBase : MonoBehaviour
{
    [SerializeField] ECollectibleType _collectibleType;

	public ECollectibleType CollectibleType
	{
		get { return _collectibleType; }
		set { _collectibleType = value; }
	}

}
