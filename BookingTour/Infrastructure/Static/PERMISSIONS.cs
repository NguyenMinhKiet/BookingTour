
//namespace Infrastructure.Static
//{
//    public static class PERMISSIONS
//    {
//        public static string USER_GROUP_VIEW = "user-group-view";
//        public static string USER_GROUP_ADD = "user-group-add";
//        public static string USER_GROUP_UPDATE = "user-group-update";
//        public static string USER_GROUP_DELETE = "user-group-delete";

//        public static string USER_VIEW = "user-view";
//        public static string USER_ADD = "user-add";
//        public static string USER_UPDATE = "user-update";
//        public static string USER_DELETE = "user-delete";

//        public static string CUSTOMER_VIEW = "customer-view";
//        public static string CUSTOMER_ADD = "customer-add";
//        public static string CUSTOMER_UPDATE = "customer-update";
//        public static string CUSTOMER_DELETE = "customer-delete";

//        public static string EMPLOYEE_VIEW = "employee-view";
//        public static string EMPLOYEE_ADD = "employee-add";
//        public static string EMPLOYEE_UPDATE = "employee-update";
//        public static string EMPLOYEE_DELETE = "employee-delete";

//        public static string DESTINATION_VIEW = "destination-view";
//        public static string DESTINATION_ADD = "destination-add";
//        public static string DESTINATION_UPDATE = "destination-update";
//        public static string DESTINATION_DELETE = "destination-delete";

//        public static string TOUR_VIEW = "tour-view";
//        public static string TOUR_ADD = "tour-add";
//        public static string TOUR_UPDATE = "tour-update";
//        public static string TOUR_DELETE = "tour-delete";

//        public static string TOUR_DESTINATION_VIEW = "tour-destination-view";
//        public static string TOUR_DESTINATION_ADD = "tour-destination-add";
//        public static string TOUR_DESTINATION_UPDATE = "tour-destination-update";
//        public static string TOUR_DESTINATION_DELETE = "tour-destination-delete";

//        public static string TOUR_EMPLOYEE_VIEW = "tour-employee-view";
//        public static string TOUR_EMPLOYEE_ADD = "tour-employee-add";
//        public static string TOUR_EMPLOYEE_UPDATE = "tour-employee-update";
//        public static string TOUR_EMPLOYEE_DELETE = "tour-employee-delete";

//        public static string BOOKING_VIEW = "booking-view";
//        public static string BOOKING_ADD = "booking-add";
//        public static string BOOKING_UPDATE = "booking-update";
//        public static string BOOKING_DELETE = "booking-delete";

//        public static string PAYMENT_VIEW = "payment-view";
//        public static string PAYMENT_ADD = "payment-add";
//        public static string PAYMENT_UPDATE = "payment-update";
//        public static string PAYMENT_DELETE = "payment-delete";

//        public static string FEEDBACK_VIEW = "feedback-view";
//        public static string FEEDBACK_ADD = "feedback-add";
//        public static string FEEDBACK_UPDATE = "feedback-update";
//        public static string FEEDBACK_DELETE = "feedback-delete";


//        public static Dictionary<string, string> GetAllPermisstions()
//        {
//            Dictionary<string, string> list = new Dictionary<string, string>();

//            // NHÓM USER-GROUP
//            list.Add("group-1", "NHÓM TÀI KHOẢN");
//            list.Add(USER_GROUP_VIEW, "Có thể xem danh sách nhóm tài khoản");
//            list.Add(USER_GROUP_ADD, "Có thể tạo nhóm tài khoản mới");
//            list.Add(USER_GROUP_UPDATE, "Có thể cập nhật thông tin nhóm tài khoản");
//            list.Add(USER_GROUP_DELETE, "Có thể xóa nhóm tài khoản trống");

//            // NHÓM USER
//            list.Add("group-2", "TÀI KHOẢN");
//            list.Add(USER_VIEW, "Có thể xem danh sách tài khoản");
//            list.Add(USER_ADD, "Có thể tạo tài khoản mới");
//            list.Add(USER_UPDATE, "Có thể cập nhật thông tin tài khoản");
//            list.Add(USER_DELETE, "Có thể xóa tài khoản trống");

