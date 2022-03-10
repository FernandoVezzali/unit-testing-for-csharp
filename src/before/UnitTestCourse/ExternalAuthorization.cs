using System;

namespace UnitTestCourse
{
    /// <summary>
    /// Concrete class that will be replaced by a mock during the tests
    /// </summary>
    public class ExternalAuthorization : IExternalAuthorization
    {
        public bool IsAuthorized()
        {
            throw new NotImplementedException();
        }
    }

    public interface IExternalAuthorization
    {
        public bool IsAuthorized();
    }
}
