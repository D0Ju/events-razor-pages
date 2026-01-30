namespace EventsRazorApp.Models{
    public class EventType
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int MinimalnoPolaznika { get; set; }
    }
}
