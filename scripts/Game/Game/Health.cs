using UnityEngine;

public class Health : MonoBehaviour{
    public int Energy = 1;
    public int Shield = 1;

    private float _rangeDecreaseBar;

    // Use this for initialization
    void Start(){
        _rangeDecreaseBar = transform.localScale.x / Energy;
    }

    public void Hit(int damage, GameObject target){
        for (int i = 0; i < damage; i++){
            Refresh();
        }
        if (Energy == 0){
            DestroyObject(target);
            GameManager.Instantiate("Actors/Effects/Explosions/Explosion", target.transform, null);
        }
    }

    private void Refresh(){
        Energy--;
        var diff = transform.localScale.x - _rangeDecreaseBar;
        transform.localScale = new Vector3(diff, 1, 1);
    }
}