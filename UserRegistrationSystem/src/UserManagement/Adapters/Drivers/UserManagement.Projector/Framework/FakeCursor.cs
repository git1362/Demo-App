using EventStore.ClientAPI;

namespace UserManagement.Projector.Framework
{
    public class FakeCursor : ICursor
    {
        public Position CurrentPosition()
        {
            return Position.Start;
        }

        public void MoveTo(Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}