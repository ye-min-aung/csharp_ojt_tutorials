namespace CustomerEntity
{
    public class Customer
    {
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string nrc_number { get; set; }
        public string dob { get; set; }
        public string member_card { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string phone_no_1 { get; set; }
        public string phone_no_2 { get; set; }
        public string photo { get; set; }
        public string address { get; set; }
        public string created_user_id { get; set; }
        public string created_datetime { get; set; }
        public string updated_user_id { get; set; }
        public string updated_datetime { get; set; }
        public string is_deleted { get; set; }
        public string deleted_user_id { get; set; }
        public string deleted_datetime { get; set; }
        public string password { get; set; }
    }
}
