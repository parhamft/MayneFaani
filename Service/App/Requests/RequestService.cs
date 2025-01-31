using Domain.Core.App.Cars.Entity;
using Domain.Core.App.RequestLogs.Services;
using Domain.Core.App.Requests.Data;
using Domain.Core.App.Requests.Entity;
using Domain.Core.App.Requests.Services;
using Domain.Core.App.UserCars.Data;
using Domain.Core.App.Users.Entity;
using Microsoft.Extensions.Configuration;
using Service.App.RequestLogs;

namespace Service.App.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository requestRepository;
        private readonly IUserCarRepository userCarRepository;
        private readonly IRequestLogService requestLogService;
        private readonly IConfiguration Configuration;


        public RequestService(IRequestRepository requestRepositor, IUserCarRepository userCar, IConfiguration configuration, IRequestLogService request)
        {
            requestRepository = requestRepositor;
            userCarRepository = userCar;
            Configuration = configuration;
            requestLogService = request;
        }
        public List<Request> GetPendingRequests()   
        {
            return requestRepository.PendingRequests();
        }
        public bool CheckingTheCar(Request request)
        {

            var CarCheck = userCarRepository.GetByPlate(request.Plate);
            if (CarCheck == null)
            {
                throw new Exception("that car does not exist");
            }
            if (DateTime.Now.Year - CarCheck.Car.CreationYear.Year > 5)
            {
                requestLogService.AddRequestLog(request);
                throw new Exception("We Will No Longer Work On your Car");
            }
            return true;
        }
        public List<Request> GetPastRequests(User user)
        {
            return requestRepository.GetAllUsersCars(user);

        }
        public bool CheckingTheDate(Request request)
        {
            var LastReq = requestRepository.GetByPlate(request.Plate);
            if (LastReq!=null && LastReq.RequestDay.HasValue && DateOnly.FromDateTime(DateTime.Now).AddYears(-1) < LastReq.RequestDay.Value)
            {
                throw new Exception($"You Cant send a request until {LastReq.RequestDay.Value.AddYears(1)}");
            }
            return true;
        }

        public bool AddRequest(Request request)
        {
            
            return requestRepository.Add(request);
        }
        public bool DeleteRequest(int id)
        {
            return requestRepository.DeleteRequest(id);
        }
        public Request GetById(int id)
        {
            return requestRepository.Get(id);
        }
        public bool SettingDay(int id)
        {
            var request = requestRepository.Get(id);
            int dayOfWeekInt = (int)DateOnly.FromDateTime(DateTime.Now).DayOfWeek;
            var Date = DateOnly.FromDateTime(DateTime.Now);
            string zoj = Configuration.GetSection("Limits:Zoj").Value;
            string fard = Configuration.GetSection("Limits:Fard").Value;
            if (request.Car.Company == "IranKhodro")
            {   
                if (dayOfWeekInt == 5)
                {
                    Date = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
                }
                else if (dayOfWeekInt != 6 || dayOfWeekInt != 1 || dayOfWeekInt != 3)
                {
                    if (dayOfWeekInt == 4)
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now).AddDays(2);
                    }
                    else
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
                    }

                }

                while (true)
                {

                    int limit = requestRepository.GetByDate(Date).Count;
                    if (limit >= Convert.ToInt32(zoj))
                    {
                        if ((int)Date.DayOfWeek==3)
                        {
                            Date = Date.AddDays(3);
                            request.RequestDay = Date;
                            requestRepository.Update(request);
                            return true;
                        }
                        else
                        {
                            Date = Date.AddDays(2);
                            request.RequestDay = Date;
                            requestRepository.Update(request);
                            return true;
                        }
                        
                    }
                    else
                    {
                        request.RequestDay = Date;
                        requestRepository.Update(request);
                        return true;
                    }
                }


            }
            if (request.Car.Company == "Saipa")
            {
                if (dayOfWeekInt == 5)
                {
                    Date = DateOnly.FromDateTime(DateTime.Now).AddDays(2);
                }
                else if (dayOfWeekInt == 6 || dayOfWeekInt == 1 || dayOfWeekInt == 3)
                {
                        Date = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
                }

                while (true)
                {

                    int limit = requestRepository.GetByDate(Date).Count;
                    if (limit >= Convert.ToInt32(fard))
                    {
                        if ((int)Date.DayOfWeek == 4)
                        {
                            Date = Date.AddDays(3);
                            request.RequestDay = Date;
                            requestRepository.Update(request);
                            return true;
                        }
                        else
                        {
                            Date = Date.AddDays(2);
                            request.RequestDay = Date;
                            requestRepository.Update(request);
                            return true;
                        }

                    }
                    else
                    {
                        request.RequestDay = Date;
                        requestRepository.Update(request);
                        return true;
                    }
                }
            }

            return true;

        }
    }
}
