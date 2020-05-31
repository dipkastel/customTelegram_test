using System.Collections.Concurrent;

namespace Services.Queue.UserQuiz
{
    public class UserQuizQueue
    {
        private static ConcurrentQueue<UserQuizModel> _formQueue;

        private UserQuizQueue()
        {
        }

        public static ConcurrentQueue<UserQuizModel> GetQueue()
        {
            return _formQueue ?? (_formQueue = new ConcurrentQueue<UserQuizModel>());
        }

        public static void Enqueue(UserQuizModel model)
        {
            if (_formQueue == null)
            {
                _formQueue = GetQueue();
            }

            _formQueue.Enqueue(model);
        }
    }
}