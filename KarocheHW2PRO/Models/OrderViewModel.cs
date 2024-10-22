namespace KarocheHW2PRO.Models
{
    public class OrderViewModel
    {
        public List<MenuItem> FirstCourse { get; set; }
        public List<MenuItem> SecondCourse { get; set; }
        public List<MenuItem> Drink { get; set; }

        public string SelectedFirstCourse { get; set; }
        public string SelectedSecondCourse { get; set; }
        public string SelectedDrink { get; set; }

        public double TotalPrice { get; set; }
    }
}
