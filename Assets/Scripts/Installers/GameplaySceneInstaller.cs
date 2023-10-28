using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Inventory _inventory;

    public override void InstallBindings()
    {
        BindInput();
        BindPlayer();
        BindInventory();
    }

    private void BindInput()
    {
        //if (SystemInfo.deviceType == DeviceType.Desktop)
        Container.BindInterfacesAndSelfTo<DesktopInput>().FromNew().AsSingle().Lazy();
    }

    private void BindPlayer()
    {
        Container.Bind<InputHandler>().FromNew().AsSingle().Lazy();
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player).AsSingle();
    }


    private void BindInventory() =>
        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle().Lazy();
}
