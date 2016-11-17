namespace IVIEW
{
    public interface ISinhVien:IShare
    {
        int ID { get; set; }
        string Ten { get; set; }

        int IDKhoa { get; set; }

    }
}