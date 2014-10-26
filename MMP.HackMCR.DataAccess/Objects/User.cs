namespace MMP.HackMCR.DataAccess.Objects
{
    public class User
    {
        public int UserId { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Token { set; get; }
        public string MobilePhone { set; get; }
        public string Email { set; get; }
        public Entries Entries { set; get; }
    }
}
