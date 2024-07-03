using System.Collections.Generic;

namespace ProjectForCurs.Model;

internal class User
{ 
    public int Id { set; get; }
    public Profile Profile { set; get; } = new();
    public int? SubscribeId { set; get; }
    public Subscribe? Subscribe { set; get; }
    public List<PaymentMethod> PaymentMethods { set; get; } = new();
    public List<History> Histories { set; get; } = new();
}
