namespace NebulaNexus.Events
{
    public class EventService
    {
        public EventController OnPlayClick { get; private set; }

        public EventService()
        {
            OnPlayClick = new EventController();
        }
    }
}