//            // NHÓM EMPLOYEE
//            list.Add("group-3", "NHÂN VIÊN");
//            list.Add(EMPLOYEE_ADD, "Có thể xem danh sách nhân viên");
//            list.Add(EMPLOYEE_ADD, "Có thể thêm nhân viên mới");
//            list.Add(EMPLOYEE_UPDATE, "Có thể cập nhật thông tin nhân viên");
//            list.Add(EMPLOYEE_DELETE, "Có thể xóa nhân viên trống");

//            // NHÓM CUSTOMER
//            list.Add("group-4", "KHÁCH HÀNG");
//            list.Add(CUSTOMER_ADD, "Có thể xem danh sách khách hàng");
//            list.Add(CUSTOMER_ADD, "Có thể thêm khách hàng mới");
//            list.Add(CUSTOMER_UPDATE, "Có thể cập nhật thông tin khách hàng");
//            list.Add(CUSTOMER_DELETE, "Có thể xóa khách hàng trống");

//            // NHÓM DESTINATION
//            list.Add("group-5", "ĐỊA ĐIỂM");
//            list.Add(DESTINATION_VIEW, "Có thể xem danh sách địa điểm");
//            list.Add(DESTINATION_ADD, "Có thể thêm địa điểm mới");
//            list.Add(DESTINATION_UPDATE, "Có thể cập nhật thông tin địa điểm");
//            list.Add(DESTINATION_DELETE, "Có thể xóa địa điểm trống");

//            // NHÓM TOUR
//            list.Add("group-6", "TOUR");
//            list.Add(TOUR_VIEW, "Có thể xem danh sách tour");
//            list.Add(TOUR_ADD, "Có thể tạo tour mới");
//            list.Add(TOUR_UPDATE, "Có thể cập nhật thông tin tour");
//            list.Add(TOUR_DELETE, "Có thể xóa tour trống");

//            // NHÓM TOUR DESTINATION
//            list.Add("group-7", "ĐỊA ĐIỂM TOUR");
//            list.Add(TOUR_DESTINATION_VIEW, "Có thể xem danh sách địa điểm tour");
//            list.Add(TOUR_DESTINATION_ADD, "Có thể thêm địa điểm tour mới");
//            list.Add(TOUR_DESTINATION_UPDATE, "Có thể cập nhật thông tin địa điểm tour");
//            list.Add(TOUR_DESTINATION_DELETE, "Có thể xóa địa điểm khỏi tour");

//            // NHÓM TOUR EMPLOYEE
//            list.Add("group-8", "NHÂN VIÊN TOUR");
//            list.Add(TOUR_EMPLOYEE_VIEW, "Có thể xem danh sách nhân viên tour");
//            list.Add(TOUR_EMPLOYEE_ADD, "Có thể thêm nhân viên tour mới");
//            list.Add(TOUR_EMPLOYEE_UPDATE, "Có thể cập nhật thông tin nhân viên tour");
//            list.Add(TOUR_EMPLOYEE_DELETE, "Có thể xóa nhân viên khỏi tour");

//            // NHÓM TOUR BOOKING
//            list.Add("group-9", "ĐẶT TOUR");
//            list.Add(BOOKING_VIEW, "Có thể xem danh sách đặt tour");
//            list.Add(BOOKING_ADD, "Có thể đặt tour mới");
//            list.Add(BOOKING_UPDATE, "Có thể cập nhật thông tin đặt tour");
//            list.Add(BOOKING_DELETE, "Có thể hủy đặt tour");

//            // NHÓM TOUR PAYMENT
//            list.Add("group-10", "THANH TOÁN");
//            list.Add(PAYMENT_VIEW, "Có thể xem danh sách thanh toán");
//            list.Add(PAYMENT_ADD, "Có thể tạo thanh toán mới");
//            list.Add(PAYMENT_UPDATE, "Có thể cập nhật thông tin thanh toán");
//            list.Add(PAYMENT_DELETE, "Có thể hủy thanh toán");

//            // NHÓM TOUR FEEDBACK
//            list.Add("group-11", "ĐÁNH GIÁ");
//            list.Add(FEEDBACK_VIEW, "Có thể xem danh sách đánh giá");
//            list.Add(FEEDBACK_ADD, "Có thể thêm đánh giá mới");
//            list.Add(FEEDBACK_UPDATE, "Có thể cập nhật thông tin đánh giá");
//            list.Add(FEEDBACK_DELETE, "Có thể xóa đánh giá");


//        }
//    }
//}
