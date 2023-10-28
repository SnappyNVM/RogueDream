public interface IItemFunctional
{
    public bool IsMouseButtonPressed { get; set; }
    public void Work();
    public void Initialize(ItemFunctionalHandler itemFunctionalHandler);
}
