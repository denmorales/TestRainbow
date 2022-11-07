namespace RainbowApiAdapter.Dto;

public class DocumentDto
{

    public Exception exception { get; set; }
    public Data data { get; set; }
    public Outparams outparams { get; set; }

    public class Exception
    {
        public int error { get; set; }
        public object error_msg { get; set; }
    }

    public class Data
    {
        public Data1[] data1 { get; set; }
        public Data2[] data2 { get; set; }
    }

    public class Data1
    {
        public int id_inst { get; set; }
        public int actual { get; set; }
        public string doc_type { get; set; }
        public string nom_doc { get; set; }
        public string nom_doc_main { get; set; }
        public string dat_doc { get; set; }
        public string dat_delivery { get; set; }
        public int id_sost { get; set; }
        public int id_post { get; set; }
        public string name_post { get; set; }
        public string shop_name { get; set; }
        public int good_count { get; set; }
        public int place_count { get; set; }
        public int id_hd_nakl { get; set; }
        public string nom_route { get; set; }
        public object is_certificate { get; set; }
        public int is_parcel { get; set; }
        public int is_single_contour { get; set; }
        public int es_delivery_scheme { get; set; }
        public object nom_zak_ext { get; set; }
        public object nom_zak_parcel { get; set; }
        public int can_return_place { get; set; }
        public int id_zakaz { get; set; }
        public DateTime dat_zakaz { get; set; }
    }

    public class Data2
    {
        public int id_inst { get; set; }
        public int id_pos { get; set; }
        public string pos_type { get; set; }
        public string pos_value { get; set; }
        public string pos_name { get; set; }
        public string pos_group_id { get; set; }
        public string pos_group_name { get; set; }
        public string pos_category_id { get; set; }
        public string pos_category_name { get; set; }
        public float good_qty { get; set; }
        public int pos_number { get; set; }
        public int id_good_nakl { get; set; }
        public object place_qty { get; set; }
        public object type_place { get; set; }
        public object is_hole { get; set; }
        public object is_certificate { get; set; }
        public int top_500 { get; set; }
        public int id_hd_nakl { get; set; }
    }

    public class Outparams
    {
    }

}