using EventStore.ClientAPI;

namespace UserManagement.Projector.Framework
{
    public interface ICursor
    {
        Position CurrentPosition();
        void MoveTo(Position position);
    }
}