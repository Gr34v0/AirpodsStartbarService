
namespace AirpodsStartbarService
{
    class AirpodsData
    {

        public bool status { get; set; }
        public string error { get; set; }
        public int rssi { get; set; }
        public string addr { get; set; }
        public int left { get; set; }
        public int right { get; set; }
        public int case1 { get; set; }
        public string model { get; set; }
        public bool charging_case1 { get; set; }
        public bool charging_right { get; set; }
        public bool charging_left { get; set; }

        public override string ToString()
        {
            return string.Format("status: {0}, left: {1}, right: {2}, case1: {3}", status, left, right, case1);
        }

    }
}
