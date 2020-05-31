using Services.Operator.Queue.Interface;
using Services.Queue;
using Services.Queue.UserQuiz;

namespace Services.Operator.Queue
{
    public class QueueService : IQueueService
    {
        public void Insert(string formHtml, int userId, int quizId)
        {
            var model = new UserQuizModel()
            {
                Form = formHtml,
                UserId = userId,
                QuizId = quizId
            };

            Services.Queue.UserQuiz.UserQuizQueue.Enqueue(model);
        }

        public UserQuizModel GetLast()
        {
            var queue = Services.Queue.UserQuiz.UserQuizQueue.GetQueue();

            return queue.TryDequeue(out var result) ? result : new UserQuizModel();
        }

        public UserQuizModel PeekLast()
        {
            var queue = Services.Queue.UserQuiz.UserQuizQueue.GetQueue();

            return queue.TryPeek(out var result) ? result : new UserQuizModel();
        }

        public int Count()
        {
            var queue = Services.Queue.UserQuiz.UserQuizQueue.GetQueue();

            return queue.Count;
        }

        public bool IsEmpty()
        {
            var queue = Services.Queue.UserQuiz.UserQuizQueue.GetQueue();

            return queue.IsEmpty;
        }
    }
}