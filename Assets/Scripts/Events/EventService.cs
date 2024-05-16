namespace NebulaNexus.Events
{
    public class EventService
    {
        public EventController OnPlayClick { get; private set; }
        public EventController OnEnemyActive { get; private set; }
        public EventService()
        {
            OnPlayClick = new EventController();
            OnEnemyActive = new EventController();
        }
    }
}