using Clean.Domain.BasketItems;
using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Baskets
{
    public class Basket : AggregateRoot<Basket,Guid>
    {
        private List<BasketItem> _basketItems = new();
        public Basket(Guid customerId) : base(Guid.NewGuid())
        {
            CustomerId = customerId;
        }

        private Basket() : base(Guid.Empty) { }

        public Guid CustomerId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public IReadOnlyCollection<BasketItem> BasketItems => _basketItems;


        public void AddBasketItem(BasketItem basketItem)
        {
            _basketItems.Add(basketItem);
            TotalAmount += TotalAmountCalculate(basketItem.ProductPrice, basketItem.ProductQuantity);
        }


        public void ClearBasketItems()
        {
            _basketItems?.Clear();
            TotalAmount = 0;
        }

        public void RemoveBasketItem(BasketItem basketItem)
        {
            _basketItems.Remove(basketItem);
            TotalAmount -= TotalAmountCalculate(basketItem.ProductPrice, basketItem.ProductQuantity);
        }

        public void ClearTotalAmount()
        {
            TotalAmount = 0;
        }

        public void UpdateBasketItemQuantity(decimal basketItemPrice,int quantity)
        {
            TotalAmount += TotalAmountCalculate(basketItemPrice, quantity);
        }

        private decimal TotalAmountCalculate(decimal price, int quantity) => price * quantity;

    }
}
