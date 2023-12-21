using Microsoft.EntityFrameworkCore;

using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using System.Security.Cryptography;
using System.Text;
using laptopMarket.Data;

namespace laptopMarket.Repository
{
    public class coponRep : Icopon
    {
        private readonly laptopMarketContext Context;
        public coponRep(laptopMarketContext co)
        {
            Context= co;    
        }
        public async Task<string> deletecopon(int id)
        {
           var get= await readcopon(id);
            if(get==null)
            {
                return "copon not found";
            }
            Context.Copons.Remove(get);
            Context.SaveChanges();
            return "copon is deleted";    
        }

        public async Task<Copon> readcopon(int id)
        {

           var get=await Context.Copons.FirstOrDefaultAsync(p=>p.Id==id);
            return get;
        }

        public async Task<bool> updatecopon(Copon copo)
        {
            var get = Context.Copons.Update(copo);
            Context.SaveChanges();
            return true;
        }

        public async Task<bool> writecopon(Copon copo)
        {
            await Context.Copons.AddAsync(copo);   
            Context.SaveChanges();
            return true;
        }
        public async Task<string>hashcode(string code)
        {
           
            byte[] couponBytes = Encoding.UTF8.GetBytes(code);
            byte[] hashBytes;

            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(couponBytes);
            }

            string hashedCouponCode = BitConverter.ToString(hashBytes).Replace("-", "");
            return hashedCouponCode;

        }

        public async Task<bool> Comparecode(string hashcode)
        {
            var res= await Context.Copons.FirstOrDefaultAsync(p=>p.Coponcode==hashcode);
            if(res==null) 
            {
                return false;
            }
            return true;
        }
        
        public async Task<bool> check_delete(string hashcode)
        {
           var res= await Context.Copons.FirstOrDefaultAsync(p => p.Coponcode == hashcode);
            if(res==null)
            {
                return false;
            }
            Context.Copons.Remove(res);
            Context.SaveChanges();
            return true;
        }

        public async Task<bool> check_Ifexpire(DateTime da)
        {
            DateTime Date = DateTime.Now;
            //(da.Year == Date.Year) && (da.Month == Date.Month) && (da.Day == Date.Day)
            if (da<Date)
            {
                return true;
            }
            return false;
            

        }

        public async Task<string> check_Ifvalid(string coponcode)
        {
            var getHashCode = await hashcode(coponcode);
            var getcopon = await Context.Copons.FirstOrDefaultAsync(p => p.Coponcode == getHashCode);
            if(getcopon==null)
            {
                return "copon not found";
            }
            var expire = await check_Ifexpire(getcopon.Expired);
            if(expire==true)
            {
                return "the copon is expire";
            }
            return "the copon is vaild";

        }
        public async Task<IEnumerable<Copon>> check_allusage()
        {
            var getusage = await Context.Copons.Where(x => x.UsageLimit!=0&&  x.UsageLimit == x.Usagecount).ToListAsync();
            return getusage;
        }
        public async Task<Copon> check_name(string coponname)
        {
            var res = await Context.Copons.FirstOrDefaultAsync(x => x.CoponName == coponname);
            return res;
        }

    }
}
