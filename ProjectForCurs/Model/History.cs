namespace ProjectForCurs.Model;

internal class History
{
    public int Id { set; get; }
    public int MovieId { set; get; }
    public Movie? Movie { set; get; }
    public int UserId { set; get; }
    public User? User { set; get; }
}