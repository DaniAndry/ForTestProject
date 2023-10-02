using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pistol : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _maxBullets = 12;
    [SerializeField] private TextMeshProUGUI bulletText;

    private int _currentBullets;
    private DataManager _dataManager;

    private void Start()
    {
        _currentBullets = _maxBullets;

        UpdateBulletText();
    }

    public override void Attack()
    {
        if (_currentBullets > 0)
        {
            Bullet newBullet = BulletPool.Instance.GetBullet();
            newBullet.transform.position = _shootPoint.position;
            newBullet.transform.rotation = _shootPoint.rotation;
            newBullet.Launch();
            _currentBullets--;
            UpdateBulletText();
        }
        else
        {
            Debug.Log("No cartridges!!!");
        }
    }

    private void UpdateBulletText()
    {
        bulletText.text = $"{_currentBullets}/{_maxBullets}";
    }

    public void Reload()
    {
        _currentBullets = _maxBullets;
        UpdateBulletText();
    }
}