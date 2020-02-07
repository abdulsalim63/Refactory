using System;

namespace Day5Class
{
    public interface ICart
    {
        ICart addItem(int item_id, int price, int quantity = 1);
        ICart removeItem(int item_id);
        ICart addDiscount(string disc);
    }
}
