using Microsoft.AspNetCore.Mvc;

namespace Halvorson_Week3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class mainApi : ControllerBase
    {

        private readonly ILogger<mainApi> _logger;


        [HttpPost(Name = "PostIntList")]
        public ActionResult<List<string>> intListWork(List<int> lint)
        {
            List<string> sList = new List<string>();

            double sum = 0;
            double counter = 0;
            double average = 0;
            double result = 0;
            double distance = 0;
            double distanceSum = 0;

            lint.Sort();

            foreach (int i in lint)
            {
                counter++;
                sum += i;
                average = sum / counter;

                distance = Math.Pow((average - i),2);
                distanceSum += distance;
                result = distanceSum / (counter - 1);
                result = Math.Sqrt(result);

                if(counter == 1)
                {
                    sList.Add("List too small.");
                    continue;
                }

                sList.Add(counter + " Current Standart Deviation: " + result);
            }
            Console.WriteLine("Sum: " + sum);
            loggingObject(lint);

            return sList;
        }


        void loggingObject(List<int> input)
        {

            foreach(int i in input)
            {
                Console.WriteLine(i.ToString());
            }
        }

    }

}