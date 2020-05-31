using Services.Queue;
using Services.Queue.UserQuiz;

namespace Services.Operator.Queue.Interface
{
    public interface IQueueService
    {
        void Insert(string formHtml, int userId, int quizId);
        UserQuizModel GetLast();
        UserQuizModel PeekLast();
        int Count();
        bool IsEmpty();
    }
}