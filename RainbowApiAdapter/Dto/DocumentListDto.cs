namespace RainbowApiAdapter.Dto;

public class DocumentListDto
{
    public Exception exception { get; set; }
    public Datum[] data { get; set; }
    public Outparams outparams { get; set; }

    public class Exception
    {
        public int error { get; set; }
        public object error_msg { get; set; }
    }

    public class Outparams
    {
    }

    public class Datum
    {
        public int id_pos { get; set; }
        public int id_record { get; set; }
        public string nom_route { get; set; }
        public string nom_zak { get; set; }
        public int id_hd_route { get; set; }
        public string nom_nakl { get; set; }
    }

}