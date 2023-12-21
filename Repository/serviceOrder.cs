using laptopMarket.Data;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;

namespace laptopMarket.Repository
{
    public class serviceOrder : IserviceOrder
    {
        private readonly laptopMarketContext Context;
        private readonly IcartTableRepo cartTableRepo;
        private readonly Iproduct product;
        private readonly IorderTable Ordertable;
        private readonly IwarehouseProRepo ware;
        public serviceOrder(laptopMarketContext context, IcartTableRepo cartTableRepo,  IorderTable ordertable, Iproduct product, IwarehouseProRepo ware)
        {
            Context = context;
            this.cartTableRepo = cartTableRepo;
            Ordertable = ordertable;
            this.product = product;
            this.ware = ware;
        }
        public async  Task<bool> OrderTransaction(string UserId)
        {
            var transaction= Context.Database.BeginTransaction();
           
            try
            {var cartobj=await cartTableRepo.getcart(UserId);
                List<OrderItem> orderItemslist = new List<OrderItem>();
               DateTime date= DateTime.Now;

                var totalamount = 0.0;
                if (cartobj!=null&&cartobj.Cart_item!=null)
                {
                    foreach (var cartitem in cartobj.Cart_item)
                    {
                        var pro=await product.getproduct(cartitem.ProductId);
                        if (pro!=null&&cartitem!=null)
                        {
                            OrderItem order = new OrderItem()
                            {
                                ProductId = cartitem.ProductId,
                                Quantity = cartitem.Quantity,
                                Added_at = date.ToString(),
                            };
                            
                             totalamount+=  (double)(pro.Price * cartitem.Quantity);
                            //await ware.decreaseQuantity(cartitem.Quantity, cartitem.ProductId);
                            orderItemslist.Add(order);

                        }
                       
                        
                    }
                }
                Order_table orderteble = new Order_table()
                {
                    Order_date = date.ToString(),
                    Status = "none",
                    Total_amount= totalamount,
                    AppUserID= UserId,
                    OrderItem=orderItemslist

                };

                transaction.Commit();

                return true;
               

            }
            catch 
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
